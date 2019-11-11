using Dapper;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SQLite;
using System.Linq;

namespace UniFCR_Database
{
    /// <summary>
    /// This class handles the connection to the database
    /// </summary>
    public class SqliteDataAccess {
        /// <summary>
        /// This method is used by the controller to get all students from the database
        /// </summary>
        /// <returns>List of StudentModel objects</returns>
        public static List<StudentModel> LoadStudents()
        {
            List<StudentModel> students = new List<StudentModel>();
            //Get the student names and numbers from Student2 table
            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                var output = cnn.Query<StudentModel>("select * from Student2", new DynamicParameters());
                students =  output.ToList();
            }
            //Assign the student its images from the ImageTable table
            //Use the marticulation number as the foreign key between the ImageTable and Student2 tables
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


        /// <summary>
        /// Save a student in the database. This should only be used by the DatabaseController.
        /// </summary>
        /// <param name="student">The studentmodel object to be saved</param>
        public static void SavePerson(StudentModel student)
        {
            using (SQLiteConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                cnn.Open();
                //Insert the student's name and number in Student2 table
                cnn.Execute("insert into Student2 (MatNo, GivenNames, LastName) values (@MatNo, @GivenNames, @LastName)", student);
                //cnn.Execute("insert into StudentImages (MatNoID, Images) values (@MatNo, @Image)", student);

                string query = "insert into ImageTable (MatNoID, Images) values (@MatNoID, @Images)";


                //Insert the student's images in ImageTable
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
        public static bool DeletePerson(StudentModel mt)
        {
            using (SQLiteConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                cnn.Open();

                string query = "Delete from Student2 where MatNo = '" + mt.MatNo + "';Delete from ImageTable where MatNoID = '" + mt.MatNo + "'";

                using (SQLiteCommand cmd = new SQLiteCommand(query))
                {
                    cmd.Connection = cnn;
                    try
                    {
                        cmd.ExecuteNonQuery();
                        cnn.Close();
                        return true;
                    } catch (Exception e)
                    {
                        return false;
                    }

                }

            }
        }

        private static string LoadConnectionString(string id = "Default")
        {
            return ConfigurationManager.ConnectionStrings[id].ConnectionString;
        }

       
    }
}
