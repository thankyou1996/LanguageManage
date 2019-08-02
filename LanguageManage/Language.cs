using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace LanguagesManage
{
    public partial class Language : Form
    {
        #region 全局变量
        /// <summary>
        /// 登录的用户名
        /// </summary>
        public static string adminName="admin";

        /// <summary>
        /// 数据库操作类
        /// </summary>
        DataOperation data;

        AutoSizeFormClass asf = new AutoSizeFormClass();
        #endregion


        public Language()
        {
            if(adminName==null)//判断管理员是否登录成功
            {
                this.Close();//关闭窗口（关闭程序）
                //2016.03.17 TODO：这是第二次进行验证，觉得必要可以删除
                return;
            }
            InitializeComponent();
            data = new DataOperation();
        }

        private void Language_Load(object sender, EventArgs e)
        {
            asf.controlInitializeSize(this);
            ssrlblAdmin.Text += adminName;

            SetConfig.getConfigInfo();
            this.pagingDgvAllScript.PageSize = SetConfig.PageSize;
            dgvBind(data.getLanguageName(),1,0);
            //dtBind();
            cmbBind();
            //languageSwitchDT();
        }


        private void cmbBind()
        {
            cmbType.Items.Clear();
            DataTable dtAllType = data.getType().Tables[0];
            cmbType.Items.Add("所有语言"); //绑定语言下拉框
            foreach (DataRow dr in dtAllType.Rows)
            {
                cmbType.Items.Add(dr["Reserved_1"]);
            }
            cmbType.SelectedIndex = 0;

            //显示所有语言
            for (int i = 4; i < dgvAllScript.Columns.Count; i++)
            {
                dgvAllScript.Columns[i].Visible = true;
                //Common.gridViewModeControl(dgvAllScript);
            }
            //cmbProject.Items.Clear();
            DataTable dtAllProject = data.getProjects().Tables[0];
            //cmbProject.Items.Add("所有项目");
            //foreach (DataRow dr in dtAllProject.Rows)
            //{
            //    cmbProject.Items.Add(dr["ProjectName"]);
            //}
            DataRow drProject = dtAllProject.NewRow();
            drProject["ProjectID"] = 0;
            drProject["ProjectName"] = "所有项目";
            cmbProject.DisplayMember = "ProjectName";
            cmbProject.ValueMember = "ProjectID";
            dtAllProject.Rows.InsertAt(drProject,0);
            cmbProject.DataSource = dtAllProject;
            cmbProject.SelectedIndex = 0;
        }

        /// <summary>
        /// 刷新按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnRefresh_Click(object sender, EventArgs e)
        {
            cmbBind();
            projectId = 0;
            dgvBind(data.getLanguageName(),1,0);
            //dtBind();
            //if (cmbType.SelectedIndex == 0)//判断是否选择所有语言
            //{
            //    try
            //    {
            //        //显示所有语言
            //        for (int i = 4; i < dgvAllScript.Columns.Count; i++)
            //        {
            //            dgvAllScript.Columns[i].Visible = true;
            //            //Common.gridViewModeControl(dgvAllScript);
            //        }
            //    }
            //    catch
            //    {

            //    }
            //}
            //else
            //{
            //    //string LanguageName = cmbType.Text.Trim();
            //    for (int i = 4; i < dgvAllScript.Columns.Count; i++)
            //    {
            //        dgvAllScript.Columns[i].Visible = false;
            //    }
            //    dgvAllScript.Columns[cmbType.Text].Visible = true;
            //}
            //if (cmbProject.SelectedIndex == 0) //判断是否选中所有项目
            //{
            //    this.dtV_AllScript.DefaultView.RowFilter = string.Empty;
            //}
            //else
            //{
            //    this.dtV_AllScript.DefaultView.RowFilter = "ProjectName='" + cmbProject.Text + "'";
            //}
        }

        int projectId = 0;

        /// <summary>
        /// 查询按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnGetType_Click(object sender, EventArgs e)
        {
            int projectId2= Convert.ToInt32(cmbProject.SelectedValue);
            if (projectId != projectId2)
            {
                projectId = projectId2;
                dgvBind(data.getLanguageName(), 1, projectId);
            }
            if (cmbType.SelectedIndex == 0)//判断是否选择所有语言
            {
                try
                {
                    //显示所有语言
                    for (int i = 5; i < dgvAllScript.Columns.Count; i++)
                    {
                        dgvAllScript.Columns[i].Visible = true;
                        //Common.gridViewModeControl(dgvAllScript);
                    }
                }
                catch
                {

                }
            }
            else
            {
                //string LanguageName = cmbType.Text.Trim();
                for (int i = 5; i < dgvAllScript.Columns.Count; i++)
                {
                    dgvAllScript.Columns[i].Visible = false;
                }
                dgvAllScript.Columns[cmbType.Text].Visible = true;
            }


        }

        


        private void timDateTime_Tick(object sender, EventArgs e)
        {
            ssrlbltime.Text = DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss");
        }


        #region 界面链接

        BasicScript basicScript;
        /// <summary>
        /// 基本语言按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AddLanguageMenuItem_Click(object sender, EventArgs e)
        {
            if (data.getProjects().Tables[0].Rows.Count < 1)
            {
                if ((MessageBox.Show("请至少添加一个项目才能进行【中文管理】操作", "系统提示")) == DialogResult.OK)
                {
                    projectManage_Click(sender, e);
                }
                return;
            }
            if (basicScript == null || basicScript.IsDisposed)
            {
                basicScript = new BasicScript();
                basicScript.Show();
            }
            else
            {
                basicScript.Activate();
            }
        }

        //UpLanguage uplanguage;
        ScriptManage scriptManage;
        /// <summary>
        /// 脚本管理按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void UpLanguageMenuItem_Click(object sender, EventArgs e)
        {
            if (data.getProjects().Tables[0].Rows.Count < 1)
            {
                if ((MessageBox.Show("请至少添加一个项目才能进行【脚本管理】操作", "系统提示")) == DialogResult.OK)
                {
                    projectManage_Click(sender, e);
                }
                return;
            }
            if (data.getType().Tables[0].Rows.Count < 1)
            {
                if ((MessageBox.Show("请至少添加一种语言才能进行【脚本管理】操作", "系统提示")) == DialogResult.OK)
                {
                    TypeMenuItem_Click(sender, e);
                }
                return;
            }
            if (scriptManage == null || scriptManage.IsDisposed)
            {
                scriptManage = new ScriptManage();
                scriptManage.Show();
            }
            else
            {
                scriptManage.Activate();
            }


            //return;
            //if (uplanguage == null||uplanguage.IsDisposed)
            //{
            //    uplanguage = new UpLanguage();
            //    uplanguage.Show();
            //}
            //else
            //{
            //    uplanguage.Activate();
            //}
        }

        Type type;
        /// <summary>
        /// 显示类型界面
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TypeMenuItem_Click(object sender, EventArgs e)
        {
            if (type == null || type.IsDisposed)
            {
                type = new Type();
                type.Show();
            }
            else
            {
                type.Activate();
            }
        }

        Position position;
        /// <summary>
        /// 显示位置界面
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void positionMenuItem_Click(object sender, EventArgs e)
        {
            if (position == null || position.IsDisposed)
            {
                position = new Position();
                position.Show();
            }
            else
            {
                position.Activate();
            }
        }

        Project project;
        /// <summary>
        /// 项目管理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void projectManage_Click(object sender, EventArgs e)
        {
            if (project == null || project.IsDisposed)
            {
                project = new Project();
                project.Show();
            }
            else
            {
                project.Activate();
            }
        }

        ExportXml2 export2;
        /// <summary>
        /// 导出可操作文件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsbtnExportEditXml_Click(object sender, EventArgs e)
        {
            if (export2 == null || export2.IsDisposed)
            {
                export2 = new ExportXml2();
                export2.Show();
            }
            else
            {
                export2.Activate();
            }
        }

        GuideBackPreview view;
        /// <summary>
        /// 导回数据库
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsbtnGuideBack_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFile = new OpenFileDialog();
            openFile.Multiselect = false; //不可选择多个文件
            openFile.InitialDirectory = Application.StartupPath;  //设置工作路径
            openFile.Filter = "所有文件(*.*)|*.*|Xml文件|*.xml"; //筛选文件为所有文件和Xml文件
            openFile.FilterIndex = 2;   //默认筛选项为XML文件
            openFile.RestoreDirectory = true;
            if (openFile.ShowDialog() == DialogResult.OK)
            {
                string filePath = openFile.FileName.ToString();
                if (view == null || view.IsDisposed)
                {
                    view = new GuideBackPreview(filePath);
                    view.Show();
                }
                else
                {
                    view.Dispose();
                    view = new GuideBackPreview(filePath);
                    view.Show();
                }
            }
        }

        ExportXml exportXml;
        /// <summary>
        /// 导出读取文件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsbtnExportXml_Click(object sender, EventArgs e)
        {
            if (exportXml == null || exportXml.IsDisposed)
            {
                exportXml = new ExportXml();
                exportXml.Show();
            }
            else
            {
                exportXml.Activate();
            }
        }

        CodeFilter codeFilter;

        /// <summary>
        /// 源码过滤按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsbCodeFilter_Click(object sender, EventArgs e)
        {
            if (codeFilter == null || codeFilter.IsDisposed)
            {
                codeFilter = new CodeFilter();
                codeFilter.Show();
            }
            else
            {
                codeFilter.Activate();
            }
        }

        SetUp setUp;
        private void tsbSet_Click(object sender, EventArgs e)
        {
            if (setUp == null || setUp.IsDisposed)
            {
                setUp = new SetUp();
                setUp.Show();
            }
            else
            {
                setUp.Activate();
            }
        }

        /// <summary>
        /// 退出按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OutMenuItem_Click(object sender, EventArgs e)
        {
            //System.Environment.Exit(0);//彻底退出程序
            this.Close();
        }
        private void tsbExit_Click(object sender, EventArgs e)
        {
            //System.Environment.Exit(0);//彻底退出程序
            this.Close();
        }

        
        #endregion

        
        private void pagingControl1_PageIndexChanged(object sender, EventArgs e)
        {
            this.pagingDgvAllScript.PageSize = SetConfig.PageSize;
            dgvBind(data.getLanguageName(), pagingDgvAllScript.PageIndex, projectId);
        }


        /// <summary>
        /// 退出确认
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Language_FormClosing(object sender, FormClosingEventArgs e)
        {
            if ((MessageBox.Show("确认退出?", "系统提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question)) == DialogResult.Yes)
            {
                //System.Environment.Exit(0);
            }
            else
            {
                e.Cancel = true;
            }
        }


        /// <summary>
        /// 界面大小改变
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Language_SizeChanged(object sender, EventArgs e)
        {
            asf.controlAutoSize(this);
        }

        int recordCount = 0;
        public void dgvBind(string languageName, int index,int projectId)
        {
            pagingDgvAllScript.PageIndex = index;
            this.pagingDgvAllScript.PageSize = SetConfig.PageSize;
            DataSet ds = data.getV_Script(languageName, projectId, pagingDgvAllScript.PageSize, pagingDgvAllScript.PageIndex - 1);
            recordCount = Convert.ToInt32(ds.Tables[1].Rows[0][0]);
            pagingDgvAllScript.RecordCount = recordCount;
            dgvAllScript.DataSource = ds.Tables[0];
            dgvAllScript.Columns["Number"].HeaderText="No.";
            dgvAllScript.Columns["ScriptID"].HeaderText = "ID";
            dgvAllScript.Columns["ProjectName"].HeaderText = "项目名称";
            dgvAllScript.Columns["Position"].HeaderText = "类";
            dgvAllScript.Columns["BasicText"].HeaderText = "中文简体";
            Common.gridViewModeControl(this.dgvAllScript);
            dgvAllScript.Columns["Number"].Width = 75;
            dgvAllScript.Columns["ScriptID"].Width = 75;
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        

        //public DataTable getDt(string languageName, int pageSize,int pageIndex)
        //{
        //    DataSet ds = data.getV_Script(languageName, pageSize, pageIndex);
        //    recordCount = Convert.ToInt32(ds.Tables[1].Rows[0][0]);
        //}

        

    }
}
