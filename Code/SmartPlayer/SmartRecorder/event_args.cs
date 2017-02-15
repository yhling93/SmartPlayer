using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartRecorder
{
    class RenderFrameEventArgs : EventArgs
    {
        public int index { get; set; }
        public PXCMImage image { get; set; }

        public RenderFrameEventArgs(int index, PXCMImage image)
        {
            this.index = index;
            this.image = image;
        }
    }
}
