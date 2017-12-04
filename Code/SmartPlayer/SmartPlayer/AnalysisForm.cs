using SmartPlayer.Data.CourseData;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SmartPlayer
{
    public partial class AnalysisForm : Form
    {
        MyCourseInfo mInfo;
        string mSid;

        List<string> chapterList = new List<string>();

        int mode = 0; // 0 for pie chart and 1 for line chart, default showing is pie chart


        public AnalysisForm(MyCourseInfo info, string sid)
        {
            InitializeComponent();

            courseNameLabel.Text = courseNameLabel.Text + info.CourseName;
            courseCodeLabel.Text = courseCodeLabel.Text + info.CourseCode;
            courseTimeLabel.Text = courseTimeLabel.Text + info.CourseLessonNum;
            myProgressLabel.Text = myProgressLabel.Text + info.MyCourseLessonProgress;

            mInfo = info;
            mSid = sid;

            iniData();
            iniChapterList();
            iniPie();
            iniTimeline();
        }

        public AnalysisForm()
        {
            InitializeComponent();
        }

        /************** init *************/
        public void iniData()
        {
            chapterList.Add("第一章 软件项目管理概述");
            chapterList.Add("第二章 软件项目确立");
            chapterList.Add("第三章 项目生存期模");
            chapterList.Add("第四章 软件项目需求管理");
            chapterList.Add("第五章 软件项目任务分解");
            chapterList.Add("第六章 软件项目成本计划");
            chapterList.Add("第七章 软件项目进度计划");
            chapterList.Add("第八章 软件项目质量计划");
            chapterList.Add("第九章 软件配置管理计划");
            chapterList.Add("第十章 软件项目质量计划");
        }

        public void iniChapterList()
        {
            chapterListBox.DataSource = chapterList;
        }

        // 1：高兴, 2：困惑, 3：专注, 4：惊讶, 5：思考, 6：正常, 7：未知, 8：笔记, 9：分心
        public void iniTimeline()
        {
            List<int> timelineData = new List<int>();
            int idx = 0;
            for (int i = 0; i < 2; i++)
                timelineData.Add(7);
            idx += 2;
            for (int i = 0; i < 3; i++)
                timelineData.Add(9);
            idx += 3;
            for (int i = 0; i < 30; i++)
                timelineData.Add(6);
            idx += 30;
            for (int i = 0; i < 10; i++)
                timelineData.Add(1);
            idx += 10;
            for (int i = 0; i < 109; i++)
                timelineData.Add(8);
            idx += 109;
            for (int i = 0; i < 83; i++)
                timelineData.Add(2);
            idx += 83;
            for (int i = 0; i < 100; i++)
                timelineData.Add(3);
            idx += 100;
            for (int i = 0; i < 2; i++)
                timelineData.Add(4);
            idx += 2;
            for (int i = 0; i < 37; i++)
                timelineData.Add(5);
            idx += 37;
            for (int i = 0; i < 152; i++)
                timelineData.Add(3);
            idx += 152;
            List<int> idxList = new List<int>();
            for (int i = 0; i < idx; i++)
            {
                idxList.Add(i + 1);
            }
            timelineChart.Series[0].BorderWidth = 3;
            timelineChart.Series[0].Points.DataBindXY(idxList, timelineData);
            noteLabel.Text = "情感与纵轴坐标对应关系\n\n1 ： 高兴\n\n2 ： 困惑\n\n3 ： 专注\n\n4 ： 惊讶\n\n5 ： 思考\n\n6 ： 正常\n\n7 ： 未知\n\n8 ： 笔记\n\n9 ： 分心";
        }

        public void iniPie()
        {
            List<string> xData = new List<string>() { "高兴", "困惑", "专注", "惊讶", "思考", "正常", "未知", "笔记", "分心" };
            List<int> yData = new List<int>() { 10, 83, 252, 2, 37, 30, 2, 109, 3 };
            distributionChart.Series[0]["PieLabelStyle"] = "Outside";
            distributionChart.Series[0]["PieLineColor"] = "Black";
            distributionChart.Series[0].Points.DataBindXY(xData, yData);
        }

        private void analysisSwitchButton_Click(object sender, EventArgs e)
        {
            if (mode == 0)
            {
                titleLabel.Text = "情感随时间变化分析";
                distributionChart.Hide();
                timelineChart.Show();
                noteLabel.Show();
                mode = 1;
            }
            else
            {
                titleLabel.Text = "情感时间分布";
                distributionChart.Show();
                timelineChart.Hide();
                noteLabel.Hide();
                mode = 0;
            }
        }
    }
}
