using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using Emgu.CV;
using Emgu.CV.Structure;
using Emgu.CV.CvEnum;
using Emgu.Util;
using System.IO;
using System.Diagnostics;

namespace UniFCR_GUI {
    public partial class AttendanceScreen : Form {

        Form menuScreen;
        Image<Bgr, Byte> currentFrame;
        Capture cam;
        

        public AttendanceScreen(Form menuScreen)
        {
            this.menuScreen = menuScreen;
            InitializeComponent();

            //Show loading screen first
            loadingPanel.BringToFront();
        }

        //While the attendance screen is preparing (calculating size, loading camera) show a loading screen
        private void loadingPanel_Paint(object sender, PaintEventArgs e)
        {
            //Center the logo and the text on the loading screen
            int textLogoX = (this.Size.Width / 2) - (logoTextPanel.Size.Width / 2);
            int textLogoY = (this.Size.Height / 2) - (logoTextPanel.Size.Height / 2);
            logoTextPanel.Location = new Point(textLogoX, textLogoY);
            
            //The camera feed may take up 3/4 of the screen
            camPanel.Width = (int)(mainPanel.Size.Width * 0.75);
        }

        private void camPanel_Paint(object sender, PaintEventArgs e)
        {
            cam = new Capture();
            cam.Start();
            cam.ImageGrabbed += ProcessFrame;

            //Hide the loading screen when the camera feed is set up
            Thread.Sleep(1000);
            loadingPanel.Visible = false;
        }

        private void ProcessFrame(object sender, EventArgs arg)
        {
            //***If you want to access the image data the use the following method call***/
            //Image<Bgr, Byte> frame = new Image<Bgr,byte>(_capture.RetrieveBgrFrame().ToBitmap());

            Image<Bgr, Byte> frame = cam.RetrieveBgrFrame();
            //because we are using an autosize picturebox we need to do a thread safe update
            DisplayImage(frame.ToBitmap());
        }
        private delegate void DisplayImageDelegate(Bitmap Image);
        private void DisplayImage(Bitmap Image)
        {

            if (camView.InvokeRequired)
            {
                try
                {
                    DisplayImageDelegate DI = new DisplayImageDelegate(DisplayImage);
                    this.BeginInvoke(DI, new object[] { Image });
                }
                catch (Exception ex)
                {
                }
            }
            else
            {
                camView.Image = new Image<Bgr, Byte>(Image).Resize(camView.Width, camView.Height, INTER.CV_INTER_CUBIC);
            }
        }
        
        private void exitButton_Click(object sender, EventArgs e)
        {
            this.Close();
            menuScreen.Visible = true;            
        }
    }
}
