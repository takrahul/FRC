using System;
using Emgu.CV;
using Emgu.CV.Structure;
using Emgu.CV.CvEnum;
using Emgu.CV.UI;
using System.Threading;

namespace UniFCR_Controller {

    /// <summary>
    /// Class <c>Camera</c> contains all methods neccesary to grab images from the Webcam and displaying them in the GUI.
    /// </summary>
    public class Camera {

        private Capture cam = null; //Camera
        public ImageBox cameraBox = null; //Component of the GUI that shows the cam feed (needed for resizing etc.)

        //=================================================================
        // EVENT HANDLERS FOR NOTIFYING GUI ABOUT NEW IMAGES
        //=================================================================
        #region Event Handlers for new images
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
        #endregion

        //=================================================================
        // CAMERA
        //=================================================================
        #region Camera
        public Camera (ImageBox box)
        {
            this.cameraBox = box;
        }

        /// <summary>
        /// This Method is called when the Camera is started. It sets up the resolution and 
        /// framerate of the camera and adds the event handler for processing new frames.
        /// </summary>
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

        /// <summary>
        /// This Method is called when the Camera is stopped.
        /// It stops and disposes the capture object and removes the event handler.
        /// </summary>
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

        /// <summary>
        /// This Method is called everytime the Webcam captures a new frame
        /// and then grabs the newest frame from the Webcam.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="arg"></param>
        private void ProcessFrame(object sender, EventArgs arg)
        {
            //Get current frame from the camera
            if (cam != null)
            {
                Image < Bgr, Byte > grabbedFrame = cam.RetrieveBgrFrame();
                if (grabbedFrame != null)
                {
                    frame = grabbedFrame;
                }                
            }         
        }

        /// <summary>
        /// This Method display an image in the GUI
        /// </summary>
        /// <param name="Image">the frame that should be shown in the GUI</param>
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
        #endregion
    }
}
