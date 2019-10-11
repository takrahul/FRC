using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UniFCR_GUI {
    public partial class MenuScreen : Form {
        private bool mouseDown;
        private Point lastLocation;
        public MenuScreen()
        {
            InitializeComponent();
            optionsPanel.Visible = false;
            this.CenterToScreen();
        }

        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            mouseDown = true;
            lastLocation = e.Location;
        }

        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            if (mouseDown) {
                this.Location = new Point(
                    (this.Location.X - lastLocation.X) + e.X, (this.Location.Y - lastLocation.Y) + e.Y);

                this.Update();
            }
        }

        private void Form1_MouseUp(object sender, MouseEventArgs e)
        {
            mouseDown = false;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        private void exitButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void trainButton_Click(object sender, EventArgs e)
        {

        }

        private void optionsButton_Click(object sender, EventArgs e)
        {
            buttonPanel.Visible = false;
            optionsPanel.Visible = true;
        }

        private void startButton_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            AttendanceScreen attendanceScreen = new AttendanceScreen(this);
            attendanceScreen.WindowState = FormWindowState.Maximized;
            attendanceScreen.Show();
        }

        private void buttonPanel_Paint(object sender, PaintEventArgs e)
        {

            
        }

        private void menuPanel_Paint(object sender, PaintEventArgs e)
        {
            //Center the Buttons 
            int buttonPanelX = (this.Size.Width / 2) - (buttonPanel.Size.Width / 2);
            int buttonPanelY = (this.Size.Height / 2) - (buttonPanel.Size.Height);
            buttonPanel.Location = new Point(buttonPanelX, buttonPanelY);
        }

        private void backButton_Click(object sender, EventArgs e)
        {
            optionsPanel.Visible = false;
            buttonPanel.Visible = true;
        }
    }
}
