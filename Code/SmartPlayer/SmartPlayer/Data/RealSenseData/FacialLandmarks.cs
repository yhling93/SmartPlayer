using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartPlayer.Data.RealSenseData
{
    /// <summary>
    /// 面部标定数据
    /// </summary>
    public class FacialLandmarks
    {
        // RealSense提供
        public Dictionary<PXCMFaceData.LandmarksGroupType, PXCMPoint3DF32[]> landmarksData { set; get; }
        // 发生时间
        public CustomTime happenTS { set; get; }
        public double[] Landmarks = new double[EmotionModel.FaceLandmarkCnt];

        public FacialLandmarks()
        {
            this.landmarksData = new Dictionary<PXCMFaceData.LandmarksGroupType, PXCMPoint3DF32[]>();
        }

        public void updateData(PXCMFaceData.Face face)
        {
            PXCMFaceData.LandmarksData ldata = face.QueryLandmarks();

            // get the landmark data
            var landmarkGroupTypes = Enum.GetValues(typeof(PXCMFaceData.LandmarksGroupType)).Cast<PXCMFaceData.LandmarksGroupType>();
            int featureIdx = 0;
            // 对于每个LandmarkPoint转换成成员变量中的world属性
            foreach (var landmarkGroupType in landmarkGroupTypes)
            {
                PXCMFaceData.LandmarkPoint[] points;

                ldata.QueryPointsByGroup(landmarkGroupType, out points);

                PXCMPoint3DF32[] Point3DArray = new PXCMPoint3DF32[points.Length];
                for (int i = 0; i < points.Length; i++)
                {
                    Point3DArray[i] = points[i].world;
                    // 把脸部特征放入数组中
                    Landmarks[featureIdx++] = points[i].world.x;
                    Landmarks[featureIdx++] = points[i].world.y;
                    Landmarks[featureIdx++] = points[i].world.z;
                }
                
                // 将world坐标加进去
                // landmarksData.Add(landmarkGroupType, Point3DArray);
            }
        }

        public string ToString()
        {
            string res = "";
            var result = string.Join(", ", this.landmarksData.Select(kvp => string.Join("-", kvp.Key, kvp.Value)));
            return result;
        }
    }
}
