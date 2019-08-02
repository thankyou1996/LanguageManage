namespace LanguagesManage
{
    partial class Type
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Type));
            this.dgvType = new System.Windows.Forms.DataGridView();
            this.txtLanguageName = new System.Windows.Forms.TextBox();
            this.txtLanguageName2 = new System.Windows.Forms.TextBox();
            this.lblLanguageName = new System.Windows.Forms.Label();
            this.lblLanguageName2 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnFlush = new System.Windows.Forms.Button();
            this.txtID = new System.Windows.Forms.TextBox();
            this.lblAdmin = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.lblUpdateTime = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lblAddTime = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lblID = new System.Windows.Forms.Label();
            this.txtAbbreviation = new System.Windows.Forms.TextBox();
            this.btnAdd = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.btnEdit = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvType)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvType
            // 
            this.dgvType.AllowUserToAddRows = false;
            this.dgvType.AllowUserToDeleteRows = false;
            this.dgvType.AllowUserToResizeRows = false;
            this.dgvType.BackgroundColor = System.Drawing.SystemColors.ActiveBorder;
            this.dgvType.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvType.Location = new System.Drawing.Point(-2, 2);
            this.dgvType.Name = "dgvType";
            this.dgvType.ReadOnly = true;
            this.dgvType.RowHeadersVisible = false;
            this.dgvType.RowTemplate.Height = 23;
            this.dgvType.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvType.Size = new System.Drawing.Size(349, 385);
            this.dgvType.TabIndex = 0;
            this.dgvType.TabStop = false;
            this.dgvType.CellEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvType_CellEnter);
            // 
            // txtLanguageName
            // 
            this.txtLanguageName.Location = new System.Drawing.Point(87, 60);
            this.txtLanguageName.Name = "txtLanguageName";
            this.txtLanguageName.Size = new System.Drawing.Size(176, 23);
            this.txtLanguageName.TabIndex = 2;
            // 
            // txtLanguageName2
            // 
            this.txtLanguageName2.Location = new System.Drawing.Point(87, 102);
            this.txtLanguageName2.Name = "txtLanguageName2";
            this.txtLanguageName2.Size = new System.Drawing.Size(176, 23);
            this.txtLanguageName2.TabIndex = 3;
            // 
            // lblLanguageName
            // 
            this.lblLanguageName.AutoSize = true;
            this.lblLanguageName.Location = new System.Drawing.Point(3, 63);
            this.lblLanguageName.Name = "lblLanguageName";
            this.lblLanguageName.Size = new System.Drawing.Size(70, 14);
            this.lblLanguageName.TabIndex = 4;
            this.lblLanguageName.Text = "语言名称:";
            // 
            // lblLanguageName2
            // 
            this.lblLanguageName2.AutoSize = true;
            this.lblLanguageName2.Location = new System.Drawing.Point(3, 106);
            this.lblLanguageName2.Name = "lblLanguageName2";
            this.lblLanguageName2.Size = new System.Drawing.Size(70, 14);
            this.lblLanguageName2.TabIndex = 6;
            this.lblLanguageName2.Text = "中文名称:";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnFlush);
            this.panel1.Controls.Add(this.txtID);
            this.panel1.Controls.Add(this.lblAdmin);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.lblUpdateTime);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.lblAddTime);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.lblID);
            this.panel1.Controls.Add(this.txtAbbreviation);
            this.panel1.Controls.Add(this.btnAdd);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.btnEdit);
            this.panel1.Controls.Add(this.btnCancel);
            this.panel1.Controls.Add(this.btnSave);
            this.panel1.Controls.Add(this.lblLanguageName);
            this.panel1.Controls.Add(this.txtLanguageName);
            this.panel1.Controls.Add(this.lblLanguageName2);
            this.panel1.Controls.Add(this.txtLanguageName2);
            this.panel1.Location = new System.Drawing.Point(353, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(269, 375);
            this.panel1.TabIndex = 8;
            // 
            // btnFlush
            // 
            this.btnFlush.Location = new System.Drawing.Point(98, 338);
            this.btnFlush.Name = "btnFlush";
            this.btnFlush.Size = new System.Drawing.Size(75, 35);
            this.btnFlush.TabIndex = 9;
            this.btnFlush.Text = "刷新";
            this.btnFlush.UseVisualStyleBackColor = true;
            this.btnFlush.Click += new System.EventHandler(this.btnFlush_Click);
            // 
            // txtID
            // 
            this.txtID.Location = new System.Drawing.Point(87, 19);
            this.txtID.Name = "txtID";
            this.txtID.ReadOnly = true;
            this.txtID.Size = new System.Drawing.Size(105, 23);
            this.txtID.TabIndex = 11;
            // 
            // lblAdmin
            // 
            this.lblAdmin.AutoSize = true;
            this.lblAdmin.Location = new System.Drawing.Point(87, 259);
            this.lblAdmin.Name = "lblAdmin";
            this.lblAdmin.Size = new System.Drawing.Size(14, 14);
            this.lblAdmin.TabIndex = 10;
            this.lblAdmin.Text = ".";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(3, 259);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(70, 14);
            this.label5.TabIndex = 10;
            this.label5.Text = "操作人员:";
            // 
            // lblUpdateTime
            // 
            this.lblUpdateTime.AutoSize = true;
            this.lblUpdateTime.Location = new System.Drawing.Point(87, 220);
            this.lblUpdateTime.Name = "lblUpdateTime";
            this.lblUpdateTime.Size = new System.Drawing.Size(14, 14);
            this.lblUpdateTime.TabIndex = 10;
            this.lblUpdateTime.Text = ".";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(3, 220);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(70, 14);
            this.label4.TabIndex = 10;
            this.label4.Text = "更新时间:";
            // 
            // lblAddTime
            // 
            this.lblAddTime.AutoSize = true;
            this.lblAddTime.Location = new System.Drawing.Point(87, 187);
            this.lblAddTime.Name = "lblAddTime";
            this.lblAddTime.Size = new System.Drawing.Size(14, 14);
            this.lblAddTime.TabIndex = 10;
            this.lblAddTime.Text = ".";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(3, 187);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(70, 14);
            this.label3.TabIndex = 10;
            this.label3.Text = "添加时间:";
            // 
            // lblID
            // 
            this.lblID.AutoSize = true;
            this.lblID.Location = new System.Drawing.Point(3, 22);
            this.lblID.Name = "lblID";
            this.lblID.Size = new System.Drawing.Size(42, 14);
            this.lblID.TabIndex = 10;
            this.lblID.Text = "I  D:";
            // 
            // txtAbbreviation
            // 
            this.txtAbbreviation.Location = new System.Drawing.Point(87, 142);
            this.txtAbbreviation.Name = "txtAbbreviation";
            this.txtAbbreviation.Size = new System.Drawing.Size(176, 23);
            this.txtAbbreviation.TabIndex = 4;
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(98, 286);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(75, 35);
            this.btnAdd.TabIndex = 6;
            this.btnAdd.Text = "添加";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click_1);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 145);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(70, 14);
            this.label2.TabIndex = 8;
            this.label2.Text = "语言简写:";
            // 
            // btnEdit
            // 
            this.btnEdit.Location = new System.Drawing.Point(6, 286);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(75, 35);
            this.btnEdit.TabIndex = 5;
            this.btnEdit.Text = "编辑";
            this.btnEdit.UseVisualStyleBackColor = true;
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(6, 338);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 35);
            this.btnCancel.TabIndex = 8;
            this.btnCancel.Text = "取消";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click_1);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(188, 286);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 35);
            this.btnSave.TabIndex = 7;
            this.btnSave.Text = "保存";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // Type
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(623, 391);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.dgvType);
            this.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Type";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "语言管理";
            this.Load += new System.EventHandler(this.Type_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvType)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvType;
        private System.Windows.Forms.TextBox txtLanguageName;
        private System.Windows.Forms.TextBox txtLanguageName2;
        private System.Windows.Forms.Label lblLanguageName;
        private System.Windows.Forms.Label lblLanguageName2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox txtAbbreviation;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblID;
        private System.Windows.Forms.TextBox txtID;
        private System.Windows.Forms.Label lblAdmin;
        private System.Windows.Forms.Label lblUpdateTime;
        private System.Windows.Forms.Label lblAddTime;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnFlush;
    }
}