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
using System.Diagnostics;

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
          
           System.IO.DirectoryInfo folder = new System.IO.DirectoryInfo(@"H:\20170218");
            //System.IO.DirectoryInfo folder = new System.IO.DirectoryInfo(@"H:\2017.3.19");
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
                        System.IO.FileInfo[] finfos= threeDir[k].GetFiles("*.rssdk");
                        foreach (System.IO.FileInfo fi in finfos)
                        {
                            dirList.Add(threeDir[k].FullName);
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

            Console.WriteLine(fnameList.Count);
            // int idex = 1;
            //string[] dirs = new string[] { dirList[idex] };
            //string[] fnames = new string[] { fnameList[idex] };
            string dirname = @"H:\20170218\5\SmartPlayer Data\7bb6057f-4333-47ff-a68f-311666a9c663";
            string[] dirs = new string[] { dirname };
            string[] fnames = new string[] {dirname+"\\record.rssdk" };
            rs.GenerateFaceData(dirs, fnames);

            //dirList.RemoveAt(0);
            //fnameList.RemoveAt(0);
            //dirList.RemoveAt(1);
            //fnameList.RemoveAt(1);

           // rs.GenerateFaceData(dirList.ToArray(), fnameList.ToArray());

        }

        private void button5_Click(object sender, EventArgs e)
        {
            rs.Pause();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            System.IO.DirectoryInfo folder = new System.IO.DirectoryInfo(@"H:\20170218");
            //System.IO.DirectoryInfo folder = new System.IO.DirectoryInfo(@"H:\2017.3.19");
            // 1,2,3...
            System.IO.DirectoryInfo[] oneDir = folder.GetDirectories();
            // SmartPlayer_Data
            System.IO.DirectoryInfo[] twoDir;
            //SessionID
            System.IO.DirectoryInfo[] threeDir;

            List<string> dirList = new List<string>();
            List<string> fnameList = new List<string>();

            for (int i = 0; i < oneDir.Length; i++)
            {
                twoDir = oneDir[i].GetDirectories();

                for (int j = 0; j < twoDir.Length; j++)
                {
                    threeDir = twoDir[j].GetDirectories();
                    for (int k = 0; k < threeDir.Length; k++)
                    {
                        System.IO.FileInfo[] finfos = threeDir[k].GetFiles("*.rssdk");
                        foreach (System.IO.FileInfo fi in finfos)
                        {
                            dirList.Add(threeDir[k].FullName);
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

            Console.WriteLine("fname count : "+fnameList.Count);
            Console.WriteLine();
            Console.WriteLine();

#if false
            string dirname = @"H:\2017.3.19\3\data\1aaa1907-8584-4aad-88bd-2a465d1cadf1";
            string dirname2 = @"H:\20170218\5\SmartPlayer Data\7bb6057f-4333-47ff-a68f-311666a9c663";
            string[] dirs = new string[] { dirname };
            string[] fnames = new string[] { dirname + "\\record.rssdk" };
#else
            string[] dirs = dirList.ToArray();
            string[] fnames = fnameList.ToArray();
#endif

            for (int i = 0; i < fnames.Length; i++)
            {
                Console.WriteLine("start handle " + fnames[i]);
                Console.WriteLine("record No." + i + " start to handle");

                string exepath=@"F:\GitPath\SmartPlayer\Code\SmartPlayer\ProcessHandle\bin\Debug\ProcessHandle.exe";
                //string exepath = "cmd.exe";

                Process myProcess = new Process();
                try
                {
                    myProcess.StartInfo.UseShellExecute = false;
                    myProcess.StartInfo.FileName = exepath;
                    myProcess.StartInfo.Arguments = " "+dirs[i] + " "+fnames[i];
                    myProcess.StartInfo.CreateNoWindow = false;
                    //myProcess.StartInfo.RedirectStandardInput = true;  // 重定向输入流 
                   // myProcess.StartInfo.RedirectStandardOutput = true;  //重定向输出流 
                    //myProcess.StartInfo.RedirectStandardError = true;  //重定向错误流 


                    myProcess.Start();

                    
                    myProcess.WaitForExit();
                }
                catch (Exception eee)
                {
                    Console.WriteLine(eee.Message);
                }


                Console.WriteLine("record No." + i + " is handled");
            }
        }
    }
}
