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

namespace TestRealSense
{
    public partial class Form1 : Form
    {
        private RealSense.Stream rs;

        public Form1()
        {
            InitializeComponent(); 

            rs = new RealSense.Stream(this, Stream.StreamOption.Color);
        }

        private void buttonStart_Click(object sender, EventArgs e)
        {
            rs.Start();
        }

        private void buttonStop_Click(object sender, EventArgs e)
        {
            rs.Stop();
        }

        private void buttonDisplay_Click(object sender, EventArgs e)
        {
            rs.OpenDisplay(pbMain);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            rs.CloseDisplay();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            RealSense.RealSenseData.FacialLandmarks fe = rs.GetFaceLandmarks();
            MessageBox.Show((fe == null) ? "no landmarks" : fe.ToString());
        }
    }
}
