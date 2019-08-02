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
    public partial class BasicScript : Form
    {
        #region 全局变量
        /// <summary>
        /// 数据操作类
        /// </summary>
        DataOperation data;

        /// <summary>
        /// 自适应窗体
        /// </summary>
        AutoSizeFormClass asf = new AutoSizeFormClass();
        #endregion

        DataTable dtBasicScript = new DataTable();

        string basicScriptIDstr;

        int projectID;

        public BasicScript()
        {
            InitializeComponent();
            data = new DataOperation();
        }

        private void BasicScript_Load(object sender, EventArgs e)
        {
            asf.controlInitializeSize(this);
            pagingDgvBasicScript.PageSize = 30;
            cmbBindProject();
            initialBtnSer();
            projectId = Convert.ToInt32(cmbProject.SelectedValue);
            this.pagingDgvBasicScript.PageSize = SetConfig.PageSize;
            dgvBind(1);
            if (dtBasicScript.Rows.Count < 1)
            {
                return;
            }
            basicScriptIDstr = dgvBasicScript.CurrentRow.Cells[1].Value.ToString();
            getBasicScriptInfo(basicScriptIDstr);

            
        }

        
        /// <summary>
        /// 下拉框数据源绑定
        /// </summary>
        public void cmbBindProject()
        {
            DataTable dtProjects = data.getProjects().Tables[0];
            cmbProject.DisplayMember = "ProjectName";
            cmbProject.ValueMember = "ProjectID";
            cmbProject.DataSource = dtProjects;
            cmbPosition.SelectedIndex = 0;
        }

        /// <summary>
        /// 确定按钮，根据选择的项目和类名
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnGetPosition_Click(object sender, EventArgs e)
        {  
            positionId = Convert.ToInt32(cmbPosition.SelectedValue);
            projectID = Convert.ToInt32(cmbProject.SelectedValue);
            dgvBind(1);
        }

        /// <summary>
        /// 刷新按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnRefresh_Click(object sender, EventArgs e)
        {
            cmbProject.SelectedIndex = 0;
            cmbPosition.SelectedValue = 0;
            projectId = Convert.ToInt32(cmbProject.SelectedValue);
            positionId = 0;
            dgvBind(1);
        }

        /// <summary>
        /// cmbProject索引变换
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmbProject_SelectedIndexChanged(object sender, EventArgs e)
        {
            projectID = Convert.ToInt32(cmbProject.SelectedValue);
            
            positionId = 0;
            cmbGet(projectID);
        }
        
        /// <summary>
        /// 获取选择项目的下属类
        /// </summary>
        /// <param name="projectId"></param>
        public void cmbGet(int projectId)
        {
            DataTable dtAllPosition = data.getPosition(projectId).Tables[0];
            //DataTable dtProjects = data.getProjects().Tables[0];
            //DataTable dtPosition = dtAllPosition.Copy();
            DataRow dra = dtAllPosition.NewRow(); //添加全部选项，放在最上方
            dra["PositionID"] = 0;
            dra["Position"] = "全部";
            dtAllPosition.Rows.InsertAt(dra, 0);
            cmbPosition.DisplayMember = "Position";
            cmbPosition.ValueMember = "PositionID";
            cmbPosition.DataSource = dtAllPosition;
            cmbPosition.SelectedIndex = 0;
        }

        /// <summary>
        /// 获取文本信息
        /// </summary>
        /// <param name="scriptID"></param>
        public void getBasicScriptInfo(string scriptID)
        {
            if (string.IsNullOrEmpty(scriptID))
            {
                return;
            }
            DataTable dtProjects = data.getPosition(projectID).Tables[0];
            cmbAddPosition.DisplayMember = "Position";
            cmbAddPosition.ValueMember = "PositionID";
            cmbAddPosition.DataSource = dtProjects;
            DataRow basicScriptInfo = dtBasicScript.Select("ScriptID='" + scriptID + "'")[0];
            txtScriptID.Text = basicScriptInfo["ScriptID"].ToString();
            lblProjectName.Text = basicScriptInfo["ProjectName"].ToString();
            cmbAddPosition.SelectedValue = basicScriptInfo["PositionID"];
            lblAddTime.Text = basicScriptInfo["AddTime"].ToString();
            lblUpdateTime.Text = basicScriptInfo["UpdateTime"].ToString();
            lblAdmin.Text = basicScriptInfo["AdminName"].ToString();
            txtBasicText.Text = basicScriptInfo["BasicText"].ToString();
        }

        /// <summary>
        /// 界面控件TextBox设置
        /// </summary>
        /// <param name="setBool"></param>
        private void controlOperatSet(bool setBool)
        {
            txtBasicText.ReadOnly = !setBool;
            cmbAddPosition.Enabled = setBool;
        }

        /// <summary>
        /// 界面控件Button设置
        /// </summary>
        public void initialBtnSer()
        {
            btnEdit.Enabled = true;
            btnAdd.Enabled = true;
            btnSave.Enabled = false;
        }

        /// <summary>
        /// 编辑按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnEdit_Click(object sender, EventArgs e)
        {
            //string tesst = dgvBasicScript.CurrentCell.Value.ToString();
            infoisnull();
            controlOperatSet(true);
            btnAdd.Enabled = false;
            btnEdit.Enabled = false;
            btnSave.Enabled = true;
        }

        /// <summary>
        /// 添加按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAdd_Click_1(object sender, EventArgs e)
        {
            infoisnull();
            txtScriptID.Text = "";
            lblAddTime.Text = "";
            lblUpdateTime.Text = "";
            lblAdmin.Text = "";
            txtBasicText.Text = "";
            controlOperatSet(true);
            btnEdit.Enabled = false;
            btnAdd.Enabled = false;
            btnSave.Enabled = true;
        }

        /// <summary>
        /// 如果信息为空
        /// </summary>
        private void infoisnull()
        {
            if (dgvBasicScript.CurrentCell == null) //数据为空
            {
                lblProjectName.Text = cmbProject.Text;
                int projectId = Convert.ToInt32(cmbProject.SelectedValue);
                DataTable dt = data.getPosition(projectId).Tables[0];
                cmbAddPosition.DisplayMember = "Position";
                cmbAddPosition.ValueMember = "PositionID";
                cmbAddPosition.DataSource = dt;
            }
            else  //不为空不做操作
            { 
            
            }
        }

        /// <summary>
        /// 取消按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCancel_Click(object sender, EventArgs e)
        {
            initialBtnSer();
            controlOperatSet(false);
            try
            {
                basicScriptIDstr = dgvBasicScript.SelectedRows[0].Cells[1].Value.ToString();
                getBasicScriptInfo(basicScriptIDstr);
            }
            catch
            {
                txtBasicText.Text = "";
            }
            
        }

        /// <summary>
        /// 保存按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtBasicText.Text))
            {
                MessageBox.Show("请输入信息");
                return;
            }
            string basicText = txtBasicText.Text; //文本
            int positionID = Convert.ToInt32(cmbAddPosition.SelectedValue);
            if (data.existsBasicScript(basicText, positionID) > 0)  //是否存在相同信息
            {
                MessageBox.Show("请不要输入重复信息");
                return;
            }
            if (string.IsNullOrEmpty(txtScriptID.Text.Trim())) //添加或者更新
            {
                data.addBasicScript(basicText, positionID, Language.adminName);
                int scriptID = data.getScriptID(basicText, positionID);
                addScript(scriptID);
                dgvBind(pagingDgvBasicScript.PageCount);
                getValue(basicText, positionID);
                initialBtnSer();
                controlOperatSet(false);
                MessageBox.Show("添加成功");
                return;
            }
            else
            {
                int scriptID = Convert.ToInt32(txtScriptID.Text);
                data.updateBasic(scriptID, basicText, positionID, Language.adminName);
                dgvBind(pagingDgvBasicScript.PageIndex);
                getValue(basicText, positionID);
                initialBtnSer();
                controlOperatSet(false);
                MessageBox.Show("编辑成功");
            }
        }

        /// <summary>
        /// 添加信息
        /// </summary>
        /// <param name="scriptID"></param>
        private void addScript(int scriptID)
        {
            DataTable dtType = data.getType().Tables[0];
            //DataTable dtBasicScriptID = data.getBasicScriptID().Tables[0];
            DataTable dtScript = data.getScriptClone().Tables[0];
            DataRow newDr;
            foreach (DataRow dr in dtType.Rows)
            {
                newDr = dtScript.NewRow();
                newDr["ScriptID"] = scriptID;
                newDr["TypeID"] = dr["TypeID"];
                newDr["Content"] = "###";
                newDr["AdminName"] = Language.adminName;
                dtScript.Rows.Add(newDr);
            }
            data.updateScriptDt(dtScript);
        }

        /// <summary>
        /// 编辑完成后重新获取选中行焦点
        /// </summary>
        /// <param name="basicText"></param>
        /// <param name="positionID"></param>
        public void getValue(string basicText, int positionID)
        {
            try
            {
                DataRow[] drs = dtBasicScript.Select("BasicText='" + basicText + "' AND positionID='" + positionID + "'");
                int index = dtBasicScript.Rows.IndexOf(drs[0]);
                dgvBasicScript.Rows[index].Selected = true;
                dgvBasicScript.CurrentCell = dgvBasicScript.Rows[index].Cells[0];
            }
            catch
            {

            }
        }


        /// <summary>
        /// dgv选中单元格选中事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgvBasicScript_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                basicScriptIDstr = dgvBasicScript.SelectedRows[0].Cells[1].Value.ToString();
                getBasicScriptInfo(basicScriptIDstr);
            }
            catch
            {

            }
        }

        /// <summary>
        /// 分页控件页索引改变
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void pagingControl1_PageIndexChanged(object sender, EventArgs e)
        {
            this.pagingDgvBasicScript.PageSize = SetConfig.PageSize;
            dgvBind(pagingDgvBasicScript.PageIndex);
        }


        int projectId = 0;
        int positionId = 0;

        /// <summary>
        /// dgv数据绑定
        /// </summary>
        /// <param name="index"></param>
        public void dgvBind(int index)
        {
            projectId = Convert.ToInt32(cmbProject.SelectedValue);
            dtBasicScript = getDt(index);
            dgvBasicScript.DataSource = dtBasicScript;
            //20160321 TODO:显示控制
            dgvBasicScript.Columns["RowNum"].HeaderText = "No.";
            
            dgvBasicScript.Columns["ScriptID"].HeaderText = "ID";
            dgvBasicScript.Columns["BasicText"].HeaderText = "文本";
            dgvBasicScript.Columns["PositionID"].Visible = false;
            dgvBasicScript.Columns["AddTime"].Visible = false;
            dgvBasicScript.Columns["UpdateTime"].Visible = false;
            dgvBasicScript.Columns["AdminName"].Visible = false;
            dgvBasicScript.Columns["Reserved_1"].Visible = false;
            dgvBasicScript.Columns["Reserved_2"].Visible = false;
            dgvBasicScript.Columns["Reserved_3"].Visible = false;
            dgvBasicScript.Columns["Position"].HeaderText = "类名";
            //dgvBasicScript.Columns["Position"].Visible = false;
            dgvBasicScript.Columns["ProjectName"].HeaderText = "项目";
            Common.gridViewModeControl(this.dgvBasicScript);
            dgvBasicScript.Columns["RowNum"].Width = 75;
        }

        /// <summary>
        /// 获取数据表，根据页索引
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public DataTable getDt(int index)
        {
            pagingDgvBasicScript.PageIndex = index;
            DataSet ds = data.getBasicScript(projectId, positionId, pagingDgvBasicScript.PageSize, pagingDgvBasicScript.PageIndex - 1);
            pagingDgvBasicScript.RecordCount = Convert.ToInt32(ds.Tables[1].Rows[0][0]);
            return ds.Tables[0];
        }

        /// <summary>
        /// 窗体自适应
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BasicScript_SizeChanged(object sender, EventArgs e)
        {
            asf.controlAutoSize(this);
        }
    }
}
