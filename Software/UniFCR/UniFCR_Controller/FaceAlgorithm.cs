using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Emgu.CV;
using Emgu.CV.Structure;
using Emgu.CV.CvEnum;
using System.Drawing;
using Emgu.CV.UI;
using System.IO;




namespace UniFCR_Controller {
    public class FaceAlgorithm {
        //private AttendanceScreen screen;
        int t = 0;
        String name, names;
        MCvFont font = new MCvFont(FONT.CV_FONT_HERSHEY_TRIPLEX, 0.5d, 0.5d);
        List<string> NamePersons = new List<string>();
        HaarCascade face = new HaarCascade("haarcascade_frontalface_default.xml");



        public FaceAlgorithm()
        {
            // DO NOT TOUCH
            if (Globals.created == true)
            {

                //Load of previus trainned faces and labels for each image
                string Labelsinfo = File.ReadAllText("D:/Documents/Team Oriented Project/Repo/Software/UniFCR/UniFCR_GUI/bin/Debug/TrainedFaces/TrainedLabels.txt");
                string[] Labels = Labelsinfo.Split('%');
                Globals.numLabels = Convert.ToInt16(Labels[0]);
                Globals.ContTrain = Globals.numLabels;
                string LoadFaces;

                for (int tf = 1; tf < Globals.numLabels + 1; tf++)
                {
                    LoadFaces = "face" + tf + ".bmp";
                    Globals.trainingImages.Add(new Image<Gray, byte>("D:/Documents/Team Oriented Project/Repo/Software/UniFCR/UniFCR_GUI/bin/Debug/TrainedFaces/" + LoadFaces));
                    Globals.labels.Add(Labels[tf]);
                }
                Globals.created = false;
            }

        }
        public void detectFaces(Image<Bgr, Byte> frame)
        {
            //make sure this xml file is in the debug folder for this to work
            Image<Gray, byte> gray = null;
            Image<Gray, byte> result = null;
            gray = frame.Convert<Gray, Byte>();
            MCvAvgComp[][] facesDetected = gray.DetectHaarCascade(face, 1.2, 10, Emgu.CV.CvEnum.HAAR_DETECTION_TYPE.DO_CANNY_PRUNING, new Size(20, 20));
            foreach (MCvAvgComp f in facesDetected[0])
            {
                t = t + 1;
                result = frame.Copy(f.rect).Convert<Gray, byte>().Resize(100, 100, Emgu.CV.CvEnum.INTER.CV_INTER_CUBIC);
                //draw the face detected in the 0th (gray) channel with red color
                frame.Draw(f.rect, new Bgr(Color.Red), 2);
            }
        }


        public Image<Bgr, Byte> recognizeFaces(Image<Bgr, Byte> frame)
        {
            NamePersons.Add("");
            Image<Gray, byte> gray = null;
            Image<Gray, byte> result = null;
            gray = frame.Convert<Gray, Byte>();
            MCvAvgComp[][] facesDetected = gray.DetectHaarCascade(face, 1.2, 10, Emgu.CV.CvEnum.HAAR_DETECTION_TYPE.DO_CANNY_PRUNING, new Size(20, 20));
            foreach (MCvAvgComp f in facesDetected[0])
            {
                t = t + 1;
                result = frame.Copy(f.rect).Convert<Gray, byte>().Resize(100, 100, Emgu.CV.CvEnum.INTER.CV_INTER_CUBIC);
                //draw the face detected in the 0th (gray) channel with red color
                frame.Draw(f.rect, new Bgr(Color.Red), 2);


                if (Globals.trainingImages.ToArray().Length != 0)
                {
                    //TermCriteria for face recognition with numbers of trained images like maxIteration
                    MCvTermCriteria termCrit = new MCvTermCriteria(Globals.ContTrain, 0.001);

                    //Eigen face recognizer
                    EigenObjectRecognizer recognizer = new EigenObjectRecognizer(
                       Globals.trainingImages.ToArray(),
                       Globals.labels.ToArray(),
                       3000,
                       ref termCrit);

                    name = recognizer.Recognize(result);

                    //Draw the label for each face detected and recognized
                    frame.Draw(name, ref font, new Point(f.rect.X - 2, f.rect.Y - 2), new Bgr(Color.LightGreen));

                }
                NamePersons[t - 1] = name;
                NamePersons.Add("");
                //nameLabel.Text = "Number: " + facesDetected[0].Length.ToString();

            }
            t = 0;
            for (int nnn = 0; nnn < facesDetected[0].Length; nnn++)
            {
                names = names + NamePersons[nnn] + ", ";
            }
            //Show the faces procesed and recognized
            //camView.Image = frame.ToBitmap();
            //List the names
            //nameLabel.Text += "\n " + names;
            names = "";
            NamePersons.Clear();

            return frame;

        }
    }
}
