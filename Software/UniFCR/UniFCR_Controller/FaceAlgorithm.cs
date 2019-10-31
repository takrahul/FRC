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
using UniFCR_Database;




namespace UniFCR_Controller {
    public class FaceAlgorithm {
        //private AttendanceScreen screen;
        public Boolean recognizationInProgress = false;
        int t = 0;
        String name, names;
        MCvFont font = new MCvFont(FONT.CV_FONT_HERSHEY_TRIPLEX, 0.5d, 0.5d);
       List<string> NamePersons = new List<string>();
        CascadeClassifier face = new CascadeClassifier("haarcascade_frontalface_default.xml");

        public FaceAlgorithm()
        {
            List<StudentModel> students = new List<StudentModel>();
            students = SqliteDataAccess.LoadStudents();

            // DO NOT TOUCH
            if (Globals.created == true)
            {

                //Load of previus trainned faces and labels for each image
                //string Labelsinfo = File.ReadAllText("D:/Documents/Team Oriented Project/Repo/Software/UniFCR/UniFCR_GUI/bin/Debug/TrainedFaces/TrainedLabels.txt");

                foreach (StudentModel m in students) 
                {
                    foreach (byte[] b in m.Image)
                    {
                        Console.WriteLine("For loop" +  m.GivenNames + " " + m.LastName);
                        Globals.studentNames.Add(m.GivenNames + " " + m.LastName);
                        ImageConverter converter = new ImageConverter();

                        Bitmap bmp;
                        using (var ms = new MemoryStream(b))
                        {
                            bmp = new Bitmap(ms);
                        }
                        Image<Gray, byte> trainedFaceImage = new Image<Gray, byte>(bmp);
                        Globals.trainingImages.Add(trainedFaceImage);
                        Globals.labels.Add(m.GivenNames + " " + m.LastName);

                    }


                }
                Globals.numLabels = Globals.studentNames.Count;
                Globals.ContTrain = Globals.numLabels;
                string LoadFaces;


 /*               for (int tf = 0; tf < Globals.numLabels; tf++)
                {
                    LoadFaces = "face" + tf + ".bmp";

                    
                    //Globals.trainingImages.Add(new Image<Gray, byte>("D:/Documents/Team Oriented Project/Repo/Software/UniFCR/UniFCR_GUI/bin/Debug/TrainedFaces/" + LoadFaces));
                    Globals.labels.Add(Globals.studentNames.ToArray()[tf]);
                }
                */

                Globals.created = false;
            }
        }

        public Image<Bgr, byte> detectFaces(Image<Bgr, Byte> frame)
        {
            Globals.processedDetectedFaces = new List<Image<Gray, byte>>();

            //make sure this xml file is in the debug folder for this to work
            Image<Gray, byte> gray = null;
            Image<Gray, byte> result = null;
            gray = frame.Convert<Gray, Byte>();
            //MCvAvgComp[][] facesDetected = gray.DetectHaarCascade(face, 1.2, 10, Emgu.CV.CvEnum.HAAR_DETECTION_TYPE.DO_CANNY_PRUNING, new Size(20, 20));
            Globals.facesDetected = face.DetectMultiScale(gray, 1.2, 10, new Size(50, 50), Size.Empty);
            for (int i = 0; i < Globals.facesDetected.Length; i++)
            {
                t = t + 1;
                Globals.facesDetected[i].X += (int)(Globals.facesDetected[i].Height * 0.15);
                Globals.facesDetected[i].Y += (int)(Globals.facesDetected[i].Width * 0.22);
                Globals.facesDetected[i].Height -= (int)(Globals.facesDetected[i].Height * 0.3);
                Globals.facesDetected[i].Width -= (int)(Globals.facesDetected[i].Width * 0.35);
                result = frame.Copy(Globals.facesDetected[i]).Convert<Gray, byte>().Resize(100, 100, Emgu.CV.CvEnum.INTER.CV_INTER_CUBIC);
                result._EqualizeHist();
                //draw the face detected in the 0th (gray) channel with red color
                frame.Draw(Globals.facesDetected[i], new Bgr(Color.Red), 2);
                Globals.processedDetectedFaces.Add(result);
            }

            return frame;
        }


