using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using SampleDX;

namespace RealSense
{
    public class Stream
    {
        private static PXCMSession session = PXCMSession.CreateInstance();
        private PXCMSenseManager manager;
        private PXCMCapture.Sample sample;

        // 用于display
        private static D2D1Render render=new D2D1Render();
        private event EventHandler<RenderFrameEventArgs> RenderFrame = null;
        
        private bool m_stopped = true;
        private bool m_display = false;
        private bool m_display_once = false;

        public bool Stopped
        {
            get
            {
                return m_stopped;
            }

            set
            {
                m_stopped = value;
            }
        }

        public enum AlgoOption
        {
            Face,
            Hand,
            FaceAndHand
        };

        public enum StreamOption
        {
            None,
            Color,
            Depth,
            ColorAndDepth,
            IR
        };

        public enum RecordOption
        {
            Live,
            Record,
            Playback
        };

        private AlgoOption m_algoOption;
        private StreamOption m_streamOption;
        private RecordOption m_recordOption;
        

        /// <summary>
        /// 构造函数依据美剧Stream.StreamOption来使用
        /// </summary>
        /// <param name="so"></param>
        public Stream(StreamOption so = StreamOption.None, AlgoOption ao=AlgoOption.Face, RecordOption ro= RecordOption.Record)
        {
            m_algoOption = ao;
            m_streamOption = so;
            m_recordOption = ro;
            
            InitPowerState();
        }

        public bool Start()
        {
            if (!this.m_stopped)
            {
                System.Windows.Forms.MessageBox.Show("Already Start");
                return false;
            }
            System.Threading.Thread thread = new System.Threading.Thread(DoStreaming);
            thread.Start();
            System.Threading.Thread.Sleep(5);
            return true;
        }

        public void Stop()
        {
            this.m_stopped = true;

           
        }

        public bool OpenDisplay(System.Windows.Forms.PictureBox pb)
        {
            if (this.m_display)
            {
                System.Windows.Forms.MessageBox.Show("Already Display");
                return false;
            }

            if(!this.m_display_once)
            {
                this.RenderFrame += new EventHandler<RenderFrameEventArgs>(RenderFrameHandler);
                render.SetHWND(pb);
                pb.Paint += new System.Windows.Forms.PaintEventHandler(PaintHandler);
                pb.Resize += new EventHandler(ResizeHandler);
                pb.FindForm().FormClosing += new System.Windows.Forms.FormClosingEventHandler(FormClosingHandler);

                this.m_display_once = true;
            }

            this.m_display = true;
            return true;
        }

        public void CloseDisplay()
        {
            this.m_display = false;
            
        }

        
        

        //*********************************私有函数*******************************************************************

        private void DoStreaming()
        {
            this.m_stopped = false;
            InitStreamState();

            if (manager.Init() < pxcmStatus.PXCM_STATUS_NO_ERROR)
            {
#if DEBUG
                System.Windows.Forms.MessageBox.Show("init failed");
#endif
                return;
            }

            while (!m_stopped)
            {
                if (manager.AcquireFrame(false).IsError()) { break; }

                this.sample = manager.QuerySample();

                // Render streams 
                if (m_display)
                {
                    EventHandler<RenderFrameEventArgs> renderLocal = RenderFrame;
                    PXCMImage image = null;
                    switch (m_streamOption)
                    {
                        case StreamOption.Color:
                            image = sample.color;
                            break;
                        case StreamOption.Depth:
                            image = sample.depth;
                            break;
                        case StreamOption.IR:
                            image = sample.ir;
                            break;
                    }
                    renderLocal(this, new RenderFrameEventArgs(0, image));
                }

                manager.ReleaseFrame();
            }
            manager.Dispose();
        }

        private void InitStreamState()
        {
            manager = session.CreateSenseManager();

            //算法模块
            switch (m_algoOption)
            {
                case AlgoOption.Face:
                    manager.EnableFace();
                    break;
                case AlgoOption.Hand:
                    manager.EnableHand();
                    break;
                case AlgoOption.FaceAndHand:
                    manager.EnableFace();
                    manager.EnableHand();
                    break;
                default:
                    break;
            }

            //视频显示流模块
            switch (m_streamOption)
            {
                case StreamOption.Color:
                    manager.EnableStream(PXCMCapture.StreamType.STREAM_TYPE_COLOR, 640, 360);
                    break;
                case StreamOption.Depth:
                    manager.EnableStream(PXCMCapture.StreamType.STREAM_TYPE_DEPTH, 640, 480);
                    break;
                case StreamOption.IR:
                    manager.EnableStream(PXCMCapture.StreamType.STREAM_TYPE_IR, 640, 480);
                    break;
                default:
                    break;
            }

            //控制录像模块
            var recordPath = System.Configuration.ConfigurationManager.AppSettings["RecordPath"];
            switch (m_recordOption)
            {
                case RecordOption.Live:
                    break;
                case RecordOption.Record:
                    if (recordPath == null)
                    {
#if DEBUG
                        System.Windows.Forms.MessageBox.Show("RecordPath Error");
#endif
                    }
                    manager.captureManager.SetFileName(recordPath, true);
                    break;
                case RecordOption.Playback:
                    manager.captureManager.SetFileName(recordPath, true);
                    break;
            }
        }

        private void InitPowerState()
        {
            PXCMPowerState ps = session.CreatePowerManager();
            ps.SetState(PXCMPowerState.State.STATE_PERFORMANCE);
        }

        /* Redirect to DirectX Update */
        private void PaintHandler(object sender, System.Windows.Forms.PaintEventArgs e)
        {
            render.UpdatePanel();
        }

        /* Redirect to DirectX Resize */
        private void ResizeHandler(object sender, EventArgs e)
        {
            render.ResizePanel();
        }

        private void RenderFrameHandler(Object sender, RenderFrameEventArgs e)
        {
            if (e.image == null) return;
            render.UpdatePanel(e.image);
        }

        private void FormClosingHandler(object sender, System.Windows.Forms.FormClosingEventArgs e)
        {
            this.Stopped = true;
        }
    }
}
