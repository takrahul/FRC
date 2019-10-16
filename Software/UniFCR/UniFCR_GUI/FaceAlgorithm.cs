using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Emgu.CV;
using Emgu.CV.Structure;
using Emgu.CV.CvEnum;
using System.Drawing;




namespace UniFCR_GUI
{
    class FaceAlgorithm
    {
        private AttendanceScreen screen;
        public FaceAlgorithm(AttendanceScreen ac)
        {
            screen = ac;
        }

        public void detectFaces ()
        {
            //make sure this xml file is in the debug folder for this to work
            HaarCascade face = new HaarCascade("haarcascade_frontalface_default.xml");
            Image<Gray, byte> gray = null;
            Image<Gray, byte> result = null;
            gray = screen.CurrentFrame.Convert<Gray, Byte>();
            MCvAvgComp[][] facesDetected = gray.DetectHaarCascade(face, 1.2, 10, Emgu.CV.CvEnum.HAAR_DETECTION_TYPE.DO_CANNY_PRUNING, new Size(20, 20));
            foreach (MCvAvgComp f in facesDetected[0])
            {
                result = screen.CurrentFrame.Copy(f.rect).Convert<Gray, byte>().Resize(100, 100, Emgu.CV.CvEnum.INTER.CV_INTER_CUBIC);
                //draw the face detected in the 0th (gray) channel with red color
                screen.CurrentFrame.Draw(f.rect, new Bgr(Color.Red), 2);
            }

            //Show the faces procesed and recognized
            screen.CamView.Image = screen.CurrentFrame;
            //Number of faces 
            screen.NameLabel.Text = "Number of Faces: " + facesDetected[0].Length.ToString();

        }
    }
}
