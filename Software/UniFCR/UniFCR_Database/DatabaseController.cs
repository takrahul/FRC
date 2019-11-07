using System.Collections.Generic;
using System.Drawing;
using Emgu.CV;
using Emgu.CV.Structure;

namespace UniFCR_Database
{
    /// <summary>
    /// Class that should be used for loading and saving to the database.
    /// </summary>
    public class DatabaseController
    {
        //List that will contain all studentmodel objects
        public List<StudentModel> student = new List<StudentModel>();

        /// <summary>
        /// Fill up student list using a method from the SqliteDataAccess class
        /// </summary>
        public void LoadStudentsList()
        {
            student = SqliteDataAccess.LoadStudents();
        }

        /// <summary>
        /// Save a student's list of images into the database.
        /// </summary>
        /// <param name="firstName"> Student's first name</param>
        /// <param name="lastName">Student's last name</param>
        /// <param name="matNum">Student's marticulation number</param>
        /// <param name="images">List of images belonging to the student</param>
        public void saveStudentList(string firstName, string lastName, int matNum, List<Image<Gray, byte>> images)
        {
            //Create a studentmodel object using the names and number
            StudentModel st = new StudentModel
            {
                LastName = lastName,
                GivenNames = firstName,
                MatNo = matNum
            };
            
            //Convert the Image<Gray,byte> into a byte[] and then assign it to the studentmodel object
            ImageConverter converter = new ImageConverter();
            foreach (var i in images)
            {
                byte[] studentImage = (byte[])converter.ConvertTo(i.ToBitmap(), typeof(byte[]));
                st.Image.Add(studentImage);
            }

            //Save it in the database
            SqliteDataAccess.SavePerson(st);

            //todo
            // tabbing order in UI
            // DB location
            // popup after saving
            // Add close/exit button to close app
            // Upload pictures
            // Read data from Database
            // Surround save and read operations in a try catch block
        }
        /// <summary>
        /// Gets a list of all the full names from the database
        /// </summary>
        /// <returns>List of full names</returns>
        public List<string> studentNameList()
        {
            List<string> fullNames = new List<string>();

            foreach (StudentModel s in student)
            {
                fullNames.Add(s.GivenNames + " " + s.LastName);
            }

            return fullNames;
        }
    }
}
