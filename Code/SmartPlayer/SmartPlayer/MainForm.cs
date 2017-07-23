using SmartPlayer.Data;
using SmartPlayer.RealSense;
using SmartPlayer.Storage;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using SmartPlayer.DB;
using SmartPlayer.Data.EntityData;
namespace SmartPlayer
{
    public partial class MainForm : Form
    {
        // 20170723
        public Form loginForm;
        public Course curCourse;
        public CourseChapter curCourseChapter;
        public List<Video> curVideoList;
        public Dictionary<Emotion.EmotionType, List<VideoAssistance>> curVideoHelpMap;
        public Emotion.EmotionType curEmotion;
        public Thread emotionThread;
        public EmotionModel emotionModel = new EmotionModel();
        public Label curLabel;
        public Dictionary<Emotion.EmotionType, Label> labelMap
            = new Dictionary<Emotion.EmotionType, Label>();
        // 学习过程的Session
        public LearningSession learningSession;

        // RealSense需要,维护一个session
        public PXCMSession Session;

        //record
        private RenderStreams streaming = new RenderStreams();

        // m_bitmap的lock
        private readonly object m_bitmapLock = new object();

        // 视频流显示的每帧缓存
        private Bitmap m_bitmap;

        // 描述主界面是否暂停
        public bool Stopped = false;

        // 视频相关
        private VlcPlayer mVlcPlayer; // 播放器
        private VideoModule mVideoModule; // 处理视频交互事件的模块
        private List<FileInfo> playList; // 播放列表
        private FileInfo curPlayFile; // 当前正在播放的文件

        // 用户相关
        private string username = "testUser";

        // 持久化相关
        private IStore mStoreModule;
        private bool isOnline = false;

        /// <summary>
        /// 主窗体
        /// </summary>
        public MainForm(PXCMSession session, string stuName, string stuNo, Form lForm)
        {
            InitializeComponent();
            CheckForIllegalCrossThreadCalls = false;
            loginForm = lForm;

            stuNameLabel.Text = stuName;
            stuNoLabel.Text = stuNo;
            stuAgeLabel.Text = "25";

            pb_Monitor.Paint += Pb_Monitor_Paint;
            Session = session;
            this.FormClosing += MainForm_FormClosing;

            iniData();
            iniVideoModule();
            // iniPlayList();

            if (!isOnline)
            {
                // 本地存储
                mStoreModule = FileStore.getFileStoreInstance();
            } else
            {
                // kafka+mongodb存储
            }

            // Sleep(200);
            //var thread = new Thread(Go);
            //thread.IsBackground = true;
            //thread.Start();
        }

        /// <summary>
        /// 关闭窗口的操作
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Stopped = true;
            streaming.Stop = true;

            if (mVideoModule.IsPlaying)
            {
                mVideoModule.stopPlay();
            }
            mVideoModule.release();
            closeSession();
            emotionModel.stopDectecting();
            loginForm.Close();

        }

