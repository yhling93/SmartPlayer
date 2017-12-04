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
    public partial class StartForm : Form
    {
        // student information
        string mStuName = "", mStdNo = "";
        int mStuAge = 0;
        // course list information
        List<Course> mCouseList = new List<Course>();
        // my course information
        List<MyCourseInfo> mMyCourseInfoList = new List<MyCourseInfo>();

        Panel mCurPanel;

        public StartForm()
        {
            InitializeComponent();

        }

        public StartForm(string stuName, string stdNo)
        {
            InitializeComponent();
            mCurPanel = courseListPanel;

            iniData();
            iniCourseList();
            iniMyCourseInfoList();
        }

        /************** panel switch *************/
        private void courseListBtn_Click(object sender, EventArgs e)
        {
           if(mCurPanel != courseListPanel)
            {
                mCurPanel.Visible = false;
                courseListPanel.Visible = true;
                mCurPanel = courseListPanel;
            }
        }

        private void mycourseBtn_Click(object sender, EventArgs e)
        {
            if (mCurPanel != myCoursePanel)
            {
                mCurPanel.Visible = false;
                myCoursePanel.Visible = true;
                mCurPanel = myCoursePanel;
            }
        }

        private void myinfoBtn_Click(object sender, EventArgs e)
        {
            if (mCurPanel != myInfoPanel)
            {
                mCurPanel.Visible = false;
                myInfoPanel.Visible = true;
                mCurPanel = myInfoPanel;
            }
        }
        /************** panel switch *************/
        
        /************** exit *************/
        private void exitBtn_Click(object sender, EventArgs e)
        {
;
            Application.Exit();
        }

        private void StartForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        /************** exit *************/

        /************** init *************/


        public void iniData() {
            // Course list

            Course c1 = new Course(); c1.CourseCode = "SE001"; c1.CourseName = "软件项目管理"; c1.CourseDifficulty = "初级";
            c1.CourseLessonNum = 48; c1.CourseParticipantNum = 192; c1.CourseTeacher = "韩一";
            c1.CourseTextDescription = "软件工程是一门研究用工程化方法构建和维护有效的、实用的和高质量的软件的学科。它涉及程序设计语言、数据库、软件开发工具、系统平台、标准、设计模式等方面。";
            Course c2 = new Course(); c2.CourseCode = "CS001"; c2.CourseName = "信息论"; c2.CourseDifficulty = "中级";
            c2.CourseLessonNum = 60; c2.CourseParticipantNum = 60; c2.CourseTeacher = "韩二";
            c2.CourseTextDescription = "信息论是运用概率论与数理统计的方法研究信息、信息熵、通信系统、数据传输、密码学、数据压缩等问题的应用数学学科。";
            Course c3 = new Course(); c3.CourseCode = "SE002"; c3.CourseName = "开源大数据"; c3.CourseDifficulty = "高级";
            c3.CourseLessonNum = 32; c3.CourseParticipantNum = 40; c3.CourseTeacher = "韩三"; 
            c3.CourseTextDescription = "大数据技术，是指从各种各样类型的数据中，快速获得有价值信息的能力。";

            mCouseList.Add(c1);
            mCouseList.Add(c2);
            mCouseList.Add(c3);

            // My Course Info List
            MyCourseInfo m1 = new MyCourseInfo(); m1.CourseCode = "SE001"; m1.CourseName = "软件项目管理";
            m1.CourseLessonNum = 48; m1.MyCourseLessonProgress = 5;
            MyCourseInfo m2 = new MyCourseInfo(); m2.CourseCode = "SE002"; m2.CourseName = "开源大数据";
            m2.CourseLessonNum = 32; m2.MyCourseLessonProgress = 30;

            mMyCourseInfoList.Add(m1);
            mMyCourseInfoList.Add(m2);

            // Stu info
            nameBox.Text = "凌云";
            noBox.Text = "stu0001";
            ageBox.Text = "25";
        }

        public void iniCourseList()
        {
            for (int i = 0; i < mCouseList.Count; i++)
            {
                courseDataGrid.Rows.Add();
                courseDataGrid.Rows[i].Cells[0].Value = mCouseList[i].CourseCode;
                courseDataGrid.Rows[i].Cells[1].Value = mCouseList[i].CourseName;
                courseDataGrid.Rows[i].Cells[2].Value = mCouseList[i].CourseTeacher;
                courseDataGrid.Rows[i].Cells[3].Value = mCouseList[i].CourseTextDescription;
                courseDataGrid.Rows[i].Cells[4].Value = mCouseList[i].CourseLessonNum;
                courseDataGrid.Rows[i].Cells[5].Value = mCouseList[i].CourseDifficulty;
                courseDataGrid.Rows[i].Cells[6].Value = mCouseList[i].CourseParticipantNum;
                courseDataGrid.Rows[i].Cells[7].Value = "点击参与";
                courseDataGrid.Rows[i].Cells[8].Value = "点击开始";
            }


        }

        public void iniMyCourseInfoList()
        {
            for (int i = 0; i < mMyCourseInfoList.Count; i++)
            {
                myCourseDataGrid.Rows.Add();
                myCourseDataGrid.Rows[i].Cells[0].Value = mMyCourseInfoList[i].CourseCode;
                myCourseDataGrid.Rows[i].Cells[1].Value = mMyCourseInfoList[i].CourseName;
                myCourseDataGrid.Rows[i].Cells[2].Value = mMyCourseInfoList[i].CourseLessonNum;
                myCourseDataGrid.Rows[i].Cells[3].Value = mMyCourseInfoList[i].MyCourseLessonProgress;
                myCourseDataGrid.Rows[i].Cells[4].Value = "点击开始";
                myCourseDataGrid.Rows[i].Cells[5].Value = "点击查看";
            } 
        }

        private void myCourseDataGrid_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            const int statusIdx = 5, startLessonIdx = 4;
            if (e.ColumnIndex == statusIdx && e.RowIndex < mMyCourseInfoList.Count)
            {
                AnalysisForm af = new AnalysisForm(mMyCourseInfoList[e.RowIndex], mStdNo);
                af.Show();
            }

            if (e.ColumnIndex == startLessonIdx && e.RowIndex < mMyCourseInfoList.Count)
            {
                int i = e.RowIndex;
                //PXCMSession session = PXCMSession.CreateInstance();

                MainForm main = new MainForm(null, mStuName, mStdNo, this,
                    mMyCourseInfoList[i].CourseName, mMyCourseInfoList[i].CourseCode);
                main.Show();
            }
        }
        /************** init *************/

    }
}
