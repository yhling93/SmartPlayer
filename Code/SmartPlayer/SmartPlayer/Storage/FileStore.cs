using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SmartPlayer.Data;
using System.IO;

namespace SmartPlayer.Storage
{
    class FileStore : IStore
    {
        private static FileStore instance = new FileStore();

        private StreamWriter sessionSW;
        private StreamWriter momentSW;
        private StreamWriter periodSW;
        private string dataPath;

        public static FileStore getFileStoreInstance()
        {
            return instance;
        }

        private FileStore()
        {
            string curPath = Environment.CurrentDirectory;
            dataPath = curPath + "\\data\\";
        }

        void IStore.openSession(LearningSession s)
        {
            lock(this)
            {
                if (!Directory.Exists(dataPath + s.SessionID)) Directory.CreateDirectory(dataPath + s.SessionID);
                if (momentSW == null) momentSW = new StreamWriter(dataPath + s.SessionID + "\\moment", true);
                if (periodSW == null) periodSW = new StreamWriter(dataPath + s.SessionID + "\\period", true);
                if (sessionSW == null) sessionSW = new StreamWriter(dataPath + s.SessionID + "\\session", true);

                sessionSW.WriteLine(Newtonsoft.Json.JsonConvert.SerializeObject(s));
                sessionSW.Flush();
            }
        }

        void IStore.closeSession(LearningSession s)
        {
            if (momentSW != null)
            {
                momentSW.Flush();
                momentSW.Close();
                momentSW = null;
            }

            if (periodSW != null)
            {
                periodSW.Flush();
                periodSW.Close();
                periodSW = null;
            }

            if (sessionSW != null)
            {
                sessionSW.WriteLine(Newtonsoft.Json.JsonConvert.SerializeObject(s));
                sessionSW.Flush();
                sessionSW.Close();
                sessionSW = null;
            }
        }
        // 并发可能会出现问题？
        void IStore.saveMomentEvent(MomentEvent e)
        {
            lock(this)
            {
                momentSW.WriteLine(e.toJsonString());
                momentSW.Flush();
            }

        }

        // 并发可能会出现问题？
        void IStore.savePeriodEvent(PeriodEvent e)
        {
            lock (this)
            {
                periodSW.WriteLine(e.toJsonString());
                periodSW.Flush();
            }
        }
    }
}
