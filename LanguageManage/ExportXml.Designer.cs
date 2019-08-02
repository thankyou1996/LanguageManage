namespace LanguagesManage
{
    partial class ExportXml
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ExportXml));
            this.chklistType = new System.Windows.Forms.CheckedListBox();
            this.btnCreateXml = new System.Windows.Forms.Button();
            this.txtFileName = new System.Windows.Forms.TextBox();
            this.txtInfo = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.chklistProject = new System.Windows.Forms.CheckedListBox();
            this.rdoExportEdit = new System.Windows.Forms.RadioButton();
            this.rdoExportRead = new System.Windows.Forms.RadioButton();
            this.btnOpenEditFile = new System.Windows.Forms.Button();
            this.btnOpenReadFile = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // chklistType
            // 
            this.chklistType.FormattingEnabled = true;
            this.chklistType.Location = new System.Drawing.Point(12, 22);
            this.chklistType.Name = "chklistType";
            this.chklistType.Size = new System.Drawing.Size(217, 228);
            this.chklistType.TabIndex = 0;
            // 
            // btnCreateXml
            // 
            this.btnCreateXml.Location = new System.Drawing.Point(223, 256);
            this.btnCreateXml.Name = "btnCreateXml";
            this.btnCreateXml.Size = new System.Drawing.Size(75, 31);
            this.btnCreateXml.TabIndex = 1;
            this.btnCreateXml.Text = "生成";
            this.btnCreateXml.UseVisualStyleBackColor = true;
            this.btnCreateXml.Click += new System.EventHandler(this.btnCreateXml_Click);
            // 
            // txtFileName
            // 
            this.txtFileName.Location = new System.Drawing.Point(53, 262);
            this.txtFileName.Name = "txtFileName";
            this.txtFileName.Size = new System.Drawing.Size(164, 21);
            this.txtFileName.TabIndex = 2;
            // 
            // txtInfo
            // 
            this.txtInfo.Location = new System.Drawing.Point(53, 290);
            this.txtInfo.Multiline = true;
            this.txtInfo.Name = "txtInfo";
            this.txtInfo.Size = new System.Drawing.Size(245, 74);
            this.txtInfo.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 268);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 12);
            this.label1.TabIndex = 4;
            this.label1.Text = "文件名";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 290);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 12);
            this.label2.TabIndex = 5;
            this.label2.Text = "备注";
            // 
            // chklistProject
            // 
            this.chklistProject.FormattingEnabled = true;
            this.chklistProject.Location = new System.Drawing.Point(235, 22);
            this.chklistProject.Name = "chklistProject";
            this.chklistProject.Size = new System.Drawing.Size(219, 228);
            this.chklistProject.TabIndex = 6;
            // 
            // rdoExportEdit
            // 
            this.rdoExportEdit.AutoSize = true;
            this.rdoExportEdit.Checked = true;
            this.rdoExportEdit.Location = new System.Drawing.Point(304, 266);
            this.rdoExportEdit.Name = "rdoExportEdit";
            this.rdoExportEdit.Size = new System.Drawing.Size(71, 16);
            this.rdoExportEdit.TabIndex = 7;
            this.rdoExportEdit.TabStop = true;
            this.rdoExportEdit.Text = "编辑文件";
            this.rdoExportEdit.UseVisualStyleBackColor = true;
            this.rdoExportEdit.CheckedChanged += new System.EventHandler(this.rdoExportEdit_CheckedChanged);
            // 
            // rdoExportRead
            // 
            this.rdoExportRead.AutoSize = true;
            this.rdoExportRead.Location = new System.Drawing.Point(304, 306);
            this.rdoExportRead.Name = "rdoExportRead";
            this.rdoExportRead.Size = new System.Drawing.Size(71, 16);
            this.rdoExportRead.TabIndex = 7;
            this.rdoExportRead.Text = "读取文件";
            this.rdoExportRead.UseVisualStyleBackColor = true;
            this.rdoExportRead.CheckedChanged += new System.EventHandler(this.rdoExportRead_CheckedChanged);
            // 
            // btnOpenEditFile
            // 
            this.btnOpenEditFile.Location = new System.Drawing.Point(381, 263);
            this.btnOpenEditFile.Name = "btnOpenEditFile";
            this.btnOpenEditFile.Size = new System.Drawing.Size(75, 23);
            this.btnOpenEditFile.TabIndex = 8;
            this.btnOpenEditFile.Text = "打开文件夹";
            this.btnOpenEditFile.UseVisualStyleBackColor = true;
            this.btnOpenEditFile.Click += new System.EventHandler(this.btnOpenEditFile_Click);
            // 
            // btnOpenReadFile
            // 
            this.btnOpenReadFile.Location = new System.Drawing.Point(381, 303);
            this.btnOpenReadFile.Name = "btnOpenReadFile";
            this.btnOpenReadFile.Size = new System.Drawing.Size(75, 23);
            this.btnOpenReadFile.TabIndex = 8;
            this.btnOpenReadFile.Text = "打开文件夹";
            this.btnOpenReadFile.UseVisualStyleBackColor = true;
            this.btnOpenReadFile.Click += new System.EventHandler(this.btnOpenReadFile_Click);
            // 
            // ExportXml
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(466, 376);
            this.Controls.Add(this.btnOpenReadFile);
            this.Controls.Add(this.btnOpenEditFile);
            this.Controls.Add(this.rdoExportRead);
            this.Controls.Add(this.rdoExportEdit);
            this.Controls.Add(this.chklistProject);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtInfo);
            this.Controls.Add(this.txtFileName);
            this.Controls.Add(this.btnCreateXml);
            this.Controls.Add(this.chklistType);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "ExportXml";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "导出文件";
            this.Load += new System.EventHandler(this.ExportXml_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckedListBox chklistType;
        private System.Windows.Forms.Button btnCreateXml;
        private System.Windows.Forms.TextBox txtFileName;
        private System.Windows.Forms.TextBox txtInfo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckedListBox chklistProject;
        private System.Windows.Forms.RadioButton rdoExportEdit;
        private System.Windows.Forms.RadioButton rdoExportRead;
        private System.Windows.Forms.Button btnOpenEditFile;
        private System.Windows.Forms.Button btnOpenReadFile;
    }
}