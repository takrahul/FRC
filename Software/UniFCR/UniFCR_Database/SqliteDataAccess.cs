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

namespace UniFCR_Database
{
    public class SqliteDataAccess
    {
        public static List<StudentModel> LoadStudents()
        {
            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                var output = cnn.Query<StudentModel>("select * from Student", new DynamicParameters());
                return output.ToList();
            }

        }
        /*public static List<StudentModel> FetchStudents()
        {
            var dt = new DataTable();
            //string dataSource = ".\\StudentDB.db";
            
            using (SQLiteConnection conn = new SQLiteConnection(LoadConnectionString()))
            {
                var sql = $"select * from Student";
                SQLiteDataAdapter da = new SQLiteDataAdapter(sql, conn);
                da.Fill(dt);
                conn.Close();
            }

            List<StudentModel> studentList = new List<StudentModel>();
            foreach (StudentModel m in dt)
            {
                studentList.Add(m);
            }

            return studentList;
        }*/

        public static void SavePerson(StudentModel student/*, byte[] imageBt2*/)
        //public static void SavePerson(StudentModel student)
        {
            using (SQLiteConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                cnn.Execute("insert into Student (LastName, GivenNames, MatNo, Image) values (@LastName, @GivenNames, @MatNo, @Image)", student);

                //For Chisom
                //cnn.Execute("insert into Student2 (MatNo, GivenNames, Lastname) values (@MatNo, @GivenNames, @LastName)", student);
                //cnn.Execute("insert into StudentImages2 (MatNoID, Images) values (@MatNo, @Image)", student);

                //string querry = "insert into Student (LastName, GivenNames, MatNo, Image) values (@LastName, @GivenNames, @MatNo, @IMG";
                using (SQLiteCommand command = new SQLiteCommand(cnn))
                {
                    //cnn.Open();
                    //command.Parameters.Add(new SQLiteParameter("@Image", imageBt2));
                }


            }
        }

        private static string LoadConnectionString(string id = "Default")
        {
            return ConfigurationManager.ConnectionStrings[id].ConnectionString;
        }

       
    }
}
