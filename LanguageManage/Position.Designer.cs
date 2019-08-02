namespace LanguagesManage
{
    partial class Position
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
            this.dgvPosition = new System.Windows.Forms.DataGridView();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.txtPosition = new System.Windows.Forms.TextBox();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.cmbAddProjects = new System.Windows.Forms.ComboBox();
            this.cmbProjects = new System.Windows.Forms.ComboBox();
            this.btnGetProjects = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lblPositionID = new System.Windows.Forms.Label();
            this.lblAddTime = new System.Windows.Forms.Label();
            this.lblUpdate = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.lblAdmin = new System.Windows.Forms.Label();
            this.txtPositionID = new System.Windows.Forms.TextBox();
            this.btnEdit = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPosition)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvPosition
            // 
            this.dgvPosition.AllowUserToAddRows = false;
            this.dgvPosition.AllowUserToDeleteRows = false;
            this.dgvPosition.BackgroundColor = System.Drawing.SystemColors.ActiveBorder;
            this.dgvPosition.Location = new System.Drawing.Point(14, 45);
            this.dgvPosition.MultiSelect = false;
            this.dgvPosition.Name = "dgvPosition";
            this.dgvPosition.ReadOnly = true;
            this.dgvPosition.RowTemplate.Height = 23;
            this.dgvPosition.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvPosition.Size = new System.Drawing.Size(432, 348);
            this.dgvPosition.TabIndex = 0;
            this.dgvPosition.TabStop = false;
            this.dgvPosition.CellEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvPosition_CellEnter);
            this.dgvPosition.RowStateChanged += new System.Windows.Forms.DataGridViewRowStateChangedEventHandler(this.dgvPosition_RowStateChanged);
            // 
            // btnUpdate
            // 
            this.btnUpdate.Location = new System.Drawing.Point(694, 329);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(75, 35);
            this.btnUpdate.TabIndex = 6;
            this.btnUpdate.Text = "保存";
            this.btnUpdate.UseVisualStyleBackColor = true;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(532, 329);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(75, 35);
            this.btnAdd.TabIndex = 4;
            this.btnAdd.Text = "添加";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // txtPosition
            // 
            this.txtPosition.Location = new System.Drawing.Point(546, 144);
            this.txtPosition.Name = "txtPosition";
            this.txtPosition.ReadOnly = true;
            this.txtPosition.Size = new System.Drawing.Size(219, 23);
            this.txtPosition.TabIndex = 2;
            // 
            // btnRefresh
            // 
            this.btnRefresh.Location = new System.Drawing.Point(359, 14);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(87, 27);
            this.btnRefresh.TabIndex = 3;
            this.btnRefresh.Text = "刷新";
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // cmbAddProjects
            // 
            this.cmbAddProjects.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbAddProjects.Enabled = false;
            this.cmbAddProjects.FormattingEnabled = true;
            this.cmbAddProjects.Location = new System.Drawing.Point(546, 99);
            this.cmbAddProjects.Name = "cmbAddProjects";
            this.cmbAddProjects.Size = new System.Drawing.Size(219, 22);
            this.cmbAddProjects.TabIndex = 0;
            // 
            // cmbProjects
            // 
            this.cmbProjects.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbProjects.FormattingEnabled = true;
            this.cmbProjects.Location = new System.Drawing.Point(14, 17);
            this.cmbProjects.Name = "cmbProjects";
            this.cmbProjects.Size = new System.Drawing.Size(246, 22);
            this.cmbProjects.TabIndex = 4;
            // 
            // btnGetProjects
            // 
            this.btnGetProjects.Location = new System.Drawing.Point(266, 14);
            this.btnGetProjects.Name = "btnGetProjects";
            this.btnGetProjects.Size = new System.Drawing.Size(87, 27);
            this.btnGetProjects.TabIndex = 5;
            this.btnGetProjects.Text = "确定";
            this.btnGetProjects.UseVisualStyleBackColor = true;
            this.btnGetProjects.Click += new System.EventHandler(this.btnGetProjects_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(463, 102);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 14);
            this.label1.TabIndex = 6;
            this.label1.Text = "项目名称：";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(463, 147);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(63, 14);
            this.label2.TabIndex = 7;
            this.label2.Text = "类 名 ：";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(463, 63);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(28, 14);
            this.label3.TabIndex = 8;
            this.label3.Text = "I D";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(463, 191);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(63, 14);
            this.label4.TabIndex = 8;
            this.label4.Text = "添加时间";
            // 
            // lblPositionID
            // 
            this.lblPositionID.AutoSize = true;
            this.lblPositionID.Location = new System.Drawing.Point(685, 63);
            this.lblPositionID.Name = "lblPositionID";
            this.lblPositionID.Size = new System.Drawing.Size(14, 14);
            this.lblPositionID.TabIndex = 9;
            this.lblPositionID.Text = ".";
            // 
            // lblAddTime
            // 
            this.lblAddTime.AutoSize = true;
            this.lblAddTime.Location = new System.Drawing.Point(543, 191);
            this.lblAddTime.Name = "lblAddTime";
            this.lblAddTime.Size = new System.Drawing.Size(14, 14);
            this.lblAddTime.TabIndex = 8;
            this.lblAddTime.Text = ".";
            // 
            // lblUpdate
            // 
            this.lblUpdate.AutoSize = true;
            this.lblUpdate.Location = new System.Drawing.Point(544, 235);
            this.lblUpdate.Name = "lblUpdate";
            this.lblUpdate.Size = new System.Drawing.Size(14, 14);
            this.lblUpdate.TabIndex = 8;
            this.lblUpdate.Text = ".";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(464, 235);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(63, 14);
            this.label7.TabIndex = 8;
            this.label7.Text = "更新时间";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(463, 271);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(63, 14);
            this.label8.TabIndex = 8;
            this.label8.Text = "操作人员";
            // 
            // lblAdmin
            // 
            this.lblAdmin.AutoSize = true;
            this.lblAdmin.Location = new System.Drawing.Point(543, 271);
            this.lblAdmin.Name = "lblAdmin";
            this.lblAdmin.Size = new System.Drawing.Size(14, 14);
            this.lblAdmin.TabIndex = 8;
            this.lblAdmin.Text = ".";
            // 
            // txtPositionID
            // 
            this.txtPositionID.Location = new System.Drawing.Point(546, 60);
            this.txtPositionID.Name = "txtPositionID";
            this.txtPositionID.ReadOnly = true;
            this.txtPositionID.Size = new System.Drawing.Size(100, 23);
            this.txtPositionID.TabIndex = 10;
            // 
            // btnEdit
            // 
            this.btnEdit.Location = new System.Drawing.Point(452, 329);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(75, 35);
            this.btnEdit.TabIndex = 3;
            this.btnEdit.Text = "编辑";
            this.btnEdit.UseVisualStyleBackColor = true;
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(613, 329);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 35);
            this.btnCancel.TabIndex = 5;
            this.btnCancel.Text = "取消";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // Position
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(777, 404);
            this.Controls.Add(this.btnEdit);
            this.Controls.Add(this.txtPositionID);
            this.Controls.Add(this.lblPositionID);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.lblAdmin);
            this.Controls.Add(this.lblUpdate);
            this.Controls.Add(this.lblAddTime);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnGetProjects);
            this.Controls.Add(this.cmbProjects);
            this.Controls.Add(this.cmbAddProjects);
            this.Controls.Add(this.btnRefresh);
            this.Controls.Add(this.txtPosition);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnUpdate);
            this.Controls.Add(this.dgvPosition);
            this.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "Position";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "类管理";
            this.Load += new System.EventHandler(this.Position_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvPosition)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvPosition;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.TextBox txtPosition;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.ComboBox cmbAddProjects;
        private System.Windows.Forms.ComboBox cmbProjects;
        private System.Windows.Forms.Button btnGetProjects;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lblPositionID;
        private System.Windows.Forms.Label lblAddTime;
        private System.Windows.Forms.Label lblUpdate;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label lblAdmin;
        private System.Windows.Forms.TextBox txtPositionID;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.Button btnCancel;
    }
}