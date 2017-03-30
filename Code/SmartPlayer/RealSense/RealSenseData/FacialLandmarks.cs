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
       private static PXCMPoint3DF32[] landmarksData=new PXCMPoint3DF32[78];
        //public Dictionary<PXCMFaceData.LandmarksGroupType, PXCMPoint3DF32[]> landmarksData { set; get; }
        // 发生时间
        public CustomTime happenTS { set; get; }

        private string SEPERATOR = " ";

        public FacialLandmarks()
        {
            //this.landmarksData = new Dictionary<PXCMFaceData.LandmarksGroupType, PXCMPoint3DF32[]>();
        }

        public void updateData(PXCMFaceData.Face face)
        {
            if (face == null) { return; }
            PXCMFaceData.LandmarksData ldata = face.QueryLandmarks();
            if (ldata == null) { return; }

            PXCMRectI32 rect;
            face.QueryDetection().QueryBoundingRect(out rect);

            PXCMFaceData.LandmarkPoint[] points;
            ldata.QueryPoints(out points);
            if(points==null || points.Length == 0) { return; }

            for(int i=0;i<78;i++)
            {
                landmarksData[i].x = points[i].image.x - rect.x;
                landmarksData[i].y = points[i].image.y - rect.y;
                landmarksData[i].z = points[i].world.z;
            }
        }
        

        public override string ToString()
        {
            string res = "";

            foreach(var p in landmarksData)
            {
                res += p.x + SEPERATOR + p.y + SEPERATOR + p.z + SEPERATOR;
            }
            return res;
        }

        public static string generateBlank()
        {
            string res = "";

            for (int i = 0; i < 33 * 3; i++)
            {
                res += "0" + " ";
            }
            return res;

        }
    }


    /// <summary>
    /// 面部标定数据
    /// </summary>
    public class FacialLandmarks2
    {
        // RealSense提供
        public Dictionary<PXCMFaceData.LandmarksGroupType, PXCMPoint3DF32[]> landmarksData { set; get; }
        // 发生时间
        public CustomTime happenTS { set; get; }

        private string SEPERATOR = " ";

        public FacialLandmarks2()
        {
            this.landmarksData = new Dictionary<PXCMFaceData.LandmarksGroupType, PXCMPoint3DF32[]>();
        }

        public void updateData(PXCMFaceData.Face face)
        {
            if (face == null) { return; }
            PXCMFaceData.LandmarksData ldata = face.QueryLandmarks();
            if (ldata == null) { return; }

            PXCMRectI32 rect;
            face.QueryDetection().QueryBoundingRect(out rect);

            // get the landmark data
            var landmarkGroupTypes = Enum.GetValues(typeof(PXCMFaceData.LandmarksGroupType)).Cast<PXCMFaceData.LandmarksGroupType>();

            int count = 0;
            // 对于每个LandmarkPoint转换成成员变量中的world属性
            foreach (var landmarkGroupType in landmarkGroupTypes)
            {
                PXCMFaceData.LandmarkPoint[] points;

                ldata.QueryPointsByGroup(landmarkGroupType, out points);

                PXCMPoint3DF32[] Point3DArray = new PXCMPoint3DF32[points.Length];
                for (int i = 0; i < points.Length; i++)
                {
                    Point3DArray[i] = points[i].world;
                    Console.WriteLine(String.Join(" ", rect.x, rect.y, rect.w, rect.h));
                    Console.WriteLine(points[i].image.x + "\t"+points[i].image.y + "\t"+ points[i].world.z);
                }
                count += points.Length;
                // 将world坐标加进去
                landmarksData.Add(landmarkGroupType, Point3DArray);
            }

            Console.WriteLine(count);
        }

        public override string ToString()
        {
            string res = "";

            PXCMPoint3DF32[] points;
            PXCMPoint3DF32 p;
            List< PXCMFaceData.LandmarksGroupType> keys= this.landmarksData.Keys.ToList();
            foreach(PXCMFaceData.LandmarksGroupType k in keys)
            {
                points = this.landmarksData[k];
                for(int i=0;i<points.Length;i++)
                {
                    p = points[i];
                    res += p.x + SEPERATOR + p.y + SEPERATOR + p.z + SEPERATOR;
                }
                res += SEPERATOR;
            }

            return res;
        }

        public static string generateBlank()
        {
            string res = "";

            for(int i=0;i<33*3;i++)
            {
                res += "0" + " ";
            }

            
            return res;

        }
    }
}
