using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using RealSense;

namespace RealSensePlayer
{
    public partial class Form1 : Form
    {
        private RealSense.Stream rs;

        public Form1()
        {
            InitializeComponent();

            rs = new RealSense.Stream(this, Stream.StreamOption.ColorAndDepth, Stream.AlgoOption.Face, Stream.RecordOption.Playback, this.lb_ts);
            rs.TimeStampChanged += Rs_TimeStampChanged;
        }

        private void Rs_TimeStampChanged(string newTimeStamp)
        {
            this.lb_ts.Text = newTimeStamp;
        }

        private void button1_Click(object sender, EventArgs e)
        {

            rs.OpenDisplay(pictureBox1);
            var recordPath = System.Configuration.ConfigurationManager.AppSettings["RecordPath"];
            rs.PlayByFrameIndex(recordPath);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            rs.Pause();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            rs.OpenDisplay(pictureBox1);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            rs.ReversePlay();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            rs.updateFrameSpeed(Convert.ToInt32(this.textBox1.Text));
        }
    }
}