        public Image<Bgr, Byte> recognizeFaces(Image<Bgr, Byte> frame)
        {
            Globals.processedDetectedFaces = new List<Image<Gray, byte>>();
            NamePersons.Add("");
            Image<Gray, byte> gray = null;
            Image<Gray, byte> result = null;
            gray = frame.Convert<Gray, Byte>();
            //Globals.facesDetected = gray.DetectHaarCascade(face, 1.2, 10, Emgu.CV.CvEnum.HAAR_DETECTION_TYPE.DO_CANNY_PRUNING, new Size(20, 20));
            Globals.facesDetected = face.DetectMultiScale(gray, 1.2, 10, new Size(50, 50), Size.Empty);
            //foreach (MCvAvgComp f in Globals.facesDetected[0])
            for(int i = 0; i<Globals.facesDetected.Length; i++)
            {
                t = t + 1;
                Globals.facesDetected[i].X += (int)(Globals.facesDetected[i].Height * 0.15);
                Globals.facesDetected[i].Y += (int)(Globals.facesDetected[i].Width * 0.22);
                Globals.facesDetected[i].Height -= (int)(Globals.facesDetected[i].Height * 0.3);
                Globals.facesDetected[i].Width -= (int)(Globals.facesDetected[i].Width * 0.35);


                //result = frame.Copy(f.rect).Convert<Gray, byte>().Resize(100, 100, Emgu.CV.CvEnum.INTER.CV_INTER_CUBIC);
                result = frame.Copy(Globals.facesDetected[i]).Convert<Gray, byte>().Resize(100, 100, Emgu.CV.CvEnum.INTER.CV_INTER_CUBIC);
                result._EqualizeHist();
				Globals.processedDetectedFaces.Add(result);
                //draw the face detected in the 0th (gray) channel with red color
                //frame.Draw(f.rect, new Bgr(Color.Red), 2);
                frame.Draw(Globals.facesDetected[i], new Bgr(Color.Red), 2);

                if (Globals.trainingImages.ToArray().Length != 0)
                {
                    //TermCriteria for face recognition with numbers of trained images like maxIteration
                    //MCvTermCriteria termCrit = new MCvTermCriteria(Globals.ContTrain, 0.001);

                    //Eigen face recognizer
                    //EigenObjectRecognizer recognizer = new EigenObjectRecognizer(
                    //Globals.trainingImages.ToArray(),
                    //Globals.labels.ToArray(),
                    //3000,
                    //ref termCrit);

                    //name = recognizer.Recognize(result);
                    Classifier_Train Eigen_Recog = new Classifier_Train();
                    Eigen_Recog.Set_Eigen_Threshold = 3000;
                    name = Eigen_Recog.Recognise(result);

                    if (!Globals.recognizedNames.Contains(name) && !name.Equals("Unknown"))
                    {
                        Globals.recognizedNames.Add(name);
                    }

                    //Draw the label for each face detected and recognized
                    //frame.Draw(name, ref font, new Point(f.rect.X - 2, f.rect.Y - 2), new Bgr(Color.LightGreen));
                    frame.Draw(name, ref font, new Point(Globals.facesDetected[i].X - 2, Globals.facesDetected[i].Y - 2), new Bgr(Color.LightGreen));

                }
                //NamePersons[t - 1] = name;
                //nameLabel.Text = "Number: " + facesDetected[0].Length.ToString();

            }
            t = 0;
            //for (int nnn = 0; nnn < Globals.facesDetected[0].Length; nnn++)
            //{
               // names = names + NamePersons[nnn] + ", ";
            //}
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
