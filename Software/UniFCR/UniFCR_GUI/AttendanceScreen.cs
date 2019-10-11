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
    public partial class AttendanceScreen : Form {

        Form menuScreen;
        public AttendanceScreen(Form menuScreen)
        {
            this.menuScreen = menuScreen;
            InitializeComponent();
        }

        private void mainPanel_Paint(object sender, PaintEventArgs e)
        {
            
        }

        private void camPanel_Paint(object sender, PaintEventArgs e)
        {
            camPanel.Width = (int) (mainPanel.Size.Width * 0.75);

        }

        private void exitButton_Click(object sender, EventArgs e)
        {
            this.Close();
            menuScreen.Visible = true;
            
        }
    }
}
