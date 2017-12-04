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
            this.components = new System.ComponentModel.Container();
            this.fastSpeedBtn = new System.Windows.Forms.Button();
            this.normalSpeedBtn = new System.Windows.Forms.Button();
            this.slowSpeedBtn = new System.Windows.Forms.Button();
            this.forwardBtn = new System.Windows.Forms.Button();
            this.normalBtn = new System.Windows.Forms.Button();
            this.reverseBtn = new System.Windows.Forms.Button();
            this.videoPanel = new System.Windows.Forms.Panel();
            this.coverPanel = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.stopBtn = new System.Windows.Forms.Button();
            this.videoVolumeTrackBar = new System.Windows.Forms.TrackBar();
            this.videoProgressLabel = new System.Windows.Forms.Label();
            this.videoProgressTrackBar = new System.Windows.Forms.TrackBar();
            this.videoListBox = new System.Windows.Forms.ListBox();
            this.videoProgressTimer = new System.Windows.Forms.Timer(this.components);
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.label10 = new System.Windows.Forms.Label();
            this.modelComboBox = new System.Windows.Forms.ComboBox();
            this.wrongBtn = new System.Windows.Forms.Button();
            this.correctBtn = new System.Windows.Forms.Button();
            this.notetakingLabel = new System.Windows.Forms.Label();
            this.unknownLabel = new System.Windows.Forms.Label();
            this.normalLabel = new System.Windows.Forms.Label();
            this.concentratedLabel = new System.Windows.Forms.Label();
            this.distractedLabel = new System.Windows.Forms.Label();
            this.surprisedLabel = new System.Windows.Forms.Label();
            this.confusedLabel = new System.Windows.Forms.Label();
            this.thinkingLabel = new System.Windows.Forms.Label();
            this.amusedLabel = new System.Windows.Forms.Label();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.helpTextLabel = new System.Windows.Forms.Label();
            this.groupBox8 = new System.Windows.Forms.GroupBox();
            this.groupBox10 = new System.Windows.Forms.GroupBox();
            this.highLevelCourse2 = new System.Windows.Forms.Label();
            this.highLevelCourse1 = new System.Windows.Forms.Label();
            this.groupBox9 = new System.Windows.Forms.GroupBox();
            this.lowLevelCourse2 = new System.Windows.Forms.Label();
            this.lowLevelCourse1 = new System.Windows.Forms.Label();
            this.groupBox7 = new System.Windows.Forms.GroupBox();
            this.book3 = new System.Windows.Forms.PictureBox();
            this.book2 = new System.Windows.Forms.PictureBox();
            this.book1 = new System.Windows.Forms.PictureBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.pb_Monitor = new System.Windows.Forms.PictureBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.courseCodeLabel = new System.Windows.Forms.Label();
            this.courseNameLabel = new System.Windows.Forms.Label();
            this.videoPanel.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.videoVolumeTrackBar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.videoProgressTrackBar)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.groupBox6.SuspendLayout();
            this.groupBox8.SuspendLayout();
            this.groupBox10.SuspendLayout();
            this.groupBox9.SuspendLayout();
            this.groupBox7.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.book3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.book2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.book1)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pb_Monitor)).BeginInit();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // fastSpeedBtn
            // 
            this.fastSpeedBtn.AutoSize = true;
            this.fastSpeedBtn.Location = new System.Drawing.Point(378, 32);
            this.fastSpeedBtn.Margin = new System.Windows.Forms.Padding(2);
            this.fastSpeedBtn.Name = "fastSpeedBtn";
            this.fastSpeedBtn.Size = new System.Drawing.Size(63, 44);
            this.fastSpeedBtn.TabIndex = 3;
            this.fastSpeedBtn.Text = "快速播放";
            this.fastSpeedBtn.UseVisualStyleBackColor = true;
            this.fastSpeedBtn.Click += new System.EventHandler(this.fastSpeedBtn_Click);
            // 
            // normalSpeedBtn
            // 
            this.normalSpeedBtn.AutoSize = true;
            this.normalSpeedBtn.Location = new System.Drawing.Point(306, 32);
            this.normalSpeedBtn.Margin = new System.Windows.Forms.Padding(2);
            this.normalSpeedBtn.Name = "normalSpeedBtn";
            this.normalSpeedBtn.Size = new System.Drawing.Size(68, 44);
            this.normalSpeedBtn.TabIndex = 4;
            this.normalSpeedBtn.Text = "常速播放";
            this.normalSpeedBtn.UseVisualStyleBackColor = true;
            this.normalSpeedBtn.Click += new System.EventHandler(this.normalSpeedBtn_Click);
            // 
            // slowSpeedBtn
            // 
            this.slowSpeedBtn.AutoSize = true;
            this.slowSpeedBtn.Location = new System.Drawing.Point(241, 32);
            this.slowSpeedBtn.Margin = new System.Windows.Forms.Padding(2);
            this.slowSpeedBtn.Name = "slowSpeedBtn";
            this.slowSpeedBtn.Size = new System.Drawing.Size(63, 44);
            this.slowSpeedBtn.TabIndex = 5;
            this.slowSpeedBtn.Text = "慢速播放";
            this.slowSpeedBtn.UseVisualStyleBackColor = true;
            this.slowSpeedBtn.Click += new System.EventHandler(this.slowSpeedBtn_Click);
            // 
            // forwardBtn
            // 
            this.forwardBtn.AutoSize = true;
            this.forwardBtn.Location = new System.Drawing.Point(176, 33);
            this.forwardBtn.Margin = new System.Windows.Forms.Padding(2);
            this.forwardBtn.Name = "forwardBtn";
            this.forwardBtn.Size = new System.Drawing.Size(63, 43);
            this.forwardBtn.TabIndex = 6;
            this.forwardBtn.Text = "快进播放";
            this.forwardBtn.UseVisualStyleBackColor = true;
            this.forwardBtn.MouseDown += new System.Windows.Forms.MouseEventHandler(this.forwardBtn_MouseDown);
            this.forwardBtn.MouseUp += new System.Windows.Forms.MouseEventHandler(this.forwardBtn_MouseUp);
            // 
            // normalBtn
            // 
            this.normalBtn.AutoSize = true;
            this.normalBtn.Location = new System.Drawing.Point(2, 33);
            this.normalBtn.Margin = new System.Windows.Forms.Padding(2);
            this.normalBtn.Name = "normalBtn";
            this.normalBtn.Size = new System.Drawing.Size(63, 43);
            this.normalBtn.TabIndex = 7;
            this.normalBtn.Text = "正常播放";
            this.normalBtn.UseVisualStyleBackColor = true;
            this.normalBtn.Click += new System.EventHandler(this.normalBtn_Click);
            // 
            // reverseBtn
            // 
            this.reverseBtn.AutoSize = true;
            this.reverseBtn.Location = new System.Drawing.Point(111, 33);
            this.reverseBtn.Margin = new System.Windows.Forms.Padding(2);
            this.reverseBtn.Name = "reverseBtn";
            this.reverseBtn.Size = new System.Drawing.Size(63, 43);
            this.reverseBtn.TabIndex = 8;
            this.reverseBtn.Text = "倒退播放";
            this.reverseBtn.UseVisualStyleBackColor = true;
            this.reverseBtn.MouseDown += new System.Windows.Forms.MouseEventHandler(this.reverseBtn_MouseDown);
            this.reverseBtn.MouseUp += new System.Windows.Forms.MouseEventHandler(this.reverseBtn_MouseUp);
            // 
            // videoPanel
            // 
            this.videoPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.videoPanel.BackColor = System.Drawing.Color.Black;
            this.videoPanel.Controls.Add(this.coverPanel);
            this.videoPanel.Location = new System.Drawing.Point(235, 12);
            this.videoPanel.Name = "videoPanel";
            this.videoPanel.Size = new System.Drawing.Size(772, 490);
            this.videoPanel.TabIndex = 9;
            // 
            // coverPanel
            // 
            this.coverPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.coverPanel.BackColor = System.Drawing.Color.Transparent;
            this.coverPanel.Location = new System.Drawing.Point(1, 0);
            this.coverPanel.Name = "coverPanel";
            this.coverPanel.Size = new System.Drawing.Size(771, 491);
            this.coverPanel.TabIndex = 0;
            this.coverPanel.DoubleClick += new System.EventHandler(this.coverPanel_DoubleClick);
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2.Controls.Add(this.stopBtn);
            this.panel2.Controls.Add(this.videoVolumeTrackBar);
            this.panel2.Controls.Add(this.videoProgressLabel);
            this.panel2.Controls.Add(this.normalBtn);
            this.panel2.Controls.Add(this.reverseBtn);
            this.panel2.Controls.Add(this.fastSpeedBtn);
            this.panel2.Controls.Add(this.normalSpeedBtn);
            this.panel2.Controls.Add(this.slowSpeedBtn);
            this.panel2.Controls.Add(this.forwardBtn);
            this.panel2.Controls.Add(this.videoProgressTrackBar);
            this.panel2.Location = new System.Drawing.Point(235, 508);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(772, 78);
            this.panel2.TabIndex = 10;
            // 
            // stopBtn
            // 
            this.stopBtn.AutoSize = true;
            this.stopBtn.Location = new System.Drawing.Point(68, 33);
            this.stopBtn.Margin = new System.Windows.Forms.Padding(2);
            this.stopBtn.Name = "stopBtn";
            this.stopBtn.Size = new System.Drawing.Size(40, 43);
            this.stopBtn.TabIndex = 14;
            this.stopBtn.Text = "停止";
            this.stopBtn.UseVisualStyleBackColor = true;
            this.stopBtn.Click += new System.EventHandler(this.stopBtn_Click);
            // 
            // videoVolumeTrackBar
            // 
            this.videoVolumeTrackBar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.videoVolumeTrackBar.Location = new System.Drawing.Point(444, 32);
            this.videoVolumeTrackBar.Name = "videoVolumeTrackBar";
            this.videoVolumeTrackBar.Size = new System.Drawing.Size(185, 45);
            this.videoVolumeTrackBar.TabIndex = 10;
            this.videoVolumeTrackBar.Scroll += new System.EventHandler(this.videoVolumeTrackBar_Scroll);
            // 
            // videoProgressLabel
            // 
            this.videoProgressLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.videoProgressLabel.AutoSize = true;
            this.videoProgressLabel.Location = new System.Drawing.Point(635, 48);
            this.videoProgressLabel.Name = "videoProgressLabel";
            this.videoProgressLabel.Size = new System.Drawing.Size(107, 12);
            this.videoProgressLabel.TabIndex = 9;
            this.videoProgressLabel.Text = "00:00:00/00:00:00";
            // 
            // videoProgressTrackBar
            // 
            this.videoProgressTrackBar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.videoProgressTrackBar.LargeChange = 1;
            this.videoProgressTrackBar.Location = new System.Drawing.Point(0, 0);
            this.videoProgressTrackBar.Margin = new System.Windows.Forms.Padding(0);
            this.videoProgressTrackBar.Name = "videoProgressTrackBar";
            this.videoProgressTrackBar.Size = new System.Drawing.Size(772, 45);
            this.videoProgressTrackBar.TabIndex = 0;
            this.videoProgressTrackBar.Scroll += new System.EventHandler(this.videoProgressTrackBar_Scroll);
            this.videoProgressTrackBar.MouseDown += new System.Windows.Forms.MouseEventHandler(this.videoProgressTrackBar_MouseDown);
            this.videoProgressTrackBar.MouseUp += new System.Windows.Forms.MouseEventHandler(this.videoProgressTrackBar_MouseUp);
            // 
            // videoListBox
            // 
            this.videoListBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.videoListBox.FormattingEnabled = true;
            this.videoListBox.ItemHeight = 12;
            this.videoListBox.Location = new System.Drawing.Point(6, 20);
            this.videoListBox.Name = "videoListBox";
            this.videoListBox.Size = new System.Drawing.Size(211, 304);
            this.videoListBox.TabIndex = 11;
            // 
            // videoProgressTimer
            // 
            this.videoProgressTimer.Interval = 500;
            this.videoProgressTimer.Tick += new System.EventHandler(this.videoProgressTimer_Tick);
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.groupBox1.Controls.Add(this.videoListBox);
            this.groupBox1.Location = new System.Drawing.Point(6, 121);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(223, 329);
            this.groupBox1.TabIndex = 14;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "播放列表";
            // 
            // groupBox5
            // 
            this.groupBox5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox5.Controls.Add(this.label10);
            this.groupBox5.Controls.Add(this.modelComboBox);
            this.groupBox5.Controls.Add(this.wrongBtn);
            this.groupBox5.Controls.Add(this.correctBtn);
            this.groupBox5.Controls.Add(this.notetakingLabel);
            this.groupBox5.Controls.Add(this.unknownLabel);
            this.groupBox5.Controls.Add(this.normalLabel);
            this.groupBox5.Controls.Add(this.concentratedLabel);
            this.groupBox5.Controls.Add(this.distractedLabel);
            this.groupBox5.Controls.Add(this.surprisedLabel);
            this.groupBox5.Controls.Add(this.confusedLabel);
            this.groupBox5.Controls.Add(this.thinkingLabel);
            this.groupBox5.Controls.Add(this.amusedLabel);
            this.groupBox5.Location = new System.Drawing.Point(1014, 13);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(277, 185);
            this.groupBox5.TabIndex = 18;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "当前状态";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(19, 158);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(65, 12);
            this.label10.TabIndex = 12;
            this.label10.Text = "模型选择：";
            // 
            // modelComboBox
            // 
            this.modelComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.modelComboBox.FormattingEnabled = true;
            this.modelComboBox.Location = new System.Drawing.Point(97, 155);
            this.modelComboBox.Name = "modelComboBox";
            this.modelComboBox.Size = new System.Drawing.Size(172, 20);
            this.modelComboBox.TabIndex = 11;
            this.modelComboBox.SelectedIndexChanged += new System.EventHandler(this.modelComboBox_SelectedIndexChanged);
            // 
            // wrongBtn
            // 
            this.wrongBtn.Location = new System.Drawing.Point(144, 119);
            this.wrongBtn.Name = "wrongBtn";
            this.wrongBtn.Size = new System.Drawing.Size(125, 22);
            this.wrongBtn.TabIndex = 10;
            this.wrongBtn.Text = "判断错误";
            this.wrongBtn.UseVisualStyleBackColor = true;
            // 
            // correctBtn
            // 
            this.correctBtn.Location = new System.Drawing.Point(5, 119);
            this.correctBtn.Name = "correctBtn";
            this.correctBtn.Size = new System.Drawing.Size(130, 23);
            this.correctBtn.TabIndex = 9;
            this.correctBtn.Text = "判断正确";
            this.correctBtn.UseVisualStyleBackColor = true;
            // 
            // notetakingLabel
            // 
            this.notetakingLabel.AutoSize = true;
            this.notetakingLabel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.notetakingLabel.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.notetakingLabel.ForeColor = System.Drawing.Color.Black;
            this.notetakingLabel.Location = new System.Drawing.Point(206, 88);
            this.notetakingLabel.Name = "notetakingLabel";
            this.notetakingLabel.Size = new System.Drawing.Size(31, 14);
            this.notetakingLabel.TabIndex = 8;
            this.notetakingLabel.Text = "笔记";
            // 
            // unknownLabel
            // 
            this.unknownLabel.AutoSize = true;
            this.unknownLabel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.unknownLabel.ForeColor = System.Drawing.Color.Black;
            this.unknownLabel.Location = new System.Drawing.Point(110, 88);
            this.unknownLabel.Name = "unknownLabel";
            this.unknownLabel.Size = new System.Drawing.Size(31, 14);
            this.unknownLabel.TabIndex = 7;
            this.unknownLabel.Text = "未知";
            // 
            // normalLabel
            // 
            this.normalLabel.AutoSize = true;
            this.normalLabel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.normalLabel.Location = new System.Drawing.Point(7, 88);
            this.normalLabel.Name = "normalLabel";
            this.normalLabel.Size = new System.Drawing.Size(31, 14);
            this.normalLabel.TabIndex = 6;
            this.normalLabel.Text = "正常";
            // 
            // concentratedLabel
            // 
            this.concentratedLabel.AutoSize = true;
            this.concentratedLabel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.concentratedLabel.Location = new System.Drawing.Point(206, 54);
            this.concentratedLabel.Name = "concentratedLabel";
            this.concentratedLabel.Size = new System.Drawing.Size(31, 14);
            this.concentratedLabel.TabIndex = 5;
            this.concentratedLabel.Text = "专注";
            // 
            // distractedLabel
            // 
            this.distractedLabel.AutoSize = true;
            this.distractedLabel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.distractedLabel.Location = new System.Drawing.Point(110, 54);
            this.distractedLabel.Name = "distractedLabel";
            this.distractedLabel.Size = new System.Drawing.Size(31, 14);
            this.distractedLabel.TabIndex = 4;
            this.distractedLabel.Text = "分心";
            // 
            // surprisedLabel
            // 
            this.surprisedLabel.AutoSize = true;
            this.surprisedLabel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.surprisedLabel.Location = new System.Drawing.Point(7, 54);
            this.surprisedLabel.Name = "surprisedLabel";
            this.surprisedLabel.Size = new System.Drawing.Size(31, 14);
            this.surprisedLabel.TabIndex = 3;
            this.surprisedLabel.Text = "惊讶";
            // 
            // confusedLabel
            // 
            this.confusedLabel.AutoSize = true;
            this.confusedLabel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.confusedLabel.Location = new System.Drawing.Point(206, 20);
            this.confusedLabel.Name = "confusedLabel";
            this.confusedLabel.Size = new System.Drawing.Size(31, 14);
            this.confusedLabel.TabIndex = 2;
            this.confusedLabel.Text = "困惑";
            // 
            // thinkingLabel
            // 
            this.thinkingLabel.AutoSize = true;
            this.thinkingLabel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.thinkingLabel.Location = new System.Drawing.Point(110, 20);
            this.thinkingLabel.Name = "thinkingLabel";
            this.thinkingLabel.Size = new System.Drawing.Size(31, 14);
            this.thinkingLabel.TabIndex = 1;
            this.thinkingLabel.Text = "思考";
            // 
            // amusedLabel
            // 
            this.amusedLabel.AutoSize = true;
            this.amusedLabel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.amusedLabel.Location = new System.Drawing.Point(7, 20);
            this.amusedLabel.Name = "amusedLabel";
            this.amusedLabel.Size = new System.Drawing.Size(31, 14);
            this.amusedLabel.TabIndex = 0;
            this.amusedLabel.Text = "愉悦";
            // 
            // groupBox6
            // 
            this.groupBox6.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox6.Controls.Add(this.helpTextLabel);
            this.groupBox6.Location = new System.Drawing.Point(1014, 204);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(277, 120);
            this.groupBox6.TabIndex = 19;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "相关资料";
            // 
            // helpTextLabel
            // 
            this.helpTextLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.helpTextLabel.Location = new System.Drawing.Point(3, 17);
            this.helpTextLabel.Name = "helpTextLabel";
            this.helpTextLabel.Size = new System.Drawing.Size(271, 100);
            this.helpTextLabel.TabIndex = 0;
            this.helpTextLabel.Text = " ";
            // 
            // groupBox8
            // 
            this.groupBox8.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox8.Controls.Add(this.groupBox10);
            this.groupBox8.Controls.Add(this.groupBox9);
            this.groupBox8.Location = new System.Drawing.Point(1014, 485);
            this.groupBox8.Name = "groupBox8";
            this.groupBox8.Size = new System.Drawing.Size(277, 102);
            this.groupBox8.TabIndex = 21;
            this.groupBox8.TabStop = false;
            this.groupBox8.Text = "推荐课程";
            // 
            // groupBox10
            // 
            this.groupBox10.Controls.Add(this.highLevelCourse2);
            this.groupBox10.Controls.Add(this.highLevelCourse1);
            this.groupBox10.Location = new System.Drawing.Point(144, 20);
            this.groupBox10.Name = "groupBox10";
            this.groupBox10.Size = new System.Drawing.Size(127, 71);
            this.groupBox10.TabIndex = 1;
            this.groupBox10.TabStop = false;
            this.groupBox10.Text = "进阶课程";
            // 
            // highLevelCourse2
            // 
            this.highLevelCourse2.AutoSize = true;
            this.highLevelCourse2.Location = new System.Drawing.Point(9, 65);
            this.highLevelCourse2.Name = "highLevelCourse2";
            this.highLevelCourse2.Size = new System.Drawing.Size(11, 12);
            this.highLevelCourse2.TabIndex = 3;
            this.highLevelCourse2.Text = " ";
            // 
            // highLevelCourse1
            // 
            this.highLevelCourse1.AutoSize = true;
            this.highLevelCourse1.Location = new System.Drawing.Point(9, 38);
            this.highLevelCourse1.Name = "highLevelCourse1";
            this.highLevelCourse1.Size = new System.Drawing.Size(11, 12);
            this.highLevelCourse1.TabIndex = 2;
            this.highLevelCourse1.Text = " ";
            // 
            // groupBox9
            // 
            this.groupBox9.Controls.Add(this.lowLevelCourse2);
            this.groupBox9.Controls.Add(this.lowLevelCourse1);
            this.groupBox9.Location = new System.Drawing.Point(7, 20);
            this.groupBox9.Name = "groupBox9";
            this.groupBox9.Size = new System.Drawing.Size(127, 73);
            this.groupBox9.TabIndex = 0;
            this.groupBox9.TabStop = false;
            this.groupBox9.Text = "基础课程";
            // 
            // lowLevelCourse2
            // 
            this.lowLevelCourse2.AutoSize = true;
            this.lowLevelCourse2.Location = new System.Drawing.Point(6, 64);
            this.lowLevelCourse2.Name = "lowLevelCourse2";
            this.lowLevelCourse2.Size = new System.Drawing.Size(11, 12);
            this.lowLevelCourse2.TabIndex = 1;
            this.lowLevelCourse2.Text = " ";
            // 
            // lowLevelCourse1
            // 
            this.lowLevelCourse1.AutoSize = true;
            this.lowLevelCourse1.Location = new System.Drawing.Point(7, 35);
            this.lowLevelCourse1.Name = "lowLevelCourse1";
            this.lowLevelCourse1.Size = new System.Drawing.Size(11, 12);
            this.lowLevelCourse1.TabIndex = 0;
            this.lowLevelCourse1.Text = " ";
            // 
            // groupBox7
            // 
            this.groupBox7.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox7.Controls.Add(this.book3);
            this.groupBox7.Controls.Add(this.book2);
            this.groupBox7.Controls.Add(this.book1);
            this.groupBox7.Location = new System.Drawing.Point(1014, 330);
            this.groupBox7.Name = "groupBox7";
            this.groupBox7.Size = new System.Drawing.Size(277, 149);
            this.groupBox7.TabIndex = 20;
            this.groupBox7.TabStop = false;
            this.groupBox7.Text = "推荐书籍";
            // 
            // book3
            // 
            this.book3.Location = new System.Drawing.Point(188, 21);
            this.book3.Name = "book3";
            this.book3.Size = new System.Drawing.Size(83, 112);
            this.book3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.book3.TabIndex = 2;
            this.book3.TabStop = false;
            // 
            // book2
            // 
            this.book2.Location = new System.Drawing.Point(97, 20);
            this.book2.Name = "book2";
            this.book2.Size = new System.Drawing.Size(83, 112);
            this.book2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.book2.TabIndex = 1;
            this.book2.TabStop = false;
            // 
            // book1
            // 
            this.book1.InitialImage = null;
            this.book1.Location = new System.Drawing.Point(6, 21);
            this.book1.Name = "book1";
            this.book1.Size = new System.Drawing.Size(83, 112);
            this.book1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.book1.TabIndex = 0;
            this.book1.TabStop = false;
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.groupBox2.Controls.Add(this.pb_Monitor);
            this.groupBox2.Location = new System.Drawing.Point(6, 458);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(223, 123);
            this.groupBox2.TabIndex = 15;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "实时画面";
            this.groupBox2.Visible = false;
            // 
            // pb_Monitor
            // 
            this.pb_Monitor.Location = new System.Drawing.Point(57, 20);
            this.pb_Monitor.Name = "pb_Monitor";
            this.pb_Monitor.Size = new System.Drawing.Size(107, 96);
            this.pb_Monitor.TabIndex = 0;
            this.pb_Monitor.TabStop = false;
            this.pb_Monitor.Click += new System.EventHandler(this.pb_Monitor_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.courseNameLabel);
            this.groupBox3.Controls.Add(this.courseCodeLabel);
            this.groupBox3.Location = new System.Drawing.Point(6, 12);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(223, 103);
            this.groupBox3.TabIndex = 22;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "课程信息";
            // 
            // courseCodeLabel
            // 
            this.courseCodeLabel.AutoSize = true;
            this.courseCodeLabel.Location = new System.Drawing.Point(10, 34);
            this.courseCodeLabel.Name = "courseCodeLabel";
            this.courseCodeLabel.Size = new System.Drawing.Size(65, 12);
            this.courseCodeLabel.TabIndex = 0;
            this.courseCodeLabel.Text = "课程代码：";
            // 
            // courseNameLabel
            // 
            this.courseNameLabel.AutoSize = true;
            this.courseNameLabel.Location = new System.Drawing.Point(10, 62);
            this.courseNameLabel.Name = "courseNameLabel";
            this.courseNameLabel.Size = new System.Drawing.Size(65, 12);
            this.courseNameLabel.TabIndex = 1;
            this.courseNameLabel.Text = "课程名称：";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1303, 598);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox8);
            this.Controls.Add(this.groupBox7);
            this.Controls.Add(this.groupBox6);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.videoPanel);
            this.Name = "MainForm";
            this.Text = "自适应学习系统";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.videoPanel.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.videoVolumeTrackBar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.videoProgressTrackBar)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.groupBox6.ResumeLayout(false);
            this.groupBox8.ResumeLayout(false);
            this.groupBox10.ResumeLayout(false);
            this.groupBox10.PerformLayout();
            this.groupBox9.ResumeLayout(false);
            this.groupBox9.PerformLayout();
            this.groupBox7.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.book3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.book2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.book1)).EndInit();
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pb_Monitor)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button fastSpeedBtn;
        private System.Windows.Forms.Button normalSpeedBtn;
        private System.Windows.Forms.Button slowSpeedBtn;
        private System.Windows.Forms.Button forwardBtn;
        private System.Windows.Forms.Button normalBtn;
        private System.Windows.Forms.Button reverseBtn;
        private System.Windows.Forms.Panel videoPanel;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TrackBar videoVolumeTrackBar;
        private System.Windows.Forms.Label videoProgressLabel;
        private System.Windows.Forms.ListBox videoListBox;
        private System.Windows.Forms.TrackBar videoProgressTrackBar;
        private System.Windows.Forms.Button stopBtn;
        private System.Windows.Forms.Timer videoProgressTimer;
        private System.Windows.Forms.Panel coverPanel;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.Label notetakingLabel;
        private System.Windows.Forms.Label unknownLabel;
        private System.Windows.Forms.Label normalLabel;
        private System.Windows.Forms.Label concentratedLabel;
        private System.Windows.Forms.Label distractedLabel;
        private System.Windows.Forms.Label surprisedLabel;
        private System.Windows.Forms.Label confusedLabel;
        private System.Windows.Forms.Label thinkingLabel;
        private System.Windows.Forms.Label amusedLabel;
        private System.Windows.Forms.Button wrongBtn;
        private System.Windows.Forms.Button correctBtn;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.GroupBox groupBox8;
        private System.Windows.Forms.GroupBox groupBox7;
        private System.Windows.Forms.GroupBox groupBox10;
        private System.Windows.Forms.GroupBox groupBox9;
        private System.Windows.Forms.Label highLevelCourse2;
        private System.Windows.Forms.Label highLevelCourse1;
        private System.Windows.Forms.Label lowLevelCourse2;
        private System.Windows.Forms.Label lowLevelCourse1;
        private System.Windows.Forms.Label helpTextLabel;
        private System.Windows.Forms.PictureBox book3;
        private System.Windows.Forms.PictureBox book2;
        private System.Windows.Forms.PictureBox book1;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.ComboBox modelComboBox;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.PictureBox pb_Monitor;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label courseNameLabel;
        private System.Windows.Forms.Label courseCodeLabel;
    }
}

