namespace LanguagesManage
{
    partial class UpLanguage
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
            this.btnGetType = new System.Windows.Forms.Button();
            this.lblTypeOption = new System.Windows.Forms.Label();
            this.cmbType = new System.Windows.Forms.ComboBox();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.dgvScript = new System.Windows.Forms.DataGridView();
            this.lblPosition = new System.Windows.Forms.Label();
            this.cmbPosition = new System.Windows.Forms.ComboBox();
            this.btnGetPosition = new System.Windows.Forms.Button();
            this.pagingControl1 = new WinFormPaging.PagingControl();
            this.butOut = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvScript)).BeginInit();
            this.SuspendLayout();
            // 
            // btnGetType
            // 
            this.btnGetType.Location = new System.Drawing.Point(601, 9);
            this.btnGetType.Name = "btnGetType";
            this.btnGetType.Size = new System.Drawing.Size(87, 27);
            this.btnGetType.TabIndex = 3;
            this.btnGetType.Text = "确定";
            this.btnGetType.UseVisualStyleBackColor = true;
            this.btnGetType.Click += new System.EventHandler(this.btnGetType_Click);
            // 
            // lblTypeOption
            // 
            this.lblTypeOption.AutoSize = true;
            this.lblTypeOption.Location = new System.Drawing.Point(336, 15);
            this.lblTypeOption.Name = "lblTypeOption";
            this.lblTypeOption.Size = new System.Drawing.Size(63, 14);
            this.lblTypeOption.TabIndex = 2;
            this.lblTypeOption.Text = "显示语言";
            // 
            // cmbType
            // 
            this.cmbType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbType.FormattingEnabled = true;
            this.cmbType.Location = new System.Drawing.Point(405, 11);
            this.cmbType.Name = "cmbType";
            this.cmbType.Size = new System.Drawing.Size(181, 22);
            this.cmbType.TabIndex = 1;
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(892, 40);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(61, 35);
            this.btnCancel.TabIndex = 2;
            this.btnCancel.Text = "取消";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.Cancelbtn_Click);
            // 
            // btnUpdate
            // 
            this.btnUpdate.Location = new System.Drawing.Point(825, 40);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(61, 35);
            this.btnUpdate.TabIndex = 1;
            this.btnUpdate.Text = "更新";
            this.btnUpdate.UseVisualStyleBackColor = true;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // dgvScript
            // 
            this.dgvScript.AllowUserToAddRows = false;
            this.dgvScript.AllowUserToDeleteRows = false;
            this.dgvScript.BackgroundColor = System.Drawing.SystemColors.ActiveBorder;
            this.dgvScript.Location = new System.Drawing.Point(12, 81);
            this.dgvScript.Name = "dgvScript";
            this.dgvScript.RowTemplate.Height = 23;
            this.dgvScript.Size = new System.Drawing.Size(946, 469);
            this.dgvScript.TabIndex = 0;
            this.dgvScript.CellBeginEdit += new System.Windows.Forms.DataGridViewCellCancelEventHandler(this.dgvUpdateScript_CellBeginEdit);
            this.dgvScript.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvUpdateScript_CellEndEdit);
            // 
            // lblPosition
            // 
            this.lblPosition.AutoSize = true;
            this.lblPosition.Location = new System.Drawing.Point(19, 15);
            this.lblPosition.Name = "lblPosition";
            this.lblPosition.Size = new System.Drawing.Size(35, 14);
            this.lblPosition.TabIndex = 4;
            this.lblPosition.Text = "类名";
            // 
            // cmbPosition
            // 
            this.cmbPosition.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbPosition.FormattingEnabled = true;
            this.cmbPosition.Location = new System.Drawing.Point(60, 12);
            this.cmbPosition.Name = "cmbPosition";
            this.cmbPosition.Size = new System.Drawing.Size(189, 22);
            this.cmbPosition.TabIndex = 5;
            // 
            // btnGetPosition
            // 
            this.btnGetPosition.Location = new System.Drawing.Point(255, 10);
            this.btnGetPosition.Name = "btnGetPosition";
            this.btnGetPosition.Size = new System.Drawing.Size(75, 23);
            this.btnGetPosition.TabIndex = 6;
            this.btnGetPosition.Text = "确定";
            this.btnGetPosition.UseVisualStyleBackColor = true;
            this.btnGetPosition.Click += new System.EventHandler(this.btnGetPosition_Click);
            // 
            // pagingControl1
            // 
            this.pagingControl1.Location = new System.Drawing.Point(12, 39);
            this.pagingControl1.Name = "pagingControl1";
            this.pagingControl1.RecordCount = 0;
            this.pagingControl1.Size = new System.Drawing.Size(745, 36);
            this.pagingControl1.TabIndex = 8;
            // 
            // butOut
            // 
            this.butOut.Location = new System.Drawing.Point(878, 4);
            this.butOut.Name = "butOut";
            this.butOut.Size = new System.Drawing.Size(75, 35);
            this.butOut.TabIndex = 7;
            this.butOut.Text = "退出";
            this.butOut.UseVisualStyleBackColor = true;
            this.butOut.Click += new System.EventHandler(this.butOut_Click);
            // 
            // UpLanguage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(962, 562);
            this.Controls.Add(this.pagingControl1);
            this.Controls.Add(this.butOut);
            this.Controls.Add(this.btnGetPosition);
            this.Controls.Add(this.cmbPosition);
            this.Controls.Add(this.lblPosition);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnUpdate);
            this.Controls.Add(this.btnGetType);
            this.Controls.Add(this.dgvScript);
            this.Controls.Add(this.lblTypeOption);
            this.Controls.Add(this.cmbType);
            this.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.MaximizeBox = false;
            this.Name = "UpLanguage";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "脚本管理";
            this.Load += new System.EventHandler(this.UpLanguage_Load);
            this.SizeChanged += new System.EventHandler(this.UpLanguage_SizeChanged);
            ((System.ComponentModel.ISupportInitialize)(this.dgvScript)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.DataGridView dgvScript;
        private System.Windows.Forms.Label lblTypeOption;
        private System.Windows.Forms.ComboBox cmbType;
        private System.Windows.Forms.Button btnGetType;
        private System.Windows.Forms.Label lblPosition;
        private System.Windows.Forms.ComboBox cmbPosition;
        private System.Windows.Forms.Button btnGetPosition;
        private WinFormPaging.PagingControl pagingControl1;
        private System.Windows.Forms.Button butOut;
    }
}