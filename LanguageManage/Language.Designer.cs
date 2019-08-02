namespace LanguagesManage
{
    partial class Language
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Language));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.pagingDgvAllScript = new WinFormPaging.PagingControl();
            this.cmbProject = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.lblLanguage = new System.Windows.Forms.Label();
            this.btnGetType = new System.Windows.Forms.Button();
            this.cmbType = new System.Windows.Forms.ComboBox();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.dgvAllScript = new System.Windows.Forms.DataGridView();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.ssrlbltime = new System.Windows.Forms.ToolStripStatusLabel();
            this.ssrlblAdmin = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripDropDownButton();
            this.AddLanguageMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.UpLanguageMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.TypeMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.positionMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.projectManage = new System.Windows.Forms.ToolStripMenuItem();
            this.OutMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tsddbManage = new System.Windows.Forms.ToolStripDropDownButton();
            this.tsmiProject = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiType = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiBasicScript = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiScript = new System.Windows.Forms.ToolStripMenuItem();
            this.tsddbXmlImAndEx = new System.Windows.Forms.ToolStripDropDownButton();
            this.tsmiXmlExportRead = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiImportEdit = new System.Windows.Forms.ToolStripMenuItem();
            this.tsbCodeFilter = new System.Windows.Forms.ToolStripButton();
            this.tsbSet = new System.Windows.Forms.ToolStripButton();
            this.tsbExit = new System.Windows.Forms.ToolStripButton();
            this.timDateTime = new System.Windows.Forms.Timer(this.components);
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAllScript)).BeginInit();
            this.statusStrip1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.pagingDgvAllScript);
            this.groupBox1.Controls.Add(this.cmbProject);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.lblLanguage);
            this.groupBox1.Controls.Add(this.btnGetType);
            this.groupBox1.Controls.Add(this.cmbType);
            this.groupBox1.Controls.Add(this.btnRefresh);
            this.groupBox1.Controls.Add(this.dgvAllScript);
            this.groupBox1.Location = new System.Drawing.Point(0, 28);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(951, 521);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "数据库现有信息";
            this.groupBox1.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // pagingDgvAllScript
            // 
            this.pagingDgvAllScript.BackColor = System.Drawing.Color.PowderBlue;
            this.pagingDgvAllScript.Location = new System.Drawing.Point(-5, 482);
            this.pagingDgvAllScript.Name = "pagingDgvAllScript";
            this.pagingDgvAllScript.RecordCount = 0;
            this.pagingDgvAllScript.Size = new System.Drawing.Size(958, 54);
            this.pagingDgvAllScript.TabIndex = 7;
            this.pagingDgvAllScript.PageIndexChanged += new System.EventHandler(this.pagingControl1_PageIndexChanged);
            // 
            // cmbProject
            // 
            this.cmbProject.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbProject.FormattingEnabled = true;
            this.cmbProject.Location = new System.Drawing.Point(76, 25);
            this.cmbProject.Name = "cmbProject";
            this.cmbProject.Size = new System.Drawing.Size(220, 22);
            this.cmbProject.TabIndex = 6;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(63, 14);
            this.label1.TabIndex = 5;
            this.label1.Text = "显示项目";
            // 
            // lblLanguage
            // 
            this.lblLanguage.AutoSize = true;
            this.lblLanguage.Location = new System.Drawing.Point(302, 28);
            this.lblLanguage.Name = "lblLanguage";
            this.lblLanguage.Size = new System.Drawing.Size(63, 14);
            this.lblLanguage.TabIndex = 4;
            this.lblLanguage.Text = "显示语言";
            // 
            // btnGetType
            // 
            this.btnGetType.Location = new System.Drawing.Point(597, 20);
            this.btnGetType.Name = "btnGetType";
            this.btnGetType.Size = new System.Drawing.Size(75, 30);
            this.btnGetType.TabIndex = 3;
            this.btnGetType.Text = "确定";
            this.btnGetType.UseVisualStyleBackColor = true;
            this.btnGetType.Click += new System.EventHandler(this.btnGetType_Click);
            // 
            // cmbType
            // 
            this.cmbType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbType.FormattingEnabled = true;
            this.cmbType.Location = new System.Drawing.Point(371, 25);
            this.cmbType.Name = "cmbType";
            this.cmbType.Size = new System.Drawing.Size(220, 22);
            this.cmbType.TabIndex = 2;
            // 
            // btnRefresh
            // 
            this.btnRefresh.Location = new System.Drawing.Point(678, 20);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(75, 30);
            this.btnRefresh.TabIndex = 1;
            this.btnRefresh.Text = "刷新";
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // dgvAllScript
            // 
            this.dgvAllScript.AllowUserToAddRows = false;
            this.dgvAllScript.AllowUserToDeleteRows = false;
            this.dgvAllScript.AllowUserToResizeRows = false;
            this.dgvAllScript.BackgroundColor = System.Drawing.SystemColors.ActiveBorder;
            this.dgvAllScript.GridColor = System.Drawing.Color.MintCream;
            this.dgvAllScript.Location = new System.Drawing.Point(0, 62);
            this.dgvAllScript.Name = "dgvAllScript";
            this.dgvAllScript.ReadOnly = true;
            this.dgvAllScript.RowHeadersVisible = false;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control;
            this.dgvAllScript.RowsDefaultCellStyle = dataGridViewCellStyle4;
            this.dgvAllScript.RowTemplate.Height = 23;
            this.dgvAllScript.Size = new System.Drawing.Size(951, 423);
            this.dgvAllScript.TabIndex = 0;
            // 
            // statusStrip1
            // 
            this.statusStrip1.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ssrlbltime,
            this.ssrlblAdmin});
            this.statusStrip1.Location = new System.Drawing.Point(0, 554);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Padding = new System.Windows.Forms.Padding(1, 0, 16, 0);
            this.statusStrip1.Size = new System.Drawing.Size(953, 22);
            this.statusStrip1.TabIndex = 1;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // ssrlbltime
            // 
            this.ssrlbltime.Name = "ssrlbltime";
            this.ssrlbltime.Size = new System.Drawing.Size(140, 17);
            this.ssrlbltime.Text = "时间：2016年3月17日";
            // 
            // ssrlblAdmin
            // 
            this.ssrlblAdmin.Name = "ssrlblAdmin";
            this.ssrlblAdmin.Size = new System.Drawing.Size(77, 17);
            this.ssrlblAdmin.Text = "操作人员：";
            // 
            // toolStrip1
            // 
            this.toolStrip1.BackColor = System.Drawing.SystemColors.Control;
            this.toolStrip1.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripLabel1,
            this.tsddbManage,
            this.tsddbXmlImAndEx,
            this.tsbCodeFilter,
            this.tsbSet,
            this.tsbExit});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(953, 25);
            this.toolStrip1.TabIndex = 2;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.AddLanguageMenuItem,
            this.UpLanguageMenuItem,
            this.TypeMenuItem,
            this.positionMenuItem,
            this.projectManage,
            this.OutMenuItem});
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(48, 22);
            this.toolStripLabel1.Text = "菜单";
            // 
            // AddLanguageMenuItem
            // 
            this.AddLanguageMenuItem.Name = "AddLanguageMenuItem";
            this.AddLanguageMenuItem.Size = new System.Drawing.Size(158, 22);
            this.AddLanguageMenuItem.Text = "基本语言管理";
            this.AddLanguageMenuItem.Click += new System.EventHandler(this.AddLanguageMenuItem_Click);
            // 
            // UpLanguageMenuItem
            // 
            this.UpLanguageMenuItem.Name = "UpLanguageMenuItem";
            this.UpLanguageMenuItem.Size = new System.Drawing.Size(158, 22);
            this.UpLanguageMenuItem.Text = "语言脚本管理";
            this.UpLanguageMenuItem.Click += new System.EventHandler(this.UpLanguageMenuItem_Click);
            // 
            // TypeMenuItem
            // 
            this.TypeMenuItem.Name = "TypeMenuItem";
            this.TypeMenuItem.Size = new System.Drawing.Size(158, 22);
            this.TypeMenuItem.Text = "语言类型管理";
            this.TypeMenuItem.Click += new System.EventHandler(this.TypeMenuItem_Click);
            // 
            // positionMenuItem
            // 
            this.positionMenuItem.Name = "positionMenuItem";
            this.positionMenuItem.Size = new System.Drawing.Size(158, 22);
            this.positionMenuItem.Text = "类管理";
            this.positionMenuItem.Click += new System.EventHandler(this.positionMenuItem_Click);
            // 
            // projectManage
            // 
            this.projectManage.Name = "projectManage";
            this.projectManage.Size = new System.Drawing.Size(158, 22);
            this.projectManage.Text = "项目管理";
            this.projectManage.Click += new System.EventHandler(this.projectManage_Click);
            // 
            // OutMenuItem
            // 
            this.OutMenuItem.Name = "OutMenuItem";
            this.OutMenuItem.Size = new System.Drawing.Size(158, 22);
            this.OutMenuItem.Text = "退出";
            this.OutMenuItem.Click += new System.EventHandler(this.OutMenuItem_Click);
            // 
            // tsddbManage
            // 
            this.tsddbManage.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiProject,
            this.tsmiType,
            this.tsmiBasicScript,
            this.tsmiScript});
            this.tsddbManage.Image = ((System.Drawing.Image)(resources.GetObject("tsddbManage.Image")));
            this.tsddbManage.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsddbManage.Name = "tsddbManage";
            this.tsddbManage.Size = new System.Drawing.Size(92, 22);
            this.tsddbManage.Text = "信息管理";
            // 
            // tsmiProject
            // 
            this.tsmiProject.Name = "tsmiProject";
            this.tsmiProject.Size = new System.Drawing.Size(130, 22);
            this.tsmiProject.Text = "项目管理";
            this.tsmiProject.Click += new System.EventHandler(this.projectManage_Click);
            // 
            // tsmiType
            // 
            this.tsmiType.Name = "tsmiType";
            this.tsmiType.Size = new System.Drawing.Size(130, 22);
            this.tsmiType.Text = "语言管理";
            this.tsmiType.Click += new System.EventHandler(this.TypeMenuItem_Click);
            // 
            // tsmiBasicScript
            // 
            this.tsmiBasicScript.Name = "tsmiBasicScript";
            this.tsmiBasicScript.Size = new System.Drawing.Size(130, 22);
            this.tsmiBasicScript.Text = "中文管理";
            this.tsmiBasicScript.Click += new System.EventHandler(this.AddLanguageMenuItem_Click);
            // 
            // tsmiScript
            // 
            this.tsmiScript.Name = "tsmiScript";
            this.tsmiScript.Size = new System.Drawing.Size(130, 22);
            this.tsmiScript.Text = "脚本管理";
            this.tsmiScript.Click += new System.EventHandler(this.UpLanguageMenuItem_Click);
            // 
            // tsddbXmlImAndEx
            // 
            this.tsddbXmlImAndEx.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiXmlExportRead,
            this.tsmiImportEdit});
            this.tsddbXmlImAndEx.Image = ((System.Drawing.Image)(resources.GetObject("tsddbXmlImAndEx.Image")));
            this.tsddbXmlImAndEx.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsddbXmlImAndEx.Name = "tsddbXmlImAndEx";
            this.tsddbXmlImAndEx.Size = new System.Drawing.Size(141, 22);
            this.tsddbXmlImAndEx.Text = "Xml文件导入导出";
            // 
            // tsmiXmlExportRead
            // 
            this.tsmiXmlExportRead.Name = "tsmiXmlExportRead";
            this.tsmiXmlExportRead.Size = new System.Drawing.Size(151, 22);
            this.tsmiXmlExportRead.Text = "导出Xml文件";
            this.tsmiXmlExportRead.Click += new System.EventHandler(this.tsbtnExportXml_Click);
            // 
            // tsmiImportEdit
            // 
            this.tsmiImportEdit.Name = "tsmiImportEdit";
            this.tsmiImportEdit.Size = new System.Drawing.Size(151, 22);
            this.tsmiImportEdit.Text = "导入Xml文件";
            this.tsmiImportEdit.Click += new System.EventHandler(this.tsbtnGuideBack_Click);
            // 
            // tsbCodeFilter
            // 
            this.tsbCodeFilter.Image = ((System.Drawing.Image)(resources.GetObject("tsbCodeFilter.Image")));
            this.tsbCodeFilter.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbCodeFilter.Name = "tsbCodeFilter";
            this.tsbCodeFilter.Size = new System.Drawing.Size(97, 22);
            this.tsbCodeFilter.Text = "源码过滤  ";
            this.tsbCodeFilter.Click += new System.EventHandler(this.tsbCodeFilter_Click);
            // 
            // tsbSet
            // 
            this.tsbSet.Image = ((System.Drawing.Image)(resources.GetObject("tsbSet.Image")));
            this.tsbSet.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbSet.Name = "tsbSet";
            this.tsbSet.Size = new System.Drawing.Size(69, 22);
            this.tsbSet.Text = "设置  ";
            this.tsbSet.Click += new System.EventHandler(this.tsbSet_Click);
            // 
            // tsbExit
            // 
            this.tsbExit.Image = ((System.Drawing.Image)(resources.GetObject("tsbExit.Image")));
            this.tsbExit.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbExit.Name = "tsbExit";
            this.tsbExit.Size = new System.Drawing.Size(55, 22);
            this.tsbExit.Text = "退出";
            this.tsbExit.Click += new System.EventHandler(this.tsbExit_Click);
            // 
            // timDateTime
            // 
            this.timDateTime.Enabled = true;
            this.timDateTime.Interval = 1000;
            this.timDateTime.Tick += new System.EventHandler(this.timDateTime_Tick);
            // 
            // Language
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(953, 576);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.statusStrip1);
            this.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Language";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "多语言管理系统";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Language_FormClosing);
            this.Load += new System.EventHandler(this.Language_Load);
            this.SizeChanged += new System.EventHandler(this.Language_SizeChanged);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAllScript)).EndInit();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView dgvAllScript;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel ssrlbltime;
        private System.Windows.Forms.ToolStripStatusLabel ssrlblAdmin;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripDropDownButton toolStripLabel1;
        private System.Windows.Forms.ToolStripMenuItem UpLanguageMenuItem;
        private System.Windows.Forms.ToolStripMenuItem AddLanguageMenuItem;
        private System.Windows.Forms.ToolStripMenuItem OutMenuItem;
        private System.Windows.Forms.ToolStripMenuItem TypeMenuItem;
        private System.Windows.Forms.ToolStripMenuItem positionMenuItem;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.Button btnGetType;
        private System.Windows.Forms.ComboBox cmbType;
        private System.Windows.Forms.Label lblLanguage;
        private System.Windows.Forms.Timer timDateTime;
        private System.Windows.Forms.ToolStripMenuItem projectManage;
        private System.Windows.Forms.ToolStripButton tsbCodeFilter;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbProject;
        private System.Windows.Forms.ToolStripDropDownButton tsddbManage;
        private System.Windows.Forms.ToolStripMenuItem tsmiProject;
        private System.Windows.Forms.ToolStripMenuItem tsmiType;
        private System.Windows.Forms.ToolStripMenuItem tsmiBasicScript;
        private System.Windows.Forms.ToolStripMenuItem tsmiScript;
        private System.Windows.Forms.ToolStripDropDownButton tsddbXmlImAndEx;
        private System.Windows.Forms.ToolStripMenuItem tsmiXmlExportRead;
        private System.Windows.Forms.ToolStripMenuItem tsmiImportEdit;
        private System.Windows.Forms.ToolStripButton tsbExit;
        private WinFormPaging.PagingControl pagingDgvAllScript;
        private System.Windows.Forms.ToolStripButton tsbSet;
    }
}

