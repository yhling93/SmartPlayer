namespace SmartPlayer
{
    partial class StartForm
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle25 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle26 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle27 = new System.Windows.Forms.DataGridViewCellStyle();
            this.courseListBtn = new System.Windows.Forms.Button();
            this.mycourseBtn = new System.Windows.Forms.Button();
            this.myinfoBtn = new System.Windows.Forms.Button();
            this.exitBtn = new System.Windows.Forms.Button();
            this.courseDataGrid = new System.Windows.Forms.DataGridView();
            this.CourseCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CourseName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CourseTeacher = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CourseDesp = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CourseLesson = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CourseDifficulty = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CourseEnterMember = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ParticipateCourse = new System.Windows.Forms.DataGridViewButtonColumn();
            this.DirectGo = new System.Windows.Forms.DataGridViewButtonColumn();
            this.courseListPanel = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.myCoursePanel = new System.Windows.Forms.Panel();
            this.label5 = new System.Windows.Forms.Label();
            this.myCourseDataGrid = new System.Windows.Forms.DataGridView();
            this.MyCourseNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MyCourseName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MyCourseTotalProgress = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MyCourseProgress = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.StartCourse = new System.Windows.Forms.DataGridViewButtonColumn();
            this.MyCourseState = new System.Windows.Forms.DataGridViewButtonColumn();
            this.myInfoPanel = new System.Windows.Forms.Panel();
            this.updateBtn = new System.Windows.Forms.Button();
            this.ageBox = new System.Windows.Forms.TextBox();
            this.noBox = new System.Windows.Forms.TextBox();
            this.nameBox = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.courseDataGrid)).BeginInit();
            this.courseListPanel.SuspendLayout();
            this.myCoursePanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.myCourseDataGrid)).BeginInit();
            this.myInfoPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // courseListBtn
            // 
            this.courseListBtn.Location = new System.Drawing.Point(-1, -1);
            this.courseListBtn.Name = "courseListBtn";
            this.courseListBtn.Size = new System.Drawing.Size(200, 60);
            this.courseListBtn.TabIndex = 1;
            this.courseListBtn.Text = "课程列表";
            this.courseListBtn.UseVisualStyleBackColor = true;
            this.courseListBtn.Click += new System.EventHandler(this.courseListBtn_Click);
            // 
            // mycourseBtn
            // 
            this.mycourseBtn.Location = new System.Drawing.Point(198, -1);
            this.mycourseBtn.Name = "mycourseBtn";
            this.mycourseBtn.Size = new System.Drawing.Size(200, 60);
            this.mycourseBtn.TabIndex = 2;
            this.mycourseBtn.Text = "我的课程";
            this.mycourseBtn.UseVisualStyleBackColor = true;
            this.mycourseBtn.Click += new System.EventHandler(this.mycourseBtn_Click);
            // 
            // myinfoBtn
            // 
            this.myinfoBtn.Location = new System.Drawing.Point(397, -1);
            this.myinfoBtn.Name = "myinfoBtn";
            this.myinfoBtn.Size = new System.Drawing.Size(200, 60);
            this.myinfoBtn.TabIndex = 3;
            this.myinfoBtn.Text = "我的信息";
            this.myinfoBtn.UseVisualStyleBackColor = true;
            this.myinfoBtn.Click += new System.EventHandler(this.myinfoBtn_Click);
            // 
            // exitBtn
            // 
            this.exitBtn.Location = new System.Drawing.Point(596, -1);
            this.exitBtn.Name = "exitBtn";
            this.exitBtn.Size = new System.Drawing.Size(200, 60);
            this.exitBtn.TabIndex = 5;
            this.exitBtn.Text = "退出";
            this.exitBtn.UseVisualStyleBackColor = true;
            this.exitBtn.Click += new System.EventHandler(this.exitBtn_Click);
            // 
            // courseDataGrid
            // 
            dataGridViewCellStyle25.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle25.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle25.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle25.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle25.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle25.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle25.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.courseDataGrid.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle25;
            this.courseDataGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.courseDataGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.CourseCode,
            this.CourseName,
            this.CourseTeacher,
            this.CourseDesp,
            this.CourseLesson,
            this.CourseDifficulty,
            this.CourseEnterMember,
            this.ParticipateCourse,
            this.DirectGo});
            dataGridViewCellStyle26.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle26.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle26.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle26.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle26.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle26.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle26.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.courseDataGrid.DefaultCellStyle = dataGridViewCellStyle26;
            this.courseDataGrid.Location = new System.Drawing.Point(13, 34);
            this.courseDataGrid.Name = "courseDataGrid";
            dataGridViewCellStyle27.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle27.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle27.Font = new System.Drawing.Font("微软雅黑", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle27.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle27.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle27.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle27.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.courseDataGrid.RowHeadersDefaultCellStyle = dataGridViewCellStyle27;
            this.courseDataGrid.RowTemplate.Height = 23;
            this.courseDataGrid.Size = new System.Drawing.Size(771, 362);
            this.courseDataGrid.TabIndex = 6;
            // 
            // CourseCode
            // 
            this.CourseCode.HeaderText = "代号";
            this.CourseCode.Name = "CourseCode";
            this.CourseCode.ReadOnly = true;
            this.CourseCode.Width = 80;
            // 
            // CourseName
            // 
            this.CourseName.HeaderText = "名字";
            this.CourseName.Name = "CourseName";
            this.CourseName.ReadOnly = true;
            this.CourseName.Width = 68;
            // 
            // CourseTeacher
            // 
            this.CourseTeacher.HeaderText = "教师";
            this.CourseTeacher.Name = "CourseTeacher";
            this.CourseTeacher.ReadOnly = true;
            this.CourseTeacher.Width = 80;
            // 
            // CourseDesp
            // 
            this.CourseDesp.HeaderText = "描述";
            this.CourseDesp.Name = "CourseDesp";
            this.CourseDesp.ReadOnly = true;
            this.CourseDesp.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.CourseDesp.Width = 80;
            // 
            // CourseLesson
            // 
            this.CourseLesson.HeaderText = "课时";
            this.CourseLesson.Name = "CourseLesson";
            // 
            // CourseDifficulty
            // 
            this.CourseDifficulty.HeaderText = "难度";
            this.CourseDifficulty.Name = "CourseDifficulty";
            this.CourseDifficulty.ReadOnly = true;
            this.CourseDifficulty.Width = 80;
            // 
            // CourseEnterMember
            // 
            this.CourseEnterMember.HeaderText = "参与人数";
            this.CourseEnterMember.Name = "CourseEnterMember";
            this.CourseEnterMember.ReadOnly = true;
            this.CourseEnterMember.Width = 80;
            // 
            // ParticipateCourse
            // 
            this.ParticipateCourse.HeaderText = "参加课程";
            this.ParticipateCourse.Name = "ParticipateCourse";
            this.ParticipateCourse.ReadOnly = true;
            this.ParticipateCourse.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.ParticipateCourse.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.ParticipateCourse.Width = 80;
            // 
            // DirectGo
            // 
            this.DirectGo.HeaderText = "直接上课";
            this.DirectGo.Name = "DirectGo";
            this.DirectGo.ReadOnly = true;
            this.DirectGo.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.DirectGo.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.DirectGo.Width = 80;
            // 
            // courseListPanel
            // 
            this.courseListPanel.Controls.Add(this.label1);
            this.courseListPanel.Controls.Add(this.courseDataGrid);
            this.courseListPanel.Location = new System.Drawing.Point(-1, 65);
            this.courseListPanel.Name = "courseListPanel";
            this.courseListPanel.Size = new System.Drawing.Size(797, 409);
            this.courseListPanel.TabIndex = 7;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 6);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 7;
            this.label1.Text = "课程列表";
            // 
            // myCoursePanel
            // 
            this.myCoursePanel.Controls.Add(this.label5);
            this.myCoursePanel.Controls.Add(this.myCourseDataGrid);
            this.myCoursePanel.Location = new System.Drawing.Point(1, 65);
            this.myCoursePanel.Name = "myCoursePanel";
            this.myCoursePanel.Size = new System.Drawing.Size(792, 406);
            this.myCoursePanel.TabIndex = 8;
            this.myCoursePanel.Visible = false;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(9, 6);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(53, 12);
            this.label5.TabIndex = 1;
            this.label5.Text = "我的课程";
            // 
            // myCourseDataGrid
            // 
            this.myCourseDataGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.myCourseDataGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.MyCourseNo,
            this.MyCourseName,
            this.MyCourseTotalProgress,
            this.MyCourseProgress,
            this.StartCourse,
            this.MyCourseState});
            this.myCourseDataGrid.Location = new System.Drawing.Point(11, 34);
            this.myCourseDataGrid.Name = "myCourseDataGrid";
            this.myCourseDataGrid.RowTemplate.Height = 23;
            this.myCourseDataGrid.Size = new System.Drawing.Size(771, 362);
            this.myCourseDataGrid.TabIndex = 0;
            this.myCourseDataGrid.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.myCourseDataGrid_CellContentClick);
            // 
            // MyCourseNo
            // 
            this.MyCourseNo.HeaderText = "课程代号";
            this.MyCourseNo.Name = "MyCourseNo";
            this.MyCourseNo.ReadOnly = true;
            // 
            // MyCourseName
            // 
            this.MyCourseName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.MyCourseName.HeaderText = "课程名称";
            this.MyCourseName.Name = "MyCourseName";
            this.MyCourseName.ReadOnly = true;
            // 
            // MyCourseTotalProgress
            // 
            this.MyCourseTotalProgress.HeaderText = "全部课时";
            this.MyCourseTotalProgress.Name = "MyCourseTotalProgress";
            this.MyCourseTotalProgress.ReadOnly = true;
            // 
            // MyCourseProgress
            // 
            this.MyCourseProgress.HeaderText = "我的进度";
            this.MyCourseProgress.Name = "MyCourseProgress";
            this.MyCourseProgress.ReadOnly = true;
            // 
            // StartCourse
            // 
            this.StartCourse.HeaderText = "开始上课";
            this.StartCourse.Name = "StartCourse";
            this.StartCourse.ReadOnly = true;
            this.StartCourse.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.StartCourse.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // MyCourseState
            // 
            this.MyCourseState.HeaderText = "上课情况";
            this.MyCourseState.Name = "MyCourseState";
            this.MyCourseState.ReadOnly = true;
            this.MyCourseState.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.MyCourseState.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // myInfoPanel
            // 
            this.myInfoPanel.Controls.Add(this.updateBtn);
            this.myInfoPanel.Controls.Add(this.ageBox);
            this.myInfoPanel.Controls.Add(this.noBox);
            this.myInfoPanel.Controls.Add(this.nameBox);
            this.myInfoPanel.Controls.Add(this.label4);
            this.myInfoPanel.Controls.Add(this.label3);
            this.myInfoPanel.Controls.Add(this.label2);
            this.myInfoPanel.Location = new System.Drawing.Point(0, 62);
            this.myInfoPanel.Name = "myInfoPanel";
            this.myInfoPanel.Size = new System.Drawing.Size(797, 409);
            this.myInfoPanel.TabIndex = 9;
            this.myInfoPanel.Visible = false;
            // 
            // updateBtn
            // 
            this.updateBtn.Location = new System.Drawing.Point(363, 260);
            this.updateBtn.Name = "updateBtn";
            this.updateBtn.Size = new System.Drawing.Size(75, 23);
            this.updateBtn.TabIndex = 6;
            this.updateBtn.Text = "保存信息";
            this.updateBtn.UseVisualStyleBackColor = true;
            // 
            // ageBox
            // 
            this.ageBox.Location = new System.Drawing.Point(378, 212);
            this.ageBox.Name = "ageBox";
            this.ageBox.Size = new System.Drawing.Size(100, 21);
            this.ageBox.TabIndex = 5;
            // 
            // noBox
            // 
            this.noBox.Location = new System.Drawing.Point(378, 171);
            this.noBox.Name = "noBox";
            this.noBox.ReadOnly = true;
            this.noBox.Size = new System.Drawing.Size(100, 21);
            this.noBox.TabIndex = 4;
            // 
            // nameBox
            // 
            this.nameBox.Location = new System.Drawing.Point(378, 128);
            this.nameBox.Name = "nameBox";
            this.nameBox.ReadOnly = true;
            this.nameBox.Size = new System.Drawing.Size(100, 21);
            this.nameBox.TabIndex = 3;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(309, 215);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(41, 12);
            this.label4.TabIndex = 2;
            this.label4.Text = "年龄：";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(309, 174);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 12);
            this.label3.TabIndex = 1;
            this.label3.Text = "学号：";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(309, 131);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 12);
            this.label2.TabIndex = 0;
            this.label2.Text = "姓名：";
            // 
            // StartForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(795, 473);
            this.Controls.Add(this.exitBtn);
            this.Controls.Add(this.myinfoBtn);
            this.Controls.Add(this.mycourseBtn);
            this.Controls.Add(this.courseListBtn);
            this.Controls.Add(this.courseListPanel);
            this.Controls.Add(this.myCoursePanel);
            this.Controls.Add(this.myInfoPanel);
            this.Name = "StartForm";
            this.Text = "功能选择";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.StartForm_FormClosed);
            ((System.ComponentModel.ISupportInitialize)(this.courseDataGrid)).EndInit();
            this.courseListPanel.ResumeLayout(false);
            this.courseListPanel.PerformLayout();
            this.myCoursePanel.ResumeLayout(false);
            this.myCoursePanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.myCourseDataGrid)).EndInit();
            this.myInfoPanel.ResumeLayout(false);
            this.myInfoPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button courseListBtn;
        private System.Windows.Forms.Button mycourseBtn;
        private System.Windows.Forms.Button myinfoBtn;
        private System.Windows.Forms.Button exitBtn;
        private System.Windows.Forms.DataGridView courseDataGrid;
        private System.Windows.Forms.Panel courseListPanel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel myCoursePanel;
        private System.Windows.Forms.Panel myInfoPanel;
        private System.Windows.Forms.TextBox ageBox;
        private System.Windows.Forms.TextBox noBox;
        private System.Windows.Forms.TextBox nameBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button updateBtn;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DataGridView myCourseDataGrid;
        private System.Windows.Forms.DataGridViewTextBoxColumn MyCourseNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn MyCourseName;
        private System.Windows.Forms.DataGridViewTextBoxColumn MyCourseTotalProgress;
        private System.Windows.Forms.DataGridViewTextBoxColumn MyCourseProgress;
        private System.Windows.Forms.DataGridViewButtonColumn StartCourse;
        private System.Windows.Forms.DataGridViewButtonColumn MyCourseState;
        private System.Windows.Forms.DataGridViewTextBoxColumn CourseCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn CourseName;
        private System.Windows.Forms.DataGridViewTextBoxColumn CourseTeacher;
        private System.Windows.Forms.DataGridViewTextBoxColumn CourseDesp;
        private System.Windows.Forms.DataGridViewTextBoxColumn CourseLesson;
        private System.Windows.Forms.DataGridViewTextBoxColumn CourseDifficulty;
        private System.Windows.Forms.DataGridViewTextBoxColumn CourseEnterMember;
        private System.Windows.Forms.DataGridViewButtonColumn ParticipateCourse;
        private System.Windows.Forms.DataGridViewButtonColumn DirectGo;
    }
}