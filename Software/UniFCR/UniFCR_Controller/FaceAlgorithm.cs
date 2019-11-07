using System;
using System.Collections.Generic;
using Emgu.CV;
using Emgu.CV.Structure;
using Emgu.CV.CvEnum;
using System.Drawing;
using System.IO;
using UniFCR_Database;




namespace UniFCR_Controller {
    public class FaceAlgorithm {
        public bool recognizationInProgress = false; //to make sure the face recognition only happens one at a time
        string name; //name of student recognized
        MCvFont font = new MCvFont(FONT.CV_FONT_HERSHEY_TRIPLEX, 0.5d, 0.5d);
        //make sure this xml file is in the debug folder for this to work
        readonly CascadeClassifier face = new CascadeClassifier("haarcascade_frontalface_default.xml");

        //public constructor
        public FaceAlgorithm()
        {
            //load studentmodel objects from database 
            DatabaseController dc = new DatabaseController();
            dc.LoadStudentsList();
            List <StudentModel> students = dc.student;

            if (Globals.created == false)
            {
                foreach (StudentModel m in students) 
                {
                    //go through every image of every student
                    foreach (byte[] b in m.Image)
                    {
                        //fill up the studentNames list
                        Globals.studentNames.Add(m.GivenNames + " " + m.LastName);

                        //convert the image from a byte array into an Image<Gray, byte> object
                        ImageConverter converter = new ImageConverter();
                        Bitmap bmp;
                        using (var ms = new MemoryStream(b))
                        {
                            bmp = new Bitmap(ms);
                        }
                        //after conversion store in trainingImages list
                        Image<Gray, byte> trainedFaceImage = new Image<Gray, byte>(bmp);
                        Globals.trainingImages.Add(trainedFaceImage);
                        //fill up studentNumbers list as well
                        Globals.studentNumbers.Add(m.MatNo);
                    }

                }
                //after going through all images initialize numLabels and set created as false
                Globals.numLabels = Globals.studentNames.Count;
                Globals.created = true;
            }
        }

        /// <summary>
        /// Method detects faces
        /// </summary>
        /// <param name="frame">Frame from the camera</param>
        /// <returns>Frame with all faces marked with rectangles</returns>
        public Image<Bgr, byte> detectFaces(Image<Bgr, byte> frame)
        {
            Globals.processedDetectedFaces = new List<Image<Gray, byte>>();
            Image<Gray, byte> gray;
            Image<Gray, byte> result;
            //store the gray version of the frame in the gray variable
            gray = frame.Convert<Gray, byte>();
            //get the faces detected using the detectmultiscale method
            Globals.facesDetected = face.DetectMultiScale(gray, 1.2, 10, new Size(50, 50), Size.Empty);
            for (int i = 0; i < Globals.facesDetected.Length; i++)
            {
                Globals.facesDetected[i].X += (int)(Globals.facesDetected[i].Height * 0.15);
                Globals.facesDetected[i].Y += (int)(Globals.facesDetected[i].Width * 0.22);
                Globals.facesDetected[i].Height -= (int)(Globals.facesDetected[i].Height * 0.3);
                Globals.facesDetected[i].Width -= (int)(Globals.facesDetected[i].Width * 0.35);
                //result stores image of detected face that has been cropped and gray-scaled.
                result = frame.Copy(Globals.facesDetected[i]).Convert<Gray, byte>().Resize(100, 100, INTER.CV_INTER_CUBIC);
                result._EqualizeHist();
                //draw the face detected in the 0th (gray) channel with red color
                frame.Draw(Globals.facesDetected[i], new Bgr(Color.Red), 2);
                //store the image of the processed detected face in its list
                Globals.processedDetectedFaces.Add(result);
            }
            //return the frame with rectangles drawn over the faces
            return frame;
        } 

        /// <summary>
        /// This method takes a frame from the camera. It returns a frame with all faces marked and labeled.
        /// </summary>
        /// <param name="frame">Frame from the camera</param>
        /// <returns>Frame with all faces marked and labeled</returns>
        public Image<Bgr, byte> recognizeFaces(Image<Bgr, byte> frame)
        {
            //first part of method is just like the detectFaces method
            Globals.processedDetectedFaces = new List<Image<Gray, byte>>();
            Image<Gray, byte> gray;
            Image<Gray, byte> result;
            gray = frame.Convert<Gray, byte>();
            Globals.facesDetected = face.DetectMultiScale(gray, 1.2, 10, new Size(50, 50), Size.Empty);
            for(int i = 0; i<Globals.facesDetected.Length; i++)
            {
                Globals.facesDetected[i].X += (int)(Globals.facesDetected[i].Height * 0.15);
                Globals.facesDetected[i].Y += (int)(Globals.facesDetected[i].Width * 0.22);
                Globals.facesDetected[i].Height -= (int)(Globals.facesDetected[i].Height * 0.3);
                Globals.facesDetected[i].Width -= (int)(Globals.facesDetected[i].Width * 0.35);


                result = frame.Copy(Globals.facesDetected[i]).Convert<Gray, byte>().Resize(100, 100, INTER.CV_INTER_CUBIC);
                result._EqualizeHist();
				Globals.processedDetectedFaces.Add(result);
                //draw the face detected in the 0th (gray) channel with red color
                frame.Draw(Globals.facesDetected[i], new Bgr(Color.Red), 2);
                //after doing the detection phase go through all trainingImages list.
                if (Globals.trainingImages.ToArray().Length != 0)
                {
                    //initalize instance of classifier_train and set its eiegn threshold
                    Classifier_Train Eigen_Recog = new Classifier_Train
                    {
                        Set_Eigen_Threshold = 2000
                    };
                    //send cropped face to classifier_train class for recognition
                    //name belonging to recognized face is returned by classifier_train
                    //name is "unknown" if it's not recognized
                    name = Eigen_Recog.Recognise(result);
                    Eigen_Recog.Dispose();
                    //add student number to map if it doesn't already exist
                    //key is student number and value is number of times it has been recognized
                    if (!Globals.map.ContainsKey(Globals.numIndex) && !name.Equals("Unknown"))
                    {
                        Globals.map.Add(Globals.numIndex, 0);
                    }
                    //increment map value if the student number already exists in map
                    else if (Globals.map.ContainsKey(Globals.numIndex) && !name.Equals("Unknown")) {
                        int currentCount = Globals.map[Globals.numIndex];
                        Globals.map[Globals.numIndex] = currentCount + 1;  
                    }
                    //check if student number has been recognized enough times. If so then add it to recognizedStudentNumbers
                    if (Globals.map[Globals.numIndex] == Globals.recognizedThreshold)
                    {
                        Globals.recognizedStudentNumbers.Add(Globals.numIndex);
                    }

                    //Draw the label for each face detected and recognized
                    //Only draw if captureInProgress is set. This way this won't be called in parallel.
                    //Surronded with try-catch for an AccessViolationException error. This error could happen if the algorithm tries to draw when
                    //after the attendance screen has been closed and frame has been set to null.
                     try {
                        if (Globals.captureInProgress)
                        {
                            frame.Draw(name, ref font, new Point(Globals.facesDetected[i].X - 2, Globals.facesDetected[i].Y - 2), new Bgr(Color.LightGreen));
                        }
                     }
                     catch (System.AccessViolationException e) {
                        Console.WriteLine("Error: " + e.Message);
                     }
           

                }

            }
            return frame;
        }
    }
}
