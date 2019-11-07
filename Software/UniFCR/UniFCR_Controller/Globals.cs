using System.Collections.Generic;
using Emgu.CV;
using Emgu.CV.Structure;
using DirectShowLib;
using System.Drawing;

namespace UniFCR_Controller
{
    /// <summary>
    /// variables that need to be shared between classes
    /// </summary>
    public static class Globals
    {
        public static List<Image<Gray, byte>> trainingImages = new List<Image<Gray, byte>>(); //All student images in the database
        public static int numLabels; //This is equal to the number of images in the database.
        public static List<int> listOfInts = new List<int>(); //Will be used as an index for the algorithm. Contains all integers from 0 to numLabels
        public static List<int> recognizedStudentNumbers = new List<int>(); //student numbers of all students recognized
        public static bool created = false;//checks if trainingImages and numLabels have been created yet
        public static int numIndex; //contains student number of most recently recognized face
        public static Rectangle[] facesDetected; //contains detected faces
        public static List<string> studentNames = new List<string>(); //Names belonging to the images in trainingImages
		public static List<Image<Gray, byte>> processedDetectedFaces;//contains proccessed detected faces
        public static List<int> studentNumbers = new List<int>();//contains student numbers of every image in trainingImages
        public static bool captureInProgress = false; //Variable to track camera state

        //Variables for choosing the camera
        public static DsDevice[] systemCameras;
        public static int selectedCameraIndex = 0;

        public static bool fileSaved = false; //checks whether the eigen file has been saved or not
        
        public static Dictionary<int, int> map = new Dictionary<int, int>();//used to store number of times a specific number has been recognized
        public static int recognizedThreshold = 30;//how many times should a face be recognized before being marked as attended
    }
}
