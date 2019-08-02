namespace LanguagesManage
{
    partial class BasicScript
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BasicScript));
            this.dgvBasicScript = new System.Windows.Forms.DataGridView();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.cmbPosition = new System.Windows.Forms.ComboBox();
            this.btnGetPosition = new System.Windows.Forms.Button();
            this.txtBasicText = new System.Windows.Forms.TextBox();
            this.cmbAddPosition = new System.Windows.Forms.ComboBox();
            this.lblBasicText = new System.Windows.Forms.Label();
            this.lblPosition = new System.Windows.Forms.Label();
            this.btnEdit = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblAdmin = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtScriptID = new System.Windows.Forms.TextBox();
            this.lblUpdateTime = new System.Windows.Forms.Label();
            this.lblAddTime = new System.Windows.Forms.Label();
            this.lblProjectName = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.cmbProject = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.pagingDgvBasicScript = new WinFormPaging.PagingControl();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBasicScript)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvBasicScript
            // 
            this.dgvBasicScript.AllowUserToAddRows = false;
            this.dgvBasicScript.AllowUserToDeleteRows = false;
            this.dgvBasicScript.AllowUserToResizeRows = false;
            this.dgvBasicScript.BackgroundColor = System.Drawing.SystemColors.ActiveBorder;
            this.dgvBasicScript.Location = new System.Drawing.Point(0, 151);
            this.dgvBasicScript.Name = "dgvBasicScript";
            this.dgvBasicScript.ReadOnly = true;
            this.dgvBasicScript.RowHeadersVisible = false;
            this.dgvBasicScript.RowTemplate.Height = 23;
            this.dgvBasicScript.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvBasicScript.Size = new System.Drawing.Size(505, 428);
            this.dgvBasicScript.TabIndex = 0;
            this.dgvBasicScript.TabStop = false;
            this.dgvBasicScript.CellEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvBasicScript_CellEnter);
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(83, 533);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(75, 35);
            this.btnAdd.TabIndex = 7;
            this.btnAdd.Text = "添加";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click_1);
            // 
            // btnRefresh
            // 
            this.btnRefresh.Location = new System.Drawing.Point(358, 11);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(54, 50);
            this.btnRefresh.TabIndex = 2;
            this.btnRefresh.Text = "刷新";
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // cmbPosition
            // 
            this.cmbPosition.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbPosition.FormattingEnabled = true;
            this.cmbPosition.Items.AddRange(new object[] {
            "所有"});
            this.cmbPosition.Location = new System.Drawing.Point(66, 39);
            this.cmbPosition.Name = "cmbPosition";
            this.cmbPosition.Size = new System.Drawing.Size(226, 22);
            this.cmbPosition.TabIndex = 3;
            // 
            // btnGetPosition
            // 
            this.btnGetPosition.Location = new System.Drawing.Point(298, 11);
            this.btnGetPosition.Name = "btnGetPosition";
            this.btnGetPosition.Size = new System.Drawing.Size(54, 50);
            this.btnGetPosition.TabIndex = 4;
            this.btnGetPosition.Text = "确定";
            this.btnGetPosition.UseVisualStyleBackColor = true;
            this.btnGetPosition.Click += new System.EventHandler(this.btnGetPosition_Click);
            // 
            // txtBasicText
            // 
            this.txtBasicText.Location = new System.Drawing.Point(87, 236);
            this.txtBasicText.Multiline = true;
            this.txtBasicText.Name = "txtBasicText";
            this.txtBasicText.ReadOnly = true;
            this.txtBasicText.Size = new System.Drawing.Size(234, 291);
            this.txtBasicText.TabIndex = 5;
            // 
            // cmbAddPosition
            // 
            this.cmbAddPosition.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbAddPosition.Enabled = false;
            this.cmbAddPosition.FormattingEnabled = true;
            this.cmbAddPosition.Location = new System.Drawing.Point(87, 88);
            this.cmbAddPosition.Name = "cmbAddPosition";
            this.cmbAddPosition.Size = new System.Drawing.Size(234, 22);
            this.cmbAddPosition.TabIndex = 6;
            // 
            // lblBasicText
            // 
            this.lblBasicText.AutoSize = true;
            this.lblBasicText.Location = new System.Drawing.Point(14, 236);
            this.lblBasicText.Name = "lblBasicText";
            this.lblBasicText.Size = new System.Drawing.Size(56, 14);
            this.lblBasicText.TabIndex = 7;
            this.lblBasicText.Text = "文   本";
            // 
            // lblPosition
            // 
            this.lblPosition.AutoSize = true;
            this.lblPosition.Location = new System.Drawing.Point(14, 91);
            this.lblPosition.Name = "lblPosition";
            this.lblPosition.Size = new System.Drawing.Size(56, 14);
            this.lblPosition.TabIndex = 8;
            this.lblPosition.Text = "类   名";
            // 
            // btnEdit
            // 
            this.btnEdit.Location = new System.Drawing.Point(2, 533);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(75, 35);
            this.btnEdit.TabIndex = 6;
            this.btnEdit.Text = "编辑";
            this.btnEdit.UseVisualStyleBackColor = true;
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 42);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(49, 14);
            this.label1.TabIndex = 13;
            this.label1.Text = "类名：";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.panel1.Controls.Add(this.lblAdmin);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.txtScriptID);
            this.panel1.Controls.Add(this.lblUpdateTime);
            this.panel1.Controls.Add(this.lblAddTime);
            this.panel1.Controls.Add(this.lblProjectName);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label8);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.btnSave);
            this.panel1.Controls.Add(this.btnEdit);
            this.panel1.Controls.Add(this.lblPosition);
            this.panel1.Controls.Add(this.btnCancel);
            this.panel1.Controls.Add(this.btnAdd);
            this.panel1.Controls.Add(this.cmbAddPosition);
            this.panel1.Controls.Add(this.txtBasicText);
            this.panel1.Controls.Add(this.lblBasicText);
            this.panel1.Location = new System.Drawing.Point(511, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(332, 577);
            this.panel1.TabIndex = 14;
            // 
            // lblAdmin
            // 
            this.lblAdmin.AutoSize = true;
            this.lblAdmin.Location = new System.Drawing.Point(85, 201);
            this.lblAdmin.Name = "lblAdmin";
            this.lblAdmin.Size = new System.Drawing.Size(14, 14);
            this.lblAdmin.TabIndex = 14;
            this.lblAdmin.Text = ".";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(14, 201);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(63, 14);
            this.label5.TabIndex = 14;
            this.label5.Text = "操作人员";
            // 
            // txtScriptID
            // 
            this.txtScriptID.Location = new System.Drawing.Point(87, 18);
            this.txtScriptID.Name = "txtScriptID";
            this.txtScriptID.ReadOnly = true;
            this.txtScriptID.Size = new System.Drawing.Size(124, 23);
            this.txtScriptID.TabIndex = 13;
            // 
            // lblUpdateTime
            // 
            this.lblUpdateTime.AutoSize = true;
            this.lblUpdateTime.Location = new System.Drawing.Point(85, 165);
            this.lblUpdateTime.Name = "lblUpdateTime";
            this.lblUpdateTime.Size = new System.Drawing.Size(14, 14);
            this.lblUpdateTime.TabIndex = 12;
            this.lblUpdateTime.Text = ".";
            // 
            // lblAddTime
            // 
            this.lblAddTime.AutoSize = true;
            this.lblAddTime.Location = new System.Drawing.Point(85, 128);
            this.lblAddTime.Name = "lblAddTime";
            this.lblAddTime.Size = new System.Drawing.Size(14, 14);
            this.lblAddTime.TabIndex = 12;
            this.lblAddTime.Text = ".";
            // 
            // lblProjectName
            // 
            this.lblProjectName.AutoSize = true;
            this.lblProjectName.Location = new System.Drawing.Point(84, 57);
            this.lblProjectName.Name = "lblProjectName";
            this.lblProjectName.Size = new System.Drawing.Size(63, 14);
            this.lblProjectName.TabIndex = 12;
            this.lblProjectName.Text = "项目名称";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(14, 21);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(35, 14);
            this.label4.TabIndex = 12;
            this.label4.Text = "I  D";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(14, 165);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(63, 14);
            this.label8.TabIndex = 10;
            this.label8.Text = "更新时间";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(14, 128);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(63, 14);
            this.label7.TabIndex = 10;
            this.label7.Text = "添加时间";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(14, 57);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(63, 14);
            this.label3.TabIndex = 10;
            this.label3.Text = "项目名称";
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(246, 534);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 35);
            this.btnSave.TabIndex = 9;
            this.btnSave.Text = "保存";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(164, 533);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 35);
            this.btnCancel.TabIndex = 8;
            this.btnCancel.Text = "取消";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // cmbProject
            // 
            this.cmbProject.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbProject.FormattingEnabled = true;
            this.cmbProject.Location = new System.Drawing.Point(66, 11);
            this.cmbProject.Name = "cmbProject";
            this.cmbProject.Size = new System.Drawing.Size(226, 22);
            this.cmbProject.TabIndex = 15;
            this.cmbProject.SelectedIndexChanged += new System.EventHandler(this.cmbProject_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(11, 14);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(49, 14);
            this.label2.TabIndex = 16;
            this.label2.Text = "项目：";
            // 
            // pagingDgvBasicScript
            // 
            this.pagingDgvBasicScript.BackColor = System.Drawing.Color.PowderBlue;
            this.pagingDgvBasicScript.LabelButtonRalition = WinFormPaging.PagingControl.LabelButtonRalitionEnum.Up;
            this.pagingDgvBasicScript.Location = new System.Drawing.Point(0, 67);
            this.pagingDgvBasicScript.Name = "pagingDgvBasicScript";
            this.pagingDgvBasicScript.RecordCount = 0;
            this.pagingDgvBasicScript.Size = new System.Drawing.Size(505, 88);
            this.pagingDgvBasicScript.TabIndex = 17;
            this.pagingDgvBasicScript.PageIndexChanged += new System.EventHandler(this.pagingControl1_PageIndexChanged);
            // 
            // BasicScript
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(841, 583);
            this.Controls.Add(this.dgvBasicScript);
            this.Controls.Add(this.pagingDgvBasicScript);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cmbProject);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnGetPosition);
            this.Controls.Add(this.cmbPosition);
            this.Controls.Add(this.btnRefresh);
            this.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "BasicScript";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "中文管理";
            this.Load += new System.EventHandler(this.BasicScript_Load);
            this.SizeChanged += new System.EventHandler(this.BasicScript_SizeChanged);
            ((System.ComponentModel.ISupportInitialize)(this.dgvBasicScript)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvBasicScript;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.ComboBox cmbPosition;
        private System.Windows.Forms.Button btnGetPosition;
        private System.Windows.Forms.TextBox txtBasicText;
        private System.Windows.Forms.ComboBox cmbAddPosition;
        private System.Windows.Forms.Label lblBasicText;
        private System.Windows.Forms.Label lblPosition;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ComboBox cmbProject;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtScriptID;
        private System.Windows.Forms.Label lblUpdateTime;
        private System.Windows.Forms.Label lblAddTime;
        private System.Windows.Forms.Label lblProjectName;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Label lblAdmin;
        private System.Windows.Forms.Label label5;
        private WinFormPaging.PagingControl pagingDgvBasicScript;
    }
}