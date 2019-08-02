namespace LanguagesManage
{
    partial class Login
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

        private void InitializeComponent()
        {
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblName = new System.Windows.Forms.Label();
            this.lblPwd = new System.Windows.Forms.Label();
            this.txtName = new System.Windows.Forms.TextBox();
            this.txtPwd = new System.Windows.Forms.TextBox();
            this.btnLogin = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.lblHint = new System.Windows.Forms.Label();
            this.cmbType = new System.Windows.Forms.ComboBox();
            this.lblLanguage = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("宋体", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblTitle.Location = new System.Drawing.Point(45, 24);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(246, 33);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "多语言管理系统";
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblName.Location = new System.Drawing.Point(37, 122);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(89, 20);
            this.lblName.TabIndex = 1;
            this.lblName.Text = "用户名：";
            // 
            // lblPwd
            // 
            this.lblPwd.AutoSize = true;
            this.lblPwd.Font = new System.Drawing.Font("宋体", 15F);
            this.lblPwd.Location = new System.Drawing.Point(37, 181);
            this.lblPwd.Name = "lblPwd";
            this.lblPwd.Size = new System.Drawing.Size(89, 20);
            this.lblPwd.TabIndex = 2;
            this.lblPwd.Text = "密  码：";
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(132, 126);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(169, 21);
            this.txtName.TabIndex = 3;
            // 
            // txtPwd
            // 
            this.txtPwd.Location = new System.Drawing.Point(130, 180);
            this.txtPwd.Name = "txtPwd";
            this.txtPwd.PasswordChar = '*';
            this.txtPwd.Size = new System.Drawing.Size(171, 21);
            this.txtPwd.TabIndex = 4;
            // 
            // btnLogin
            // 
            this.btnLogin.Font = new System.Drawing.Font("宋体", 15F);
            this.btnLogin.Location = new System.Drawing.Point(25, 245);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Size = new System.Drawing.Size(87, 34);
            this.btnLogin.TabIndex = 5;
            this.btnLogin.Text = "登录";
            this.btnLogin.UseVisualStyleBackColor = true;
            this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click);
            // 
            // btnClose
            // 
            this.btnClose.Font = new System.Drawing.Font("宋体", 15F);
            this.btnClose.Location = new System.Drawing.Point(214, 245);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(87, 34);
            this.btnClose.TabIndex = 6;
            this.btnClose.Text = "退出";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // lblHint
            // 
            this.lblHint.AutoSize = true;
            this.lblHint.ForeColor = System.Drawing.Color.Red;
            this.lblHint.Location = new System.Drawing.Point(107, 221);
            this.lblHint.Name = "lblHint";
            this.lblHint.Size = new System.Drawing.Size(0, 12);
            this.lblHint.TabIndex = 7;
            // 
            // cmbType
            // 
            this.cmbType.FormattingEnabled = true;
            this.cmbType.Location = new System.Drawing.Point(130, 75);
            this.cmbType.Name = "cmbType";
            this.cmbType.Size = new System.Drawing.Size(171, 20);
            this.cmbType.TabIndex = 8;
            this.cmbType.SelectedIndexChanged += new System.EventHandler(this.cmbType_SelectedIndexChanged);
            // 
            // lblLanguage
            // 
            this.lblLanguage.AutoSize = true;
            this.lblLanguage.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblLanguage.Location = new System.Drawing.Point(37, 75);
            this.lblLanguage.Name = "lblLanguage";
            this.lblLanguage.Size = new System.Drawing.Size(89, 20);
            this.lblLanguage.TabIndex = 9;
            this.lblLanguage.Text = "选择语言";
            // 
            // Login
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(342, 295);
            this.Controls.Add(this.lblLanguage);
            this.Controls.Add(this.cmbType);
            this.Controls.Add(this.lblHint);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnLogin);
            this.Controls.Add(this.txtPwd);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.lblPwd);
            this.Controls.Add(this.lblName);
            this.Controls.Add(this.lblTitle);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "Login";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "登录";
            this.Load += new System.EventHandler(this.Login_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.Label lblPwd;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.TextBox txtPwd;
        private System.Windows.Forms.Button btnLogin;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Label lblHint;
        private System.Windows.Forms.ComboBox cmbType;
        private System.Windows.Forms.Label lblLanguage;
    }
}
