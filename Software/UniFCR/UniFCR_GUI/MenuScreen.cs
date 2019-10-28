using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using System.Threading;
using Emgu.CV;
using Emgu.CV.Structure;
using UniFCR_Controller;
using UniFCR_Database;
using DirectShowLib;

namespace UniFCR_GUI {
    public partial class MenuScreen : Form {

        //Variables for moving the window with the mouse
        private bool mouseDown;
        private Point lastLocation;

        static Camera trainingCam;
        Image<Bgr, Byte> frame; //Stores the latest frame
        Boolean camRunning = false;

        DatabaseController database = new DatabaseController();
        List<string> systemCameraNames = new List<string>();

        public MenuScreen()
        {
            InitializeComponent();
            optionsPanel.Visible = false;
            optionsPanel.SendToBack();
            trainPanel.Visible = false;
            trainPanel.SendToBack();
            this.CenterToScreen();

            //Get all cameras connected to the computer and save them to systemCameras
            Globals.systemCameras = DsDevice.GetDevicesOfCat(FilterCategory.VideoInputDevice);
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

            //The attendance screen should show on the same monitor as the menu
            attendanceScreen.StartPosition = FormStartPosition.Manual;
            Screen screen = Screen.FromPoint(this.Location);
            attendanceScreen.Location = screen.Bounds.Location;
            attendanceScreen.WindowState = FormWindowState.Maximized;

            attendanceScreen.Show();
        }

        //=================================================================
        // OPTIONS MENU
        //=================================================================

        //Show the options menu
        private void optionsButton_Click(object sender, EventArgs e)
        {
            buttonPanel.Visible = false;
            buttonPanel.SendToBack();

            optionsPanel.BringToFront();
            optionsPanel.Visible = true;

            foreach (DsDevice cam in Globals.systemCameras)
            {
                //Store the names of all cameras connected to the computer in systemCameraNames
                systemCameraNames.Add(cam.Name);
            }

            //Show the names in the Dropdown list
            cameraListBox.DataSource = systemCameraNames;
        }

        //Hide options menu and show main menu again
        private void optionsBackButton_Click(object sender, EventArgs e)
        {
            Globals.selectedCameraIndex = cameraListBox.SelectedIndex;     

            optionsPanel.Visible = false;
            optionsPanel.SendToBack();

            buttonPanel.BringToFront();
            buttonPanel.Visible = true;
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

        //Show training menu
        private void trainButton_Click(object sender, EventArgs e)
        {
            trainPanel.BringToFront();
            trainPanel.Visible = true;

            trainLoadingPanel.BringToFront();
            trainLoadingPanel.Visible = true;
        }        

        //Center the logo and the text on the loading screen
        private void trainLoadingPanel_Paint(object sender, PaintEventArgs e)
        {
            int textLogoX = (this.Size.Width / 2) - (logoTextPanel.Size.Width / 2);
            int textLogoY = (this.Size.Height / 2) - (logoTextPanel.Size.Height / 2);
            logoTextPanel.Location = new Point(textLogoX, textLogoY);
        }

        //Automatically start the camera when the training window is being painted
        private void trainCamPanel_Paint(object sender, PaintEventArgs e)
        {
            //Fit the trainCamView into the trainCamPanel but don't change the aspect ratio (~16:9)
            trainCamView.Width = trainCamPanel.Width;
            trainCamView.Height = (int)(trainCamPanel.Width / 1.8);
            trainCamView.Dock = DockStyle.None;
            trainCamView.Anchor = AnchorStyles.None;
            trainCamView.Location = new Point(
                (trainCamPanel.Width / 2) - (trainCamView.Width / 2), (trainCamPanel.Height / 2) - (trainCamView.Height / 2));

            //Because of the resizing etc. this methode is called multiple times 
            //so we check if there is already a camera running before starting one
            if (!camRunning)
            {
                trainingCam = new Camera(trainCamView);
                trainingCam.start();
                camRunning = true;
                database.LoadStudentsList();

                //When the trainingCam grabs a new frame from the webcam call newImageListener
                trainingCam.ValueChanged += newImageListener;
            }

            //Hide the loading screen when the camera feed is set up
            Thread.Sleep(1000); //Give the camera more time to start
            trainLoadingPanel.Visible = false;
            trainLoadingPanel.SendToBack();
        }

        private void newImageListener(Object sender, EventArgs e)
        {
            if (trainingCam.frame != null)
            {
                FaceAlgorithm faceAlgorithm = new FaceAlgorithm();
                frame = faceAlgorithm.recognizeFaces(trainingCam.frame);
                trainingCam.DisplayImage(frame);
            }
            
        }

        //Clicking the "START" Button takes the user from 
        //the training window directly to the Attendance Mode
        private void trainStartButton_Click(object sender, EventArgs e)
        {
            trainingCam.stop();

            camRunning = false;

            trainPanel.Visible = false;
            trainPanel.SendToBack();

            trainLoadingPanel.Visible = false;
            trainLoadingPanel.SendToBack();

            this.Visible = false; //Hide the menu screen while Attendance Mode is active

            AttendanceScreen attendanceScreen = new AttendanceScreen(this);

            //the attendance screen should show on the same monitor as the menu
            attendanceScreen.StartPosition = FormStartPosition.Manual;
            Screen screen = Screen.FromPoint(this.Location);
            attendanceScreen.Location = screen.Bounds.Location;
            attendanceScreen.WindowState = FormWindowState.Maximized;

            attendanceScreen.Show();
        }

        //Saves entered data in the database
        private void trainSaveButton_Click(object sender, EventArgs e)
        {
            Image<Gray, Byte> image = null;

            if (firstNameBox.Text.Equals(""))
            {
                MessageBox.Show("Enter your first name!", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Information);

            } else if (lastNameBox.Text.Equals(""))
            {
                MessageBox.Show("Enter your last name!", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Information);

            } else if (numberBox.Text.Equals(""))
            {
                MessageBox.Show("Enter your matriculation number!", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Information);

            } else if (trainingCam.currentFrame != null)
            {
                FaceAlgorithm faceAlgorithm = new FaceAlgorithm();
                List<Image<Gray, Byte>> detectedFaces = new List<Image<Gray, byte>>();
                detectedFaces = faceAlgorithm.detectFaces(trainingCam.currentFrame);

                if (detectedFaces.Count > 1)
                {
                    MessageBox.Show("Too many faces in the picture!", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                } else if (detectedFaces.Count == 0)
                {
                    MessageBox.Show("No face detected!", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                } else
                {
                    image = detectedFaces.ElementAt(0);
                    String firstName = firstNameBox.Text;
                    String lastName = lastNameBox.Text;
                    int matNum = Int32.Parse(numberBox.Text);
                    database.saveStudentList(firstName, lastName, matNum, image);
                    firstNameBox.Text = "";
                    lastNameBox.Text = "";
                    numberBox.Text = "";
                    MessageBox.Show(firstName + "´s face detected and added!", "Training OK", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            } else
            {

            }
        }

        private void trainBackButton_Click(object sender, EventArgs e)
        {
            trainingCam.stop();
            camRunning = false;

            trainPanel.SendToBack();
            trainPanel.Visible = false;

            trainLoadingPanel.SendToBack();
            trainLoadingPanel.Visible = false;
        }
    }
}
