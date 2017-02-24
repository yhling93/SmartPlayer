using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealSense.RealSenseData
{
    /// <summary>
    /// 手部标定数据
    /// </summary>
    public class HandData
    {
        // 手轮廓定位点
        public List<PXCMPointI32[]> handContourOuter { set; get; }
        public List<PXCMPointI32[]> handContourInner { set; get; }
        // 手关节坐标
        public PXCMHandData.JointData[] handJoint { set; get; }
        // 手指弯曲和半径
        public PXCMHandData.FingerData[] handFinger { set; get; }
        // 发生时间
        public CustomTime happenTS { set; get; }

        public void updateData(PXCMHandData.IHand handData)
        {
            this.handJoint = new PXCMHandData.JointData[22];

            

            var jointTypes = Enum.GetValues(typeof(PXCMHandData.JointType)).Cast<PXCMHandData.JointType>();

            int index = 0;
            foreach(var jtmp in jointTypes)
            {
                PXCMHandData.JointData jdata = null;
                handData.QueryTrackedJoint(jtmp, out jdata);
                handJoint[index] = jdata;
                index++;
            }

            index = 0;

            this.handFinger = new PXCMHandData.FingerData[5];
            var fingerTypes = Enum.GetValues(typeof(PXCMHandData.FingerType)).Cast<PXCMHandData.FingerType>();
            foreach(var fmp in fingerTypes)
            {
                PXCMHandData.FingerData fdata = null;
                handData.QueryFingerData(fmp, out fdata);
                handFinger[index] = fdata;
                index++;
            }

            this.handContourInner = new List<PXCMPointI32[]>();
            this.handContourOuter = new List<PXCMPointI32[]>();
            int contourNumber = handData.QueryNumberOfContours();
            if (contourNumber > 0)
            {
                PXCMPointI32[] pointOuter;
                PXCMPointI32[] pointInner;
                for (int k = 0; k < contourNumber; ++k)
                {
                    PXCMHandData.IContour contour;
                    pxcmStatus sts = handData.QueryContour(k, out contour);
                    if (sts == pxcmStatus.PXCM_STATUS_NO_ERROR)
                    {
                        if (contour.IsOuter() == true)
                        {
                            contour.QueryPoints(out pointOuter);
                            handContourOuter.Add(pointOuter);
                        }
                        else
                        {
                            contour.QueryPoints(out pointInner);
                            handContourInner.Add(pointInner);
                        }
                    }
                }

            }

        }
    }
}
