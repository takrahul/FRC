using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Emgu.CV;
using Emgu.CV.Structure;
using DirectShowLib;
using System.Drawing;

namespace UniFCR_Controller
{
    public static class Globals
    {
        public static List<Image<Gray, byte>> trainingImages = new List<Image<Gray, byte>>();
        public static int ContTrain;
        public static int numLabels;
        public static List<int> listOfInts = new List<int>();
        public static List<string> labels = new List<string>();
        public static List<string> recognizedNames = new List<string>();
        public static Boolean created = true;
        //public static MCvAvgComp[][] facesDetected;
        public static Rectangle[] facesDetected;
        public static List<String> studentNames = new List<String>();
		public static List<Image<Gray, byte>> processedDetectedFaces;

        //Variables for choosing the camera
        public static DsDevice[] systemCameras;
        public static int selectedCameraIndex = 0;

        public static Boolean fileSaved = false;

    }
}
