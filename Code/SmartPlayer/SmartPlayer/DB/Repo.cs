using SmartPlayer.Data;
using SmartPlayer.Data.EntityData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartPlayer.DB
{
    public class Repo
    {
        public static Dictionary<string, Course> courses = new Dictionary<string,Course>();
        public static Dictionary<Course, CourseChapter> courseDetails = new Dictionary<Course,CourseChapter>();
        public static Dictionary<Video, Dictionary<Emotion.EmotionType, List<VideoAssistance>>> assistances
            = new Dictionary<Video, Dictionary<Emotion.EmotionType, List<VideoAssistance>>>(); 

        public static void init()
        {
            Course c1 = new Course();
            c1.CourseID = "0001";
            c1.CourseName = "算法分析与设计1";
            c1.CourseDesc = "斯坦福算法课程，适合有一定编程基础的学生，系统性地介绍常用算法的设计与分析";
            c1.CourseTeacher = "Stanford";
            c1.CourseDifficulty = Course.Difficulty.Easy;

            Course c2 = new Course();
            c2.CourseID = "0002";
            c2.CourseName = "高性能算法设计和实践";
            c2.CourseDesc = "高级算法课程，介绍工业中常用的算法以及应用场景";
            c2.CourseTeacher = "Stanford";
            c2.CourseDifficulty = Course.Difficulty.Medium;

            Course c3 = new Course();
            c3.CourseID = "0003";
            c3.CourseName = "数据结构（Java语言）";
            c3.CourseDesc = "数据结构是计算机存储、组织数据的方式，对于优化程序有极大的帮助";
            c3.CourseTeacher = "MIT";
            c3.CourseDifficulty = Course.Difficulty.Easy;

            courses.Add(c1.CourseName, c1);
            courses.Add(c2.CourseName, c2);
            courses.Add(c3.CourseName, c3);

            CourseChapter cp1 = new CourseChapter();
            courseDetails.Add(c1, cp1);
            cp1.Course = c1;
            cp1.Videos = new List<Video>();

            Video cp1v1 = new Video();
            cp1v1.VideoName = "Union-Find - Dynamic Connectivity";
            cp1v1.VideoLength = 622;
            cp1v1.VideoID = "cp1v1";
            cp1v1.VideoPath = "02-Union-Find-DynamicConnectivity.mp4";
            Video cp1v2 = new Video();
            cp1v2.VideoName = "Union-Find - Quick Union";
            cp1v2.VideoLength = 618;
            cp1v2.VideoID = "cp1v2";
            cp1v2.VideoPath = "03-Union-Find-QuickFind.mp4";

            Video cp1v3 = new Video();
            cp1v3.VideoName = "Union-Find - Quick-Union Improvements";
            cp1v3.VideoLength = 470;
            cp1v3.VideoID = "cp1v3";
            cp1v3.VideoPath = "04-Union-Find-QuickUnion.mp4";

            cp1.Videos.Add(cp1v1);
            cp1.Videos.Add(cp1v2);
            cp1.Videos.Add(cp1v3);

            VideoAssistance va1 = new VideoAssistance();
            va1.Assistance = new TextAssistance();
            ((TextAssistance)va1.Assistance).TextInfo = "TextHelp";
            va1.StartVideoTime = 0;
            va1.EndVideoTime = 500;
            va1.Video = cp1v1;
            va1.EmotionType = Emotion.EmotionType.Normal;
            VideoAssistance va2 = new VideoAssistance();
            va2.Assistance = new BookAssistance();
            ((BookAssistance)va2.Assistance).BookName = "BookHelp";
            va2.StartVideoTime = 0;
            va2.EndVideoTime = 500;
            va2.Video = cp1v1;
            va2.EmotionType = Emotion.EmotionType.Confused;

            VideoAssistance va3 = new VideoAssistance();
            va3.Assistance = new CourseAssistance();
            ((CourseAssistance)va3.Assistance).Course = c2;
            ((CourseAssistance)va3.Assistance).courseLevel = CourseAssistance.CourseLevel.LowLevel;
            va3.StartVideoTime = 0;
            va3.EndVideoTime = 500;
            va3.Video = cp1v1;
            va3.EmotionType = Emotion.EmotionType.Surprised;

            List<VideoAssistance> vaList = new List<VideoAssistance>();
            vaList.Add(va1);
            vaList.Add(va2);
            vaList.Add(va3);

            Dictionary<Emotion.EmotionType, List<VideoAssistance>> emotionHelpMap = new Dictionary<Emotion.EmotionType, List<VideoAssistance>>();
            List<VideoAssistance> helpList1 = new List<VideoAssistance>();
            List<VideoAssistance> helpList2 = new List<VideoAssistance>();
            List<VideoAssistance> helpList3 = new List<VideoAssistance>();
            List<VideoAssistance> helpList4 = new List<VideoAssistance>();
            List<VideoAssistance> helpList5 = new List<VideoAssistance>();
            List<VideoAssistance> helpList6 = new List<VideoAssistance>();
            List<VideoAssistance> helpList7 = new List<VideoAssistance>();
            List<VideoAssistance> helpList8 = new List<VideoAssistance>();
            List<VideoAssistance> helpList9 = new List<VideoAssistance>();
            emotionHelpMap.Add(Emotion.EmotionType.Amused, helpList1);
            emotionHelpMap.Add(Emotion.EmotionType.Concentrated, helpList2);
            emotionHelpMap.Add(Emotion.EmotionType.Confused, helpList3);
            emotionHelpMap.Add(Emotion.EmotionType.Distracted, helpList4);
            emotionHelpMap.Add(Emotion.EmotionType.Normal, helpList5);
            emotionHelpMap.Add(Emotion.EmotionType.Notetaking, helpList6);
            emotionHelpMap.Add(Emotion.EmotionType.Surprised, helpList7);
            emotionHelpMap.Add(Emotion.EmotionType.Thinking, helpList8);
            emotionHelpMap.Add(Emotion.EmotionType.Unknown, helpList9);
            assistances.Add(cp1v1, emotionHelpMap);

            VideoAssistance va11 = new VideoAssistance(cp1v1, new TextAssistance("this is va11"), 0, 500, Emotion.EmotionType.Amused);
            VideoAssistance va12 = new VideoAssistance(cp1v1, new BookAssistance("bnva12", "1.jpg"), 0, 500, Emotion.EmotionType.Amused);
            VideoAssistance va13 = new VideoAssistance(cp1v1, new CourseAssistance(c1, CourseAssistance.CourseLevel.LowLevel), 0, 500, Emotion.EmotionType.Amused);

            VideoAssistance va21 = new VideoAssistance(cp1v1, new TextAssistance("this is va21"), 0, 500, Emotion.EmotionType.Amused);
            VideoAssistance va22 = new VideoAssistance(cp1v1, new BookAssistance("bnva12", "2.jpg"), 0, 500, Emotion.EmotionType.Amused);
            VideoAssistance va23 = new VideoAssistance(cp1v1, new CourseAssistance(c2, CourseAssistance.CourseLevel.LowLevel), 0, 500, Emotion.EmotionType.Amused); 

            VideoAssistance va31 = new VideoAssistance(cp1v1, new TextAssistance("this is va31"), 0, 500, Emotion.EmotionType.Amused);
            VideoAssistance va32 = new VideoAssistance(cp1v1, new CourseAssistance(c3, CourseAssistance.CourseLevel.LowLevel), 0, 500, Emotion.EmotionType.Amused); 
            VideoAssistance va33 = new VideoAssistance(cp1v1, new BookAssistance("bnva12", "3.jpg"), 0, 500, Emotion.EmotionType.Amused);

            VideoAssistance va41 = new VideoAssistance(cp1v1, new TextAssistance("this is va41"), 0, 500, Emotion.EmotionType.Amused); 
            VideoAssistance va42 = new VideoAssistance(cp1v1, new BookAssistance("bnva12", "4.jpg"), 0, 500, Emotion.EmotionType.Amused);
            VideoAssistance va43 = new VideoAssistance(cp1v1, new CourseAssistance(c1, CourseAssistance.CourseLevel.LowLevel), 0, 500, Emotion.EmotionType.Amused); 

            VideoAssistance va51 = new VideoAssistance(cp1v1, new TextAssistance("this is va51"), 0, 500, Emotion.EmotionType.Amused);
            VideoAssistance va52 = new VideoAssistance(cp1v1, new CourseAssistance(c2, CourseAssistance.CourseLevel.LowLevel), 0, 500, Emotion.EmotionType.Amused); 
            VideoAssistance va53 = new VideoAssistance(cp1v1, new BookAssistance("bnva12", "5.jpg"), 0, 500, Emotion.EmotionType.Amused);

            VideoAssistance va61 = new VideoAssistance(cp1v1, new TextAssistance("this is va61"), 0, 500, Emotion.EmotionType.Amused); 
            VideoAssistance va62 = new VideoAssistance(cp1v1, new BookAssistance("bnva12", "6.jpg"), 0, 500, Emotion.EmotionType.Amused);
            VideoAssistance va63 = new VideoAssistance(cp1v1, new CourseAssistance(c3, CourseAssistance.CourseLevel.LowLevel), 0, 500, Emotion.EmotionType.Amused);
 
            VideoAssistance va71 = new VideoAssistance(cp1v1, new TextAssistance("this is va 71"), 0, 500, Emotion.EmotionType.Amused);
            VideoAssistance va72 = new VideoAssistance(cp1v1, new CourseAssistance(c1, CourseAssistance.CourseLevel.LowLevel), 0, 500, Emotion.EmotionType.Amused);
            VideoAssistance va73 = new VideoAssistance(cp1v1, new BookAssistance("bnva12", "7.jpg"), 0, 500, Emotion.EmotionType.Amused);

            VideoAssistance va81 = new VideoAssistance(cp1v1, new TextAssistance("this is va 81"), 0, 500, Emotion.EmotionType.Amused);
            VideoAssistance va82 = new VideoAssistance(cp1v1, new CourseAssistance(c2, CourseAssistance.CourseLevel.LowLevel), 0, 500, Emotion.EmotionType.Amused);
            VideoAssistance va83 = new VideoAssistance(cp1v1, new BookAssistance("bnva12", "8.jpg"), 0, 500, Emotion.EmotionType.Amused);

            VideoAssistance va91 = new VideoAssistance(cp1v1, new TextAssistance("this is va91"), 0, 500, Emotion.EmotionType.Amused);
            VideoAssistance va92 = new VideoAssistance(cp1v1, new CourseAssistance(c3, CourseAssistance.CourseLevel.LowLevel), 0, 500, Emotion.EmotionType.Amused);
            VideoAssistance va93 = new VideoAssistance(cp1v1, new BookAssistance("bnva12", "9.jpg"), 0, 500, Emotion.EmotionType.Amused);

            helpList1.Add(va11);
            helpList1.Add(va12);
            helpList1.Add(va13);

            helpList2.Add(va21);
            helpList2.Add(va22);
            helpList2.Add(va23);

            helpList3.Add(va31);
            helpList3.Add(va32);
            helpList3.Add(va33);

            helpList4.Add(va41);
            helpList4.Add(va42);
            helpList4.Add(va43);

            helpList5.Add(va51);
            helpList5.Add(va52);
            helpList5.Add(va53);

            helpList6.Add(va61);
            helpList6.Add(va62);
            helpList6.Add(va63);

            helpList7.Add(va71);
            helpList7.Add(va72);
            helpList7.Add(va73);

            helpList8.Add(va81);
            helpList8.Add(va82);
            helpList8.Add(va83);

            helpList9.Add(va91);
            helpList9.Add(va92);
            helpList9.Add(va93);


        }
    }
}
