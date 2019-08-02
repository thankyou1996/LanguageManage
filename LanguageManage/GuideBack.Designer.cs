namespace LanguagesManage
{
    partial class GuideBack
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dgvStrContent = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.lblStrNum = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.btnMulti = new System.Windows.Forms.Button();
            this.lstPath = new System.Windows.Forms.ListBox();
            this.btnRemoveAll = new System.Windows.Forms.Button();
            this.btnRemove = new System.Windows.Forms.Button();
            this.btnReplaces = new System.Windows.Forms.Button();
            this.btnFlushs = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.cmbType = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvStrContent)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvStrContent
            // 
            this.dgvStrContent.AllowUserToAddRows = false;
            this.dgvStrContent.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.dgvStrContent.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
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
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(538, 182);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(71, 27);
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
            this.lstPath.FormattingEnabled = true;
            this.lstPath.ItemHeight = 12;
            this.lstPath.Location = new System.Drawing.Point(12, 49);
            this.lstPath.Name = "lstPath";
            this.lstPath.Size = new System.Drawing.Size(520, 160);
            this.lstPath.TabIndex = 15;
            // 
            // btnRemoveAll
            // 
            this.btnRemoveAll.Location = new System.Drawing.Point(538, 115);
            this.btnRemoveAll.Name = "btnRemoveAll";
            this.btnRemoveAll.Size = new System.Drawing.Size(71, 27);
            this.btnRemoveAll.TabIndex = 17;
            this.btnRemoveAll.Text = "清空";
            this.btnRemoveAll.UseVisualStyleBackColor = true;
            this.btnRemoveAll.Click += new System.EventHandler(this.btnRemoveAll_Click);
            // 
            // btnRemove
            // 
            this.btnRemove.Location = new System.Drawing.Point(538, 49);
            this.btnRemove.Name = "btnRemove";
            this.btnRemove.Size = new System.Drawing.Size(71, 27);
            this.btnRemove.TabIndex = 18;
            this.btnRemove.Text = "移除";
            this.btnRemove.UseVisualStyleBackColor = true;
            this.btnRemove.Click += new System.EventHandler(this.btnRemove_Click);
            // 
            // btnReplaces
            // 
            this.btnReplaces.Location = new System.Drawing.Point(107, 12);
            this.btnReplaces.Name = "btnReplaces";
            this.btnReplaces.Size = new System.Drawing.Size(75, 23);
            this.btnReplaces.TabIndex = 21;
            this.btnReplaces.Text = "导回";
            this.btnReplaces.UseVisualStyleBackColor = true;
            this.btnReplaces.Click += new System.EventHandler(this.btnReplaces_Click);
            // 
            // btnFlushs
            // 
            this.btnFlushs.Location = new System.Drawing.Point(539, 148);
            this.btnFlushs.Name = "btnFlushs";
            this.btnFlushs.Size = new System.Drawing.Size(71, 27);
            this.btnFlushs.TabIndex = 22;
            this.btnFlushs.Text = "刷新";
            this.btnFlushs.UseVisualStyleBackColor = true;
            this.btnFlushs.Click += new System.EventHandler(this.btnFlushs_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(538, 82);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(71, 27);
            this.btnAdd.TabIndex = 23;
            this.btnAdd.Text = "添加";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // cmbType
            // 
            this.cmbType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbType.FormattingEnabled = true;
            this.cmbType.Location = new System.Drawing.Point(203, 14);
            this.cmbType.Name = "cmbType";
            this.cmbType.Size = new System.Drawing.Size(168, 20);
            this.cmbType.TabIndex = 24;
            this.cmbType.SelectedIndexChanged += new System.EventHandler(this.cmbType_SelectedIndexChanged);
            // 
            // GuideBack
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(622, 659);
            this.Controls.Add(this.cmbType);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.btnFlushs);
            this.Controls.Add(this.btnReplaces);
            this.Controls.Add(this.btnRemove);
            this.Controls.Add(this.btnRemoveAll);
            this.Controls.Add(this.lstPath);
            this.Controls.Add(this.btnMulti);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.lblStrNum);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dgvStrContent);
            this.Name = "GuideBack";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "源码导回";
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
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button btnMulti;
        private System.Windows.Forms.ListBox lstPath;
        private System.Windows.Forms.Button btnRemoveAll;
        private System.Windows.Forms.Button btnRemove;
        private System.Windows.Forms.Button btnReplaces;
        private System.Windows.Forms.Button btnFlushs;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.ComboBox cmbType;
    }
}

