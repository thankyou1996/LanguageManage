namespace LanguagesManage
{
    partial class CodeFilter_Resx
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
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dgvStrContent = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.lblStrNum = new System.Windows.Forms.Label();
            this.btnAllSelected = new System.Windows.Forms.Button();
            this.chkOnlyChines = new System.Windows.Forms.CheckBox();
            this.button1 = new System.Windows.Forms.Button();
            this.btnMulti = new System.Windows.Forms.Button();
            this.lstPath = new System.Windows.Forms.ListBox();
            this.btnRemoveAll = new System.Windows.Forms.Button();
            this.btnRemove = new System.Windows.Forms.Button();
            this.chkControl = new System.Windows.Forms.CheckBox();
            this.btnDbInputs = new System.Windows.Forms.Button();
            this.btnReplaces = new System.Windows.Forms.Button();
            this.btnFlushs = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.rdoXml = new System.Windows.Forms.RadioButton();
            this.rdoDb = new System.Windows.Forms.RadioButton();
            this.chkSql = new System.Windows.Forms.CheckBox();
            this.chkFontSet = new System.Windows.Forms.CheckBox();
            this.chkImageSet = new System.Windows.Forms.CheckBox();
            this.cmbProject = new System.Windows.Forms.ComboBox();
            this.btnGuideBack = new System.Windows.Forms.Button();
            this.cmbResx = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvStrContent)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvStrContent
            // 
            this.dgvStrContent.AllowUserToAddRows = false;
            this.dgvStrContent.AllowUserToDeleteRows = false;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.dgvStrContent.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvStrContent.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvStrContent.BackgroundColor = System.Drawing.SystemColors.ActiveBorder;
            this.dgvStrContent.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgvStrContent.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvStrContent.Location = new System.Drawing.Point(12, 241);
            this.dgvStrContent.Name = "dgvStrContent";
            this.dgvStrContent.RowTemplate.Height = 23;
            this.dgvStrContent.Size = new System.Drawing.Size(603, 406);
            this.dgvStrContent.TabIndex = 3;
            this.dgvStrContent.CellMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dataGridView1_CellMouseDoubleClick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(10, 218);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 12);
            this.label1.TabIndex = 6;
            this.label1.Text = "数量:";
            // 
            // lblStrNum
            // 
            this.lblStrNum.AutoSize = true;
            this.lblStrNum.Location = new System.Drawing.Point(51, 218);
            this.lblStrNum.Name = "lblStrNum";
            this.lblStrNum.Size = new System.Drawing.Size(11, 12);
            this.lblStrNum.TabIndex = 7;
            this.lblStrNum.Text = "0";
            // 
            // btnAllSelected
            // 
            this.btnAllSelected.Location = new System.Drawing.Point(552, 214);
            this.btnAllSelected.Name = "btnAllSelected";
            this.btnAllSelected.Size = new System.Drawing.Size(63, 23);
            this.btnAllSelected.TabIndex = 9;
            this.btnAllSelected.Text = "反选";
            this.btnAllSelected.UseVisualStyleBackColor = true;
            this.btnAllSelected.Click += new System.EventHandler(this.btnAllSelected_Click);
            // 
            // chkOnlyChines
            // 
            this.chkOnlyChines.AutoSize = true;
            this.chkOnlyChines.Checked = true;
            this.chkOnlyChines.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkOnlyChines.Location = new System.Drawing.Point(122, 217);
            this.chkOnlyChines.Name = "chkOnlyChines";
            this.chkOnlyChines.Size = new System.Drawing.Size(60, 16);
            this.chkOnlyChines.TabIndex = 12;
            this.chkOnlyChines.Text = "仅中文";
            this.chkOnlyChines.UseVisualStyleBackColor = true;
            this.chkOnlyChines.CheckedChanged += new System.EventHandler(this.chkOnlyChines_CheckedChanged);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(471, 213);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 13;
            this.button1.Text = "查看文件";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnMulti
            // 
            this.btnMulti.Location = new System.Drawing.Point(12, 12);
            this.btnMulti.Name = "btnMulti";
            this.btnMulti.Size = new System.Drawing.Size(75, 23);
            this.btnMulti.TabIndex = 14;
            this.btnMulti.Text = "选择文件";
            this.btnMulti.UseVisualStyleBackColor = true;
            this.btnMulti.Click += new System.EventHandler(this.btnMulti_Click);
            // 
            // lstPath
            // 
            this.lstPath.AllowDrop = true;
            this.lstPath.FormattingEnabled = true;
            this.lstPath.ItemHeight = 12;
            this.lstPath.Location = new System.Drawing.Point(12, 73);
            this.lstPath.Name = "lstPath";
            this.lstPath.Size = new System.Drawing.Size(520, 136);
            this.lstPath.TabIndex = 15;
            this.lstPath.DragDrop += new System.Windows.Forms.DragEventHandler(this.LstPath_DragDrop);
            this.lstPath.DragEnter += new System.Windows.Forms.DragEventHandler(this.LstPath_DragEnter);
            // 
            // btnRemoveAll
            // 
            this.btnRemoveAll.Location = new System.Drawing.Point(538, 144);
            this.btnRemoveAll.Name = "btnRemoveAll";
            this.btnRemoveAll.Size = new System.Drawing.Size(71, 27);
            this.btnRemoveAll.TabIndex = 17;
            this.btnRemoveAll.Text = "清空";
            this.btnRemoveAll.UseVisualStyleBackColor = true;
            this.btnRemoveAll.Click += new System.EventHandler(this.btnRemoveAll_Click);
            // 
            // btnRemove
            // 
            this.btnRemove.Location = new System.Drawing.Point(538, 73);
            this.btnRemove.Name = "btnRemove";
            this.btnRemove.Size = new System.Drawing.Size(71, 27);
            this.btnRemove.TabIndex = 18;
            this.btnRemove.Text = "移除";
            this.btnRemove.UseVisualStyleBackColor = true;
            this.btnRemove.Click += new System.EventHandler(this.btnRemove_Click);
            // 
            // chkControl
            // 
            this.chkControl.AutoSize = true;
            this.chkControl.Location = new System.Drawing.Point(242, 217);
            this.chkControl.Name = "chkControl";
            this.chkControl.Size = new System.Drawing.Size(72, 16);
            this.chkControl.TabIndex = 19;
            this.chkControl.Text = "控件名称";
            this.chkControl.UseVisualStyleBackColor = true;
            this.chkControl.CheckedChanged += new System.EventHandler(this.chkControl_CheckedChanged);
            // 
            // btnDbInputs
            // 
            this.btnDbInputs.Location = new System.Drawing.Point(93, 12);
            this.btnDbInputs.Name = "btnDbInputs";
            this.btnDbInputs.Size = new System.Drawing.Size(89, 23);
            this.btnDbInputs.TabIndex = 20;
            this.btnDbInputs.Text = "添加至数据库";
            this.btnDbInputs.UseVisualStyleBackColor = true;
            this.btnDbInputs.Click += new System.EventHandler(this.btnDbInputs_Click);
            // 
            // btnReplaces
            // 
            this.btnReplaces.Location = new System.Drawing.Point(188, 12);
            this.btnReplaces.Name = "btnReplaces";
            this.btnReplaces.Size = new System.Drawing.Size(75, 23);
            this.btnReplaces.TabIndex = 21;
            this.btnReplaces.Text = "替换";
            this.btnReplaces.UseVisualStyleBackColor = true;
            this.btnReplaces.Click += new System.EventHandler(this.btnReplaces_Click);
            // 
            // btnFlushs
            // 
            this.btnFlushs.Location = new System.Drawing.Point(538, 179);
            this.btnFlushs.Name = "btnFlushs";
            this.btnFlushs.Size = new System.Drawing.Size(71, 27);
            this.btnFlushs.TabIndex = 22;
            this.btnFlushs.Text = "刷新";
            this.btnFlushs.UseVisualStyleBackColor = true;
            this.btnFlushs.Click += new System.EventHandler(this.btnFlushs_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(538, 106);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(71, 27);
            this.btnAdd.TabIndex = 23;
            this.btnAdd.Text = "添加";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // rdoXml
            // 
            this.rdoXml.AutoSize = true;
            this.rdoXml.Location = new System.Drawing.Point(339, 15);
            this.rdoXml.Name = "rdoXml";
            this.rdoXml.Size = new System.Drawing.Size(65, 16);
            this.rdoXml.TabIndex = 24;
            this.rdoXml.TabStop = true;
            this.rdoXml.Text = "Xml文件";
            this.rdoXml.UseVisualStyleBackColor = true;
            // 
            // rdoDb
            // 
            this.rdoDb.AutoSize = true;
            this.rdoDb.Checked = true;
            this.rdoDb.Location = new System.Drawing.Point(274, 15);
            this.rdoDb.Name = "rdoDb";
            this.rdoDb.Size = new System.Drawing.Size(59, 16);
            this.rdoDb.TabIndex = 25;
            this.rdoDb.TabStop = true;
            this.rdoDb.Text = "数据库";
            this.rdoDb.UseVisualStyleBackColor = true;
            this.rdoDb.CheckedChanged += new System.EventHandler(this.rdoDb_CheckedChanged);
            // 
            // chkSql
            // 
            this.chkSql.AutoSize = true;
            this.chkSql.Location = new System.Drawing.Point(320, 217);
            this.chkSql.Name = "chkSql";
            this.chkSql.Size = new System.Drawing.Size(66, 16);
            this.chkSql.TabIndex = 26;
            this.chkSql.Text = "SQL语句";
            this.chkSql.UseVisualStyleBackColor = true;
            this.chkSql.CheckedChanged += new System.EventHandler(this.chkSql_CheckedChanged);
            // 
            // chkFontSet
            // 
            this.chkFontSet.AutoSize = true;
            this.chkFontSet.Location = new System.Drawing.Point(188, 217);
            this.chkFontSet.Name = "chkFontSet";
            this.chkFontSet.Size = new System.Drawing.Size(48, 16);
            this.chkFontSet.TabIndex = 27;
            this.chkFontSet.Text = "字体";
            this.chkFontSet.UseVisualStyleBackColor = true;
            this.chkFontSet.CheckedChanged += new System.EventHandler(this.chkFontSet_CheckedChanged);
            // 
            // chkImageSet
            // 
            this.chkImageSet.AutoSize = true;
            this.chkImageSet.Location = new System.Drawing.Point(392, 217);
            this.chkImageSet.Name = "chkImageSet";
            this.chkImageSet.Size = new System.Drawing.Size(72, 16);
            this.chkImageSet.TabIndex = 28;
            this.chkImageSet.Text = "图片设置";
            this.chkImageSet.UseVisualStyleBackColor = true;
            this.chkImageSet.CheckedChanged += new System.EventHandler(this.chkImageSet_CheckedChanged);
            // 
            // cmbProject
            // 
            this.cmbProject.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbProject.FormattingEnabled = true;
            this.cmbProject.Location = new System.Drawing.Point(12, 41);
            this.cmbProject.Name = "cmbProject";
            this.cmbProject.Size = new System.Drawing.Size(251, 20);
            this.cmbProject.TabIndex = 29;
            this.cmbProject.SelectedIndexChanged += new System.EventHandler(this.cmbProject_SelectedIndexChanged);
            // 
            // btnGuideBack
            // 
            this.btnGuideBack.Location = new System.Drawing.Point(538, 12);
            this.btnGuideBack.Name = "btnGuideBack";
            this.btnGuideBack.Size = new System.Drawing.Size(72, 23);
            this.btnGuideBack.TabIndex = 30;
            this.btnGuideBack.Text = "导回";
            this.btnGuideBack.UseVisualStyleBackColor = true;
            this.btnGuideBack.Click += new System.EventHandler(this.btnGuideBack_Click);
            // 
            // cmbResx
            // 
            this.cmbResx.FormattingEnabled = true;
            this.cmbResx.Location = new System.Drawing.Point(320, 41);
            this.cmbResx.Name = "cmbResx";
            this.cmbResx.Size = new System.Drawing.Size(147, 20);
            this.cmbResx.TabIndex = 31;
            // 
            // CodeFilter_Resx
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(622, 659);
            this.Controls.Add(this.cmbResx);
            this.Controls.Add(this.btnGuideBack);
            this.Controls.Add(this.cmbProject);
            this.Controls.Add(this.chkImageSet);
            this.Controls.Add(this.chkFontSet);
            this.Controls.Add(this.chkSql);
            this.Controls.Add(this.rdoXml);
            this.Controls.Add(this.rdoDb);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.btnFlushs);
            this.Controls.Add(this.btnReplaces);
            this.Controls.Add(this.btnDbInputs);
            this.Controls.Add(this.chkControl);
            this.Controls.Add(this.btnRemove);
            this.Controls.Add(this.btnRemoveAll);
            this.Controls.Add(this.lstPath);
            this.Controls.Add(this.btnMulti);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.chkOnlyChines);
            this.Controls.Add(this.btnAllSelected);
            this.Controls.Add(this.lblStrNum);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dgvStrContent);
            this.Name = "CodeFilter_Resx";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "源码过滤";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.SizeChanged += new System.EventHandler(this.Form1_SizeChanged);
            ((System.ComponentModel.ISupportInitialize)(this.dgvStrContent)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvStrContent;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblStrNum;
        private System.Windows.Forms.Button btnAllSelected;
        private System.Windows.Forms.CheckBox chkOnlyChines;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button btnMulti;
        private System.Windows.Forms.ListBox lstPath;
        private System.Windows.Forms.Button btnRemoveAll;
        private System.Windows.Forms.Button btnRemove;
        private System.Windows.Forms.CheckBox chkControl;
        private System.Windows.Forms.Button btnDbInputs;
        private System.Windows.Forms.Button btnReplaces;
        private System.Windows.Forms.Button btnFlushs;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.RadioButton rdoXml;
        private System.Windows.Forms.RadioButton rdoDb;
        private System.Windows.Forms.CheckBox chkSql;
        private System.Windows.Forms.CheckBox chkFontSet;
        private System.Windows.Forms.CheckBox chkImageSet;
        private System.Windows.Forms.ComboBox cmbProject;
        private System.Windows.Forms.Button btnGuideBack;
        private System.Windows.Forms.ComboBox cmbResx;
    }
}

