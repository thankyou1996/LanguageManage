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
    public partial class Login : Form
    {
        #region 全局变量
        /// <summary>
        /// 数据库操作类
        /// </summary>
        DataOperation data;


        #endregion
        public Login()
        {
            InitializeComponent();
            data = new DataOperation();
        }
        private void Login_Load(object sender, EventArgs e)
        {
            //LanguageSwitchDT();
            DataTable dtType = LanguageGet.getLanguageType().Tables[0];
            DataRow dr = dtType.NewRow();
            dr["TypeID"]=0;
            dr["LanguageName"] = "中文简体";
            dtType.Rows.InsertAt(dr, 0);
            cmbType.DisplayMember = "LanguageName";
            cmbType.ValueMember = "TypeID";
            cmbType.DataSource = dtType;
        }

        /// <summary>
        /// 登录按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnLogin_Click(object sender, EventArgs e)
        {
            lblHint.Text="";
            if(string.IsNullOrEmpty(txtName.Text.Trim())||string.IsNullOrEmpty(txtPwd.Text.Trim()))//判断文本框是否为空
            {
                lblHint.Text = "用户名和密码不能为空";
                txtName.Focus();  //焦点返回文本框
                return;//有一项为空则不进行操作
            }
            lblHint.Text = "登录中...";
            btnLogin.Enabled = false;
            Thread thr = new Thread(new ThreadStart(login));//避免数据库异常时界面卡顿
            thr.IsBackground = true;
            thr.Start();
        }

        /// <summary>
        /// 登录事件
        /// </summary>
        public void login()
        {
            string adminName = txtName.Text.Trim();
            string password = txtPwd.Text.Trim();
            try
            {
                int LoginInt = data.adminLogin(adminName, password);
                if (LoginInt > 0)//登录成功
                {
                    Language.adminName = adminName;//记录登录名
                    this.DialogResult = DialogResult.OK;
                }
                else//登录失败
                {
                    this.BeginInvoke(new EventHandler(delegate
                        {
                            btnLogin.Enabled = true;
                            txtName.Focus();  //焦点返回文本框
                            lblHint.Text = "用户名或密码不正确";
                        }));
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("发生错误，请确认数据库连接。");
                ErrorLog.WriteLog(ex, "登录错误");
            }
        }

        /// <summary>
        /// 退出按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();//窗口关闭
        }

        #region  界面语言切换

        /// <summary>
        ///  语言切换（从数据库读取信息）
        /// </summary>
        public void LanguageSwitchDB()
        {
            try
            {
                this.Text = LanguageGet.getContentFromDB((int)LoginFormenum.Form);
                lblTitle.Text = LanguageGet.getContentFromDB((int)LoginFormenum.lblTitle);
                lblName.Text = LanguageGet.getContentFromDB((int)LoginFormenum.lblName);
                lblPwd.Text = LanguageGet.getContentFromDB((int)LoginFormenum.lblPwd);
                lblLanguage.Text = LanguageGet.getContentFromDB((int)LoginFormenum.lblLanguage);
                btnLogin.Text = LanguageGet.getContentFromDB((int)LoginFormenum.btnLogin);
                btnClose.Text = LanguageGet.getContentFromDB((int)LoginFormenum.btnClose);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        /// <summary>
        /// 语言切换（从内存表中读取
        /// ）
        /// </summary>
        public void LanguageSwitchDT()
        {
            try
            {
                this.Text = LanguageGet.getContentFromDT((int)LoginFormenum.Form);
                lblTitle.Text = LanguageGet.getContentFromDT((int)LoginFormenum.lblTitle);
                lblName.Text = LanguageGet.getContentFromDT((int)LoginFormenum.lblName);
                lblPwd.Text = LanguageGet.getContentFromDT((int)LoginFormenum.lblPwd);
                lblLanguage.Text = LanguageGet.getContentFromDT((int)LoginFormenum.lblLanguage);
                btnLogin.Text = LanguageGet.getContentFromDT((int)LoginFormenum.btnLogin);
                btnClose.Text = LanguageGet.getContentFromDT((int)LoginFormenum.btnClose);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


        #endregion


        /// <summary>
        /// 下拉框切换事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmbType_SelectedIndexChanged(object sender, EventArgs e)
        {
            LanguageGet.typeID = Convert.ToInt32(cmbType.SelectedValue);
            //LanguageSwitchDT();
        }
    }
}
