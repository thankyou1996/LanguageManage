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
    public partial class UpLanguage : Form
    {
        #region 全局变量
        /// <summary>
        /// 数据操作类
        /// </summary>
        DataOperation data;

        /// <summary>
        /// 存放数据库语句对象(key代表参数，value代表SQL语句)
        /// </summary>
        List<DictionaryEntry> SQLlist = new List<DictionaryEntry>();

        Hashtable SQLStrings = new Hashtable();

        /// <summary>
        /// 用于存放单元格修改的信息
        /// </summary>
        string cellString;

        DataTable dt;

        AutoSizeFormClass asf = new AutoSizeFormClass();
        #endregion
        public UpLanguage()
        {
            InitializeComponent();
            data = new DataOperation();
        }

        /// <summary>
        /// 取消按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Cancelbtn_Click(object sender, EventArgs e)
        {
            dataBind();
        }

        private void UpLanguage_Load(object sender, EventArgs e)
        {

            asf.controlInitializeSize(this);
            DataTable dtAllType = data.getType().Tables[0];
            cmbType.Items.Add("所有语言"); //绑定语言下拉框
            foreach (DataRow dr in dtAllType.Rows)
            {
                cmbType.Items.Add(dr["LanguageName"]);
            }
            cmbType.SelectedIndex = 0;

            DataTable dtAllPosition = data.getPosition().Tables[0];
            cmbPosition.Items.Add("所有"); //绑定位置下拉框
            foreach (DataRow dr in dtAllPosition.Rows)
            {
                cmbPosition.Items.Add(dr["Position"]);
            }
            cmbPosition.SelectedIndex = 0;
            dataBind();
        }

        #region  更新语言
        /// <summary>
        /// 更新语言页获取下拉框选择的语言
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnGetType_Click(object sender, EventArgs e)
        {
            if (cmbType.SelectedIndex == 0)//判断是否选择所有语言
            {
                try
                {
                    //显示所有语言
                    for (int i = 4; i < dgvScript.Columns.Count; i++)
                    {
                        dgvScript.Columns[i].Visible = true;
                        //Common.gridViewModeControl(dgvScript);
                    }
                }
                catch
                { 
                
                }
                return;
            }
            string LanguageName = cmbType.Text.Trim();
            for (int i = 4; i < dgvScript.Columns.Count; i++)
            {
                dgvScript.Columns[i].Visible = false;
            }
            dgvScript.Columns[cmbType.Text].Visible = true;
            //dgvScript.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        /// <summary>
        /// 单元格启动编辑时发生的事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgvUpdateScript_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            cellString =dgvScript.CurrentCell.Value.ToString(); //记录单元个信息
        }

        /// <summary>
        /// 单元格关闭编辑是发生的事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgvUpdateScript_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            string content = dgvScript.CurrentCell.Value.ToString(); //获取编辑完成后单元格的值
            if (content == cellString)//判断单元格的内容是否发生改变
            {
                //内容未发生改变，不进行操作
                return;
            }
            else
            {
                #region 修改后验证通过后创建语句
                int scriptID = int.Parse(dgvScript.Rows[e.RowIndex].Cells[0].Value.ToString());//获取语句ID
                string LanguageName = dgvScript.Columns[e.ColumnIndex].HeaderText; //获取姓名
                int typeID = data.getTypeID(LanguageName); //获取语言ID
                DictionaryEntry de = data.paraAndSQLScriptUpdate(scriptID, typeID, content, Language.adminName);//组建数据库语句
                //（20160318 TODO:最后一项参数修改为登录管理员的姓名）
                SQLlist.Add(de);
                #endregion
            }
        }

        /// <summary>
        /// 更新语言页更新按钮操作
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            //if (SQLStrings.Count == 0||SQLStrings==null)
            //{
            //    MessageBox.Show("请编辑要更新数据");
            //    return;
            //}
            //try
            //{
            //    //20160318 TODO:可以添加更新前的确认（提示修改的数量）
            //    //添加修改成功后的提示
            //    data.ExecuteSQLs(SQLStrings);
            //    DataTable dtScript = data.getScript().Tables[0];
            //    SQLStrings = new Hashtable();
            //    dgvScript.DataSource = dtScript;
            //    dgvScript.Columns[0].ReadOnly = true;
            //    dgvScript.Columns[1].ReadOnly = true;
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show(ex.Message);
            //    //20160318 TODO:添加插入失败的界面提示(数据库操作失败)
            //}
            //20160319 TODO:添加提醒（更新的数量，确定后才对数据进行更新）
            if (SQLlist.Count == 0 || SQLlist == null)
            {
                return; //没有进行更新操作
            }
            try
            {
                data.ExecuteSQLs(SQLlist);
                SQLlist = new List<DictionaryEntry>(); //执行完成后重新实例化list对象
                dataBind(); //界面数据重新绑定
                MessageBox.Show("更新成功");
            }
            catch
            {
                MessageBox.Show("由于数据库原因，更新失败");
            }

        }
        #endregion


        /// <summary>
        /// 界面绑定数据源
        /// </summary>
        private void dataBind()
        {
            try
            {
                string languageNames = data.getLanguageNames();
                dt = data.getV_Script(languageNames).Tables[0];
                dgvScript.DataSource = dt;//绑定数据源
                //Common.gridViewModeControl(dgvScript);
                //20160323 对数据显示进行控制
                dgvScript.Columns[0].ReadOnly = true;
                dgvScript.Columns[1].ReadOnly = true;
                dgvScript.Columns[2].ReadOnly = true;
                dgvScript.Columns[3].ReadOnly = true;

                dgvScript.Columns["Position"].HeaderText = "所在窗体";
                dgvScript.Columns["Reserved_1"].HeaderText = "控件名称";
                dgvScript.Columns["BasicText"].HeaderText = "中文简体";
                dgvScript.Columns[0].Visible = false;
                //dgvScript.Columns[2].Visible = false;
            }
            catch(Exception ex)
            {
                ErrorLog.WriteLog(ex, "更新界面出错");
            }
        }

        private void btnGetPosition_Click(object sender, EventArgs e)
        {
            if (cmbPosition.SelectedIndex == 0)
            {
                dgvScript.DataSource = dt;
            }
            else
            {
                string position = cmbPosition.Text;
                DataRow[] drs =  dt.Select(" Position = '"+position+"' ");
                if (drs.Count() == 0)
                {
                    MessageBox.Show("没有相关信息");
                    return;
                }
                dgvScript.DataSource = drs.CopyToDataTable();
            }
        }
        /// <summary>
        /// 退出按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void butOut_Click(object sender, EventArgs e)
        {
            //this.Close();
        }

        private void UpLanguage_SizeChanged(object sender, EventArgs e)
        {
            asf.controlAutoSize(this);
        }

    }
}
