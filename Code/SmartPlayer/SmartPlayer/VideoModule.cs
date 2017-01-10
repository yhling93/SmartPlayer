using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SmartPlayer.Data.InteractionData;
using SmartPlayer.Data;
using SmartPlayer.DB;
using System.Threading;

namespace SmartPlayer
{
    class VideoModule
    {
        private VlcPlayer mPlayer;

        private bool isMediaOpen; // 是否已经打开文件
        private bool isPlaying; // 是否正在播放
        private bool isFullScreen; // 是否全屏播放
        private double playSpeed; // 当前播放速率

        private bool forwardFlag; // 快进标识
        private bool reverseFlag; // 快退标识

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
        }

        public void playFile(string filepath)
        {
            mPlayer.PlayFile(filepath);
            isMediaOpen = true;
            isPlaying = true;
            isFullScreen = false;
            playSpeed = 1;
        }

        public void play()
        {
            mPlayer.Play();
            isPlaying = true;
        }

        public void pause()
        {
            mPlayer.Pause();
            isPlaying = false;
        }

        public void stopPlay()
        {
            mPlayer.Stop();
            isPlaying = false;
        }

        public void fastForward(bool flag)
        {
            if(forwardFlag && !flag)
            {
                forwardFlag = false;
            } else if(!forwardFlag && flag)
            {
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
            }
            else if (!reverseFlag && flag)
            {
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

        public int setPlayTime(int time)
        {
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
        }

        public void fastSpeed()
        {
            mPlayer.SetRate(1.5f);
        }

        public void slowSpeed()
        {
            mPlayer.SetRate(0.5f);
        }

        public void normalSpeed()
        {
            mPlayer.SetRate(1f);
        }
    }
}
