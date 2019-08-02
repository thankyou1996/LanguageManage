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
    public partial class test : Form
    {
        public test()
        {
            InitializeComponent();
        }

        protected override void OnMouseWheel(MouseEventArgs e)
        {
            MessageBox.Show("1");
            base.OnMouseWheel(e);
        }
        DataOperation data = new DataOperation();
        private void test_Load(object sender, EventArgs e)
        {
            DataTable dt;
            
            string languageNames = data.getLanguageNames();
            dt = data.getV_Script(languageNames).Tables[0];
            dgvScript.DataSource = dt;//绑定数据源
            //Common.gridViewModeControl(dgvScript);
            //20160323 对数据显示进行控制
            dgvScript.Columns[0].ReadOnly = true;
            dgvScript.Columns[1].ReadOnly = true;
            dgvScript.Columns[2].ReadOnly = true;
            dgvScript.Columns[3].ReadOnly = true;

            //dgvScript.Columns["Position"].HeaderText = "所在窗体";
            //dgvScript.Columns["Reserved_1"].HeaderText = "控件名称";
            //dgvScript.Columns["BasicText"].HeaderText = "中文简体";
            dgvScript.Columns[0].Visible = false;
            //dgvScript.Columns[2].Visible = false;
            textBox1.MouseWheel +=new MouseEventHandler(this.zz);
        }

        private void zz(object sender, MouseEventArgs e)
        {
            //Rectangle rectangle = this.dgvScript.RectangleToClient(this.dgvScript.ClientRectangle);
            Rectangle rect = new Rectangle(this.Left+this.dgvScript.Left, this.dgvScript.Location.X, this.dgvScript.Width, this.dgvScript.Height); // huoqu 
            if (rect.Contains(MousePosition))
            {
                textBox2.Text = "in";
            }
            else
            {
                textBox2.Text="not in";
            }
        }
        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void toolTip1_Popup(object sender, PopupEventArgs e)
        {

        }
    }
}
