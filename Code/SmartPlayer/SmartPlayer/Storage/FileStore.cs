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

        private StreamWriter sw;
        private string dataPath;

        public static FileStore getFileStoreInstance()
        {
            return instance;
        }

        public FileStore()
        {
            string curPath = Environment.CurrentDirectory;
            dataPath = curPath + "\\data\\";
        }

        // 并发可能会出现问题？
        void IStore.saveMomentEvent(MomentEvent e)
        {
            if (sw == null) sw = new StreamWriter(dataPath + e.SessionID, true);
            sw.WriteLine(e.toJsonString());
            sw.Flush();
        }

        // 并发可能会出现问题？
        void IStore.savePeriodEvent(PeriodEvent e)
        {
            throw new NotImplementedException();
        }

        public void close()
        {
            if (sw != null)
            {
                sw.Close();
                sw = null;
            }
        }

        void IStore.saveLearningSession(LearningSession ls)
        {
            throw new NotImplementedException();
        }
    }
}
