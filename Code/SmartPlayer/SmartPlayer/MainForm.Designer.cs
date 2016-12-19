namespace SmartPlayer
{
    partial class MainForm
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.pb_Monitor = new System.Windows.Forms.PictureBox();
            this.statusStripHint = new System.Windows.Forms.StatusStrip();
            this.statusLabelHint = new System.Windows.Forms.ToolStripStatusLabel();
            this.axWindowsMediaPlayer = new AxWMPLib.AxWindowsMediaPlayer();
            this.fastSpeedBtn = new System.Windows.Forms.Button();
            this.normalSpeedBtn = new System.Windows.Forms.Button();
            this.slowSpeedBtn = new System.Windows.Forms.Button();
            this.forwardBtn = new System.Windows.Forms.Button();
            this.normalBtn = new System.Windows.Forms.Button();
            this.reverseBtn = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pb_Monitor)).BeginInit();
            this.statusStripHint.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.axWindowsMediaPlayer)).BeginInit();
            this.SuspendLayout();
            // 
            // pb_Monitor
            // 
            this.pb_Monitor.Location = new System.Drawing.Point(34, 46);
            this.pb_Monitor.Margin = new System.Windows.Forms.Padding(4);
            this.pb_Monitor.Name = "pb_Monitor";
            this.pb_Monitor.Size = new System.Drawing.Size(259, 230);
            this.pb_Monitor.TabIndex = 0;
            this.pb_Monitor.TabStop = false;
            // 
            // statusStripHint
            // 
            this.statusStripHint.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.statusStripHint.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.statusLabelHint});
            this.statusStripHint.Location = new System.Drawing.Point(0, 732);
            this.statusStripHint.Name = "statusStripHint";
            this.statusStripHint.Padding = new System.Windows.Forms.Padding(1, 0, 19, 0);
            this.statusStripHint.Size = new System.Drawing.Size(1266, 25);
            this.statusStripHint.TabIndex = 1;
            this.statusStripHint.Text = "statusStrip1";
            // 
            // statusLabelHint
            // 
            this.statusLabelHint.Name = "statusLabelHint";
            this.statusLabelHint.Size = new System.Drawing.Size(167, 20);
            this.statusLabelHint.Text = "toolStripStatusLabel1";
            // 
            // axWindowsMediaPlayer
            // 
            this.axWindowsMediaPlayer.Enabled = true;
            this.axWindowsMediaPlayer.Location = new System.Drawing.Point(393, 46);
            this.axWindowsMediaPlayer.Name = "axWindowsMediaPlayer";
            this.axWindowsMediaPlayer.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("axWindowsMediaPlayer.OcxState")));
            this.axWindowsMediaPlayer.Size = new System.Drawing.Size(508, 516);
            this.axWindowsMediaPlayer.TabIndex = 2;
            // 
            // fastSpeedBtn
            // 
            this.fastSpeedBtn.Location = new System.Drawing.Point(248, 463);
            this.fastSpeedBtn.Name = "fastSpeedBtn";
            this.fastSpeedBtn.Size = new System.Drawing.Size(95, 41);
            this.fastSpeedBtn.TabIndex = 3;
            this.fastSpeedBtn.Text = "快速播放";
            this.fastSpeedBtn.UseVisualStyleBackColor = true;
            // 
            // normalSpeedBtn
            // 
            this.normalSpeedBtn.Enabled = false;
            this.normalSpeedBtn.Location = new System.Drawing.Point(141, 463);
            this.normalSpeedBtn.Name = "normalSpeedBtn";
            this.normalSpeedBtn.Size = new System.Drawing.Size(91, 41);
            this.normalSpeedBtn.TabIndex = 4;
            this.normalSpeedBtn.Text = "常速播放";
            this.normalSpeedBtn.UseVisualStyleBackColor = true;
            // 
            // slowSpeedBtn
            // 
            this.slowSpeedBtn.Location = new System.Drawing.Point(34, 463);
            this.slowSpeedBtn.Name = "slowSpeedBtn";
            this.slowSpeedBtn.Size = new System.Drawing.Size(91, 41);
            this.slowSpeedBtn.TabIndex = 5;
            this.slowSpeedBtn.Text = "慢速播放";
            this.slowSpeedBtn.UseVisualStyleBackColor = true;
            // 
            // forwardBtn
            // 
            this.forwardBtn.Location = new System.Drawing.Point(248, 524);
            this.forwardBtn.Name = "forwardBtn";
            this.forwardBtn.Size = new System.Drawing.Size(95, 38);
            this.forwardBtn.TabIndex = 6;
            this.forwardBtn.Text = "快进播放";
            this.forwardBtn.UseVisualStyleBackColor = true;
            // 
            // normalBtn
            // 
            this.normalBtn.Enabled = false;
            this.normalBtn.Location = new System.Drawing.Point(137, 524);
            this.normalBtn.Name = "normalBtn";
            this.normalBtn.Size = new System.Drawing.Size(95, 38);
            this.normalBtn.TabIndex = 7;
            this.normalBtn.Text = "正常播放";
            this.normalBtn.UseVisualStyleBackColor = true;
            // 
            // reverseBtn
            // 
            this.reverseBtn.Location = new System.Drawing.Point(34, 524);
            this.reverseBtn.Name = "reverseBtn";
            this.reverseBtn.Size = new System.Drawing.Size(91, 38);
            this.reverseBtn.TabIndex = 8;
            this.reverseBtn.Text = "倒退播放";
            this.reverseBtn.UseVisualStyleBackColor = true;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1266, 757);
            this.Controls.Add(this.reverseBtn);
            this.Controls.Add(this.normalBtn);
            this.Controls.Add(this.forwardBtn);
            this.Controls.Add(this.slowSpeedBtn);
            this.Controls.Add(this.normalSpeedBtn);
            this.Controls.Add(this.fastSpeedBtn);
            this.Controls.Add(this.axWindowsMediaPlayer);
            this.Controls.Add(this.statusStripHint);
            this.Controls.Add(this.pb_Monitor);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "MainForm";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.pb_Monitor)).EndInit();
            this.statusStripHint.ResumeLayout(false);
            this.statusStripHint.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.axWindowsMediaPlayer)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pb_Monitor;
        private System.Windows.Forms.StatusStrip statusStripHint;
        private System.Windows.Forms.ToolStripStatusLabel statusLabelHint;
        private AxWMPLib.AxWindowsMediaPlayer axWindowsMediaPlayer;
        private System.Windows.Forms.Button fastSpeedBtn;
        private System.Windows.Forms.Button normalSpeedBtn;
        private System.Windows.Forms.Button slowSpeedBtn;
        private System.Windows.Forms.Button forwardBtn;
        private System.Windows.Forms.Button normalBtn;
        private System.Windows.Forms.Button reverseBtn;
    }
}

