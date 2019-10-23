﻿using System;
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
using UniFCR_Controller;

namespace UniFCR_GUI {
    public partial class AttendanceScreen : Form {

        Form menuScreen;
        static Camera attendanceCam;
        Boolean camRunning = false;
        int enrolledStudents = 6; //For testing purposes

        public AttendanceScreen(Form menuScreen)
        {
            InitializeComponent();
            this.menuScreen = menuScreen;

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

        private void camPanel_Paint(object sender, PaintEventArgs e)
        {
            //Making the camera feed fit into the window without changing the aspect ration is kind of difficult
            camView.Width = camPanel.Width;
            camView.Height = (int)(camPanel.Width / 1.8);
            camView.Dock = DockStyle.None;
            camView.Anchor = AnchorStyles.None;
            camView.Location = new Point(
                (camPanel.Width / 2) - (camView.Width / 2), (camPanel.Height / 2) - (camView.Height / 2));

            if (!camRunning)
            {
                attendanceCam = new Camera(camView);
                attendanceCam.start();
                attendanceCam.ValueChanged += newImageListener;
                camRunning = true;
            }

            //hide the loading screen when the camera feed is set up
            Thread.Sleep(1000);
            loadingPanel.Visible = false;

            //Testing the attendance precentage circle
            int attendance = 4;
            double attendancePercentage = ((double) attendance / (double) enrolledStudents) * 100;
            attendancePercentageCircle.Value = (int) attendancePercentage;
            attendancePercentageCircle.Text = (int) attendancePercentage + "%";
            attendancePercentageCircle.Update();
            attendanceLabel.Text = "Students present: " + attendance;
        }

        private void newImageListener(Object sender, EventArgs e)
        {
            if (attendanceCam.frame != null)
            {
                FaceAlgorithm faceAlgorithm = new FaceAlgorithm();
                Image<Bgr, Byte> frame = faceAlgorithm.recognizeFaces(attendanceCam.frame);
                attendanceCam.DisplayImage(frame);
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
