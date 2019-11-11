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
using System.Text;
using System.IO;

namespace UniFCR_GUI {
    public partial class MenuScreen : Form {

        #region Variables
        //Variables for moving the window with the mouse
        private bool mouseDown;
        private Point lastLocation;

        private  static Camera trainingCam;
        private Image<Bgr, Byte> frame; //Stores the latest frame
        private Boolean camRunning = false;

        private DatabaseController database = new DatabaseController();
        private List<string> systemCameraNames = new List<string>();

        private List<Image<Gray, Byte>> images = new List<Image<Gray, byte>>(); //Saving multiple images in training mode
        private Boolean capturingInProgress = false;

        private FaceAlgorithm faceAlgorithm = new FaceAlgorithm();
        #endregion

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

        //=================================================================
        // MAIN MENU
        //=================================================================
        #region Main Menu

        /// <summary>
        /// This Method centers the panel containing the buttons in the main menu.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void menuPanel_Paint(object sender, PaintEventArgs e)
        {
            //Center the buttons 
            int buttonPanelX = (this.Size.Width / 2) - (buttonPanel.Size.Width / 2);
            int buttonPanelY = (this.Size.Height / 2) - (buttonPanel.Size.Height);
            buttonPanel.Location = new Point(buttonPanelX, buttonPanelY);
        }

        /// <summary>
        /// This Method is called when the start button is clicked. 
        /// It hides the menu screen, initializes the attendance screen and then maximizes it.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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

        /// <summary>
        /// This Method is called when the exit button is clicked.
        /// After showing a yes/no message box it saves a list of all students
        /// in the database and marks if they attended.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void exitButton_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Do you want to save a list of all attended students?", "Save", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                List<StudentModel> students = database.student;
                var csv = new StringBuilder();
                csv.Append("Last Name, First Name, Marticulation Number, Attended? \n");
                for (int i = 0; i < students.Count(); i++)
                {
                    if (Globals.recognizedStudentNumbers.Contains(students.ElementAt(i).MatNo))
                    {
                        csv.Append(students.ElementAt(i).StudentData + ", Yes" + "\n");
                    }
                    else
                    {
                        csv.Append(students.ElementAt(i).StudentData + ", No" + "\n");
                    }
                }
                if (!System.IO.Directory.Exists("../../../Lists/"))
                {
                    System.IO.Directory.CreateDirectory("../../../Lists/");
                }

                File.WriteAllText("../../../Lists/attendance_" + DateTime.Today.ToString("dd_MM") + ".csv", csv.ToString());
            }
            
