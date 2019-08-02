namespace LanguagesManage
{
    partial class FrmResxInfoSet
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
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.txtValue = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtComment = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // richTextBox1
            // 
            this.richTextBox1.Location = new System.Drawing.Point(10, 9);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(919, 392);
            this.richTextBox1.TabIndex = 2;
            this.richTextBox1.Text = "";
            this.richTextBox1.WordWrap = false;
            // 
            // txtValue
            // 
            this.txtValue.Location = new System.Drawing.Point(14, 429);
            this.txtValue.Multiline = true;
            this.txtValue.Name = "txtValue";
            this.txtValue.Size = new System.Drawing.Size(341, 65);
            this.txtValue.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 414);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 12);
            this.label1.TabIndex = 4;
            this.label1.Text = "内容";
            // 
            // txtComment
            // 
            this.txtComment.Location = new System.Drawing.Point(361, 429);
            this.txtComment.Multiline = true;
            this.txtComment.Name = "txtComment";
            this.txtComment.Size = new System.Drawing.Size(337, 65);
            this.txtComment.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(359, 414);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 12);
            this.label2.TabIndex = 4;
            this.label2.Text = "注释";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(579, 502);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(105, 50);
            this.button1.TabIndex = 5;
            this.button1.Text = "保存";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.Button1_Click);
            // 
            // FrmResxInfoSet
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(941, 564);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtComment);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtValue);
            this.Controls.Add(this.richTextBox1);
            this.Name = "FrmResxInfoSet";
            this.Text = "FrmResxInfoSet";
            this.Load += new System.EventHandler(this.FrmResxInfoSet_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.TextBox txtValue;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtComment;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button1;
    }
}