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
        private Image<Bgr, Byte> currentFrame;
        public Image<Bgr, Byte> CurrentFrame
        {
            get { return currentFrame; }
            set { currentFrame = value; }
        }
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
            cam = new Capture(0);
            cam.QueryFrame();
            Application.Idle += new EventHandler(FrameGrabber);

            //hide the loading screen when the camera feed is set up
            Thread.Sleep(1000);
            loadingPanel.Visible = false;
        }

        void FrameGrabber(object sender, EventArgs e)
        {
            //Get the current frame form capture device and set size
            currentFrame = cam.QueryFrame().Resize((int)(camPanel.Width*0.7), (int)(camPanel.Height*0.7), Emgu.CV.CvEnum.INTER.CV_INTER_CUBIC);

            //Show the faces procesed and recognized
            camView.Image = currentFrame;

            FaceAlgorithm f = new FaceAlgorithm(this);
            f.detectFaces();

        }

        private void exitButton_Click(object sender, EventArgs e)
        {
            this.Close();
            menuScreen.Visible = true;            
        }

        

    }
}
