using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SmartPlayer.Data.InteractionData;
using SmartPlayer.Data;
using SmartPlayer.DB;
using System.Threading;
using System.IO;

using Newtonsoft.Json;
using SmartPlayer.Storage;

namespace SmartPlayer
{
    class VideoModule
    {
        private VlcPlayer mPlayer;

        private bool isMediaOpen; // 是否已经打开文件
        private bool isPlaying; // 是否正在播放
        private bool isPause; // 是否暂停
        private bool isFullScreen; // 是否全屏播放
        private double playSpeed; // 当前播放速率

        private bool forwardFlag; // 快进标识
        private bool reverseFlag; // 快退标识
        private bool isStopped; // 是否停止

        private List<FileInfo> playList; // 播放列表
        private FileInfo curPlayItem; // 当前播放文件

        private Thread featureExtractThread; // 特征抽取线程

        private LearningSession curSession; // 当前会话

        // 时段事件
        private FastForwardEvent fastForwardEvent;
        private RewindEvent rewindEvent;

        // 所有属性仅可读
        public double PlaySpeed
        {
            get { return this.playSpeed; }
        }
        public bool IsMediaOpen
        {
           get { return this.isMediaOpen; }
        }
        public bool IsPlaying
        {
            get { return this.isPlaying; }
        }
        public bool IsFullScreen
        {
            get { return this.isFullScreen; }
        }

        private IStore storeModule;

        // 构造方法
        public VideoModule(VlcPlayer player)
        {
            this.mPlayer = player;
            isMediaOpen = false;
            isPlaying = false;
            isFullScreen = false;
            playSpeed = 0;

            forwardFlag = false;
            reverseFlag = false;

            storeModule = FileStore.getFileStoreInstance();
        }

        public void setPlayList(List<FileInfo> playList)
        {
            this.playList = playList;
        }

        public void playFile(FileInfo file, LearningSession session)
        {
            curSession = session;

            curPlayItem = file;
            mPlayer.PlayFile(file.FullName);
            isMediaOpen = true;
            isPlaying = true;
            isFullScreen = false;
            isStopped = false;
            playSpeed = 1;

            featureExtractThread = new Thread(featureExtract);
            featureExtractThread.Start();

            // 创建PlayEvent
            PlayEvent e = (PlayEvent) EventFactory.createMomentEvent(curSession.SessionID, (int)mPlayer.GetPlayTime(), MomentEventType.PLAY);
            storeModule.saveMomentEvent(e);
            // For Debug
            Console.WriteLine(JsonConvert.SerializeObject(e));
        }

        public void play()
        {
            // 创建PlayEvent
            PlayEvent e = (PlayEvent)EventFactory.createMomentEvent(curSession.SessionID, (int)mPlayer.GetPlayTime(), MomentEventType.PLAY);
            storeModule.saveMomentEvent(e);
            // For Debug
            Console.WriteLine(JsonConvert.SerializeObject(e));

            mPlayer.Play();
            isPlaying = true;
        }

        public void pause()
        {
            // 创建PauseEvent
            PauseEvent e = (PauseEvent)EventFactory.createMomentEvent(curSession.SessionID, (int)mPlayer.GetPlayTime(), MomentEventType.PAUSE);
            storeModule.saveMomentEvent(e);
            // For Debug
            Console.WriteLine(JsonConvert.SerializeObject(e));

            mPlayer.Pause();
            isPlaying = false;
        }

        public void stopPlay()
        {
            // 创建StopEvent
            StopEvent e = (StopEvent)EventFactory.createMomentEvent(curSession.SessionID, (int)mPlayer.GetPlayTime(), MomentEventType.STOP);
            storeModule.saveMomentEvent(e);
            // For Debug
            Console.WriteLine(JsonConvert.SerializeObject(e));

            mPlayer.Stop();
            isPlaying = false;
        }

