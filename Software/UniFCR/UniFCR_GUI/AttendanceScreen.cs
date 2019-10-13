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
using System.IO;
using System.Diagnostics;

namespace UniFCR_GUI
{
    public partial class AttendanceScreen : Form
    {

        Form menuScreen;

        //Declararation of all variables, vectors and haarcascades
        Image<Bgr, Byte> currentFrame;
        Capture grabber;
        HaarCascade face;
        HaarCascade eye;
        MCvFont font = new MCvFont(FONT.CV_FONT_HERSHEY_TRIPLEX, 0.5d, 0.5d);
        Image<Gray, byte> result, TrainedFace = null;
        Image<Gray, byte> gray = null;
        List<Image<Gray, byte>> trainingImages = new List<Image<Gray, byte>>();
        List<string> labels = new List<string>();
        List<string> NamePersons = new List<string>();
        int ContTrain, NumLabels, t;
        string name, names = null;

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
            //the camera feed may take up 3/4 of the screen
            //had to comment this out for camera to not switch itself off
            //camPanel.Width = (int) (mainPanel.Size.Width * 0.75);
            grabber = new Capture();
            grabber.QueryFrame();
            Application.Idle += new EventHandler(FrameGrabber);

            //Application.Idle += new EventHandler(FrameGrabber);

        }

        void FrameGrabber(object sender, EventArgs e)
        {
            //Get the current frame form capture device
            currentFrame = grabber.QueryFrame();
            gray = currentFrame.Convert<Gray, Byte>();
            //make sure this xml file is in the debug folder for this to work
            face = new HaarCascade("haarcascade_frontalface_default.xml");
            MCvAvgComp[][] facesDetected = gray.DetectHaarCascade(face, 1.2, 10, Emgu.CV.CvEnum.HAAR_DETECTION_TYPE.DO_CANNY_PRUNING, new Size(20, 20));
            foreach (MCvAvgComp f in facesDetected[0])
            {
                result = currentFrame.Copy(f.rect).Convert<Gray, byte>().Resize(100, 100, Emgu.CV.CvEnum.INTER.CV_INTER_CUBIC);
                //draw the face detected in the 0th (gray) channel with red color
                currentFrame.Draw(f.rect, new Bgr(Color.Red), 2);
            }

            //Show the faces procesed and recognized
            imageBoxFrameGrabber.Image = currentFrame;
            //Number of faces 
            this.nameLabel.Text = "Number of Faces: " + facesDetected[0].Length.ToString();

        }





        private void exitButton_Click(object sender, EventArgs e)
        {
            this.Close();
            menuScreen.Visible = true;
        }
    }
}
