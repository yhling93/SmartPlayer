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
        private RealSense.Stream rs = new RealSense.Stream(Stream.StreamOption.Color);

        public Form1()
        {
            InitializeComponent();
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
    }
}
