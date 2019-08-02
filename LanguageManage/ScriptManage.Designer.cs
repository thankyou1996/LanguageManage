namespace LanguagesManage
{
    partial class ScriptManage
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ScriptManage));
            this.grpEdit = new System.Windows.Forms.GroupBox();
            this.chkPreviousLine = new System.Windows.Forms.CheckBox();
            this.chkSaveWrap = new System.Windows.Forms.CheckBox();
            this.txtEdit = new System.Windows.Forms.TextBox();
            this.chkWrapSave = new System.Windows.Forms.CheckBox();
            this.lblzh_CNInfo = new System.Windows.Forms.Label();
            this.chkEnterSave = new System.Windows.Forms.CheckBox();
            this.txtzh_CN = new System.Windows.Forms.TextBox();
            this.btnCancel = new System.Windows.Forms.Button();
            this.lblEditTypeInfo = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnFlush = new System.Windows.Forms.Button();
            this.btnSelect = new System.Windows.Forms.Button();
            this.cmbPosition = new System.Windows.Forms.ComboBox();
            this.cmbProject = new System.Windows.Forms.ComboBox();
            this.cmbType = new System.Windows.Forms.ComboBox();
            this.dgvScript = new System.Windows.Forms.DataGridView();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.pagingScript = new WinFormPaging.PagingControl();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.grpEdit.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvScript)).BeginInit();
            this.SuspendLayout();
            // 
            // grpEdit
            // 
            this.grpEdit.Controls.Add(this.chkPreviousLine);
            this.grpEdit.Controls.Add(this.chkSaveWrap);
            this.grpEdit.Controls.Add(this.txtEdit);
            this.grpEdit.Controls.Add(this.chkWrapSave);
            this.grpEdit.Controls.Add(this.lblzh_CNInfo);
            this.grpEdit.Controls.Add(this.chkEnterSave);
            this.grpEdit.Controls.Add(this.txtzh_CN);
            this.grpEdit.Controls.Add(this.btnCancel);
            this.grpEdit.Controls.Add(this.lblEditTypeInfo);
            this.grpEdit.Controls.Add(this.btnSave);
            this.grpEdit.Location = new System.Drawing.Point(638, 101);
            this.grpEdit.Name = "grpEdit";
            this.grpEdit.Size = new System.Drawing.Size(328, 414);
            this.grpEdit.TabIndex = 0;
            this.grpEdit.TabStop = false;
            this.grpEdit.Text = "编辑栏";
            // 
            // chkPreviousLine
            // 
            this.chkPreviousLine.AutoSize = true;
            this.chkPreviousLine.Location = new System.Drawing.Point(8, 363);
            this.chkPreviousLine.Name = "chkPreviousLine";
            this.chkPreviousLine.Size = new System.Drawing.Size(192, 16);
            this.chkPreviousLine.TabIndex = 6;
            this.chkPreviousLine.Text = "上一行并保存（Control+回车）";
            this.chkPreviousLine.UseVisualStyleBackColor = true;
            this.chkPreviousLine.CheckedChanged += new System.EventHandler(this.chkPreviousLine_CheckedChanged);
            // 
            // chkSaveWrap
            // 
            this.chkSaveWrap.AutoSize = true;
            this.chkSaveWrap.Checked = true;
            this.chkSaveWrap.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkSaveWrap.Location = new System.Drawing.Point(86, 337);
            this.chkSaveWrap.Name = "chkSaveWrap";
            this.chkSaveWrap.Size = new System.Drawing.Size(144, 16);
            this.chkSaveWrap.TabIndex = 6;
            this.chkSaveWrap.Text = "保存自动跳转至下一行";
            this.chkSaveWrap.UseVisualStyleBackColor = true;
            this.chkSaveWrap.CheckedChanged += new System.EventHandler(this.chkSaveWrap_CheckedChanged);
            // 
            // txtEdit
            // 
            this.txtEdit.Location = new System.Drawing.Point(8, 183);
            this.txtEdit.Multiline = true;
            this.txtEdit.Name = "txtEdit";
            this.txtEdit.Size = new System.Drawing.Size(312, 148);
            this.txtEdit.TabIndex = 3;
            // 
            // chkWrapSave
            // 
            this.chkWrapSave.AutoSize = true;
            this.chkWrapSave.Location = new System.Drawing.Point(236, 337);
            this.chkWrapSave.Name = "chkWrapSave";
            this.chkWrapSave.Size = new System.Drawing.Size(72, 16);
            this.chkWrapSave.TabIndex = 5;
            this.chkWrapSave.Text = "换行保存";
            this.chkWrapSave.UseVisualStyleBackColor = true;
            this.chkWrapSave.CheckedChanged += new System.EventHandler(this.chkWrapSave_CheckedChanged);
            // 
            // lblzh_CNInfo
            // 
            this.lblzh_CNInfo.AutoSize = true;
            this.lblzh_CNInfo.Location = new System.Drawing.Point(6, 17);
            this.lblzh_CNInfo.Name = "lblzh_CNInfo";
            this.lblzh_CNInfo.Size = new System.Drawing.Size(29, 12);
            this.lblzh_CNInfo.TabIndex = 0;
            this.lblzh_CNInfo.Text = "中文";
            // 
            // chkEnterSave
            // 
            this.chkEnterSave.AutoSize = true;
            this.chkEnterSave.Location = new System.Drawing.Point(8, 337);
            this.chkEnterSave.Name = "chkEnterSave";
            this.chkEnterSave.Size = new System.Drawing.Size(72, 16);
            this.chkEnterSave.TabIndex = 5;
            this.chkEnterSave.Text = "回车保存";
            this.chkEnterSave.UseVisualStyleBackColor = true;
            this.chkEnterSave.CheckedChanged += new System.EventHandler(this.chkEnterSave_CheckedChanged);
            // 
            // txtzh_CN
            // 
            this.txtzh_CN.Location = new System.Drawing.Point(8, 32);
            this.txtzh_CN.Multiline = true;
            this.txtzh_CN.Name = "txtzh_CN";
            this.txtzh_CN.ReadOnly = true;
            this.txtzh_CN.Size = new System.Drawing.Size(312, 123);
            this.txtzh_CN.TabIndex = 1;
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(89, 385);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 4;
            this.btnCancel.Text = "取消";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // lblEditTypeInfo
            // 
            this.lblEditTypeInfo.AutoSize = true;
            this.lblEditTypeInfo.Location = new System.Drawing.Point(6, 168);
            this.lblEditTypeInfo.Name = "lblEditTypeInfo";
            this.lblEditTypeInfo.Size = new System.Drawing.Size(29, 12);
            this.lblEditTypeInfo.TabIndex = 2;
            this.lblEditTypeInfo.Text = "外语";
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(8, 385);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 4;
            this.btnSave.Text = "保存";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnFlush
            // 
            this.btnFlush.Location = new System.Drawing.Point(355, 58);
            this.btnFlush.Name = "btnFlush";
            this.btnFlush.Size = new System.Drawing.Size(75, 31);
            this.btnFlush.TabIndex = 4;
            this.btnFlush.Text = "刷新";
            this.btnFlush.UseVisualStyleBackColor = true;
            this.btnFlush.Click += new System.EventHandler(this.btnFlush_Click);
            // 
            // btnSelect
            // 
            this.btnSelect.Location = new System.Drawing.Point(355, 10);
            this.btnSelect.Name = "btnSelect";
            this.btnSelect.Size = new System.Drawing.Size(75, 31);
            this.btnSelect.TabIndex = 4;
            this.btnSelect.Text = "确定";
            this.btnSelect.UseVisualStyleBackColor = true;
            this.btnSelect.Click += new System.EventHandler(this.btnSelect_Click);
            // 
            // cmbPosition
            // 
            this.cmbPosition.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbPosition.FormattingEnabled = true;
            this.cmbPosition.Location = new System.Drawing.Point(82, 64);
            this.cmbPosition.Name = "cmbPosition";
            this.cmbPosition.Size = new System.Drawing.Size(267, 20);
            this.cmbPosition.TabIndex = 3;
            // 
            // cmbProject
            // 
            this.cmbProject.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbProject.FormattingEnabled = true;
            this.cmbProject.Location = new System.Drawing.Point(82, 38);
            this.cmbProject.Name = "cmbProject";
            this.cmbProject.Size = new System.Drawing.Size(267, 20);
            this.cmbProject.TabIndex = 3;
            this.cmbProject.SelectedIndexChanged += new System.EventHandler(this.cmbProject_SelectedIndexChanged);
            // 
            // cmbType
            // 
            this.cmbType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbType.FormattingEnabled = true;
            this.cmbType.Location = new System.Drawing.Point(82, 12);
            this.cmbType.Name = "cmbType";
            this.cmbType.Size = new System.Drawing.Size(267, 20);
            this.cmbType.TabIndex = 3;
            // 
            // dgvScript
            // 
            this.dgvScript.AllowUserToAddRows = false;
            this.dgvScript.AllowUserToDeleteRows = false;
            this.dgvScript.AllowUserToResizeRows = false;
            this.dgvScript.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvScript.BackgroundColor = System.Drawing.SystemColors.ActiveBorder;
            this.dgvScript.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvScript.Location = new System.Drawing.Point(1, 101);
            this.dgvScript.Name = "dgvScript";
            this.dgvScript.ReadOnly = true;
            this.dgvScript.RowHeadersVisible = false;
            this.dgvScript.RowTemplate.Height = 23;
            this.dgvScript.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvScript.Size = new System.Drawing.Size(631, 414);
            this.dgvScript.TabIndex = 0;
            this.dgvScript.CellEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvScript_CellEnter);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(1020, 101);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 4;
            this.button2.Text = "button1";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(1020, 130);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 23);
            this.button3.TabIndex = 4;
            this.button3.Text = "button1";
            this.button3.UseVisualStyleBackColor = true;
            // 
            // pagingScript
            // 
            this.pagingScript.BackColor = System.Drawing.Color.PowderBlue;
            this.pagingScript.Location = new System.Drawing.Point(-2, 515);
            this.pagingScript.Name = "pagingScript";
            this.pagingScript.PageSize = 100;
            this.pagingScript.RecordCount = 0;
            this.pagingScript.Size = new System.Drawing.Size(1107, 88);
            this.pagingScript.TabIndex = 2;
            this.pagingScript.PageIndexChanged += new System.EventHandler(this.pagingScript_PageIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 12);
            this.label1.TabIndex = 5;
            this.label1.Text = "语言类型：";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 41);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 12);
            this.label2.TabIndex = 5;
            this.label2.Text = "项目名称：";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 67);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 12);
            this.label3.TabIndex = 5;
            this.label3.Text = "类    名：";
            // 
            // ScriptManage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(965, 550);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnFlush);
            this.Controls.Add(this.dgvScript);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.btnSelect);
            this.Controls.Add(this.pagingScript);
            this.Controls.Add(this.grpEdit);
            this.Controls.Add(this.cmbType);
            this.Controls.Add(this.cmbPosition);
            this.Controls.Add(this.cmbProject);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "ScriptManage";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "脚本管理";
            this.Load += new System.EventHandler(this.ScriptManage_Load);
            this.SizeChanged += new System.EventHandler(this.ScriptManage_SizeChanged);
            this.grpEdit.ResumeLayout(false);
            this.grpEdit.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvScript)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox grpEdit;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.TextBox txtEdit;
        private System.Windows.Forms.Label lblEditTypeInfo;
        private System.Windows.Forms.TextBox txtzh_CN;
        private System.Windows.Forms.Label lblzh_CNInfo;
        private System.Windows.Forms.DataGridView dgvScript;
        private WinFormPaging.PagingControl pagingScript;
        private System.Windows.Forms.ComboBox cmbPosition;
        private System.Windows.Forms.ComboBox cmbProject;
        private System.Windows.Forms.ComboBox cmbType;
        private System.Windows.Forms.Button btnFlush;
        private System.Windows.Forms.Button btnSelect;
        private System.Windows.Forms.CheckBox chkWrapSave;
        private System.Windows.Forms.CheckBox chkEnterSave;
        private System.Windows.Forms.CheckBox chkSaveWrap;
        private System.Windows.Forms.CheckBox chkPreviousLine;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
    }
}