        public void fastForward(bool flag)
        {
            if(forwardFlag && !flag)
            {
                forwardFlag = false;
                EventFactory.finishPeriodEvent(fastForwardEvent, (int)mPlayer.GetPlayTime());
                storeModule.savePeriodEvent(fastForwardEvent);
                // for debug
                Console.WriteLine(JsonConvert.SerializeObject(fastForwardEvent));

                fastForwardEvent = null;
            } else if(!forwardFlag && flag)
            {
                // 创建快进事件
                fastForwardEvent = (FastForwardEvent) EventFactory.startPeriodEvent(curSession.SessionID, (int)mPlayer.GetPlayTime(), PeriodEventType.FAST_FORWARD);

                // for debug
                Console.WriteLine(JsonConvert.SerializeObject(fastForwardEvent));

                forwardFlag = true;
                Thread t = new Thread(forward);
                t.Start();
            }
        }

        // 向前快进核心代码
        private void forward()
        {
            while(forwardFlag)
            {
                mPlayer.Pause();
                int time = (int)mPlayer.GetPlayTime() + 5;
                if(time < (int)mPlayer.Duration())
                {
                    mPlayer.SetPlayTime(time);
                } else
                {
                    mPlayer.SetPlayTime((int)mPlayer.Duration());
                }
                mPlayer.Play();
                Thread.Sleep(500);
            }
        }

        public void fastReverse(bool flag)
        {
            if (reverseFlag && !flag)
            {
                reverseFlag = false;
                EventFactory.finishPeriodEvent(rewindEvent, (int)mPlayer.GetPlayTime());
                storeModule.savePeriodEvent(rewindEvent);
                // for debug
                Console.WriteLine(JsonConvert.SerializeObject(rewindEvent));

                rewindEvent = null;
            }
            else if (!reverseFlag && flag)
            {
                // 创建快退事件
                rewindEvent = (RewindEvent)EventFactory.startPeriodEvent(curSession.SessionID, (int)mPlayer.GetPlayTime(), PeriodEventType.REWIND);
                // for debug
                Console.WriteLine(JsonConvert.SerializeObject(rewindEvent));

                reverseFlag = true;
                Thread t = new Thread(reverse);
                t.Start();
            }
        }

        // 向后快退核心代码
        private void reverse()
        {
            while (reverseFlag)
            {
                mPlayer.Pause();
                int time = (int)mPlayer.GetPlayTime() - 5;
                if (time >= 0 )
                {
                    mPlayer.SetPlayTime(time);
                }
                else
                {
                    mPlayer.SetPlayTime(0);
                }
                mPlayer.Play();
                Thread.Sleep(500);
            }
        }

        private int skipStartVideoTS;
        private int skipEndVideoTS;
        // 一开始无法确定是前进还是后退，需要等待鼠标松开后才能确定
        private UndeterminedSkipEvent undeterminedSkipEvent;

        public void enterSkip()
        {
            skipStartVideoTS = getPlayTime();
            undeterminedSkipEvent = (UndeterminedSkipEvent) EventFactory.startPeriodEvent(curSession.SessionID, skipStartVideoTS, PeriodEventType.UNDETERMINED);
        }

        public void quitSkip()
        {
            skipEndVideoTS = getPlayTime();
            if(skipEndVideoTS > skipStartVideoTS)
            {
                ForwardSkipEvent forwardSkipEvent = new ForwardSkipEvent(undeterminedSkipEvent);
                EventFactory.finishPeriodEvent(forwardSkipEvent, skipEndVideoTS);
                storeModule.savePeriodEvent(forwardSkipEvent);
                // for debug
                Console.WriteLine(JsonConvert.SerializeObject(forwardSkipEvent));
            } else if(skipEndVideoTS < skipStartVideoTS)
            {
                ReverseSkipEvent reverseSkipEvent = new ReverseSkipEvent(undeterminedSkipEvent);
                EventFactory.finishPeriodEvent(reverseSkipEvent, skipEndVideoTS);
                storeModule.savePeriodEvent(reverseSkipEvent);
                // for debug
                Console.WriteLine(JsonConvert.SerializeObject(reverseSkipEvent));
            }
            undeterminedSkipEvent = null;
            skipStartVideoTS = 0;
            skipEndVideoTS = 0;
        }

