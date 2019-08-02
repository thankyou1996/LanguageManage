using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LanguagesManage
{
    public partial class ScriptManage : Form
    {
        /// <summary>
        /// 数据库操作对象
        /// </summary>
        DataOperation dbOperAt;

        public ScriptManage()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 项目ID
        /// </summary>
        int projectId = 0;

        /// <summary>
        /// 类名
        /// </summary>
        string positionName = "全部";
        
        /// <summary>
        /// 当前选中的语言ID
        /// </summary>
        int typeId = 0;

        /// <summary>
        /// 当前选中的语言名称（用于定位dgvScript.Cells索引）
        /// </summary>
        string languageName = "";
        
        /// <summary>
        /// 脚本ID
        /// </summary>
        int scriptId = 0;

        /// <summary>
        /// 脚本文本
        /// </summary>
        string scriptText = "";
        
        /// <summary>
        /// 行索引
        /// </summary>
        int rowIndex = -1;

        AutoSizeFormClass asf;
        private void ScriptManage_Load(object sender, EventArgs e)
        {
            asf = new AutoSizeFormClass();
            asf.controlInitializeSize(this);
            dbOperAt = new DataOperation();
            cmbBind();
            typeId = Convert.ToInt32(cmbType.SelectedValue);
            languageName = cmbType.Text;
            projectId = Convert.ToInt32(cmbProject.SelectedValue);
            positionName = cmbPosition.Text;
            lblEditTypeInfo.Text = this.languageName;
            dgvBind(1);

            this.txtEdit.MouseWheel += new MouseEventHandler(this.rewriteMouseWheel);
            //dgvScript.Focus();
            //btnSave.Text = "11(&0)";
        }

        /// <summary>
        /// ComboBox下拉框绑定
        /// </summary>
        public void cmbBind()
        { 
            //cmbType
            DataTable dtType = dbOperAt.getType().Tables[0];
            cmbType.DisplayMember = "Reserved_1";
            cmbType.ValueMember = "TypeID";
            cmbType.DataSource = dtType;

            //cmbProject
            DataTable dtProject = dbOperAt.getProjects().Tables[0];
            cmbProject.DisplayMember = "ProjectName";
            cmbProject.ValueMember = "ProjectID";
            cmbProject.DataSource = dtProject;

            ////cmbPosition
            // DataTable dtPosition = dbOperAt.getPosition().Tables[0];
            //DataRow drPosition = dtPosition.NewRow();
            //drPosition["PositionID"] = 0;
            //drPosition["Position"] = "全部";
            //dtPosition.Rows.InsertAt(drPosition, 0);
            //cmbPosition.DisplayMember = "Position";
            //cmbPosition.ValueMember = "PositionID";
            //cmbPosition.DataSource = dtPosition;
        }

        /// <summary>
        /// cmbProject索引重新绑定cmbPosition内容
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmbProject_SelectedIndexChanged(object sender, EventArgs e)
        {
            int projectId = Convert.ToInt32(cmbProject.SelectedValue);
            DataTable dtPosition = dbOperAt.getPosition(projectId).Tables[0];
            DataRow drPosition = dtPosition.NewRow();
            drPosition["PositionID"] = 0;
            drPosition["Position"] = "全部";
            dtPosition.Rows.InsertAt(drPosition, 0);
            cmbPosition.DisplayMember = "Position";
            cmbPosition.ValueMember = "ProjectID";
            cmbPosition.DataSource = dtPosition;
        }

        /// <summary>
        /// dgvScript绑定数据
        /// </summary>
        public void dgvBind(int pageIndex)
        {
            this.pagingScript.PageSize = SetConfig.PageSize;
            DataSet ds = dbOperAt.getV_Scriptt(dbOperAt.getLanguageName(), projectId, positionName, this.pagingScript.PageSize, pageIndex - 1);
            DataTable dtScript = ds.Tables[0];
            dgvScript.DataSource = dtScript;
            pagingScript.RecordCount = Convert.ToInt32(ds.Tables[1].Rows[0][0]);

            //语言设置
            for (int i = 5; i < dgvScript.Columns.Count; i++)
            {
                dgvScript.Columns[i].Visible = false;
            }
            dgvScript.Columns[cmbType.Text].Visible = true;

            dgvScript.Columns["Number"].HeaderText = "No.";
            dgvScript.Columns["ScriptID"].HeaderText = "ID";
            dgvScript.Columns["ProjectName"].HeaderText = "项目名称";
            dgvScript.Columns["Position"].HeaderText = "类";
            dgvScript.Columns["BasicText"].HeaderText = "中文简体";
            Common.gridViewModeControl(this.dgvScript);
            dgvScript.Columns["Number"].Width = 75;
            dgvScript.Columns["ScriptID"].Width = 75;
        }

        private void pagingScript_PageIndexChanged(object sender, EventArgs e)
        {
            this.pagingScript.PageSize = SetConfig.PageSize;
            dgvBind(pagingScript.PageIndex);
        }

        /// <summary>
        /// 查询按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSelect_Click(object sender, EventArgs e)
        {
            typeId = Convert.ToInt32(cmbType.SelectedValue);
            languageName = cmbType.Text;
            projectId = Convert.ToInt32(cmbProject.SelectedValue);
            positionName = cmbPosition.Text;
            lblEditTypeInfo.Text = this.languageName;
            dgvBind(1);
        }

        /// <summary>
        /// 刷新按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnFlush_Click(object sender, EventArgs e)
        {
            cmbProject.SelectedIndex = 0;
            cmbPosition.SelectedIndex = 0;
            typeId = Convert.ToInt32(cmbType.SelectedValue);
            languageName = cmbType.Text;
            projectId = Convert.ToInt32(cmbProject.SelectedValue);
            positionName = "全部";
            lblEditTypeInfo.Text = this.languageName;
            dgvBind(1);
        }

        /// <summary>
        /// 单元格变化
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgvScript_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (scriptId != 0 && scriptText != txtEdit.Text)  //是否需要保存
            {
                if (chkWrapSave.Checked) //是否选中换行保存
                {
                    try
                    {
                        int executeResule = dbOperAt.updateScript(scriptId, this.typeId, txtEdit.Text, Language.adminName);
                        dgvScript.Rows[rowIndex].Cells[this.languageName].Value = this.txtEdit.Text;
                    }
                    catch  //修改数据时未保存点击下一页则会异常
                    { 
                    
                    }
                }
            }

            scriptId = Convert.ToInt32(dgvScript.CurrentRow.Cells["ScriptID"].Value.ToString());
            txtzh_CN.Text = dgvScript.CurrentRow.Cells["BasicText"].Value.ToString();
            string editText = dgvScript.CurrentRow.Cells[cmbType.Text].Value.ToString();
            rowIndex = e.RowIndex;
            if (editText != "###")
            {
                txtEdit.Text = editText;
                scriptText = editText;
                txtEdit.SelectionStart = txtEdit.TextLength;
            }
            else
            {
                txtEdit.Text = "";
                scriptText = "";
            }
            txtEdit.Focus();
        }
 
        /// <summary>
        /// 保存按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSave_Click(object sender, EventArgs e)
        {
            scriptSave();
            if (chkSaveWrap.Checked)
            {
                try
                {
                    dgvScript.CurrentCell = dgvScript.Rows[dgvScript.CurrentRow.Index + 1].Cells[0];
                }
                catch //dgv索引过界
                {
                    //变换到下一页
                }
            }
            txtEdit.Focus();
        }

        /// <summary>
        /// 保存信息
        /// </summary>
        private void scriptSave()
        { 
            string editText = txtEdit.Text.Trim();
            try
            {
                if (scriptText == editText)
                {
                    return;
                }
                int scriptId = Convert.ToInt32(dgvScript.CurrentRow.Cells["ScriptID"].Value);
                int executeResule = dbOperAt.updateScript(scriptId, this.typeId, editText, Language.adminName);
                dgvScript.CurrentRow.Cells[this.languageName].Value = editText;
                scriptText = editText;
            }
            catch //数据库执行异常 
            {
                
            }
            
        }

        /// <summary>
        /// 捕捉按键信息 (重写)
        /// </summary>
        /// <param name="keyData"></param>
        /// <returns></returns>
        protected override bool ProcessDialogKey(Keys keyData)
        {
            switch (keyData)
            {
                case Keys.Enter: //回车
                    if (chkEnterSave.Checked)
                    {
                        dgvRowMoveDown();
                        return true;
                    }
                    break;
                case (Keys.Control | Keys.Enter):  //Control+回车
                    if (chkPreviousLine.Checked)
                    {
                        dgvRowMoveUp();
                        return true;
                    }
                    break;
                default:
                    return base.ProcessDialogKey(keyData); //执行父类中的ProcessDialogKey事件
            }
            return base.ProcessDialogKey(keyData);  //执行父类中的ProcessDialogKey事件;
        }

        /// <summary>
        /// 上移一行
        /// </summary>
        private void dgvRowMoveUp()
        {
            try
            {
                scriptSave();
                dgvScript.CurrentCell = dgvScript.Rows[dgvScript.CurrentRow.Index -1 ].Cells[0];
            }
            catch //dgv索引过界
            {

            }
        }

        /// <summary>
        /// 下移一行
        /// </summary>
        private void dgvRowMoveDown()
        {
            try
            {
                scriptSave();
                dgvScript.CurrentCell = dgvScript.Rows[dgvScript.CurrentRow.Index + 1].Cells[0];
            }
            catch //dgv索引过界
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
            txtEdit.Text = scriptText;
            txtEdit.SelectionStart = txtEdit.TextLength;
            txtEdit.Focus();
        }
        
        #region checkBox选择
        private void chkEnterSave_CheckedChanged(object sender, EventArgs e)
        {
            txtEdit.Focus();
        }

        private void chkSaveWrap_CheckedChanged(object sender, EventArgs e)
        {
            txtEdit.Focus();
        }

        private void chkWrapSave_CheckedChanged(object sender, EventArgs e)
        {
            txtEdit.Focus();
        }

        private void chkPreviousLine_CheckedChanged(object sender, EventArgs e)
        {
            txtEdit.Focus();
        }
        #endregion

        /// <summary>
        /// 滚轮事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void  rewriteMouseWheel(object sender,MouseEventArgs e)
        {
            switch (e.Delta)
            { 
                case 120:   //上滚
                    setFirstDisplayed(true);
                    break;
                case -120:  //下滚
                    setFirstDisplayed(false);
                    break;
                default:

                    break;
            }
        }
        
        /// <summary>
        /// 滚轮设置
        /// </summary>
        /// <param name="rollState"></param>
        private void setFirstDisplayed(bool rollState)
        {
            if (rollState) //上滚
            {
                if (dgvScript.FirstDisplayedScrollingRowIndex - 3 < 0)  //小于0
                {
                    dgvScript.FirstDisplayedScrollingRowIndex = 0;
                }
                else
                {
                    dgvScript.FirstDisplayedScrollingRowIndex -= 3;
                }
            }
            else
            {
                if (dgvScript.FirstDisplayedScrollingRowIndex + 3 > dgvScript.Rows.Count - 1)
                {
                    dgvScript.FirstDisplayedScrollingRowIndex = dgvScript.Rows.Count - 1;
                }
                else
                {
                    dgvScript.FirstDisplayedScrollingRowIndex += 3;
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            dgvScript.Rows[0].Cells[5].Value = "xx";
        }

        private void ScriptManage_SizeChanged(object sender, EventArgs e)
        {
            asf.controlAutoSize(this);
        }
    }
}
