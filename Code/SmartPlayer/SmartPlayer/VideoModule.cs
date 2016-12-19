using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AxWMPLib;
using SmartPlayer.Data.InteractionData;
using SmartPlayer.Data;
using SmartPlayer.DB;

namespace SmartPlayer
{
    class VideoModule
    {
        private AxWindowsMediaPlayer mPlayer;
        private string mVideoPath;

        // 当前播放速度记录
        private PlaySpeedRecord mCurPlaySpeedRecord;

        public VideoModule(AxWindowsMediaPlayer player)
        {
            // 将视频加入播放列表
            mPlayer = player;
            mVideoPath = Environment.CurrentDirectory + "\\lecturevideo\\lecture.mp4";
            mPlayer.currentPlaylist.appendItem(mPlayer.newMedia(mVideoPath));
           
            // 设置播放状态变化事件监听器
            mPlayer.PlayStateChange += new _WMPOCXEvents_PlayStateChangeEventHandler(playStateChange);

        }

        public void startPlay()
        {
            mPlayer.Ctlcontrols.play();
        }

        public void changePlaySpeed()
        {

        }

        private void playStateChange(object sender, _WMPOCXEvents_PlayStateChangeEvent e)
        {
            Console.Write(0+e.newState);
            switch(e.newState)
            {
                case 0: // undefined
                    break;
                case 1: // Stopped
                    break;
                case 2: // Paused
                    PauseEvent pauseEvent = new PauseEvent();
                    CustomTime happenTS = new CustomTime();
                    happenTS.absTS = DateTime.Now;
                    happenTS.videoTS = (int)mPlayer.Ctlcontrols.currentPosition;
                    pauseEvent.happenTS = happenTS;
                    // DBHelper.getInstance().saveEntity(pauseEvent);
                    break;
                case 3: // Playing
                    break;
                case 4: // ScanForward
                    break;
                case 5: // ScanReverse
                    break;
                default:
                    break;
                    
            }
        }
    }
}
