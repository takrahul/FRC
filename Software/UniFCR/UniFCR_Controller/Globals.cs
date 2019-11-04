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
        public static List<Image<Gray, byte>> trainingImages = new List<Image<Gray, byte>>(); //All student images in the Database
        public static int numLabels; //Number of labels
        public static List<int> listOfInts = new List<int>();
        public static List<string> labels = new List<string>();
        public static List<int> recognizedStudentNumbers = new List<int>();
        public static Boolean created = true;
        public static int numIndex;
        //public static MCvAvgComp[][] facesDetected;
        public static Rectangle[] facesDetected;
        public static List<String> studentNames = new List<String>(); //Names belonging to the images in trainingImages
		public static List<Image<Gray, byte>> processedDetectedFaces;
        public static List<int> studentNumbers = new List<int>();
        public static bool captureInProgress = false; //Variable to track camera state

        //Variables for choosing the camera
        public static DsDevice[] systemCameras;
        public static int selectedCameraIndex = 0;

        public static Boolean fileSaved = false;

        public static int threshold = 2000;
    }
}
