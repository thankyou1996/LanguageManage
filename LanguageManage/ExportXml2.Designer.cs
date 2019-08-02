namespace LanguagesManage
{
    partial class ExportXml2
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
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtInfo = new System.Windows.Forms.TextBox();
            this.txtFileName = new System.Windows.Forms.TextBox();
            this.btnCreateXml = new System.Windows.Forms.Button();
            this.chklistType = new System.Windows.Forms.CheckedListBox();
            this.chklistProject = new System.Windows.Forms.CheckedListBox();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(10, 289);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 12);
            this.label2.TabIndex = 11;
            this.label2.Text = "备注";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(10, 258);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 12);
            this.label1.TabIndex = 10;
            this.label1.Text = "文件名";
            // 
            // txtInfo
            // 
            this.txtInfo.Location = new System.Drawing.Point(57, 289);
            this.txtInfo.Multiline = true;
            this.txtInfo.Name = "txtInfo";
            this.txtInfo.Size = new System.Drawing.Size(245, 46);
            this.txtInfo.TabIndex = 9;
            // 
            // txtFileName
            // 
            this.txtFileName.Location = new System.Drawing.Point(57, 255);
            this.txtFileName.Name = "txtFileName";
            this.txtFileName.Size = new System.Drawing.Size(164, 21);
            this.txtFileName.TabIndex = 8;
            this.txtFileName.Text = "LanguageEditXml";
            // 
            // btnCreateXml
            // 
            this.btnCreateXml.Location = new System.Drawing.Point(227, 255);
            this.btnCreateXml.Name = "btnCreateXml";
            this.btnCreateXml.Size = new System.Drawing.Size(75, 31);
            this.btnCreateXml.TabIndex = 7;
            this.btnCreateXml.Text = "生成";
            this.btnCreateXml.UseVisualStyleBackColor = true;
            this.btnCreateXml.Click += new System.EventHandler(this.btnCreateXml_Click);
            // 
            // chklistType
            // 
            this.chklistType.FormattingEnabled = true;
            this.chklistType.Location = new System.Drawing.Point(12, 12);
            this.chklistType.Name = "chklistType";
            this.chklistType.Size = new System.Drawing.Size(243, 228);
            this.chklistType.TabIndex = 6;
            // 
            // chklistProject
            // 
            this.chklistProject.FormattingEnabled = true;
            this.chklistProject.Location = new System.Drawing.Point(261, 12);
            this.chklistProject.Name = "chklistProject";
            this.chklistProject.Size = new System.Drawing.Size(241, 228);
            this.chklistProject.TabIndex = 12;
            // 
            // ExportXml2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(507, 349);
            this.Controls.Add(this.chklistProject);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtInfo);
            this.Controls.Add(this.txtFileName);
            this.Controls.Add(this.btnCreateXml);
            this.Controls.Add(this.chklistType);
            this.Name = "ExportXml2";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ExportXml2";
            this.Load += new System.EventHandler(this.ExportXml2_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtInfo;
        private System.Windows.Forms.TextBox txtFileName;
        private System.Windows.Forms.Button btnCreateXml;
        private System.Windows.Forms.CheckedListBox chklistType;
        private System.Windows.Forms.CheckedListBox chklistProject;
    }
}