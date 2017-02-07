using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartPlayer.Data
{
    // Session指用户观看一次视频的过程
    // 在一次Session中，用户观看视频学习，在Session中发生视频交互事件，人脸，手部，等
    // 当用户开始观看一个视频时，一个Session即开始
    // 当用户结束观看一个视频时，一个Session即结束
    // 每个Session需要记录当前的视频id，用户id，开始时间以及结束时间，session本身有sessionId
    public class LearningSession
    {

        public string SessionID
        {
            get { return this.mSessionID; }
        }

        public string VideoID
        {
            get { return this.mVideoID; }
        }

        public string UserID
        {
            get { return this.mUserID; }
        }

        public long StartTime
        {
            get { return this.mStartTime; }
        }

        public long EndTime
        {
            get { return this.mEndTime; }
        }

        private string mSessionID;
        private string mVideoID;
        private string mUserID;
        private long mStartTime;
        private long mEndTime;

        private LearningSession(string vid, string uid)
        {
            this.mSessionID = Guid.NewGuid().ToString();
            this.mVideoID = vid;
            this.mUserID = uid;
            this.mStartTime = CustomTime.ConvertDateTimeToTimeStamp(DateTime.Now);
        }

        public void closeSession()
        {
            this.mEndTime = CustomTime.ConvertDateTimeToTimeStamp(DateTime.Now);
        }

        public static LearningSession createSession(string vid, string uid)
        {
            return new LearningSession(vid, uid);
        }

    }
}
