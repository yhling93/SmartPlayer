using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using RealSense;

namespace TestRealSense
{
    public partial class Form1 : Form
    {
        private RealSense.Stream rs;

        public Form1()
        {
            InitializeComponent();

             rs = new RealSense.Stream(this, Stream.StreamOption.ColorAndDepth,Stream.AlgoOption.Face,Stream.RecordOption.Playback,this.lb_timestamp);
            rs.TimeStampChanged += Rs_TimeStampChanged;
           // rs = new RealSense.Stream(this, Stream.StreamOption.Color, Stream.AlgoOption.Face, Stream.RecordOption.Live);
        }

        private void Rs_TimeStampChanged(string newTimeStamp)
        {
            this.lb_timestamp.Text = newTimeStamp;
        }

        private void buttonStart_Click(object sender, EventArgs e)
        {
            rs.Start();
        }

        private void buttonStop_Click(object sender, EventArgs e)
        {
            rs.Stop();
        }

        private void buttonDisplay_Click(object sender, EventArgs e)
        {
            rs.OpenDisplay(pbMain);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            rs.CloseDisplay();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            RealSense.RealSenseData.FacialLandmarks fl = rs.GetFaceLandmarks();
            MessageBox.Show((fl == null) ? "no landmarks" : fl.ToString());
        }

        private void button3_Click(object sender, EventArgs e)
        {
            RealSense.RealSenseData.FacialExpression fe = rs.GetExpression();

            MessageBox.Show((fe == null) ? "no expression" : fe.ToString());
        }
        
        
        private void button4_Click(object sender, EventArgs e)
        {
            System.IO.DirectoryInfo folder = new System.IO.DirectoryInfo(@"H:\2017.2.18(1,2,3,5,6,9,11,13,15)");
            // 1,2,3...
            System.IO.DirectoryInfo[] oneDir = folder.GetDirectories();
            // SmartPlayer_Data
            System.IO.DirectoryInfo[] twoDir;
            //SessionID
            System.IO.DirectoryInfo[] threeDir;

            List<string> dirList = new List<string>();
            List<string> fnameList = new List<string>();

            for(int i=0;i<oneDir.Length;i++)
            {
                twoDir = oneDir[i].GetDirectories();

                for (int j = 0; j< twoDir.Length; j++)
                {
                    threeDir = twoDir[j].GetDirectories();
                    for(int k=0;k<threeDir.Length;k++)
                    {
                        dirList.Add(threeDir[k].FullName);
                        System.IO.FileInfo[] finfos= threeDir[k].GetFiles("*.rssdk");
                        foreach (System.IO.FileInfo fi in finfos)
                        {
                            fnameList.Add(fi.FullName);
                        }
                    }
                }
            }

            foreach (string n in dirList)
            {
                Console.WriteLine(n);
            }
            foreach (string n in fnameList)
            {
                Console.WriteLine(n);
            }

            string[] dirs = new string[] { dirList[0] };
            string[] fnames = new string[] { fnameList[0] };
            rs.GenerateFaceData(dirs, fnames);
            // rs.GenerateFaceData(dirList.ToArray(), fnameList.ToArray());

        }

        private void button5_Click(object sender, EventArgs e)
        {
            rs.Pause();
        }
    }
}
