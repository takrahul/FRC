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
    public partial class MenuScreen : Form {
        private bool mouseDown;
        private Point lastLocation;

        Image<Bgr, Byte> currentFrame;
        Capture trainCam;

        public MenuScreen()
        {
            InitializeComponent();
            optionsPanel.Visible = false;
            trainPanel.SendToBack();
            this.CenterToScreen();
        }

        private void menuPanel_Paint(object sender, PaintEventArgs e)
        {
            //Center the Buttons 
            int buttonPanelX = (this.Size.Width / 2) - (buttonPanel.Size.Width / 2);
            int buttonPanelY = (this.Size.Height / 2) - (buttonPanel.Size.Height);
            buttonPanel.Location = new Point(buttonPanelX, buttonPanelY);
        }

        private void exitButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void startButton_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            AttendanceScreen attendanceScreen = new AttendanceScreen(this);

            //the attendance screen should show on the same monitor as the menu
            attendanceScreen.StartPosition = FormStartPosition.Manual;
            Screen screen = Screen.FromPoint(this.Location);
            attendanceScreen.Location = screen.Bounds.Location;
            attendanceScreen.WindowState = FormWindowState.Maximized;

            attendanceScreen.Show();
        }
        
        //Show the options menu
        private void optionsButton_Click(object sender, EventArgs e)
        {
            buttonPanel.Visible = false;
            optionsPanel.Visible = true;
        }

        //Hide options menu and show main menu again
        private void optionsBackButton_Click(object sender, EventArgs e)
        {
            optionsPanel.Visible = false;
            buttonPanel.Visible = true;
        }

        //Show training menu
        private void trainButton_Click(object sender, EventArgs e)
        {
            trainPanel.Visible = true;
            trainPanel.BringToFront();

            trainLoadingPanel.Visible = true;
            trainLoadingPanel.BringToFront();
        }

        //=================================================================
        // EVENT HANDLERS FOR MOVING AROUND THE WINDOW
        //=================================================================
        private void MenuScreen_MouseDown(object sender, MouseEventArgs e)
        {
            mouseDown = true;
            lastLocation = e.Location;
        }

        private void MenuScreen_MouseMove(object sender, MouseEventArgs e)
        {
            if (mouseDown)
            {
                this.Location = new Point(
                    (this.Location.X - lastLocation.X) + e.X, (this.Location.Y - lastLocation.Y) + e.Y);

                this.Update();
            }
        }

        private void MenuScreen_MouseUp(object sender, MouseEventArgs e)
        {
            mouseDown = false;
        }

        //=================================================================
        // TRAINING MODE
        //=================================================================
        private void trainBackButton_Click(object sender, EventArgs e)
        {


            trainPanel.SendToBack();
            trainPanel.Visible = false;

            trainLoadingPanel.SendToBack();
            trainLoadingPanel.Visible = false;
        }

        private void trainLoadingPanel_Paint(object sender, PaintEventArgs e)
        {
            //Center the logo and the text on the loading screen
            int textLogoX = (this.Size.Width / 2) - (logoTextPanel.Size.Width / 2);
            int textLogoY = (this.Size.Height / 2) - (logoTextPanel.Size.Height / 2);
            logoTextPanel.Location = new Point(textLogoX, textLogoY);
        }

        private void trainCamPanel_Paint(object sender, PaintEventArgs e)
        {
            trainCam = new Capture();
            trainCam.Start();
            trainCam.ImageGrabbed += ProcessFrame;
        }

        private void ProcessFrame(object sender, EventArgs arg)
        {
            //***If you want to access the image data the use the following method call***/
            //Image<Bgr, Byte> frame = new Image<Bgr,byte>(_capture.RetrieveBgrFrame().ToBitmap());

            Image<Bgr, Byte> frame = trainCam.RetrieveBgrFrame();
            //because we are using an autosize picturebox we need to do a thread safe update
            DisplayImage(frame.ToBitmap());
        }

        private delegate void DisplayImageDelegate(Bitmap Image);
        private void DisplayImage(Bitmap Image)
        {
            if (trainCamView.InvokeRequired)
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
                trainCamView.Image = new Image<Bgr, Byte>(Image);
            }
        }

        private void tableLayoutPanel1_Paint_1(object sender, PaintEventArgs e)
        {
            //Usually called in trainCamPanel_Paint() but programm will crash then 
            closeLoadingScreen();
        }

        public void closeLoadingScreen()
        {
            //Hide the loading screen when the camera feed is set up
            Thread.Sleep(1000);
            trainLoadingPanel.Visible = false;
            trainLoadingPanel.SendToBack();
        }

        private void trainStartButton_Click(object sender, EventArgs e)
        {
            trainPanel.SendToBack();
            trainPanel.Visible = false;

            trainLoadingPanel.SendToBack();
            trainLoadingPanel.Visible = false;

            this.Visible = false;
            AttendanceScreen attendanceScreen = new AttendanceScreen(this);

            //the attendance screen should show on the same monitor as the menu
            attendanceScreen.StartPosition = FormStartPosition.Manual;
            Screen screen = Screen.FromPoint(this.Location);
            attendanceScreen.Location = screen.Bounds.Location;
            attendanceScreen.WindowState = FormWindowState.Maximized;

            attendanceScreen.Show();
        }

    }
}
