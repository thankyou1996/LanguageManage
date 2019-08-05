using LanguagesManage.Model;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace LanguagesManage
{
    public partial class FrmResxInfoSet : Form
    {
        public FrmResxInfoSet()
        {
            InitializeComponent();
        }

        public delegate void ResxInfoChangedDelegate(object sender, CodeResxItem value);

        public event ResxInfoChangedDelegate ResxInfoChangedEvent;

        private void ResxInfoChange(CodeResxItem value)
        {
            if (ResxInfoChangedEvent != null)
            {
                ResxInfoChangedEvent(this, value);
            }
        }



        int intDisplayNum = 10;
        CodeResxItem CurrentCodeResx;

        public void SetCodeResxItem(CodeResxItem item)
        {
            CurrentCodeResx = item;
            SetCodeResxItem_Code(item);
            SetCodeResxItem_CodeView(item);
        }


        private void FrmResxInfoSet_Load(object sender, EventArgs e)
        {

        }


        public void SetCodeResxItem_Code(CodeResxItem item)
        {
            txtValue.Text = item.ResxData.Value;
            txtComment.Text = item.ResxData.Comment;
        }

        public void SetCodeResxItem_CodeView(CodeResxItem item)
        {
            List<string> CodeViewSource = item.CodeViewSource;
            List<string> Temp_strValue = new List<string>();
            int Temp_intIndex = item.Line - intDisplayNum;
            for (int i = 0 ; i < CodeViewSource.Count; i++)
            {
                if (Temp_intIndex < 1)
                {
                    continue;
                }
                if (Temp_intIndex > (item.Line + intDisplayNum))
                {
                    return;
                }
                int lenght = richTextBox1.Text.Length;
                richTextBox1.AppendText(Temp_intIndex + "|" + CodeViewSource[Temp_intIndex] + System.Environment.NewLine);
                if (Temp_intIndex == item.Line)
                {
                    if (richTextBox1.Lines[i].Contains(item.ResxData.Name))
                    {
                        richTextBox1.Select(lenght + richTextBox1.Lines[i].IndexOf(item.ResxData.Name), item.ResxData.Name.Length);
                        richTextBox1.SelectionColor = Color.Red;
                    }
                }
                Temp_intIndex++;
                
            }
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            CurrentCodeResx.ResxData.Value = txtValue.Text;
            CurrentCodeResx.ResxData.Comment = txtComment.Text;
            ResxInfoChange(CurrentCodeResx);
            this.Close();
        }
    }
}
