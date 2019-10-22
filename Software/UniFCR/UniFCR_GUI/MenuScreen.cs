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

        //Variables for moving the window with the mouse
        private bool mouseDown;
        private Point lastLocation;

        Camera trainingCam;

        public MenuScreen()
        {
            InitializeComponent();
            optionsPanel.Visible = false;
            trainPanel.SendToBack();
            this.CenterToScreen();
            trainingCam = new Camera(trainCamView);
        }

        private void menuPanel_Paint(object sender, PaintEventArgs e)
        {
            //Center the buttons 
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
            //Making the camera feed fit into the window without changing the aspect ration is kind of difficult
            trainCamView.Width = trainCamPanel.Width;
            trainCamView.Height = (int)(trainCamPanel.Width / 1.8);
            trainCamView.Dock = DockStyle.None;
            trainCamView.Anchor = AnchorStyles.None;
            trainCamView.Location = new Point(
                (trainCamPanel.Width / 2) - (trainCamView.Width / 2), (trainCamPanel.Height / 2) - (trainCamView.Height / 2));

            
            trainingCam.start();
            trainingCam.ValueChanged += newImageListener;

            //Hide the loading screen when the camera feed is set up
            Thread.Sleep(2000);
            trainLoadingPanel.Visible = false;
            trainLoadingPanel.SendToBack();
        }

        private void newImageListener(Object sender, EventArgs e)
        {
            if (trainingCam.frame != null)
            {
                Console.WriteLine("new image found, " + trainingCam.frame.Width);
                FaceAlgorithm faceAlgorithm = new FaceAlgorithm();
                Image<Bgr, Byte> frame = faceAlgorithm.recognizeFaces(trainingCam.frame);
                trainingCam.DisplayImage(frame);
            }
            
        }

       /*
        * Clicking the "START" Button takes the 
        * user from the training window directly
        * to the Attendance Mode
        */
        private void trainStartButton_Click(object sender, EventArgs e)
        {
            trainPanel.SendToBack();
            trainPanel.Visible = false;

            trainLoadingPanel.SendToBack();
            trainLoadingPanel.Visible = false;

            this.Visible = false; //Hide the menu screen while Attendance Mode is active

            AttendanceScreen attendanceScreen = new AttendanceScreen(this);

            //the attendance screen should show on the same monitor as the menu
            attendanceScreen.StartPosition = FormStartPosition.Manual;
            Screen screen = Screen.FromPoint(this.Location);
            attendanceScreen.Location = screen.Bounds.Location;
            attendanceScreen.WindowState = FormWindowState.Maximized;

            attendanceScreen.Show();
        }

        private void trainSaveButton_Click(object sender, EventArgs e)
        {
            String firstName = firstNameBox.Text;
            String lastName = lastNameBox.Text;
            trainingCam.faceSaver(firstName + " " + lastName);
        }

        private void trainCamView_BackColorChanged(object sender, EventArgs e)
        {
            Console.WriteLine("success");
        }
    }
}
