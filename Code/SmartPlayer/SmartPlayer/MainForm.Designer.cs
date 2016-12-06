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
            this.pb_Monitor = new System.Windows.Forms.PictureBox();
            this.statusStripHint = new System.Windows.Forms.StatusStrip();
            this.statusLabelHint = new System.Windows.Forms.ToolStripStatusLabel();
            ((System.ComponentModel.ISupportInitialize)(this.pb_Monitor)).BeginInit();
            this.statusStripHint.SuspendLayout();
            this.SuspendLayout();
            // 
            // pb_Monitor
            // 
            this.pb_Monitor.Location = new System.Drawing.Point(12, 12);
            this.pb_Monitor.Name = "pb_Monitor";
            this.pb_Monitor.Size = new System.Drawing.Size(822, 450);
            this.pb_Monitor.TabIndex = 0;
            this.pb_Monitor.TabStop = false;
            // 
            // statusStripHint
            // 
            this.statusStripHint.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.statusLabelHint});
            this.statusStripHint.Location = new System.Drawing.Point(0, 467);
            this.statusStripHint.Name = "statusStripHint";
            this.statusStripHint.Size = new System.Drawing.Size(846, 22);
            this.statusStripHint.TabIndex = 1;
            this.statusStripHint.Text = "statusStrip1";
            // 
            // statusLabelHint
            // 
            this.statusLabelHint.Name = "statusLabelHint";
            this.statusLabelHint.Size = new System.Drawing.Size(131, 17);
            this.statusLabelHint.Text = "toolStripStatusLabel1";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(846, 489);
            this.Controls.Add(this.statusStripHint);
            this.Controls.Add(this.pb_Monitor);
            this.Name = "MainForm";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.pb_Monitor)).EndInit();
            this.statusStripHint.ResumeLayout(false);
            this.statusStripHint.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pb_Monitor;
        private System.Windows.Forms.StatusStrip statusStripHint;
        private System.Windows.Forms.ToolStripStatusLabel statusLabelHint;
    }
}

