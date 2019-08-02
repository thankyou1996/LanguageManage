using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace LanguagesManage
{
    public partial class Project : Form
    {
        public Project()
        {
            InitializeComponent();
        }
        DataTable dtProjects;

        DataOperation dbOperat;

        string projectIDstr;
        private void Project_Load(object sender, EventArgs e)
        {
            dtProjects = new DataTable();
            dbOperat = new DataOperation();
            initialBtnSet();
            dgvBind();
            if (dgvProject.Rows.Count < 1)
            {
                conTrolReadOnlySet(false);
                btnEdit.Enabled = false;
                btnAdd.Enabled = false;
                btnSave.Enabled = true;
                return;
            }
            projectIDstr = dgvProject.CurrentRow.Cells[0].Value.ToString();
            getProjectInfo(projectIDstr);
        }
        
        /// <summary>
        /// 数据源绑定
        /// </summary>
        public void dgvBind()
        {
            dtProjects = dbOperat.getProjects().Tables[0];

            dgvProject.DataSource = dtProjects;
            dgvProject.Columns["ProjectID"].HeaderText = "ID";
            
            dgvProject.Columns["ProjectName"].HeaderText = "项目名称";
            //dataGridView1.Columns["ProjectName"].Visible = false;
            dgvProject.Columns["SolutionName"].HeaderText = "解决方案名称";
            //dataGridView1.Columns["SolutionName"].Visible = false;
            dgvProject.Columns["LastModifyTime"].HeaderText = "项目修改时间";
            dgvProject.Columns["LastModifyTime"].Visible = false;
            dgvProject.Columns["BackupVersion"].HeaderText = "备份版本";
            dgvProject.Columns["BackupVersion"].Visible = false;
            dgvProject.Columns["Remarks"].HeaderText = "备注信息";
            dgvProject.Columns["Remarks"].Visible = false;
            dgvProject.Columns["AddTime"].HeaderText = "添加时间";
            dgvProject.Columns["AddTime"].Visible = false;
            dgvProject.Columns["UpdateTime"].HeaderText = "更新时间";
            dgvProject.Columns["UpdateTime"].Visible = false;
            dgvProject.Columns["AdminName"].HeaderText = "最后操作人员";
            dgvProject.Columns["AdminName"].Visible = false;
            dgvProject.Columns["Reserved_1"].Visible = false;
            dgvProject.Columns["Reserved_2"].Visible = false;
            dgvProject.Columns["Reserved_3"].Visible = false;
            Common.gridViewModeControl(this.dgvProject);
            dgvProject.Columns["ProjectID"].Width = 60;
        }

        public void getProjectInfo(string ProjectID)
        {
            if (string.IsNullOrEmpty(ProjectID))
            {
                return;
            }
            DataRow projectInfo = dtProjects.Select("ProjectID ='" + ProjectID + "'")[0];
            txtID.Text = projectInfo["ProjectID"].ToString();
            txtProjectName.Text = projectInfo["ProjectName"].ToString();
            txtSolutionName.Text = projectInfo["SolutionName"].ToString();
            lblLastModifyTime.Text = projectInfo["LastModifyTime"].ToString();
            lblBackupVersion.Text = projectInfo["BackupVersion"].ToString();
            txtRemarks.Text = projectInfo["Remarks"].ToString();
            lblAddTime.Text = projectInfo["AddTime"].ToString();
            lblAdmin.Text = projectInfo["AdminName"].ToString();
            conTrolReadOnlySet(true);
        }

        /// <summary>
        /// 刷新
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnFlush_Click(object sender, EventArgs e)
        {
            dgvBind();
            if (dgvProject.Rows.Count < 1)
            {
                return;
            }
            projectIDstr = dgvProject.CurrentRow.Cells[0].Value.ToString();
            getProjectInfo(projectIDstr);
            initialBtnSet();
        }

        /// <summary>
        /// 编辑
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnEdit_Click(object sender, EventArgs e)
        {
            conTrolReadOnlySet(false);

            btnAdd.Enabled = false;
            btnEdit.Enabled = false;
            btnSave.Enabled = true;
        }
        
        /// <summary>
        /// 保存
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!verify())
            {
                return;
            }
            string projectName = txtProjectName.Text;
            string solutionName = txtSolutionName.Text;
            string remarks = txtRemarks.Text;
            
            if (string.IsNullOrEmpty(txtID.Text))
            {
                if (dbOperat.existsProject(projectName) > 0)
                {
                    MessageBox.Show("请不要输入重复信息");
                    return;
                }
                
                dbOperat.insertProject(projectName, solutionName, remarks, Language.adminName);
                //刷新数据
                int projectId = dbOperat.getProjectId(projectName, solutionName);
                dbOperat.insertPosition(solutionName, projectId, Language.adminName);
                dgvBind(); 
                initialBtnSet();
                getValue(projectName);
                conTrolReadOnlySet(true);
                MessageBox.Show("添加成功");
                return;
            }
            if (dbOperat.existsProject(projectName) > 1-editVerify(txtID.Text))
            {
                MessageBox.Show("请不要输入重复信息");
                return;
            }
            int projectID = Convert.ToInt32(txtID.Text);
            dbOperat.updateProject(projectID, projectName, solutionName, remarks, Language.adminName);
            //刷新数据
            getProjectInfo(projectIDstr);
            initialBtnSet();
            dgvBind();
            getValue(projectName);
            conTrolReadOnlySet(true);
            MessageBox.Show("编辑成功");
        }

        private int editVerify(string projectId)
        {
            DataRow[] drs = dtProjects.Select("ProjectID='" + projectId + "'");
            string projectName = drs[0]["ProjectName"].ToString();
            if (projectName.Trim() == txtProjectName.Text.Trim())
            {
                return 0;
            }
            return 1;
        }

        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAdd_Click(object sender, EventArgs e)
        {
            //DataRow projectInfo = dtProjects.Select("ProjectID ='" + ProjectID + "'")[0];
            txtID.Text = "";
            txtProjectName.Text = "";
            txtSolutionName.Text = "";
            lblLastModifyTime.Text = "";
            lblBackupVersion.Text = "";
            txtRemarks.Text = "";
            lblAddTime.Text = "";
            lblAdmin.Text = "";
            conTrolReadOnlySet(false);
            btnEdit.Enabled = false;
            btnAdd.Enabled = false;
            btnSave.Enabled = true ;
            //btnAdd.Text = "确认添加";

            //if (!verify())
            //{
            //    return;
            //}
            //int projectID = Convert.ToInt32(txtID.Text);
            //string projectName = txtProjectName.Text;
            //string solutionName = txtSolutionName.Text;
            //string remarks = txtRemarks.Text;
            //dbOperat.updateProject(projectID, projectName, solutionName, remarks, Language.adminName);
        }

        /// <summary>
        /// 验证
        /// </summary>
        /// <returns></returns>
        public bool verify()
        {
            if (string.IsNullOrEmpty(txtProjectName.Text))
            {
                MessageBox.Show("请输入项目名称");
                return false;
            }
            if (string.IsNullOrEmpty(txtSolutionName.Text))
            {
                MessageBox.Show("请输入解决方案名称");
                return false;
            }
            return true;
        }

        /// <summary>
        /// 获取信息
        /// </summary>
        /// <param name="projectName"></param>
        public void getValue(string projectName)
        {
            DataRow[] drs = dtProjects.Select("projectName='" + projectName + "'");
            int index = dtProjects.Rows.IndexOf(drs[0]);
            dgvProject.Rows[index].Selected = true;
            //dgvPosition.currentcell=null；
            dgvProject.CurrentCell = dgvProject.Rows[index].Cells[0]; 
        }

        /// <summary>
        /// 按钮初始设置
        /// </summary>
        public void initialBtnSet()
        {
            btnFlush.Enabled = true;
            btnEdit.Enabled = true;
            btnAdd.Enabled = true;
            btnSave.Enabled = false;
        }

        /// <summary>
        /// 控件可操作设置
        /// </summary>
        /// <param name="setBool"></param>
        private void conTrolReadOnlySet(bool setBool)
        {
            txtProjectName.ReadOnly = setBool;
            txtSolutionName.ReadOnly = setBool;
            txtRemarks.ReadOnly = setBool;
        }
        private void btnCancel_Click(object sender, EventArgs e)
        {
            getProjectInfo(projectIDstr);
            initialBtnSet();
        }

        private void dgvProject_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                //positionIDstr = dgvPosition.CurrentRow.Cells[0].Value.ToString();
                //getPositionInfo(positionIDstr);

                projectIDstr = dgvProject.SelectedRows[0].Cells[0].Value.ToString();
                getProjectInfo(projectIDstr);
                initialBtnSet();
            }
            catch //选中列标题异常
            {

            }
        }

        CodeFilter cf;
        private void btnCodeFilter_Click(object sender, EventArgs e)
        {
            if (cf == null || cf.IsDisposed)
            {
                if (string.IsNullOrEmpty(txtID.Text))
                {
                    cf = new CodeFilter();
                    cf.Show();
                }
                else
                {
                    int projectId = Convert.ToInt32(txtID.Text);
                    cf = new CodeFilter(projectId);
                    cf.Show(); 
                }
                
            }
            else
            {
                cf.Activate();
            }
        }
    }
}
