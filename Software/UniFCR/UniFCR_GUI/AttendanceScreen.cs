using System;
using System.Collections.Generic;
using System.ComponentModel;
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

        #region Variables
        Form menuScreen;
        static Camera attendanceCam;
        Boolean camRunning = false;
        int enrolledStudents; //Total number of enrolled students
        int attendance; //Number of attending students
        DatabaseController database = new DatabaseController();
        FaceAlgorithm faceAlgorithm = new FaceAlgorithm();
        #endregion

        //=================================================================
        // CONSTRUCTOR + SIDEPANEL + LOADING SCREEN
        //=================================================================
        #region Constructor Sidepanel Loading Screen
        public AttendanceScreen(Form menuScreen)
        {
            InitializeComponent();
            this.menuScreen = menuScreen;

            //Get number of enrolled students
            enrolledStudents = SqliteDataAccess.LoadStudents().Count;

            //Show loading screen first
            loadingPanel.BringToFront();

            database.LoadStudentsList();

            //studentListView.View = View.Details;
            studentListView.View = View.List;
            int index = 1;
            foreach (StudentModel s in database.student)
            {
                //ListViewItem row = new ListViewItem("" + index);
                //row.SubItems.Add(s.GivenNames);
                //row.SubItems.Add(s.LastName);
                //row.SubItems.Add("" + s.MatNo);
                //studentListView.Items.Add(row);

                ListViewItem i = new ListViewItem(s.GivenNames + " " + s.LastName);
                i.SubItems.Add("" + s.MatNo);
                studentListView.Items.Add(i);

                index++;
            }
        }

        /// <summary>
        /// Unselects a item as soon as it's selected
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void studentListView_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
        {
            if (e.IsSelected)
            {
                e.Item.Selected = false;
            }
        }

        /// <summary>
        /// Waits a bit for the FaceAlgorithm to finish and then goes back to the Main Menu
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void exitButton_Click(object sender, EventArgs e)
        {
            faceAlgorithm.recognizationInProgress = true;
            Thread.Sleep(500);
            attendanceCam.stop();
            camRunning = false;
            this.Close();
            this.Dispose();
            menuScreen.Visible = true;
        }

        /// <summary>
        /// While the attendance screen is preparing (calculating size, loading camera) show a loading screen
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void loadingPanel_Paint(object sender, PaintEventArgs e)
        {
            //Center the logo and the text on the loading screen
            int textLogoX = (this.Size.Width / 2) - (logoTextPanel.Size.Width / 2);
            int textLogoY = (this.Size.Height / 2) - (logoTextPanel.Size.Height / 2);
            logoTextPanel.Location = new Point(textLogoX, textLogoY);

            //The camera feed may take up 3/4 of the screen
            camPanel.Width = (int)(mainPanel.Size.Width * 0.75);

            attendanceLabel.Width = infoPanel.Width;

            //studentListView.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);

            studentListView.Columns[0].Width = infoPanel.Width;
            studentListView.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
            studentListView.MaximumSize = studentListView.Size;
            studentListView.Dock = DockStyle.Fill;
            studentListView.Anchor = AnchorStyles.Top;
        }
        #endregion

        //=================================================================
        // CAMERA
        //=================================================================
        #region Camera
        /// <summary>
        /// Automatically start the camera when the window is being painted
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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
                if (faceAlgorithm.recognizationInProgress == false)
                {
                    faceAlgorithm.recognizationInProgress = true;
                    Image<Bgr, Byte> frame = faceAlgorithm.recognizeFaces(attendanceCam.frame);
                    frame = frame.Resize((int)(camView.Width), (int)(camView.Height), Emgu.CV.CvEnum.INTER.CV_INTER_CUBIC);
                    attendanceCam.DisplayImage(frame);

                    if (Globals.trainingImages.Count() > 0 && enrolledStudents > 0)
                    {
                        updatePercentage();
                        updateAttendance();
                        updateListView();
                    }
                    faceAlgorithm.recognizationInProgress = false;
                }
            }
        }

        #endregion

        //=================================================================
        // UPDATE GUI 
        //=================================================================
        #region Update GUI
        delegate void updateAttendanceCallback();
        private void updateAttendance()
        {
            // InvokeRequired required compares the thread ID of the
            // calling thread to the thread ID of the creating thread.
            // If these threads are different, it returns true.
            if (this.attendanceLabel.InvokeRequired)
            {
                try
                {
                    updateAttendanceCallback d = new updateAttendanceCallback(updateAttendance);
                    this.Invoke(d, new object[] { });
                }
                catch (Exception e)
                {

                }
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

                try
                {
                    updatePercentageCallback d = new updatePercentageCallback(updatePercentage);
                    this.Invoke(d, new object[] { });
                }
                catch (Exception e)
                {

                }

            }
            else
            {
                //Testing the attendance precentage circle
                attendance = Globals.recognizedStudentNumbers.Count;
                double attendancePercentage = ((double)attendance / (double)enrolledStudents) * 100;
                attendancePercentageCircle.Value = (int)attendancePercentage;
                attendancePercentageCircle.Text = (int)attendancePercentage + "%";
                attendancePercentageCircle.Update();
                attendancePercentageCircle.Update();
            }
        }

        delegate void updateListViewCallback();
        private void updateListView()
        {
            // InvokeRequired required compares the thread ID of the
            // calling thread to the thread ID of the creating thread.
            // If these threads are different, it returns true.
            if (this.attendanceLabel.InvokeRequired)
            {
                try
                {
                    updateListViewCallback d = new updateListViewCallback(updateListView);
                    this.Invoke(d, new object[] { });
                }
                catch (Exception e)
                {

                }
            }
            else
            {
                foreach (ListViewItem i in studentListView.Items)
                {
                    foreach (int num in Globals.recognizedStudentNumbers)
                    {
                        //Mark student as attended
                        if (i.SubItems[1].Text.Equals(num + ""))//3
                        {
                            i.BackColor = attendanceLabel.ForeColor;
                            i.ForeColor = Color.DarkGray;
                        }
                    }

                }
            }
        }
        #endregion

    }
}
