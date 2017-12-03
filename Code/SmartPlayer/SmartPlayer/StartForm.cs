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
        string mStuName, mStdNo;
        Panel mCurPanel;
        public StartForm(string stuName, string stdNo)
        {
            InitializeComponent();
            mStuName = stuName;
            mStdNo = stdNo;

            mCurPanel = courseListPanel;
        }

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

        private void exitBtn_Click(object sender, EventArgs e)
        {
            //mRootForm.Close();
            //this.Close();
            Application.Exit();
        }

        private void StartForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        public StartForm()
        {
            InitializeComponent();
        }

    }
}