            this.Close();
        }
        #endregion 

        //=================================================================
        // OPTIONS MENU
        //=================================================================
        #region Options Menu
        
        /// <summary>
        /// When the Options Button is clicked this method hides the 
        /// Button Panel and shows the Options Panel and populates
        /// the Camera Dropdown List.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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

        /// <summary>
        /// This Method is called when the <c>thresholdTextBox</c> is 
        /// selected and a key is pressed. If the Enter key was pressed the Value
        /// of the <c>thresholdTrackBar</c> will be updated.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void thresholdTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            //If Enter key is pressed
            if (e.KeyChar == (char)13)
            {

                if (thresholdTextBox.Text != "")
                {
                    int num = Int32.Parse(thresholdTextBox.Text);

                    if (num >= 2000 && num <= 5000)
                    {
                        thresholdTrackBar.Value = Int32.Parse(thresholdTextBox.Text);
                        thresholdTrackBar.Focus();
                    }
                }
            }
        }

        /// <summary>
        /// When the TrackBar slider is moved this Method updates the value
        /// of the <c>thresholdTrackBar</c>.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void thresholdTrackBar_Scroll(object sender, EventArgs e)
        {
            //Globals.threshold = thresholdTrackBar.Value;
            thresholdTextBox.Text = thresholdTrackBar.Value + "";
        }

        /// <summary>
        /// This Method is called when the TextBox leaves the focus.
        /// It updates the <c>thresholdTrackBar</c>.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void thresholdTextBox_Leave(object sender, EventArgs e)
        {
            thresholdTrackBar.Value = Int32.Parse(thresholdTextBox.Text);
        }

        /// <summary>
        /// This Method is called when the <c>optionsDeleteBox</c> enters the focus.
        /// It clears the TextBox
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void optionsDeleteBox_Enter(object sender, EventArgs e)
        {
            optionsDeleteBox.Text = "";
        }

        private void optionsDeleteButton_Click(object sender, EventArgs e)
        {
            if (optionsDeleteBox.Text != "Enter Mat. No." && optionsDeleteBox.Text != "")
            {
                try
                {
                    int enteredNumber = Int32.Parse(optionsDeleteBox.Text);
                    optionsDeleteBox.Text = "Enter Mat. No.";
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Enter a correct Mat. Number!", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Console.WriteLine(ex.StackTrace);
                }
            }
        }

        /// <summary>
        /// This Method is called when the Back Button in the Options 
        /// Menu is pressed. It saves the selected camera, entered threshold 
        /// and resets the <c>optionsDeleteBox</c>. Then it hides the Options 
        /// Panel and shows the Button Panel again.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void optionsBackButton_Click(object sender, EventArgs e)
        {
            Globals.selectedCameraIndex = cameraListBox.SelectedIndex;
            Globals.recognizedThreshold = thresholdTrackBar.Value;
            optionsDeleteBox.Text = "Enter Mat. No.";

            optionsPanel.Visible = false;
            optionsPanel.SendToBack();

            buttonPanel.BringToFront();
            buttonPanel.Visible = true;
        }
        #endregion

        //=================================================================
        // EVENT HANDLERS FOR MOVING AROUND THE WINDOW
        //=================================================================
        #region Event Handlers for moving around the window
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
        #endregion

        //=================================================================
        // TRAINING MODE
        //=================================================================
        #region Training Mode

        /// <summary>
        /// Show the <c>trainPanel</c>
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void trainButton_Click(object sender, EventArgs e)
        {
            buttonPanel.Visible = false;
            buttonPanel.SendToBack();

            trainPanel.BringToFront();
            trainPanel.Visible = true;

            trainLoadingPanel.BringToFront();
            trainLoadingPanel.Visible = true;
        }

        /// <summary>
        /// Center the logo and the text on the loading screen
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void trainLoadingPanel_Paint(object sender, PaintEventArgs e)
        {
            int textLogoX = (this.Size.Width / 2) - (logoTextPanel.Size.Width / 2);
            int textLogoY = (this.Size.Height / 2) - (logoTextPanel.Size.Height / 2);
            logoTextPanel.Location = new Point(textLogoX, textLogoY);
        }

        /// <summary>
        /// Automatically start the camera when the training window is being painted
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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
                frame = faceAlgorithm.detectFaces(trainingCam.frame);
                frame = frame.Resize((int)(trainCamView.Width), (int)(trainCamView.Height), Emgu.CV.CvEnum.INTER.CV_INTER_CUBIC);
                trainingCam.DisplayImage(frame);
            }
        }

        /// <summary>
        /// When the capturing is done: save all images and data in the database
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void trainSaveButton_Click(object sender, EventArgs e)
        {
            if (firstNameBox.Text.Equals(""))
            {
                MessageBox.Show("Enter your first name!", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            else if (lastNameBox.Text.Equals(""))
            {
                MessageBox.Show("Enter your last name!", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            else if (numberBox.Text.Equals(""))
            {
                MessageBox.Show("Enter your matriculation number!", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            else if (images.Count == 0 || capturingInProgress == true)
            {
                MessageBox.Show("Capture images first!", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            else
            {
                try
                {
                    String firstName = firstNameBox.Text;
                    String lastName = lastNameBox.Text;
                    int matNum = Int32.Parse(numberBox.Text);
                    database.saveStudentList(firstName, lastName, matNum, images);
                    firstNameBox.Text = "";
                    lastNameBox.Text = "";
                    numberBox.Text = "";
                    MessageBox.Show(firstName + " " + lastName + " has been added to the Database!", "Training OK", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    images = new List<Image<Gray, byte>>();
                    images.Clear();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("There was an error while saving to the Database!", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        /// <summary>
        /// Captures multiple pictures
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void trainCaptureButton_Click(object sender, EventArgs e)
        {           
            if (capturingInProgress == false)
            {
                capturingInProgress = true;

                FaceAlgorithm faceAlgorithm = new FaceAlgorithm();

                int captureCount = 0;
                while (captureCount < 10)
                {
                    faceAlgorithm.detectFaces(trainingCam.frame);

                    if (Globals.processedDetectedFaces.Count == 1)
                    {
                        images.Add(Globals.processedDetectedFaces.ElementAt(0));
                        captureCount++;
                        Thread.Sleep(31);
                    }
                                       
                }
                MessageBox.Show("A total of " + images.Count + " Pictures have been captured. Press CAPTURE to capture 10 more!", "Training OK", MessageBoxButtons.OK, MessageBoxIcon.Information);
                capturingInProgress = false;
            }
        }

        /// <summary>
        /// Stops the camera and shows the Button Panel again.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void trainBackButton_Click(object sender, EventArgs e)
        {
            trainingCam.stop();
            camRunning = false;

            buttonPanel.BringToFront();
            buttonPanel.Visible = true;

            trainPanel.SendToBack();
            trainPanel.Visible = false;

            trainLoadingPanel.SendToBack();
            trainLoadingPanel.Visible = false;
        }

        #endregion

    }
}
