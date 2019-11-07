using System.Collections.Generic;


namespace UniFCR_Database
{
    /// <summary>
    /// StudentModel represents a single student's data from the database. It has the student's first name, last name, marticulation number, and 
    /// a list of their images.
    /// </summary>
    public class StudentModel
    {
        //Getters and setters
        public string LastName { get; set; }
        public string GivenNames { get; set; }
        public int MatNo { get; set; }
        //The images are stored in a byte[] list. It has to be of type byte[] so that the database can accept them.
        public List<byte[]> Image = new List<byte[]>();

        /// <summary>
        /// This method returns the student's information in string format (without the images).
        /// </summary>
        public string StudentData
        {
            get
            {
                return $"{LastName}, {GivenNames}, {MatNo}";
            }

        }
        
    }
}
