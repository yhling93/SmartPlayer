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
    public partial class LogInForm : Form
    {
        StartForm mStartForm;

        public LogInForm()
        {
            InitializeComponent();
        }

        private void loginBtn_Click(object sender, EventArgs e)
        {
            string name = stuNameBox.Text;
            string no = stuNoBox.Text;

            mStartForm = new StartForm(name, no);
            mStartForm.Show();
            this.Hide();

            /*
            PXCMSession session = PXCMSession.CreateInstance();

            MainForm main = new MainForm(session, name, no, this);
            main.Show();
            //this.Close();
            this.Hide();
            */
        }

        private void registerBtn_Click(object sender, EventArgs e)
        {
            // do register logic
        }

        private void LogInForm_Load(object sender, EventArgs e)
        {

        }

        private void loginPanel_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
