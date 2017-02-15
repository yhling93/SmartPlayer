using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SampleDX;

namespace SmartRecorder
{
    public partial class MainForm : Form
    {
        private PXCMSession m_session;
        private D2D1Render render = new D2D1Render();
        private RenderStreams streaming = new RenderStreams();

        private volatile bool closing = false;

        public MainForm(PXCMSession session)
        {
            InitializeComponent();

            this.m_session = session;

            streaming.RenderFrame += new EventHandler<RenderFrameEventArgs>(RenderFrameHandler);

            FormClosing += new FormClosingEventHandler(FormClosingHandler);

            picbox_Main.Paint += new PaintEventHandler(PaintHandler);
            picbox_Main.Resize += new EventHandler(ResizeHandler);

            render.SetHWND(picbox_Main);

            button_stop.Enabled = false;
        }

        /* Redirect to DirectX Update */
        private void PaintHandler(object sender, PaintEventArgs e)
        {
            render.UpdatePanel();
        }

        /* Redirect to DirectX Resize */
        private void ResizeHandler(object sender, EventArgs e)
        {
            render.ResizePanel();
        }

        private void RenderFrameHandler(Object sender, RenderFrameEventArgs e)
        {
            if (e.image == null) return;
            render.UpdatePanel(e.image);
        }

        private void button_start_Click(object sender, EventArgs e)
        {
            

            button_start.Enabled = false;
            button_stop.Enabled = true;

            this.Record_ToolStripMenuItem.Enabled = false;
            this.Playback_ToolStripMenuItem.Enabled = false;

            streaming.Stop = false;

            System.Threading.Thread thread = new System.Threading.Thread(DoStreaming);
            thread.Start();
            System.Threading.Thread.Sleep(5);
        }

        delegate void DoStreamingEnd();
        private void DoStreaming()
        {
            streaming.StreamColorDepth();
            Invoke(new DoStreamingEnd(
                delegate
                {
                    button_start.Enabled = true;
                    button_stop.Enabled = false;
                    if (closing) Close();
                }
            ));
        }

        private void FormClosingHandler(object sender, FormClosingEventArgs e)
        {
            streaming.Stop = true;
            e.Cancel = button_stop.Enabled;
            closing = true;
        }

        private void button_stop_Click(object sender, EventArgs e)
        {
            streaming.Stop = true;

            this.Record_ToolStripMenuItem.Enabled = true;
            this.Playback_ToolStripMenuItem.Enabled = true;
        }

        private void Record_ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "RSSDK clip|*.rssdk|All files|*.*";
            sfd.CheckPathExists = true;
            sfd.OverwritePrompt = true;
            sfd.AddExtension = true;

            if (sfd.ShowDialog() == DialogResult.OK)
            {
                streaming.File = sfd.FileName;
                streaming.MarkAsRecord();
                Record_ToolStripMenuItem.Checked = true;
                Playback_ToolStripMenuItem.Checked = false;
            }
            else
            {
                streaming.File = null;
                return;
            }
        }

        private void Playback_ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "RSSDK clip|*.rssdk|Old format clip|*.pcsdk|All files|*.*";
            ofd.CheckFileExists = true;
            ofd.CheckPathExists = true;

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                streaming.File = ofd.FileName;
                streaming.MarkAsPlayback();
                Playback_ToolStripMenuItem.Checked = true;
                Record_ToolStripMenuItem.Checked = false;
            }
            else
            {
                streaming.File = null;
            }
              
           
        }

        
    }
}
