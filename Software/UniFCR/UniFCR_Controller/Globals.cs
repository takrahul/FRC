using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Emgu.CV;
using Emgu.CV.Structure;
using DirectShowLib;

namespace UniFCR_Controller
{
    public static class Globals
    {
        public static List<Image<Gray, byte>> trainingImages = new List<Image<Gray, byte>>();
        public static int ContTrain;
        public static int numLabels;
        public static List<string> labels = new List<string>();
        public static Boolean created = true;
        public static MCvAvgComp[][] facesDetected;
        public static DsDevice[] systemCameras;
        public static int selectedCameraIndex = 0;
    }
}
