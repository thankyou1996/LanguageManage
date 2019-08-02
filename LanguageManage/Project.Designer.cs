namespace LanguagesManage
{
    partial class Project
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Project));
            this.dgvProject = new System.Windows.Forms.DataGridView();
            this.lblID = new System.Windows.Forms.Label();
            this.lblProjectName = new System.Windows.Forms.Label();
            this.lblSolutionName = new System.Windows.Forms.Label();
            this.lblLastModifyTime = new System.Windows.Forms.Label();
            this.lblBackupVersion = new System.Windows.Forms.Label();
            this.lblRemarks = new System.Windows.Forms.Label();
            this.lblAddTime = new System.Windows.Forms.Label();
            this.lblAdmin = new System.Windows.Forms.Label();
            this.txtID = new System.Windows.Forms.TextBox();
            this.txtProjectName = new System.Windows.Forms.TextBox();
            this.txtSolutionName = new System.Windows.Forms.TextBox();
            this.txtRemarks = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.btnEdit = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.btnFlush = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnCodeFilter = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProject)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvProject
            // 
            this.dgvProject.AllowUserToAddRows = false;
            this.dgvProject.AllowUserToDeleteRows = false;
            this.dgvProject.AllowUserToResizeRows = false;
            this.dgvProject.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvProject.BackgroundColor = System.Drawing.SystemColors.ActiveBorder;
            this.dgvProject.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvProject.Location = new System.Drawing.Point(0, 0);
            this.dgvProject.MultiSelect = false;
            this.dgvProject.Name = "dgvProject";
            this.dgvProject.ReadOnly = true;
            this.dgvProject.RowHeadersVisible = false;
            this.dgvProject.RowTemplate.Height = 23;
            this.dgvProject.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvProject.Size = new System.Drawing.Size(374, 493);
            this.dgvProject.TabIndex = 0;
            this.dgvProject.TabStop = false;
            this.dgvProject.CellEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvProject_CellEnter);
            // 
            // lblID
            // 
            this.lblID.AutoSize = true;
            this.lblID.Location = new System.Drawing.Point(380, 12);
            this.lblID.Name = "lblID";
            this.lblID.Size = new System.Drawing.Size(35, 12);
            this.lblID.TabIndex = 1;
            this.lblID.Text = "I   D";
            // 
            // lblProjectName
            // 
            this.lblProjectName.AutoSize = true;
            this.lblProjectName.Location = new System.Drawing.Point(380, 50);
            this.lblProjectName.Name = "lblProjectName";
            this.lblProjectName.Size = new System.Drawing.Size(53, 12);
            this.lblProjectName.TabIndex = 1;
            this.lblProjectName.Text = "项目名称";
            // 
            // lblSolutionName
            // 
            this.lblSolutionName.AutoSize = true;
            this.lblSolutionName.Location = new System.Drawing.Point(380, 85);
            this.lblSolutionName.Name = "lblSolutionName";
            this.lblSolutionName.Size = new System.Drawing.Size(77, 12);
            this.lblSolutionName.TabIndex = 1;
            this.lblSolutionName.Text = "解决方案名称";
            // 
            // lblLastModifyTime
            // 
            this.lblLastModifyTime.AutoSize = true;
            this.lblLastModifyTime.Location = new System.Drawing.Point(463, 182);
            this.lblLastModifyTime.Name = "lblLastModifyTime";
            this.lblLastModifyTime.Size = new System.Drawing.Size(11, 12);
            this.lblLastModifyTime.TabIndex = 1;
            this.lblLastModifyTime.Text = ".";
            // 
            // lblBackupVersion
            // 
            this.lblBackupVersion.AutoSize = true;
            this.lblBackupVersion.Location = new System.Drawing.Point(464, 121);
            this.lblBackupVersion.Name = "lblBackupVersion";
            this.lblBackupVersion.Size = new System.Drawing.Size(11, 12);
            this.lblBackupVersion.TabIndex = 1;
            this.lblBackupVersion.Text = ".";
            // 
            // lblRemarks
            // 
            this.lblRemarks.AutoSize = true;
            this.lblRemarks.Location = new System.Drawing.Point(380, 247);
            this.lblRemarks.Name = "lblRemarks";
            this.lblRemarks.Size = new System.Drawing.Size(53, 12);
            this.lblRemarks.TabIndex = 1;
            this.lblRemarks.Text = "备    注";
            // 
            // lblAddTime
            // 
            this.lblAddTime.AutoSize = true;
            this.lblAddTime.Location = new System.Drawing.Point(464, 153);
            this.lblAddTime.Name = "lblAddTime";
            this.lblAddTime.Size = new System.Drawing.Size(11, 12);
            this.lblAddTime.TabIndex = 1;
            this.lblAddTime.Text = ".";
            // 
            // lblAdmin
            // 
            this.lblAdmin.AutoSize = true;
            this.lblAdmin.Location = new System.Drawing.Point(464, 213);
            this.lblAdmin.Name = "lblAdmin";
            this.lblAdmin.Size = new System.Drawing.Size(11, 12);
            this.lblAdmin.TabIndex = 1;
            this.lblAdmin.Text = ".";
            // 
            // txtID
            // 
            this.txtID.Location = new System.Drawing.Point(466, 9);
            this.txtID.Name = "txtID";
            this.txtID.ReadOnly = true;
            this.txtID.Size = new System.Drawing.Size(80, 21);
            this.txtID.TabIndex = 0;
            // 
            // txtProjectName
            // 
            this.txtProjectName.Location = new System.Drawing.Point(466, 47);
            this.txtProjectName.Name = "txtProjectName";
            this.txtProjectName.ReadOnly = true;
            this.txtProjectName.Size = new System.Drawing.Size(190, 21);
            this.txtProjectName.TabIndex = 2;
            // 
            // txtSolutionName
            // 
            this.txtSolutionName.Location = new System.Drawing.Point(466, 82);
            this.txtSolutionName.Name = "txtSolutionName";
            this.txtSolutionName.ReadOnly = true;
            this.txtSolutionName.Size = new System.Drawing.Size(190, 21);
            this.txtSolutionName.TabIndex = 3;
            // 
            // txtRemarks
            // 
            this.txtRemarks.Location = new System.Drawing.Point(466, 244);
            this.txtRemarks.Multiline = true;
            this.txtRemarks.Name = "txtRemarks";
            this.txtRemarks.ReadOnly = true;
            this.txtRemarks.Size = new System.Drawing.Size(317, 194);
            this.txtRemarks.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(380, 121);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 1;
            this.label1.Text = "备份版本";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(380, 153);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(77, 12);
            this.label2.TabIndex = 1;
            this.label2.Text = "项目添加时间";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(380, 213);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 12);
            this.label3.TabIndex = 1;
            this.label3.Text = "操作人员";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(380, 182);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(77, 12);
            this.label4.TabIndex = 1;
            this.label4.Text = "项目修改时间";
            // 
            // btnEdit
            // 
            this.btnEdit.Location = new System.Drawing.Point(465, 446);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(75, 35);
            this.btnEdit.TabIndex = 6;
            this.btnEdit.Text = "编辑";
            this.btnEdit.UseVisualStyleBackColor = true;
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(708, 446);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 35);
            this.btnSave.TabIndex = 9;
            this.btnSave.Text = "保存";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(546, 446);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(75, 35);
            this.btnAdd.TabIndex = 7;
            this.btnAdd.Text = "添加";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // splitter1
            // 
            this.splitter1.Location = new System.Drawing.Point(0, 0);
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(3, 493);
            this.splitter1.TabIndex = 5;
            this.splitter1.TabStop = false;
            // 
            // btnFlush
            // 
            this.btnFlush.Location = new System.Drawing.Point(382, 446);
            this.btnFlush.Name = "btnFlush";
            this.btnFlush.Size = new System.Drawing.Size(75, 35);
            this.btnFlush.TabIndex = 5;
            this.btnFlush.Text = "刷新";
            this.btnFlush.UseVisualStyleBackColor = true;
            this.btnFlush.Click += new System.EventHandler(this.btnFlush_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(627, 446);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 35);
            this.btnCancel.TabIndex = 8;
            this.btnCancel.Text = "取消";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnCodeFilter
            // 
            this.btnCodeFilter.Location = new System.Drawing.Point(581, 7);
            this.btnCodeFilter.Name = "btnCodeFilter";
            this.btnCodeFilter.Size = new System.Drawing.Size(75, 23);
            this.btnCodeFilter.TabIndex = 10;
            this.btnCodeFilter.Text = "源码扫描";
            this.btnCodeFilter.UseVisualStyleBackColor = true;
            this.btnCodeFilter.Click += new System.EventHandler(this.btnCodeFilter_Click);
            // 
            // Project
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(788, 493);
            this.Controls.Add(this.btnCodeFilter);
            this.Controls.Add(this.splitter1);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnFlush);
            this.Controls.Add(this.btnEdit);
            this.Controls.Add(this.txtRemarks);
            this.Controls.Add(this.txtSolutionName);
            this.Controls.Add(this.txtProjectName);
            this.Controls.Add(this.txtID);
            this.Controls.Add(this.lblAdmin);
            this.Controls.Add(this.lblAddTime);
            this.Controls.Add(this.lblRemarks);
            this.Controls.Add(this.lblBackupVersion);
            this.Controls.Add(this.lblLastModifyTime);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblSolutionName);
            this.Controls.Add(this.lblProjectName);
            this.Controls.Add(this.lblID);
            this.Controls.Add(this.dgvProject);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Project";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "项目管理";
            this.Load += new System.EventHandler(this.Project_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvProject)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvProject;
        private System.Windows.Forms.Label lblID;
        private System.Windows.Forms.Label lblProjectName;
        private System.Windows.Forms.Label lblSolutionName;
        private System.Windows.Forms.Label lblLastModifyTime;
        private System.Windows.Forms.Label lblBackupVersion;
        private System.Windows.Forms.Label lblRemarks;
        private System.Windows.Forms.Label lblAddTime;
        private System.Windows.Forms.Label lblAdmin;
        private System.Windows.Forms.TextBox txtID;
        private System.Windows.Forms.TextBox txtProjectName;
        private System.Windows.Forms.TextBox txtSolutionName;
        private System.Windows.Forms.TextBox txtRemarks;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Splitter splitter1;
        private System.Windows.Forms.Button btnFlush;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnCodeFilter;
    }
}