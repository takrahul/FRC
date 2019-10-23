using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Emgu.CV;
using Emgu.CV.Structure;

namespace UniFCR_Controller
{
    public static class Globals
    {
        public static List<Image<Gray, byte>> trainingImages = new List<Image<Gray, byte>>();
        public static int ContTrain;
        public static int numLabels;
        public static List<string> labels = new List<string>();
        public static Boolean created = true;
    }
}
