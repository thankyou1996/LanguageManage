namespace LanguagesManage
{
    partial class GuideBackPreview
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GuideBackPreview));
            this.dgvXml = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnGuideBack = new System.Windows.Forms.Button();
            this.lblCreateTime = new System.Windows.Forms.Label();
            this.lblCreater = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtFileName = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtCreateTime = new System.Windows.Forms.TextBox();
            this.txtCreater = new System.Windows.Forms.TextBox();
            this.txtRemarks = new System.Windows.Forms.TextBox();
            this.btnEdit = new System.Windows.Forms.Button();
            this.btnFlush = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvXml)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvXml
            // 
            this.dgvXml.AllowUserToAddRows = false;
            this.dgvXml.AllowUserToDeleteRows = false;
            this.dgvXml.BackgroundColor = System.Drawing.SystemColors.ActiveBorder;
            this.dgvXml.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvXml.Location = new System.Drawing.Point(4, 2);
            this.dgvXml.Name = "dgvXml";
            this.dgvXml.ReadOnly = true;
            this.dgvXml.RowTemplate.Height = 23;
            this.dgvXml.Size = new System.Drawing.Size(669, 536);
            this.dgvXml.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 71);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 12);
            this.label1.TabIndex = 1;
            this.label1.Text = "创 建 人：";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 106);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 12);
            this.label2.TabIndex = 1;
            this.label2.Text = "创建时间：";
            // 
            // btnGuideBack
            // 
            this.btnGuideBack.Location = new System.Drawing.Point(861, 484);
            this.btnGuideBack.Name = "btnGuideBack";
            this.btnGuideBack.Size = new System.Drawing.Size(86, 42);
            this.btnGuideBack.TabIndex = 2;
            this.btnGuideBack.Text = "导回数据库";
            this.btnGuideBack.UseVisualStyleBackColor = true;
            this.btnGuideBack.Click += new System.EventHandler(this.btnGuideBack_Click);
            // 
            // lblCreateTime
            // 
            this.lblCreateTime.AutoSize = true;
            this.lblCreateTime.Location = new System.Drawing.Point(330, 106);
            this.lblCreateTime.Name = "lblCreateTime";
            this.lblCreateTime.Size = new System.Drawing.Size(11, 12);
            this.lblCreateTime.TabIndex = 4;
            this.lblCreateTime.Text = ".";
            // 
            // lblCreater
            // 
            this.lblCreater.AutoSize = true;
            this.lblCreater.Location = new System.Drawing.Point(330, 71);
            this.lblCreater.Name = "lblCreater";
            this.lblCreater.Size = new System.Drawing.Size(11, 12);
            this.lblCreater.TabIndex = 4;
            this.lblCreater.Text = ".";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 144);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(65, 12);
            this.label6.TabIndex = 5;
            this.label6.Text = "备    注：";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtFileName);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.txtCreateTime);
            this.groupBox1.Controls.Add(this.txtCreater);
            this.groupBox1.Controls.Add(this.txtRemarks);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.lblCreateTime);
            this.groupBox1.Controls.Add(this.lblCreater);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Location = new System.Drawing.Point(679, 2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(371, 273);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "文件信息";
            // 
            // txtFileName
            // 
            this.txtFileName.Location = new System.Drawing.Point(86, 34);
            this.txtFileName.Name = "txtFileName";
            this.txtFileName.ReadOnly = true;
            this.txtFileName.Size = new System.Drawing.Size(217, 21);
            this.txtFileName.TabIndex = 9;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 37);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 12);
            this.label3.TabIndex = 8;
            this.label3.Text = "文件名称";
            // 
            // txtCreateTime
            // 
            this.txtCreateTime.Location = new System.Drawing.Point(86, 103);
            this.txtCreateTime.Name = "txtCreateTime";
            this.txtCreateTime.ReadOnly = true;
            this.txtCreateTime.Size = new System.Drawing.Size(217, 21);
            this.txtCreateTime.TabIndex = 7;
            // 
            // txtCreater
            // 
            this.txtCreater.Location = new System.Drawing.Point(86, 68);
            this.txtCreater.Name = "txtCreater";
            this.txtCreater.ReadOnly = true;
            this.txtCreater.Size = new System.Drawing.Size(217, 21);
            this.txtCreater.TabIndex = 7;
            // 
            // txtRemarks
            // 
            this.txtRemarks.Location = new System.Drawing.Point(86, 144);
            this.txtRemarks.Multiline = true;
            this.txtRemarks.Name = "txtRemarks";
            this.txtRemarks.ReadOnly = true;
            this.txtRemarks.Size = new System.Drawing.Size(279, 124);
            this.txtRemarks.TabIndex = 6;
            // 
            // btnEdit
            // 
            this.btnEdit.Location = new System.Drawing.Point(679, 484);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(86, 42);
            this.btnEdit.TabIndex = 7;
            this.btnEdit.Text = "编辑模式";
            this.btnEdit.UseVisualStyleBackColor = true;
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // btnFlush
            // 
            this.btnFlush.Location = new System.Drawing.Point(771, 484);
            this.btnFlush.Name = "btnFlush";
            this.btnFlush.Size = new System.Drawing.Size(84, 42);
            this.btnFlush.TabIndex = 8;
            this.btnFlush.Text = "刷新";
            this.btnFlush.UseVisualStyleBackColor = true;
            this.btnFlush.Click += new System.EventHandler(this.btnFlush_Click);
            // 
            // GuideBackPreview
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1053, 538);
            this.Controls.Add(this.btnFlush);
            this.Controls.Add(this.btnEdit);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnGuideBack);
            this.Controls.Add(this.dgvXml);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "GuideBackPreview";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "导回数据库";
            this.Load += new System.EventHandler(this.GuideBackPreview_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvXml)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvXml;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnGuideBack;
        private System.Windows.Forms.Label lblCreateTime;
        private System.Windows.Forms.Label lblCreater;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtRemarks;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.Button btnFlush;
        private System.Windows.Forms.TextBox txtCreateTime;
        private System.Windows.Forms.TextBox txtCreater;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtFileName;
    }
}