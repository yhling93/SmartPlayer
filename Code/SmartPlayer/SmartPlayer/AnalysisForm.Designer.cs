namespace SmartPlayer
{
    partial class AnalysisForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea5 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend5 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series5 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea6 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend6 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series6 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.courseGroupBox = new System.Windows.Forms.GroupBox();
            this.myProgressLabel = new System.Windows.Forms.Label();
            this.courseTimeLabel = new System.Windows.Forms.Label();
            this.courseCodeLabel = new System.Windows.Forms.Label();
            this.courseNameLabel = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.startAnalyzeButton = new System.Windows.Forms.Button();
            this.chapterListBox = new System.Windows.Forms.ListBox();
            this.distributionChart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.titleLabel = new System.Windows.Forms.Label();
            this.analysisSwitchButton = new System.Windows.Forms.Button();
            this.timelineChart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.noteLabel = new System.Windows.Forms.Label();
            this.courseGroupBox.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.distributionChart)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.timelineChart)).BeginInit();
            this.SuspendLayout();
            // 
            // courseGroupBox
            // 
            this.courseGroupBox.Controls.Add(this.myProgressLabel);
            this.courseGroupBox.Controls.Add(this.courseTimeLabel);
            this.courseGroupBox.Controls.Add(this.courseCodeLabel);
            this.courseGroupBox.Controls.Add(this.courseNameLabel);
            this.courseGroupBox.Location = new System.Drawing.Point(12, 12);
            this.courseGroupBox.Name = "courseGroupBox";
            this.courseGroupBox.Size = new System.Drawing.Size(242, 153);
            this.courseGroupBox.TabIndex = 0;
            this.courseGroupBox.TabStop = false;
            this.courseGroupBox.Text = "课程信息";
            // 
            // myProgressLabel
            // 
            this.myProgressLabel.AutoSize = true;
            this.myProgressLabel.Location = new System.Drawing.Point(18, 119);
            this.myProgressLabel.Name = "myProgressLabel";
            this.myProgressLabel.Size = new System.Drawing.Size(65, 12);
            this.myProgressLabel.TabIndex = 3;
            this.myProgressLabel.Text = "我的进度：";
            // 
            // courseTimeLabel
            // 
            this.courseTimeLabel.AutoSize = true;
            this.courseTimeLabel.Location = new System.Drawing.Point(18, 91);
            this.courseTimeLabel.Name = "courseTimeLabel";
            this.courseTimeLabel.Size = new System.Drawing.Size(65, 12);
            this.courseTimeLabel.TabIndex = 2;
            this.courseTimeLabel.Text = "全部课时：";
            // 
            // courseCodeLabel
            // 
            this.courseCodeLabel.AutoSize = true;
            this.courseCodeLabel.Location = new System.Drawing.Point(18, 62);
            this.courseCodeLabel.Name = "courseCodeLabel";
            this.courseCodeLabel.Size = new System.Drawing.Size(65, 12);
            this.courseCodeLabel.TabIndex = 1;
            this.courseCodeLabel.Text = "课程代号：";
            // 
            // courseNameLabel
            // 
            this.courseNameLabel.AutoSize = true;
            this.courseNameLabel.Location = new System.Drawing.Point(18, 34);
            this.courseNameLabel.Name = "courseNameLabel";
            this.courseNameLabel.Size = new System.Drawing.Size(65, 12);
            this.courseNameLabel.TabIndex = 0;
            this.courseNameLabel.Text = "课程名称：";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.startAnalyzeButton);
            this.groupBox1.Controls.Add(this.chapterListBox);
            this.groupBox1.Location = new System.Drawing.Point(13, 172);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(241, 375);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "课程列表";
            // 
            // startAnalyzeButton
            // 
            this.startAnalyzeButton.Location = new System.Drawing.Point(7, 305);
            this.startAnalyzeButton.Name = "startAnalyzeButton";
            this.startAnalyzeButton.Size = new System.Drawing.Size(228, 64);
            this.startAnalyzeButton.TabIndex = 1;
            this.startAnalyzeButton.Text = "开始分析";
            this.startAnalyzeButton.UseVisualStyleBackColor = true;
            // 
            // chapterListBox
            // 
            this.chapterListBox.FormattingEnabled = true;
            this.chapterListBox.ItemHeight = 12;
            this.chapterListBox.Location = new System.Drawing.Point(7, 21);
            this.chapterListBox.Name = "chapterListBox";
            this.chapterListBox.Size = new System.Drawing.Size(228, 268);
            this.chapterListBox.TabIndex = 0;
            // 
            // distributionChart
            // 
            chartArea5.Name = "ChartArea1";
            this.distributionChart.ChartAreas.Add(chartArea5);
            legend5.Enabled = false;
            legend5.Name = "Legend1";
            this.distributionChart.Legends.Add(legend5);
            this.distributionChart.Location = new System.Drawing.Point(260, 74);
            this.distributionChart.Name = "distributionChart";
            this.distributionChart.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.Fire;
            series5.ChartArea = "ChartArea1";
            series5.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Pie;
            series5.IsValueShownAsLabel = true;
            series5.Label = "#VALX: #VAL";
            series5.Legend = "Legend1";
            series5.Name = "Series1";
            this.distributionChart.Series.Add(series5);
            this.distributionChart.Size = new System.Drawing.Size(725, 473);
            this.distributionChart.TabIndex = 2;
            this.distributionChart.Text = "chart1";
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
            // 
            // titleLabel
            // 
            this.titleLabel.Font = new System.Drawing.Font("微软雅黑", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.titleLabel.Location = new System.Drawing.Point(443, 26);
            this.titleLabel.Name = "titleLabel";
            this.titleLabel.Size = new System.Drawing.Size(334, 40);
            this.titleLabel.TabIndex = 4;
            this.titleLabel.Text = "情感时间分布";
            this.titleLabel.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // analysisSwitchButton
            // 
            this.analysisSwitchButton.Location = new System.Drawing.Point(831, 41);
            this.analysisSwitchButton.Name = "analysisSwitchButton";
            this.analysisSwitchButton.Size = new System.Drawing.Size(154, 23);
            this.analysisSwitchButton.TabIndex = 5;
            this.analysisSwitchButton.Text = "切换（情感分布/时间轴）";
            this.analysisSwitchButton.UseVisualStyleBackColor = true;
            this.analysisSwitchButton.Click += new System.EventHandler(this.analysisSwitchButton_Click);
            // 
            // timelineChart
            // 
            chartArea6.Name = "ChartArea1";
            this.timelineChart.ChartAreas.Add(chartArea6);
            legend6.Name = "Legend1";
            this.timelineChart.Legends.Add(legend6);
            this.timelineChart.Location = new System.Drawing.Point(260, 74);
            this.timelineChart.Name = "timelineChart";
            this.timelineChart.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.SemiTransparent;
            series6.ChartArea = "ChartArea1";
            series6.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series6.Legend = "Legend1";
            series6.Name = "情感变化";
            this.timelineChart.Series.Add(series6);
            this.timelineChart.Size = new System.Drawing.Size(725, 473);
            this.timelineChart.TabIndex = 6;
            this.timelineChart.Text = "学情查看";
            // 
            // noteLabel
            // 
            this.noteLabel.Location = new System.Drawing.Point(863, 266);
            this.noteLabel.Name = "noteLabel";
            this.noteLabel.Size = new System.Drawing.Size(100, 241);
            this.noteLabel.TabIndex = 7;
            this.noteLabel.Text = ".";
            // 
            // AnalysisForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(997, 559);
            this.Controls.Add(this.analysisSwitchButton);
            this.Controls.Add(this.titleLabel);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.courseGroupBox);
            this.Controls.Add(this.distributionChart);
            this.Controls.Add(this.noteLabel);
            this.Controls.Add(this.timelineChart);
            this.Name = "AnalysisForm";
            this.Text = "学情查看";
            this.courseGroupBox.ResumeLayout(false);
            this.courseGroupBox.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.distributionChart)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.timelineChart)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox courseGroupBox;
        private System.Windows.Forms.Label myProgressLabel;
        private System.Windows.Forms.Label courseTimeLabel;
        private System.Windows.Forms.Label courseCodeLabel;
        private System.Windows.Forms.Label courseNameLabel;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button startAnalyzeButton;
        private System.Windows.Forms.ListBox chapterListBox;
        private System.Windows.Forms.DataVisualization.Charting.Chart distributionChart;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.Label titleLabel;
        private System.Windows.Forms.Button analysisSwitchButton;
        private System.Windows.Forms.DataVisualization.Charting.Chart timelineChart;
        private System.Windows.Forms.Label noteLabel;
    }
}