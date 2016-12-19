using SmartPlayer.RealSense;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SmartPlayer
{
    public partial class MainForm : Form
    {
        // RealSense需要,维护一个session
        public PXCMSession Session;

        // m_bitmap的lock
        private readonly object m_bitmapLock = new object();

        // 视频流显示的每帧缓存
        private Bitmap m_bitmap;

        // 描述主界面是否暂停
        public bool Stopped = false;

        // 视频事件模块
        private VideoModule mVideoModule;

        /// <summary>
        /// 主窗体
        /// </summary>
        public MainForm(PXCMSession session)
        {
            InitializeComponent();
            pb_Monitor.Paint += Pb_Monitor_Paint;
            Session = session;
            this.FormClosing += MainForm_FormClosing;

            //Sleep(200);
            var thread = new Thread(Go);
            thread.IsBackground = true;
            thread.Start();

            mVideoModule = new VideoModule(axWindowsMediaPlayer);
        }

        /// <summary>
        /// 关闭窗口的操作
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Stopped = true;
           
        }

        /// <summary>
        /// 流程的一个壳，用来在Thread中运行并测试
        /// </summary>
        private void Go()
        {
            var trackModule = new TrackModule(this);
            //trackModule.NaivePipeline();
            trackModule.FacePipeLine();
        }

        /// <summary>
        /// 每帧更新视频图像，从缓存的m_bitmap中取得
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Pb_Monitor_Paint(object sender, PaintEventArgs e)
        {
            //Console.WriteLine(" Pb_Monitor_Paint");
            lock (m_bitmapLock)
            {
                //Console.WriteLine(" Pb_Monitor_Paint Enter Lock");
                if (m_bitmap == null) return;

                e.Graphics.DrawImage(m_bitmap, pb_Monitor.ClientRectangle);
                //e.Graphics.DrawImageUnscaled(m_bitmap, 0, 0);
            }
            //Console.WriteLine(" Pb_Monitor_Paint Exit");
        }

        /// <summary>
        /// 将传入的图像写入缓存的m_bitmap中
        /// </summary>
        /// <param name="picture"></param>
        public void DrawBitmap(Bitmap picture)
        {
            lock (m_bitmapLock)
            {
                if (m_bitmap != null)
                {
                    m_bitmap.Dispose();
                }
                m_bitmap = new Bitmap(picture);
            }
        }

        /// <summary>
        /// 更新图像的委托
        /// </summary>
        private delegate void UpdatePicDelegate();

        /// <summary>
        /// 令picturebox重新画一遍
        /// </summary>
        public void UpdatePic()
        {
            //Console.WriteLine("Update Pic");
            pb_Monitor.Invoke(new UpdatePicDelegate(() => pb_Monitor.Invalidate()));
        }


        private delegate void UpdateStatusDelegate(string status);

        /// <summary>
        /// 用于提示信息,窗口下方
        /// </summary>
        /// <param name="status"></param>
        public void UpdateStatus(string status)
        {
            statusStripHint.Invoke(new UpdateStatusDelegate(delegate (string s) { statusLabelHint.Text = s; }),
                    new object[] { status });

        }
    }
}
