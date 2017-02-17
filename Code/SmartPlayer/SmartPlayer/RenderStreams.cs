using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SmartPlayer
{
    class RenderStreams
    {
        public bool Stop { get; set; }
        public string File { get; set; }
        public bool isRecord { get; set; }
        public bool isPlayback { get; set; }

        public void MarkAsRecord()
        {
            isRecord = true;
            isPlayback = false;
        }

        public void MarkAsPlayback()
        {
            isPlayback = true;
            isRecord = false;
            
        }

        public event EventHandler<RenderFrameEventArgs> RenderFrame = null;

        public RenderStreams()
        {
            File = null;
           
            Stop = false;
        }

        public void StreamColorDepth() /* Stream Color and Depth Synchronously or Asynchronously */
        {
            try
            {
                bool sts = true;

                /* Create an instance of the PXCMSenseManager interface */
                PXCMSenseManager sm = PXCMSenseManager.CreateInstance();

                /* Optional: if playback or recoridng */
                if (File != null)
                    sm.captureManager.SetFileName(File, this.isRecord);

                sm.EnableStream(PXCMCapture.StreamType.STREAM_TYPE_COLOR, 1920, 1080);

                sm.EnableStream(PXCMCapture.StreamType.STREAM_TYPE_DEPTH, 640, 480);
                sm.EnableHand();
                sm.EnableFace();
                

                /* Initialization */

                pxcmStatus status = sm.Init();

                if (status >= pxcmStatus.PXCM_STATUS_NO_ERROR)
                {
                    /* Reset all properties */
                    sm.captureManager.device.ResetProperties(PXCMCapture.StreamType.STREAM_TYPE_ANY);
                    
                    while (!Stop)
                    {
                        /* Wait until a frame is ready: Synchronized or Asynchronous */
                        if (sm.AcquireFrame(true).IsError()) break;

                        /* Display images */
                        //PXCMCapture.Sample sample = sm.QuerySample();

                        /* Render streams */
                        //EventHandler<RenderFrameEventArgs> render = RenderFrame;
                        //PXCMImage image = null;                        

                        //image = sample[PXCMCapture.StreamType.STREAM_TYPE_DEPTH];
                        //render(this, new RenderFrameEventArgs(0, image));
                        
                       
                        sm.ReleaseFrame();
                    }
                }
                else
                {
                    sts = false;
                }

                sm.Dispose();
                //if (sts) MessageBox.Show("Stopped");
            }
            catch (Exception e)
            {
                //MessageBox.Show(e.GetType().ToString());
            }
        }
    }
}
