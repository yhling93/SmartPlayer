using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using RealSense;
using System.Windows.Forms;

namespace ProcessHandle
{
    class ProcessHandle
    {
        private RealSense.Stream rs = new Stream(Stream.StreamOption.ColorAndDepth, Stream.AlgoOption.Face, Stream.RecordOption.Playback);

        public ProcessHandle( )
        {
        
        }

        public void Go(string dir,string fname)
        {            
            rs.GenerateFaceData_By_One(dir, fname);
        }

        ~ProcessHandle()
        {
            rs.Stop();
        }
    }
}
