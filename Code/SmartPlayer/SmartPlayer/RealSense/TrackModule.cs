using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Runtime.Remoting.Channels;
using System.Windows.Forms;

namespace SmartPlayer.RealSense
{
    class TrackModule
    {
        /// <summary>
        /// 窗体，用来令此窗口更新
        /// </summary>
        private readonly MainForm m_form;

        /// <summary>
        /// 构造函数，将窗体传进来
        /// </summary>
        /// <param name="form"></param>
        public TrackModule(MainForm form)
        {
            m_form = form;
        }

        /// <summary>
        /// 简易版本的流程，将color图像流置于picturebox中
        /// 后续将修改为带有面部和手部的流
        /// </summary>
        public void NaivePipeline()
        {
            PXCMSenseManager pp = m_form.Session.CreateSenseManager();

            if (pp == null)
            {
                throw new Exception("PXCMSenseManager null");
            }

            pp.EnableStream(PXCMCapture.StreamType.STREAM_TYPE_COLOR, 1920, 1080);

            pp.Init();

            while (!m_form.Stopped)
            {
                if (pp.AcquireFrame(true).IsError()) break;

                var isConnected = pp.IsConnected();
                if (isConnected)
                {
                    var sample = pp.QuerySample();
                    if (sample == null)
                    {
                        pp.ReleaseFrame();
                        continue;
                    }

                    // default is COLOR
                    DisplayPicture(sample.color);
                    m_form.UpdatePic();

                }
                pp.ReleaseFrame();
            }
        }
        
        /// <summary>
        /// 将图像缓存入m_form中的m_bitmap中
        /// </summary>
        /// <param name="image"></param>
        private void DisplayPicture(PXCMImage image)
        {
            PXCMImage.ImageData data;
            if (image.AcquireAccess(PXCMImage.Access.ACCESS_READ, PXCMImage.PixelFormat.PIXEL_FORMAT_RGB32, out data) <
                pxcmStatus.PXCM_STATUS_NO_ERROR) return;
            m_form.DrawBitmap(data.ToBitmap(0, image.info.width, image.info.height));
            image.ReleaseAccess(data);
        }

      
    }
}