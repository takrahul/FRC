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

        public Camera (PictureBox box)
        {
            this.cameraBox = box;
        }

        public void start()
        {
            cam = new Capture();
            cam.SetCaptureProperty(CAP_PROP.CV_CAP_PROP_FRAME_WIDTH, 1919); //1280
            cam.SetCaptureProperty(CAP_PROP.CV_CAP_PROP_FRAME_HEIGHT, 1079); //720
            //cam.SetCaptureProperty(CAP_PROP.CV_CAP_PROP_FPS, 30);
            cam.Start();
            cam.ImageGrabbed += ProcessFrame;
        }

        private void ProcessFrame(object sender, EventArgs arg)
        {
            //Get current frame from the camera
            Image<Bgr, Byte> frame = cam.RetrieveBgrFrame().Resize((int)(cameraBox.Width), (int)(cameraBox.Height), Emgu.CV.CvEnum.INTER.CV_INTER_CUBIC);
            
            //Update the ImageBox to show current frame (if there is one)
            if (frame != null)
            {
                DisplayImage(frame.ToBitmap());
            } else
            {
                Console.WriteLine("No Camera Found!");
            }            
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