        /// <summary>
        /// 流程的一个壳，用来在Thread中运行并测试
        /// </summary>
        private void Go()
        {
            var trackModule = new TrackModule(this);
            //trackModule.NaivePipeline();
            //trackModule.FacePipeLine();
            trackModule.HandPipeLine();
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

        private void MainForm_Load(object sender, EventArgs e)
        {

        }

        private void pb_Monitor_Click(object sender, EventArgs e)
        {

        }

        /******************** 视频相关 ********************/
        /// <summary>
        /// 初始化视频交互模块
        /// </summary>
        private void iniVideoModule()
        {
            // 初始化VlcPlayer
            string pluginPath = Environment.CurrentDirectory + "\\plugins\\";
            // 将VlcPlayer与panel绑定
            mVlcPlayer = new VlcPlayer(pluginPath);
            IntPtr render_wnd = this.videoPanel.Handle;
            mVlcPlayer.SetRenderWindow((int)render_wnd);
            // 用VlcPlayer构造VideoModule
            mVideoModule = new VideoModule(mVlcPlayer);

            videoVolumeTrackBar.SetRange(0, 100);
            videoVolumeTrackBar.Value = 50;
        }
        private void iniData()
        {
            Repo.init();
            foreach(string coursename in Repo.courses.Keys) {
                courseListBox.Items.Add(coursename);
            }
            emotionModel.initUpdateAssistance(updateUiAccordingToEmotion);
            labelMap.Add(Emotion.EmotionType.Amused, amusedLabel);
            labelMap.Add(Emotion.EmotionType.Concentrated, concentratedLabel);
            labelMap.Add(Emotion.EmotionType.Confused, confusedLabel);
            labelMap.Add(Emotion.EmotionType.Distracted, distractedLabel);
            labelMap.Add(Emotion.EmotionType.Normal, normalLabel);
            labelMap.Add(Emotion.EmotionType.Notetaking, notetakingLabel);
            labelMap.Add(Emotion.EmotionType.Surprised, surprisedLabel);
            labelMap.Add(Emotion.EmotionType.Thinking, thinkingLabel);
            labelMap.Add(Emotion.EmotionType.Unknown, unknownLabel);
        }

        /// <summary>
        /// 初始化播放列表
        /// </summary>
        private void iniPlayList()
        {
            // 读取特定目录下的所有mp4文件
            string path = Environment.CurrentDirectory + "\\lecturevideo\\";
            //DirectoryInfo folder = new DirectoryInfo(path);
            //playList = new List<FileInfo>(folder.GetFiles("*.mp4"));
            //foreach (FileInfo file in playList)
            //    videoListBox.Items.Add(file.Name);

            playList = new List<FileInfo>();
            // read fileinfo in video list
            foreach (Video v in curVideoList)
            {
                videoListBox.Items.Add(v.VideoName);
                FileInfo fileinfo = new FileInfo(path + v.VideoPath);
                playList.Add(fileinfo);
            }

            videoListBox.MouseDoubleClick += new MouseEventHandler(PlayVideo_DoubleClick);
            
            mVideoModule.setPlayList(playList);
        }

        private int curPlayIdx = -1;

        /// <summary>
        /// 处理双击ListBox条目播放事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PlayVideo_DoubleClick(object sender, MouseEventArgs e)
        {
            emotionModel.stopDectecting();

            int idx = videoListBox.IndexFromPoint(e.Location);
            if(idx == ListBox.NoMatches)
            {
                return;
            }
            // 若上次会话尚未结束，首先清空上次会话
            if(learningSession != null)
            {
                closeSession();
                //learningSession.closeSession();
                //mStoreModule.closeSession(learningSession);
                //// For Debug
                //Console.WriteLine(Newtonsoft.Json.JsonConvert.SerializeObject(learningSession));
                //learningSession = null;
            }

            curEmotion = Emotion.EmotionType.Normal;
            normalLabel.ForeColor = Color.Red;
            curLabel = normalLabel;
            videoListBox.SelectedIndex = idx;
            curChapterLabel.Text = curVideoList[idx].VideoName;
            curVideoHelpMap = Repo.assistances[curVideoList[idx]];
            curVideoWatchTimeLabel.Text = "0";
            curFinishLabel.Text = "0";

            //int idx = (sender as ListBox).SelectedIndex;
            curPlayFile = playList[idx];
            resetBtns();

            openSession(curPlayFile.FullName, username);
            //learningSession = LearningSession.createSession(curPlayFile.FullName, username);
            //mVideoModule.setSession(learningSession);
            //mStoreModule.openSession(learningSession);
            //// For Debug
            //Console.WriteLine(Newtonsoft.Json.JsonConvert.SerializeObject(learningSession));

            mVideoModule.playFile(curPlayFile, learningSession);

            normalBtn.Text = "暂停播放";
            videoProgressTrackBar.SetRange(0, mVideoModule.getVideoDuration());
            videoProgressTrackBar.Value = 0;
            videoProgressTimer.Start();

                        emotionThread = new Thread(emotionModel.startDectecting);
            emotionThread.Start();
        }

        private void reverseBtn_Click(object sender, EventArgs e)
        {

        }

        private void normalBtn_Click(object sender, EventArgs e)
        {
            if(mVideoModule.IsPlaying)
            {
                mVideoModule.pause();
                videoProgressTimer.Stop();
                normalBtn.Text = "正常播放";
            } else if(mVideoModule.IsMediaOpen)
            {
                if(learningSession == null)
                {
                    // 如果用户之前停止播放本视频了，随后再次播放本视频，则需要新建一个LearningSession
                    openSession(curPlayFile.FullName, username);
                    //learningSession = LearningSession.createSession(curPlayFile.FullName, username);
                    //mVideoModule.setSession(learningSession);
                    //mStoreModule.openSession(learningSession);
                    //// For Debug
                    //Console.WriteLine(Newtonsoft.Json.JsonConvert.SerializeObject(learningSession));
                }
                
                mVideoModule.play();
                videoProgressTimer.Start();
                normalBtn.Text = "暂停播放";
            }
        }

        private void forwardBtn_MouseDown(object sender, MouseEventArgs e)
        {
            mVideoModule.fastForward(true);
        }

        private void forwardBtn_MouseUp(object sender, MouseEventArgs e)
        {
            mVideoModule.fastForward(false);
        }

        private void reverseBtn_MouseDown(object sender, MouseEventArgs e)
        {
            mVideoModule.fastReverse(true);
        }

        private void reverseBtn_MouseUp(object sender, MouseEventArgs e)
        {
            mVideoModule.fastReverse(false);
        }

        private void slowSpeedBtn_Click(object sender, EventArgs e)
        {
            mVideoModule.slowSpeed();
        }

        private void normalSpeedBtn_Click(object sender, EventArgs e)
        {
            mVideoModule.normalSpeed();
        }

        private void fastSpeedBtn_Click(object sender, EventArgs e)
        {
            mVideoModule.fastSpeed();
        }

        private void stopBtn_Click(object sender, EventArgs e)
        {
            if(mVideoModule.IsMediaOpen)
            {
                // learningSession.closeSession();
                // 点击结束按钮，关闭LearningSession
                mVideoModule.stopPlay();
                closeSession();

                // update ui
                videoProgressTimer.Stop();
                videoProgressTrackBar.Value = 0;
                resetBtns();
                videoProgressLabel.Text = string.Format("{0}/{1}", mVideoModule.getTimeString(0), mVideoModule.getTimeString(videoProgressTrackBar.Maximum));

                // For debug
                // Console.WriteLine(Newtonsoft.Json.JsonConvert.SerializeObject(learningSession));

                // mStoreModule.closeSession(learningSession);

                // learningSession = null;
            }
        }

        private void resetBtns()
        {
            normalBtn.Enabled = true;
            normalBtn.Text = "正常播放";
            stopBtn.Enabled = true;
            forwardBtn.Enabled = true;
            reverseBtn.Enabled = true;
            normalSpeedBtn.Enabled = true;
            fastSpeedBtn.Enabled = true;
            slowSpeedBtn.Enabled = true;
        }


        private void videoProgressTrackBar_Scroll(object sender, EventArgs e)
        {
            if(mVideoModule.IsPlaying)
            {
                (sender as TrackBar).Value = mVideoModule.setPlayTime((sender as TrackBar).Value);
            }
        }

        // 进度条进入拖拽事件
        private void videoProgressTrackBar_MouseDown(object sender, MouseEventArgs e)
        {
            Console.WriteLine("TrackBar mouse down");
            if (mVideoModule.IsPlaying)
            {
                mVideoModule.enterSkip();
                // 真实的进度条有一定的边缘
                int margin = 8;
                int barWidth = videoProgressTrackBar.Size.Width - margin * 2;
                int range = videoProgressTrackBar.Maximum;
                if (e.X >= margin && e.X <= (videoProgressTrackBar.Size.Width - margin)) {
                    double portion = (e.X - margin) * 1.0f / barWidth;
                    int time = (int)(portion * range);
                    (sender as TrackBar).Value = mVideoModule.setPlayTime(time);
                    // for debug
                    //Console.WriteLine("Range:" + range + "\n" +
                    //    "Pportion:" + portion + "\n" +
                    //    "Time:" + time);
                }
            }
        }

        // 进度条退出拖拽事件
        private void videoProgressTrackBar_MouseUp(object sender, MouseEventArgs e)
        {
            Console.WriteLine("TrackBar mouse up");
            if(mVideoModule.IsPlaying)
            {
                mVideoModule.quitSkip();
            }
        }

        private void videoProgressTimer_Tick(object sender, EventArgs e)
        {
            if(mVideoModule.IsPlaying)
            {
                if(videoProgressTrackBar.Value == videoProgressTrackBar.Maximum)
                {
                    // 如果是快进结束的，需要处理
                    mVideoModule.fastForward(false);

                    // 播放自动结束，关闭LearningSession
                    mVideoModule.stopPlay();


                    closeSession();

                    videoProgressTimer.Stop();
                    videoProgressTrackBar.Value = 0;
                    resetBtns();
                } else
                {
                    videoProgressTrackBar.Value = mVideoModule.getPlayTime();
                    videoProgressLabel.Text = string.Format("{0}/{1}", mVideoModule.getTimeString(mVideoModule.getPlayTime()), mVideoModule.getTimeString(videoProgressTrackBar.Maximum));
                }
            }
        }

        private void coverPanel_DoubleClick(object sender, EventArgs e)
        {
            if (!mVideoModule.IsFullScreen)
            {
                mVideoModule.setFullScreen(true);
                this.WindowState = FormWindowState.Maximized;
            } else
            {
                mVideoModule.setFullScreen(false);
                this.WindowState = FormWindowState.Normal;
            }
        }

        private void videoVolumeTrackBar_Scroll(object sender, EventArgs e)
        {
            mVideoModule.setVolume(videoVolumeTrackBar.Value);
        }
        /******************** 视频相关 ********************/

        /**************** Learning Session ****************/
        private void closeSession()
        {
            if (learningSession != null)
            {
                learningSession.closeSession();
                mStoreModule.closeSession(learningSession);
                mVideoModule.setSession(null);
                // For Debug
                Console.WriteLine(Newtonsoft.Json.JsonConvert.SerializeObject(learningSession));
                learningSession = null;
            }

            if(streaming.Stop==false)
            {
                streaming.Stop = true;
            }
            if(streaming.File!=null)
            {
                streaming.File = null;
            }
        }

        private void openSession(string videoID, string username)
        {
            learningSession = LearningSession.createSession(videoID, username);
            mVideoModule.setSession(learningSession);
            mStoreModule.openSession(learningSession);

            string filename = System.Environment.CurrentDirectory + "\\data\\" + learningSession.SessionID + "\\record.rssdk";
            streaming.Stop = false;
            streaming.File = filename;
            streaming.MarkAsRecord();
            System.Threading.Thread thread = new System.Threading.Thread(DoStreaming);
            thread.Start();
            System.Threading.Thread.Sleep(5);
        }

        delegate void DoStreamingEnd();
        private void DoStreaming()
        {
            streaming.StreamColorDepth();
            //Close();
            //Invoke(new DoStreamingEnd(
            //    delegate
            //    {
            //        if (Stopped) Close();
            //    }
            //));
        }

        private void courseListBox_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            int idx = courseListBox.IndexFromPoint(e.Location);
            if (idx == ListBox.NoMatches)
                return;
            string selectedCourse = (string)courseListBox.SelectedItem;
            curCourse = Repo.courses[selectedCourse];
            curCourseChapter = Repo.courseDetails[curCourse];
            curVideoList = curCourseChapter.Videos;
            curCourseLabel.Text = curCourse.CourseName;
            curCourseDescLabel.Text = curCourse.CourseDesc;
            curCourseDiffLabel.Text = curCourse.CourseDifficulty.ToString();
            iniPlayList();
        }

        /**************** Learning Session ****************/

        public void updateUiAccordingToEmotion(Emotion.EmotionType emotion)
        {
            curEmotion = emotion;
            curLabel.ForeColor = Color.Black;
            curLabel = labelMap[curEmotion];
            curLabel.ForeColor = Color.Red;

            List<VideoAssistance> helpList = curVideoHelpMap[emotion];
            foreach (VideoAssistance va in helpList)
            {
                Assistance assistance = va.Assistance;
                switch (assistance.assistanceType)
                {
                    case Assistance.AssistanceType.Book:
                        book1.Load(Environment.CurrentDirectory + "\\bookimages\\" + ((BookAssistance)assistance).PictureUrl);
                        break;
                    case Assistance.AssistanceType.Course:
                        lowLevelCourse1.Text = ((CourseAssistance)assistance).Course.CourseName;
                        highLevelCourse1.Text = ((CourseAssistance)assistance).Course.CourseName;
                        break;
                    case Assistance.AssistanceType.Text:
                        helpTextLabel.Text = ((TextAssistance)assistance).TextInfo;
                        break;
                }
            }
        }
    }
}
