using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealSense.RealSenseData
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

        public FacialLandmarks()
        {
            this.landmarksData = new Dictionary<PXCMFaceData.LandmarksGroupType, PXCMPoint3DF32[]>();
        }

        public void updateData(PXCMFaceData.Face face)
        {
            PXCMFaceData.LandmarksData ldata = face.QueryLandmarks();

            // get the landmark data
            var landmarkGroupTypes = Enum.GetValues(typeof(PXCMFaceData.LandmarksGroupType)).Cast<PXCMFaceData.LandmarksGroupType>();
            
            // 对于每个LandmarkPoint转换成成员变量中的world属性
            foreach (var landmarkGroupType in landmarkGroupTypes)
            {
                PXCMFaceData.LandmarkPoint[] points;

                ldata.QueryPointsByGroup(landmarkGroupType, out points);

                PXCMPoint3DF32[] Point3DArray = new PXCMPoint3DF32[points.Length];
                for (int i = 0; i < points.Length; i++)
                {
                    Point3DArray[i] = points[i].world;
                }
                
                // 将world坐标加进去
                landmarksData.Add(landmarkGroupType, Point3DArray);
            }
        }

        public string ToString()
        {
            string res = "";
            var result = string.Join(", ", this.landmarksData.Select(kvp => string.Join(")-(", kvp.Key,
                string.Join(",", kvp.Value[0].x, kvp.Value[0].y, kvp.Value[0].z),
                 string.Join(",", kvp.Value[1].x, kvp.Value[1].y, kvp.Value[1].z),
                  string.Join(",", kvp.Value[2].x, kvp.Value[2].y, kvp.Value[2].z)
                )));
            return result;
        }
    }
}
