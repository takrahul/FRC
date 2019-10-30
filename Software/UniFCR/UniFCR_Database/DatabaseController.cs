using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Emgu.CV;
using Emgu.CV.Structure;

namespace UniFCR_Database
{
    public class DatabaseController
    {
        List<StudentModel> student = new List<StudentModel>();

        public void LoadStudentsList()
        {
            student = SqliteDataAccess.LoadStudents();

            //student = SqliteDataAccess.FetchStudents();
           // WireUpStudentList();
            PopulateStudentList(student);
        }
        private void WireUpStudentList()
        {
            /*studentListBox.DataSource = null;
            studentListBox.DataSource = student;
            studentListBox.DisplayMember = "StudentData";*/

        }

        void PopulateStudentList(List<StudentModel> stu)
        {
            List<string> populateStu;
            //populateStu = SqliteDataAccess.FetchStudents();

            //studentListBox.Items.Clear();
            foreach (StudentModel str in stu)
            {
                Console.WriteLine(str.LastName);
            }
        }

        public void saveStudentList(String firstName, String lastName, int matNum, List<Image<Gray, byte>> images)
        {
            
            StudentModel st = new StudentModel();

            st.LastName = lastName;
            st.GivenNames = firstName;
            st.MatNo = matNum;

            //BinaryReader br = new BinaryReader(image.ToBitmap());
            //byte[] imageBt = br.ReadBytes(image.ToBitmap());
            ImageConverter converter = new ImageConverter();
            foreach (var i in images)
            {
                byte[] studentImage = (byte[])converter.ConvertTo(i.ToBitmap(), typeof(byte[]));
                st.Image.Add(studentImage);
            }

           // st.Image = image.ToBitmap();
            
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

        public List<String> studentNameList()
        {
            List<String> fullNames = new List<String>();

            foreach (StudentModel s in student)
            {
                fullNames.Add(s.GivenNames + " " + s.LastName);
            }

            return fullNames;
        }
    }
}
