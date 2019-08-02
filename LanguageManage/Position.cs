using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace LanguagesManage
{
    public partial class Position : Form
    {
        #region  全局变量
        /// <summary>
        /// 数据库操作类
        /// </summary>
        DataOperation data;

        
       
        
        DataTable dtPosition;

        string positionIDstr;
        #endregion
        public Position()
        {
            InitializeComponent();
            
        }

        private void Position_Load(object sender, EventArgs e)
        {
            data = new DataOperation();
            //数据绑定
            try
            {
                cmbBind();
            }
            catch
            {
                this.Close();
                return;
            }
            
            dtBind();
            
            initialBtnSet();
            if (dtPosition.Rows.Count < 1)
            {
                conTrolOperatSet(true);
                btnEdit.Enabled = false;
                btnUpdate.Enabled = true;
                return;
            }
            positionIDstr = dgvPosition.CurrentRow.Cells[0].Value.ToString();
            getPositionInfo(positionIDstr);
        }


        /// <summary>
        /// 数据库绑定界面视图
        /// </summary>
        public void dtBind()
        {
            dtPosition = data.getPosition().Tables[0];//获取表信息
            dgvPosition.DataSource = dtPosition;
            

            //界面显示控制
            dgvPosition.Columns["PositionID"].HeaderText = "ID";
            dgvPosition.Columns["PositionID"].Width = 60;
            dgvPosition.Columns["Position"].HeaderText = "窗体名称";

            dgvPosition.Columns["AddTime"].HeaderText = "添加时间";
            dgvPosition.Columns["AddTime"].Visible = false;
            dgvPosition.Columns["UpdateTime"].HeaderText = "更新时间";
            dgvPosition.Columns["UpdateTime"].Visible = false;
            dgvPosition.Columns["AdminName"].HeaderText = "操作人员";
            dgvPosition.Columns["AdminName"].Visible = false;
            dgvPosition.Columns["ProjectName"].HeaderText = "项目名称";
            dgvPosition.Columns["ProjectName"].DisplayIndex = 1;

            dgvPosition.Columns["ProjectID"].Visible = false;
            dgvPosition.Columns["Reserved_1"].Visible = false;
            dgvPosition.Columns["Reserved_2"].Visible = false;
            dgvPosition.Columns["Reserved_3"].Visible = false;
            Common.gridViewModeControl(dgvPosition);
        }

        /// <summary>
        /// 下拉框绑定
        /// </summary>
        private void cmbBind()
        {
            DataTable dtAllProjects = data.getProjects().Tables[0]; // 查询下来框
            DataTable dtProjects = dtAllProjects.Copy(); //添加下拉框
            if (dtProjects.Rows.Count < 1)
            {
                MessageBox.Show("请至少添加一个项目后在进行[类管理]操作");
                throw new ArgumentOutOfRangeException("不存在项目");
            }
            DataTable dtProjects2 = dtAllProjects.Copy();//添加下拉框
            DataRow dr = dtAllProjects.NewRow();
            dr["ProjectID"] = 0;
            dr["ProjectName"] = "所有项目";
            dtAllProjects.Rows.InsertAt(dr, 0);
            cmbProjects.DisplayMember = "ProjectName";
            cmbProjects.ValueMember = "ProjectID";
            cmbProjects.DataSource = dtAllProjects;

            cmbAddProjects.DisplayMember = "ProjectName";
            cmbAddProjects.ValueMember = "ProjectID";
            cmbAddProjects.DataSource = dtProjects;
        }

        /// <summary>
        /// 更新按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtPosition.Text))
            {
                MessageBox.Show("请输入信息");
                return;
            }
            string position = txtPosition.Text; //类名
            int projectID = Convert.ToInt32(cmbAddProjects.SelectedValue);
            if (data.existsPosition(position, projectID)>0)
            {
                MessageBox.Show("请不要输入重复信息");
                return;
            }
            if (string.IsNullOrEmpty(txtPositionID.Text.Trim()))//判断是添加还是更新
            {
                data.insertPosition(position, projectID, Language.adminName);
                dtBind();
                initialBtnSet();
                getValue(position, projectID);
                MessageBox.Show("添加成功");
                return;
            }
            int positionID = Convert.ToInt32(txtPositionID.Text);
            data.updatePosition(positionID, position, projectID, Language.adminName);
            //getPositionInfo(positionIDstr);
            initialBtnSet();
            dtBind();
            getValue(position, projectID);
            MessageBox.Show("编辑成功");
        }

        public void getValue(string position,int projectID)
        {
            DataRow [] drs= dtPosition.Select("Position='" + position + "' AND projectID='" + projectID + "'");
            int index= dtPosition.Rows.IndexOf(drs[0]);
            dgvPosition.Rows[index].Selected = true;
            //dgvPosition.currentcell=null；
            dgvPosition.CurrentCell = dgvPosition.Rows[index].Cells[0]; 
        }

        /// <summary>
        /// 添加按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAdd_Click(object sender, EventArgs e)
        {
            txtPositionID.Text ="";
            txtPosition.Text = "";
            cmbAddProjects.SelectedValue = 1;
            lblAddTime.Text = "";
            lblUpdate.Text = "";
            lblAdmin.Text = "";
            conTrolOperatSet(true);
            btnEdit.Enabled = false;
            btnAdd.Enabled = false;
            btnUpdate.Enabled = true;
        }
        /// <summary>
        /// 刷新按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnRefresh_Click(object sender, EventArgs e)
        {
            dtBind();
            cmbBind();
            initialBtnSet();
        }

        /// <summary>
        /// 下拉框选择
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnGetProjects_Click(object sender, EventArgs e)
        {
            if (cmbProjects.SelectedIndex == 0) //是否选择
            {
                dtBind();
                return;
            }
            
            int projectID = Convert.ToInt32(cmbProjects.SelectedValue);
            dtPosition = data.getPosition(projectID).Tables[0];
            dgvPosition.DataSource = dtPosition;
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            conTrolOperatSet(true);
            btnAdd.Enabled = false;
            btnEdit.Enabled = false;
            btnUpdate.Enabled = true;
        }

        /// <summary>
        /// 按钮初始设置
        /// </summary>
        public void initialBtnSet()
        {
            btnEdit.Enabled = true;
            btnAdd.Enabled = true;
            btnUpdate.Enabled = false;
        }

        /// <summary>
        /// 获取信息
        /// </summary>
        /// <param name="PositionID"></param>
        private void getPositionInfo(string PositionID)
        {

            if (string.IsNullOrEmpty(PositionID))
            {
                return;
            }
            DataRow positionInfo = dtPosition.Select("PositionID ='" + PositionID + "'")[0];
            txtPositionID.Text = positionInfo["PositionID"].ToString();
            txtPosition.Text = positionInfo["Position"].ToString();
            cmbAddProjects.SelectedValue = positionInfo["ProjectID"];
            lblAddTime.Text = positionInfo["AddTime"].ToString();
            lblUpdate.Text = positionInfo["UpdateTime"].ToString();
            lblAdmin.Text = positionInfo["AdminName"].ToString();
            conTrolOperatSet(false);
        }

        /// <summary>
        /// 控件可操作设置
        /// </summary>
        /// <param name="setBool"></param>
        private void conTrolOperatSet(bool setBool)
        {
            txtPosition.ReadOnly = !setBool;
            cmbAddProjects.Enabled=setBool;
            //txtProjectName.ReadOnly = setBool;
            //txtSolutionName.ReadOnly = setBool;
            //txtRemarks.ReadOnly = setBool;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            getPositionInfo(positionIDstr);
            initialBtnSet();
        }

        private void dgvPosition_RowStateChanged(object sender, DataGridViewRowStateChangedEventArgs e)
        {
            
        }

        private void dgvPosition_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                //positionIDstr = dgvPosition.CurrentRow.Cells[0].Value.ToString();
                //getPositionInfo(positionIDstr);

                positionIDstr = dgvPosition.SelectedRows[0].Cells[0].Value.ToString();
                getPositionInfo(positionIDstr);
            }
            catch //选中列标题异常
            {

            }
        }


    }
}
