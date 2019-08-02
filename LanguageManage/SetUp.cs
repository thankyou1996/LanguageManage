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
    public partial class SetUp : Form
    {
        public SetUp()
        {
            InitializeComponent();
        }
        int pageSize = 0;

        private void SetUp_Load(object sender, EventArgs e)
        {
            
            getConfigInfo();
        }

        /// <summary>
        /// 获取信息
        /// </summary>
        private void getConfigInfo()
        {
            SetConfig.getConfigInfo();
            pageSize = SetConfig.PageSize;
            txtPageSize.Text = Convert.ToString(SetConfig.PageSize);
        }

        private void btnSet_Click(object sender, EventArgs e)
        {
            try
            {
                if (verift())
                {
                    SetConfig.setConfigInfo(this.pageSize);
                    getConfigInfo();
                    MessageBox.Show("保存成功");
                    this.Close();
                    
                }
            }
            catch
            {
                MessageBox.Show("请规范输入信息");
            }
        }

        /// <summary>
        /// 验证信息
        /// </summary>
        /// <returns></returns>
        public bool verift()
        {
            try
            {
                int pageSize = Convert.ToInt32(txtPageSize.Text);
                if (pageSize > 5000||pageSize<1)
                {
                    MessageBox.Show("请输入合适的数量");
                    return false;
                }
                this.pageSize = pageSize;
                return true;
            }
            catch
            {
                throw;
            }
        }

        /// <summary>
        /// 验证是否为数字
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtPageSize_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar != '\b') //判断是否为退格键
            {
                if ((e.KeyChar < '0') || e.KeyChar > '9')
                {
                    e.Handled = true;
                }
            }
        }

        /// <summary>
        /// 取消按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCancel_Click(object sender, EventArgs e)
        {
            getConfigInfo();
        }
    }
}
