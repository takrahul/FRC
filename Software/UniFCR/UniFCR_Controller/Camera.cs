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

namespace UniFCR_Controller
{
    public class Camera
    {

        private Capture cam = null; //Camera
        private bool captureInProgress = false; //Variable to track camera state
        public ImageBox cameraBox = null; //Component of the GUI that shows the cam feed (needed for resizing etc.)

        //Variables for preparing the image for the recognition/detection algorithm
        HaarCascade face;
        public Image<Bgr, Byte> currentFrame;
        Image<Gray, byte> result, TrainedFace = null;
        public Image<Bgr, Byte> frame = null;
        int camPerformanceCounter = 0;

        private int _newImageArrived;
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

        public Camera(ImageBox box)
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
                    currentFrame = frame;
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

            }
            else
            {
                Console.WriteLine("No Camera Found!");
            }
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
