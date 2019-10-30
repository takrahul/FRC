using Dapper;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SQLite;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Emgu.CV;
using Emgu.CV.Structure;
using System.Drawing;

namespace UniFCR_Database
{
    public class SqliteDataAccess {
        public static List<StudentModel> LoadStudents()
        {
            List<StudentModel> students = new List<StudentModel>();
            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                var output = cnn.Query<StudentModel>("select * from Student2", new DynamicParameters());
                students =  output.ToList();
            }

            foreach (StudentModel s in students)
            {
                using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
                {
                    var output = cnn.Query<byte[]>("select Images from Student2 inner join ImageTable on Student2.MatNo = ImageTable.MatNoID where Student2.MatNo = '" + s.MatNo + "';", new DynamicParameters());
                    s.Image = output.ToList();
                }
            }

            return students;
        }

        public static void SavePerson(StudentModel student)
        {
            using (SQLiteConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                cnn.Open();
                cnn.Execute("insert into Student2 (MatNo, GivenNames, LastName) values (@MatNo, @GivenNames, @LastName)", student);
                //cnn.Execute("insert into StudentImages (MatNoID, Images) values (@MatNo, @Image)", student);

                string query = "insert into ImageTable (MatNoID, Images) values (@MatNoID, @Images)";



                using (SQLiteCommand cmd = new SQLiteCommand(query))
                {
                    cmd.Parameters.AddWithValue("@MatNoID", student.MatNo);
                    foreach (var str in student.Image)
                    {
                        cmd.Connection = cnn;

                        cmd.Parameters.AddWithValue("@Images", str);

                        cmd.ExecuteNonQuery();


                    }
                }
                cnn.Close();

            }
        }

        private static string LoadConnectionString(string id = "Default")
        {
            return ConfigurationManager.ConnectionStrings[id].ConnectionString;
        }

       
    }
}