        public int setPlayTime(int time)
        {
            if(time - getPlayTime() >= 0)
            {
                // 设定时间减去当前时间大于0，则触发跳跃前进事件
                ForwardSkipEvent e = (ForwardSkipEvent) EventFactory.startPeriodEvent(curSession.SessionID, getPlayTime(), PeriodEventType.FORWARD_SKIP);
            } else if(time - getPlayTime() < 0)
            {

            }
            mPlayer.SetPlayTime(time);
            return (int)mPlayer.GetPlayTime();
        }

        public int getPlayTime()
        {
            return (int)mPlayer.GetPlayTime();
        }

        public int getVideoDuration()
        {
            return (int)mPlayer.Duration();
        }

        public string getTimeString(int time)
        {
            int hour = time / 3600;
            time %= 3600;
            int minute = time / 60;
            int second = time % 60;
            return string.Format("{0:00}:{1:00}:{2:00}", hour, minute, second);
        }

        public void setFullScreen(bool flag)
        {
            isFullScreen = flag;
            if(curSession != null) {
                if (isFullScreen)
                {
                    // 创建进入全屏事件
                    FullScreenEnterEvent e = (FullScreenEnterEvent) EventFactory.createMomentEvent(curSession.SessionID, getPlayTime(), MomentEventType.FULL_SCREEN_ENTER);
                    // for debug
                    Console.WriteLine(JsonConvert.SerializeObject(e));
                } else
                {
                    // 创建退出全屏事件
                    FullScreenExitEvent e = (FullScreenExitEvent)EventFactory.createMomentEvent(curSession.SessionID, getPlayTime(), MomentEventType.FULL_SCREEN_EXIT);
                    // for debug
                    Console.WriteLine(JsonConvert.SerializeObject(e));
                }
            }
        }

        public void fastSpeed()
        {
            mPlayer.SetRate(1.5f);
            // 创建播放速率变化事件
            PlayRateChangeEvent e = (PlayRateChangeEvent) EventFactory.createMomentEvent(curSession.SessionID, getPlayTime(), MomentEventType.PLAY_RATE_CHANGE);
            e.PlayRate = 1.5f;
            storeModule.saveMomentEvent(e);
            // for debug
            Console.WriteLine(JsonConvert.SerializeObject(e));
        }

        public void slowSpeed()
        {
            mPlayer.SetRate(0.5f);
            // 创建播放速率变化事件
            PlayRateChangeEvent e = (PlayRateChangeEvent)EventFactory.createMomentEvent(curSession.SessionID, getPlayTime(), MomentEventType.PLAY_RATE_CHANGE);
            e.PlayRate = 0.5f;
            storeModule.saveMomentEvent(e);

            // for debug
            Console.WriteLine(JsonConvert.SerializeObject(e));
        }

        public void normalSpeed()
        {
            mPlayer.SetRate(1f);
            // 创建播放速率变化事件
            PlayRateChangeEvent e = (PlayRateChangeEvent)EventFactory.createMomentEvent(curSession.SessionID, getPlayTime(), MomentEventType.PLAY_RATE_CHANGE);
            e.PlayRate = 1f;
            storeModule.saveMomentEvent(e);

            // for debug
            Console.WriteLine(JsonConvert.SerializeObject(e));
        }

        public void setVolume(int volume)
        {
            mPlayer.SetVolume(volume);
        }

        public void setSession(LearningSession session)
        {
            this.curSession = session;
        }

        private void featureExtract()
        {
            while (!isStopped)
            {
                VideoInteractionFeature feature = new VideoInteractionFeature();
                feature.play = this.isPlaying ? 1 : 0;
                feature.pause = this.isPause ? 1 : 0;
                feature.playRate = this.playSpeed;
            }

        }
    }
}
