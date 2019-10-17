using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using Emgu.CV;
using Emgu.CV.Structure;
using Emgu.CV.CvEnum;
using Emgu.Util;
using System.IO;
using System.Diagnostics;

namespace UniFCR_GUI {
    class Camera {

        private Capture cam = null; //Camera
        private bool captureInProgress = false; //Variable to track camera state
        private PictureBox cameraBox = null;
        HaarCascade face;
        Image<Bgr, Byte> currentFrame;
        Image<Gray, byte> result, TrainedFace = null;


        public Camera (PictureBox box)
        {
            this.cameraBox = box;
        }

        public void start()
        {
            cam = new Capture();
            cam.Start();
            cam.ImageGrabbed += ProcessFrame;
        }

        private void ProcessFrame(object sender, EventArgs arg)
        {
           //Get current frame from the camera
            Image<Bgr, Byte> frame = cam.RetrieveBgrFrame();
            //Update the ImageBox to show current frame (if there is one)
            FaceAlgorithm f = new FaceAlgorithm(frame, null, null);
            if (frame != null)
            {
                f.detectFaces();
                DisplayImage(frame.ToBitmap());
               
            } else
            {
                Console.WriteLine("No Camera Found!");
            }            
        }

        public void faceSaver(String name) {

            //Trained face counter
            Globals.ContTrain = Globals.ContTrain + 1;

                //Get a gray frame from capture device
                Image<Gray, byte> gray = null;
                gray = cam.QueryGrayFrame().Resize(320, 240, Emgu.CV.CvEnum.INTER.CV_INTER_CUBIC);
                face = new HaarCascade("haarcascade_frontalface_default.xml");

            //Face Detector
            MCvAvgComp[][] facesDetected = gray.DetectHaarCascade(
                face,
                1.2,
                10,
                Emgu.CV.CvEnum.HAAR_DETECTION_TYPE.DO_CANNY_PRUNING,
                new Size(20, 20));

                currentFrame = cam.QueryFrame().Resize(320, 240, Emgu.CV.CvEnum.INTER.CV_INTER_CUBIC);


            //Action for each element detected
            foreach (MCvAvgComp f in facesDetected[0])
                {
                    TrainedFace = currentFrame.Copy(f.rect).Convert<Gray, byte>();
                    result = currentFrame.Copy(f.rect).Convert<Gray, byte>().Resize(100, 100, Emgu.CV.CvEnum.INTER.CV_INTER_CUBIC);
                    break;
                }

                //resize face detected image for force to compare the same size with the 
                //test image with cubic interpolation type method
                TrainedFace = result.Resize(100, 100, Emgu.CV.CvEnum.INTER.CV_INTER_CUBIC);
                Globals.trainingImages.Add(TrainedFace);
                Globals.labels.Add(name);


                //Write the number of triained faces in a file text for further load
                File.WriteAllText(Application.StartupPath + "/TrainedFaces/TrainedLabels.txt", Globals.trainingImages.ToArray().Length.ToString() + "%");

                //Write the labels of triained faces in a file text for further load
                for (int i = 1; i < Globals.trainingImages.ToArray().Length + 1; i++)
                {
                    Globals.trainingImages.ToArray()[i - 1].Save(Application.StartupPath + "/TrainedFaces/face" + i + ".bmp");
                    File.AppendAllText(Application.StartupPath + "/TrainedFaces/TrainedLabels.txt", Globals.labels.ToArray()[i - 1] + "%");
                }
            
            MessageBox.Show(name + "´s face detected and added :)", "Training OK", MessageBoxButtons.OK, MessageBoxIcon.Information);
            
        }

        private delegate void DisplayImageDelegate(Bitmap Image);
        private void DisplayImage(Bitmap Image)
        {
            if (cameraBox.InvokeRequired)
            {
                try
                {
                    DisplayImageDelegate DI = new DisplayImageDelegate(DisplayImage);
                    cameraBox.BeginInvoke(DI, new object[] { Image }); //this.BeingInvoke.....
                }
                catch (Exception ex)
                {
                }
            }
            else
            {
                cameraBox.Image = Image;
            }
        }
    }
}
