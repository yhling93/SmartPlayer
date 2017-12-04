using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TeacherClient
{
    public partial class ManageForm : Form
    {
        string mTeaName, mTeaId;
        List<string> mCourseList = new List<string>() { "SE001 软件项目管理", "SE003 JAVA程序语言设计", "SE015 企业应用开发" };
        List<string> mChapterList = new List<string>();

        Panel mCurPanel;
        public ManageForm()
        {
            InitializeComponent();
        }

        public ManageForm(string tName, string tId)
        {
            InitializeComponent();
            mTeaName = tName;
            mTeaId = tId;

            myCoursePanel.Show();
            assistPanel.Hide();
            analysisPanel.Hide();
            mCurPanel = myCoursePanel;

            iniData();
        }

        /******** init *******/
        public void iniData()
        {
            courseListBox.DataSource = mCourseList;
            mChapterList.Add("第一章 软件项目管理概述");
            mChapterList.Add("第二章 软件项目确立");
            mChapterList.Add("第三章 项目生存期模");
            mChapterList.Add("第四章 软件项目需求管理");
            mChapterList.Add("第五章 软件项目任务分解");
            mChapterList.Add("第六章 软件项目成本计划");
            mChapterList.Add("第七章 软件项目进度计划");
            mChapterList.Add("第八章 软件项目质量计划");
            mChapterList.Add("第九章 软件配置管理计划");
            chapterListBox.DataSource = mChapterList;
            //mChapterList.Add("第十章 软件项目质量计划");

            assistCourseListBox.DataSource = mCourseList;
            assistChapListBox.DataSource = mChapterList;
            bookAssistLabel.Text += "\n1.软件工程.jpg\n2.软件项目管理.jpg";
            courseAssistLabel.Text += "\n1.进阶 高级软件工程";

            assisDataGridView.Rows.Add();
            assisDataGridView.Rows[0].Cells[0].Value = 15;
            assisDataGridView.Rows[0].Cells[1].Value = 75;
            assisDataGridView.Rows[0].Cells[2].Value = "书籍";
            assisDataGridView.Rows[0].Cells[3].Value = "通用";
            assisDataGridView.Rows[0].Cells[4].Value = "软件工程入门.jpg";
            assisDataGridView.Rows[0].Cells[5].Value = "删除";

            assisDataGridView.Rows.Add();
            assisDataGridView.Rows[1].Cells[0].Value = 49;
            assisDataGridView.Rows[1].Cells[1].Value = 106;
            assisDataGridView.Rows[1].Cells[2].Value = "课程";
            assisDataGridView.Rows[1].Cells[3].Value = "困惑";
            assisDataGridView.Rows[1].Cells[4].Value = "进阶 高级软件工程";
            assisDataGridView.Rows[1].Cells[5].Value = "删除";

            analysisCourseList.DataSource = mCourseList;
            analysisChapList.DataSource = mChapterList;

            stateCheckedList.Items.Add("高兴");
            stateCheckedList.Items.Add("困惑");
            stateCheckedList.Items.Add("专注");
            stateCheckedList.Items.Add("惊讶");
            stateCheckedList.Items.Add("思考");
            stateCheckedList.Items.Add("正常");
            stateCheckedList.Items.Add("未知");
            stateCheckedList.Items.Add("笔记");
            stateCheckedList.Items.Add("分析");

            analysisChart.Series.Add("困惑");
            analysisChart.Series[0].Name = "思考";
            analysisChart.Series[1].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;

            int total = 200;
            List<int> confusedData = new List<int>();
            List<int> thinkingData = new List<int>();
            List<int> idxList = new List<int>();
            Random r = new Random();
            int idx = 0;
            for (int i = 0; i < 75; i++) confusedData.Add(r.Next(0, 10));
            idx += 75;
            for (int i = 0; i < 30; i++) confusedData.Add(50 + r.Next(5, 10));
            idx += 30;
            for (int i = 0; i < 95; i++) confusedData.Add(r.Next(10, 15));
            idx += 95;
            idx = 0;
            for (int i = 0; i < 70; i++) thinkingData.Add(r.Next(0, 5));
            idx += 70;
            for (int i = 0; i < 80; i++) thinkingData.Add(30 + r.Next(5, 10));
            idx += 80;
            for (int i = 0; i < 50; i++) thinkingData.Add(r.Next(1, 10));
            idx += 50;
            for (int i = 0; i < idx; i++) idxList.Add(i+1);
            analysisChart.Series[0].Points.DataBindXY(idxList, confusedData);
            analysisChart.Series[1].Points.DataBindXY(idxList, thinkingData);


        }

        private void exitButton_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void helpButton_Click(object sender, EventArgs e)
        {
            if (mCurPanel != assistPanel)
            {
                mCurPanel.Hide();
                assistPanel.Show();
                mCurPanel = assistPanel;
            }
        }


        private void analysisButton_Click(object sender, EventArgs e)
        {
            if (mCurPanel != analysisPanel)
            {
                mCurPanel.Hide();
                analysisPanel.Show();
                mCurPanel = analysisPanel;
            }
        }

        private void myCourseButton_Click(object sender, EventArgs e)
        {
            if (mCurPanel != myCoursePanel)
            {
                mCurPanel.Hide();
                myCoursePanel.Show();
                mCurPanel = myCoursePanel;
            }
        }

        private void ManageForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}
