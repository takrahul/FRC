using System;
using System.Drawing;
using System.Linq;
using System.Threading;
using System.Windows.Forms;
using Emgu.CV;
using Emgu.CV.Structure;
using UniFCR_Controller;
using UniFCR_Database;

namespace UniFCR_GUI {
    public partial class AttendanceScreen : Form {

        Form menuScreen;
        static Camera attendanceCam;
        Boolean camRunning = false;
        int enrolledStudents;
        int attendance;

        public AttendanceScreen(Form menuScreen)
        {
            InitializeComponent();
            this.menuScreen = menuScreen;

            //Get number of enrolled students
            enrolledStudents = SqliteDataAccess.LoadStudents().Count;

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

            attendanceLabel.Width = infoPanel.Width;
            missingStudentsBox.SelectionAlignment = HorizontalAlignment.Center;
        }

        //Automatically start the camera when the window is being painted
        private void camPanel_Paint(object sender, PaintEventArgs e)
        {
            //Making the camView fit in the camPanel without changing the aspect ration (~16:9)
            camView.Width = camPanel.Width;
            camView.Height = (int)(camPanel.Width / 1.8);
            camView.Dock = DockStyle.None;
            camView.Anchor = AnchorStyles.None;
            camView.Location = new Point(
                (camPanel.Width / 2) - (camView.Width / 2), (camPanel.Height / 2) - (camView.Height / 2));

            //Because of the resizing etc. this methode is called multiple times 
            //so we check if there is already a camera running before starting one
            if (!camRunning)
            {
                attendanceCam = new Camera(camView);
                attendanceCam.start();
                camRunning = true;

                //When the attendanceCam grabs a new frame from the webcam call newImageListener
                attendanceCam.ValueChanged += newImageListener;
            }

            //hide the loading screen when the camera feed is set up
            Thread.Sleep(1000); //Give the camera more time to start
            loadingPanel.Visible = false;
        }

        private void newImageListener(Object sender, EventArgs e)
        {
            if (attendanceCam.frame != null)
            {
                FaceAlgorithm faceAlgorithm = new FaceAlgorithm();
                Image<Bgr, Byte> frame = faceAlgorithm.recognizeFaces(attendanceCam.frame);
                attendanceCam.DisplayImage(frame);

                if (Globals.trainingImages.Count() > 0 && enrolledStudents > 0)
                {
                    updatePercentage();
                    updateAttendance();
                }
            }
        }

        delegate void updateAttendanceCallback();
        private void updateAttendance()
        {
            // InvokeRequired required compares the thread ID of the
            // calling thread to the thread ID of the creating thread.
            // If these threads are different, it returns true.
            if (this.attendanceLabel.InvokeRequired)
            {
                updateAttendanceCallback d = new updateAttendanceCallback(updateAttendance);
                this.Invoke(d, new object[] {  });
            }
            else
            {
                attendanceLabel.Text = "Students present: " + attendance;
            }
        }

        delegate void updatePercentageCallback();
        private void updatePercentage()
        {
            // InvokeRequired required compares the thread ID of the
            // calling thread to the thread ID of the creating thread.
            // If these threads are different, it returns true.
            if (this.attendanceLabel.InvokeRequired)
            {
                updatePercentageCallback d = new updatePercentageCallback(updatePercentage);
                this.Invoke(d, new object[] {  });
            }
            else
            {
                //Testing the attendance precentage circle
                attendance = Globals.facesDetected[0].Length;
                double attendancePercentage = ((double)attendance / (double)enrolledStudents) * 100;
                attendancePercentageCircle.Value = (int)attendancePercentage;
                attendancePercentageCircle.Text = (int)attendancePercentage + "%";
                attendancePercentageCircle.Update();
                attendancePercentageCircle.Update();
            }
        }

        private void exitButton_Click(object sender, EventArgs e)
        {
            this.Close();
            camRunning = false;
            attendanceCam.stop();
            menuScreen.Visible = true;            
        }
    }
}
