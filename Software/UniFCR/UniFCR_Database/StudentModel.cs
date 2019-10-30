using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Drawing;
using Emgu.CV;
using Emgu.CV.Structure;

namespace UniFCR_Database
{
    public class StudentModel
    {
        public string LastName { get; set; }
        public string GivenNames { get; set; }
        public int MatNo { get; set; }
        public List<byte[]> Image = new List<byte[]>();
        public String StudentData
        {
            get
            {
                //return $"{LastName} {GivenNames}";
                return $"{LastName} {GivenNames} {MatNo} {Image}";
            }

        }
        
    }
}
