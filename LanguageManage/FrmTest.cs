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
    public partial class FrmTest : Form
    {
        public FrmTest()
        {
            InitializeComponent();
        }

        private void FrmTest_Load(object sender, EventArgs e)
        {
            Init();
        }
        public void Init()
        {
            DataTable dtSource = new DataTable();
            dtSource.Columns.Add("ID");
            dtSource.Columns.Add("Name");
            dtSource.Columns.Add("Check", typeof(Boolean));

            for (int i = 1; i < 5; i++)
            {
                DataRow dr = dtSource.NewRow();
                dr["ID"] = i;
                dr["Name"] = "Name" + i;
                dtSource.Rows.Add(dr);
            }
            dataGridView1.DataSource = dtSource;
        }


    }
}
