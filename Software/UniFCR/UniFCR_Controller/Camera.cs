using System;
using Emgu.CV;
using Emgu.CV.Structure;
using Emgu.CV.CvEnum;
using Emgu.CV.UI;
using System.Threading;

namespace UniFCR_Controller
{
    public class Camera
    {

        private Capture cam = null; //Camera
        public ImageBox cameraBox = null; //Component of the GUI that shows the cam feed (needed for resizing etc.)

        //=================================================================
        // EVENT HANDLERS FOR NOTIFYING GUI ABOUT NEW IMAGES
        //=================================================================

        private Image<Bgr, Byte> _frame;
        public Image<Bgr, Byte> frame //changed image from camera used for displaying in the GUI (resized)
        {
            get { return _frame; }
            set
            {
                if (_frame != value)
                {
                    _frame = value;
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

        //=================================================================
        // CAMERA
        //=================================================================
        public Camera(ImageBox box)
        {
            this.cameraBox = box;
        }

        public void start()
        {
            if (!Globals.captureInProgress)
            {
                cam = new Capture(Globals.selectedCameraIndex);
                cam.SetCaptureProperty(CAP_PROP.CV_CAP_PROP_FRAME_WIDTH, 1920); //1280
                cam.SetCaptureProperty(CAP_PROP.CV_CAP_PROP_FRAME_HEIGHT, 1080); //720
                cam.SetCaptureProperty(CAP_PROP.CV_CAP_PROP_FPS, 30);

                cam.Start();
                Globals.captureInProgress = true;
                cam.ImageGrabbed += ProcessFrame;
            }
        }

        public void stop()
        {
            if (Globals.captureInProgress)
            {
                Globals.captureInProgress = false;
                cam.ImageGrabbed -= ProcessFrame;
                cam.Stop();
                cam.Dispose();
                cam = null;
            }
        }

        private void ProcessFrame(object sender, EventArgs arg)
        {
            //Get current frame from the camera
            if (cam != null)
            {
                Image<Bgr, Byte> grabbedFrame = cam.RetrieveBgrFrame();
                if (grabbedFrame != null)
                {
                    frame = grabbedFrame;
                }
            }
        }

        private delegate void DisplayImageDelegate(Image<Bgr, Byte> Image);
        public void DisplayImage(Image<Bgr, Byte> Image)
        {
            if (cameraBox.InvokeRequired && cam != null)
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
