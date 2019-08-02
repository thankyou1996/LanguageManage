using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace LanguagesManage
{
    public partial class Type : Form
    {
        #region 全局变量
        /// <summary>
        /// 数据库操作类
        /// </summary>
        DataOperation data;

        /// <summary>
        /// 数据表中的更新时间列的索引
        /// </summary>
        int UpdateIndex;

        /// <summary>
        /// 数据表中管理员列的索引
        /// </summary>
        int AdminIndex;

        ///// <summary>
        ///// 判断是否需要进行修改
        ///// </summary>
        //bool isUpdate = false;

        /// <summary>
        /// 数据表行数量
        /// </summary>
        int dgvRow;

        ///// <summary>
        ///// 记录语言名称，防止重复
        ///// </summary>
        //string oldLanguageName;

        /// <summary>
        /// 语言列的索引
        /// </summary>
        int languageNameIndex;
        #endregion

        string typeIDStr;
        DataTable dtType;
        public Type()
        {
            InitializeComponent();
            data = new DataOperation();
        }

        private void Type_Load(object sender, EventArgs e)
        {
            initialBtnSet();
            controlReadOnlySet(true);
            dtBind();
            if (dtType.Rows.Count < 1)
            {
                return;
            }

            typeIDStr = dgvType.CurrentRow.Cells[0].Value.ToString();
            getTypeInfo(typeIDStr);
        }

        /// <summary>
        /// 对界面视图进行重新绑定
        /// </summary>
        public void dtBind()
        {
            dtType = data.getType().Tables[0];
            dgvType.DataSource = dtType;
            Common.gridViewModeControl(dgvType);
            UpdateIndex = dgvType.Columns["UpdateTime"].Index;
            AdminIndex = dgvType.Columns["AdminName"].Index;
            languageNameIndex = dgvType.Columns["languageName"].Index;
            //20160321 TODO:添加界面显示列的控制
            dgvType.Columns["TypeID"].HeaderText = "ID";
            dgvType.Columns["LanguageName"].HeaderText = "语言名称";
            dgvType.Columns["Reserved_1"].HeaderText = "中文名称";
            dgvType.Columns["AddTime"].HeaderText = "添加时间";
            dgvType.Columns["AddTime"].Visible = false;
            dgvType.Columns["UpdateTime"].HeaderText = "更新时间";
            dgvType.Columns["UpdateTime"].Visible = false;
            dgvType.Columns["AdminName"].HeaderText = "操作人员";
            dgvType.Columns["AdminName"].Visible = false;
            dgvType.Columns["Reserved_2"].HeaderText = "语言简称";
            dgvType.Columns["Reserved_3"].Visible = false;

            dgvRow = dgvType.Rows.Count;
            Common.gridViewModeControl(this.dgvType);
        }

        /// <summary>
        /// 获取信息
        /// </summary>
        /// <param name="typeID"></param>
        private void getTypeInfo( string  typeID)
        {
            if (string.IsNullOrEmpty(typeID)) //判断信息是否为空
            {
                return;
            }
            DataRow typeInfo = dtType.Select("TypeID='" + typeID + "'")[0];
            txtID.Text = typeInfo["TypeID"].ToString();
            txtLanguageName.Text = typeInfo["LanguageName"].ToString();
            txtLanguageName2.Text = typeInfo["Reserved_1"].ToString();
            txtAbbreviation.Text = typeInfo["Reserved_2"].ToString();
            lblAddTime.Text = typeInfo["AddTime"].ToString();
            lblUpdateTime.Text = typeInfo["UpdateTime"].ToString();
            lblAdmin.Text = typeInfo["AdminName"].ToString();

        }
       
        /// <summary>
        /// 选中行改变时
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgvType_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                typeIDStr = dgvType.SelectedRows[0].Cells[0].Value.ToString();
                getTypeInfo(typeIDStr);
                controlReadOnlySet(true);
                initialBtnSet();
            }
            catch
            { 
            
            }
        }

        /// <summary>
        /// textBox控件只读属性更改
        /// </summary>
        /// <param name="setBool"></param>
        private void controlReadOnlySet(bool setBool)
        {
            txtLanguageName.ReadOnly = setBool;
            txtLanguageName2.ReadOnly = setBool;
            txtAbbreviation.ReadOnly = setBool;
        }

        /// <summary>
        /// 按钮初始值设置
        /// </summary>
        private void initialBtnSet()
        {
            btnCancel.Enabled = true;
            btnEdit.Enabled = true;
            btnAdd.Enabled = true;
            btnSave.Enabled = false;
        }

        /// <summary>
        /// 编辑
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnEdit_Click(object sender, EventArgs e)
        {
            controlReadOnlySet(false);
            btnAdd.Enabled = false;
            btnEdit.Enabled = false;
            btnSave.Enabled = true;
        }

        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAdd_Click_1(object sender, EventArgs e)
        {
            txtID.Text = "";
            txtLanguageName.Text="";
            txtLanguageName2.Text = "";
            txtAbbreviation.Text = "";
            lblAddTime.Text = "";
            lblUpdateTime.Text = "";
            lblAdmin.Text = "";
            controlReadOnlySet(false);
            btnEdit.Enabled = false;
            btnAdd.Enabled = false;
            btnSave.Enabled = true;
        }

        /// <summary>
        /// 取消
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCancel_Click_1(object sender, EventArgs e)
        {
            getTypeInfo(typeIDStr);
            initialBtnSet();
            controlReadOnlySet(true);
        }

        /// <summary>
        /// 保存
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (!verify())
                {
                    return;
                }
                string languageName = txtLanguageName.Text;
                string languageName2 = txtLanguageName2.Text;
                string languageAbbreviation = txtAbbreviation.Text;
                if (string.IsNullOrEmpty(txtID.Text))
                {
                    if (data.existsType(txtLanguageName.Text.Trim(), txtLanguageName2.Text.Trim(), txtAbbreviation.Text.Trim()) > 0)
                    {
                        MessageBox.Show("请不要输入相同信息");
                        return;
                    }
                    data.addType(languageName, languageName2, languageAbbreviation, Language.adminName);
                    dtBind();
                    initialBtnSet();
                    getTypeInfo(typeIDStr);
                    controlReadOnlySet(true);
                    getValue(languageName);
                    addScript(languageName);
                    MessageBox.Show("添加成功");
                    return;
                }
                //if (data.existsType(txtLanguageName.Text, txtLanguageName2.Text, txtAbbreviation.Text) > (1 - editVerift()))
                //{
                //    MessageBox.Show("请不要输入相同信息");
                //    return;
                //}

                int x = data.existsType(txtLanguageName.Text, txtLanguageName2.Text, txtAbbreviation.Text);
                if ( x> (1 - editVerift()))
                {
                    MessageBox.Show("请不要输入相同信息");
                    return;
                }
                int typeID = Convert.ToInt32(txtID.Text);
                data.updateType(typeID, languageName, languageName2, languageAbbreviation, Language.adminName);
                dtBind();
                initialBtnSet();
                getTypeInfo(typeIDStr);
                controlReadOnlySet(true);
                getValue(languageName);
                MessageBox.Show("编辑成功");
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            
        }

        /// <summary>
        /// 刷新
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnFlush_Click(object sender, EventArgs e)
        {
            initialBtnSet();
            controlReadOnlySet(true);
            dtBind();
            if (dtType.Rows.Count < 1)
            {
                return;
            }

            typeIDStr = dgvType.CurrentRow.Cells[0].Value.ToString();
            getTypeInfo(typeIDStr);
        }

        /// <summary>
        /// 编辑验证
        /// </summary>
        /// <returns></returns>
        private int editVerift()
        {
            if (dgvType.CurrentRow.Cells["LanguageName"].Value.ToString() != txtLanguageName.Text)
            {
                return 1;
            }
            else if (dgvType.CurrentRow.Cells["Reserved_1"].Value.ToString() != txtLanguageName2.Text)
            {
                return 1;
            }
            else if (dgvType.CurrentRow.Cells["Reserved_2"].Value.ToString() != txtAbbreviation.Text)
            {
                return 1;
            }
            return 0;
        }
        
        private void addScript(string languageName)
        {
            int typeID = data.getTypeID(languageName);
            DataTable dtBasicScriptID = data.getBasicScriptID().Tables[0];
            DataTable dtScript = data.getScriptClone().Tables[0];
            DataRow newDr;
            foreach (DataRow dr in dtBasicScriptID.Rows)
            {
                newDr = dtScript.NewRow();
                newDr["ScriptID"]=dr["ScriptID"];
                newDr["TypeID"] = typeID;
                newDr["Content"] = "###";
                newDr["AdminName"] = Language.adminName;
                dtScript.Rows.Add(newDr);
            }
            data.updateScriptDt(dtScript);
        }

        /// <summary>
        /// 值验证
        /// </summary>
        /// <returns></returns>
        private bool verify()
        {
            if (string.IsNullOrEmpty(txtLanguageName.Text) || string.IsNullOrEmpty(txtLanguageName2.Text) || string.IsNullOrEmpty(txtAbbreviation.Text))
            {
                MessageBox.Show("请输入信息");
                return false;
            }
            return true;
        }

        /// <summary>
        /// 获取信息
        /// </summary>
        /// <param name="languageName"></param>
        private void getValue(string languageName)
        {
            DataRow[] drs = dtType.Select("LanguageName='" + languageName + "'");
            int index = dtType.Rows.IndexOf(drs[0]);
            dgvType.Rows[index].Selected = true;
            dgvType.CurrentCell = dgvType.Rows[index].Cells[0];
        }

        
    }
}
