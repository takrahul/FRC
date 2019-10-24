using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Drawing;

namespace UniFCR_Database
{
    public class StudentModel
    {
        public string LastName { get; set; }
        public string GivenNames { get; set; }
        public int MatNo { get; set; }
        public byte[] Image { get; set; }
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
