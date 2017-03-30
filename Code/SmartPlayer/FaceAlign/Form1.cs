using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FaceAlign
{
    public partial class Form1 : Form
    {

        private void DisplayFace(List<Point> face, Color color)
        {
            Graphics g = this.CreateGraphics();
            Pen p = new Pen(color);

            SolidBrush sb = new SolidBrush(Color.Black);


            foreach (Point pi in face)
            {
                g.FillEllipse(sb, pi.X, pi.Y, 10, 10);
            }

        }

        private void DisplayFace(List<Point> face,Color color,Point offsetP)
        {
            Graphics g = this.CreateGraphics();
            Pen p = new Pen(color);

            SolidBrush sb = new SolidBrush(color);

            if (offsetP == null)
            {
                foreach (Point pi in face)
                {
                    g.FillEllipse(sb, pi.X, pi.Y, 10, 10);
                }
            }
            else
            {
                foreach (Point pi in face)
                {
                    g.FillEllipse(sb, pi.X+offsetP.X, pi.Y + offsetP.Y, 10, 10);
                }
            }
        }


        private double K(Point p1,Point p2)
        {
            if (p1.X == p2.X) { return Double.MaxValue; }
            return ((double)(p2.Y-p1.Y))/((double)(p2.X-p1.X));
        }

        /// <summary>
        /// 三个左眉，三个右眉，三个左眼，三个右眼，两个鼻子，三个嘴
        /// </summary>
        /// <param name="face"></param>
        /// <param name="aligned"></param>
        private void AlignFace(List<Point> face,out List<Point> aligned)
        {
            double k1 = K(face.ElementAt(0), face.ElementAt(5));
            double k2 = K(face.ElementAt(1), face.ElementAt(4));
            double k3 = K(face.ElementAt(2), face.ElementAt(3));

            aligned = new List<Point>();
            for(int i=0;i<3+3+3+3;i++)
            {
                aligned.Add(face[i]);
            }

            Point tmp = new Point();
            Point mideye=new Point(face[7].X + face[10].X / 2, face[7].Y + face[10].Y / 2);

            mideye.X = mideye.X - (int)(200 * k1);
            mideye.Y = mideye.Y + (int)(200 * Math.Sqrt(1- k1*k1));
            aligned.Add(new Point(mideye.X,mideye.Y));


            mideye.X = mideye.X - (int)(100 * k1);
            mideye.Y = mideye.Y + (int)(100 * Math.Sqrt(1 - k1 * k1));
            aligned.Add(new Point(mideye.X, mideye.Y));
        }

        private static List<Point> faceTemplate = new List<Point>();
        private static List<List<Point>> facesList = new List<List<Point>>();
        private Point generatePoint(string x,string y)
        {
            return new Point((int)(Convert.ToDouble(x) / 4), (int)(Convert.ToDouble(y) / 4));

        }

        const int FACE_POINTS_NUMBER = 37;

        private void ReadPoints(string fullFile)
        {
            byte[] bytes = null;
            if (File.Exists(fullFile))
            {
                try
                {
                    using (FileStream fs = new FileStream(fullFile, FileMode.Open, FileAccess.Read))
                    {
                        StreamReader sr = new StreamReader(fs);
                        string line = sr.ReadLine();
                        string[] facepointstr = line.Split(' ');

                        for (int i = 1; i < FACE_POINTS_NUMBER; i += 2)
                        {
                            faceTemplate.Add(generatePoint(facepointstr[i], facepointstr[i + 1]));
                        }

                        while (!sr.EndOfStream)
                        {
                            line = sr.ReadLine();
                            facepointstr = line.Split(' ');

                            List<Point> list = new List<Point>();
                            for (int i = 1; i < FACE_POINTS_NUMBER; i += 2)
                            {
                                list.Add(generatePoint(facepointstr[i], facepointstr[i + 1]));
                            }
                            facesList.Add(list);
                        }
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }

        public Form1()
        {
            ReadPoints("Points.txt");
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DisplayFace(faceTemplate, Color.Black);

            for (int i=0;i<facesList.Count;i++)
            {
                DisplayFace(facesList[i], Color.Red, new Point(400 *(i+1),0));
                List<Point> l;
                AlignFace(facesList[i], out l);
                DisplayFace(faceTemplate, Color.Green, new Point(400 * (i + 1), 200 * (i + 1)));
            }
            
        }
    }
}
