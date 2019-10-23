using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using Emgu.CV;
using Emgu.CV.Structure;
using Emgu.CV.CvEnum;
using Emgu.Util;
using System.IO;
using System.Diagnostics;
using Emgu.CV.UI;
using System.Windows.Forms;

namespace UniFCR_Controller {
    public class Camera {

        private Capture cam = null; //Camera
        private bool captureInProgress = false; //Variable to track camera state
        public ImageBox cameraBox = null;
        HaarCascade face;
        Image<Bgr, Byte> currentFrame;
        Image<Gray, byte> result, TrainedFace = null;
        public Image<Bgr, Byte> frame = null;
        int camPerformanceCounter = 0;

        private  int _newImageArrived;
        public int newImageArrived
        {
            get { return _newImageArrived; }
            set
            {
                if (_newImageArrived != value)
                {
                    _newImageArrived = value;
                    OnValueChanged();
                }
            }
        }

        public event EventHandler ValueChanged;
        protected void OnValueChanged()
        {
            if (ValueChanged != null)
                ValueChanged(this, EventArgs.Empty);
        }

        public Camera (ImageBox box)
        {
            this.cameraBox = box;
        }

        public void start()
        {
            if (!this.captureInProgress)
            {
                cam = new Capture(0);
                cam.SetCaptureProperty(CAP_PROP.CV_CAP_PROP_FRAME_WIDTH, 1280); //1280
                cam.SetCaptureProperty(CAP_PROP.CV_CAP_PROP_FRAME_HEIGHT, 720); //720
                                                                                //cam.SetCaptureProperty(CAP_PROP.CV_CAP_PROP_FPS, 30);
                cam.Start();
                captureInProgress = true;
                Console.WriteLine("camera started");
                cam.ImageGrabbed += ProcessFrame;
            }
        }

        public void stop()
        {
            if (this.captureInProgress)
            {
                cam.ImageGrabbed -= ProcessFrame;
                captureInProgress = false;
                cam.Stop();
                cam.Dispose();
                //Thread.Sleep(1000);
                cam = null;
                Console.WriteLine("Camera stopped!");
            }
        }

        private void ProcessFrame(object sender, EventArgs arg)
        {
            //Get current frame from the camera
            if (cam != null)
            {
                frame = cam.RetrieveBgrFrame();
                if (frame != null)
                {
                    frame = frame.Resize((int)(cameraBox.Width), (int)(cameraBox.Height), Emgu.CV.CvEnum.INTER.CV_INTER_CUBIC);
                }                
            }

            //Update the ImageBox to show current frame (if there is one)
            if (frame != null)
            {

                //DisplayImage(frame.ToBitmap());
                if (camPerformanceCounter % 1 == 0)
                {
                    if (newImageArrived < 255)
                    {
                        newImageArrived += 1;
                    }
                    else
                    {
                        newImageArrived = 0;
                    }
                }
                camPerformanceCounter++;

            } else
            {
                Console.WriteLine("No Camera Found!");
            }            
        }

        public Image<Gray, byte> faceSaver(String firstName, String lastName)
        {

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
            Globals.labels.Add(firstName + " " + lastName);


            //Write the number of triained faces in a file text for further load
            //File.WriteAllText("D:/Documents/Team Oriented Project/Repo/Software/UniFCR/UniFCR_GUI/bin/Debug/TrainedFaces/TrainedLabels.txt", Globals.trainingImages.ToArray().Length.ToString() + "%");

            //Write the labels of triained faces in a file text for further load
            /*for (int i = 1; i < Globals.trainingImages.ToArray().Length + 1; i++)
            {
                Globals.trainingImages.ToArray()[i - 1].Save("D:/Documents/Team Oriented Project/Repo/Software/UniFCR/UniFCR_GUI/bin/Debug/TrainedFaces/face" + i + ".bmp");
                File.AppendAllText("D:/Documents/Team Oriented Project/Repo/Software/UniFCR/UniFCR_GUI/bin/Debug/TrainedFaces/TrainedLabels.txt", Globals.labels.ToArray()[i - 1] + "%");
            }*/

            MessageBox.Show(firstName + "´s face detected and added :)", "Training OK", MessageBoxButtons.OK, MessageBoxIcon.Information);
            return TrainedFace;
        }

        private delegate void DisplayImageDelegate(Image<Bgr, Byte> Image);
        public void DisplayImage(Image<Bgr, Byte> Image)
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
