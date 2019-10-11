using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
        }

        private void mainPanel_Paint(object sender, PaintEventArgs e)
        {
            //the camera feed may take up 3/4 of the screen
            camPanel.Width = (int) (mainPanel.Size.Width * 0.75);

        }

        private void camPanel_Paint(object sender, PaintEventArgs e)
        {
            cam = new Capture();
            cam.QueryFrame();
            Application.Idle += new EventHandler(FrameGrabber);

        }

        void FrameGrabber(object sender, EventArgs e)
        {
            //Get the current frame form capture device
            currentFrame = cam.QueryFrame().Resize(camPanel.Width, camPanel.Height, Emgu.CV.CvEnum.INTER.CV_INTER_CUBIC);

            //Show the faces procesed and recognized
            camView.Image = currentFrame;

        }





        private void exitButton_Click(object sender, EventArgs e)
        {
            this.Close();
            menuScreen.Visible = true;            
        }
    }
}
