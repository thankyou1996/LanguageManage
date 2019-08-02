using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace LanguagesManage
{
    public partial class StrDetailed : Form
    {
       
        /// <summary>
        /// 行数
        /// </summary>
        int lineNum = 1;

        /// <summary>
        /// 先后显示的行数量
        /// </summary>
        int displayNum = 10;

        DataTable strContentDt;

        string lineNumStr = "0";
        string content = "textNotExists";
        /// <summary>
        /// 判断值：
        /// 1[不存在标红字符串文件]
        /// 2[显示某个字符串前后的信息，字符串]
        /// 3[显示某个字符串前后信息，方法]
        /// 4[显示源码文件,字符串]
        /// 5[显示源码文件,方法]
        /// </summary>
        int value=0;

        public StrDetailed(int value)
        {
            InitializeComponent();
            this.value = value;
            richGetCodeContent();
        }

       
        /// <summary>
        /// 单个字符查询
        /// </summary>
        /// <param name="lineNum"></param>
        /// <param name="content"></param>
        public StrDetailed(string lineNum, string content,int value)
        {
            InitializeComponent();
            this.value = value;
            this.lineNumStr = lineNum;
            this.content = content;
            
        }


        /// <summary>
        /// 整个页面查询
        /// </summary>
        /// <param name="contentDt"></param>
        public StrDetailed(DataTable contentDt, string fileName, int value)
        {
            InitializeComponent();
            this.value = value;
            this.strContentDt = contentDt.Copy();
            this.Text = fileName;
        }




        private void StrDetailed_Load(object sender, EventArgs e)
        {
            //richGetCodeContent(1);
            asf.controlInitializeSize(this);
            switch (this.value)
            { 
                case 1:    //文件中包不含标红字符串
                    richGetCodeContent();
                    break;
                case 2:   //字符串前后信息
                    richGetCodeContent(this.lineNumStr, this.content);
                    break; 
                case 3:   //方法体前后信息
                    richGetCodeFun(this.lineNumStr, this.content);
                    break;
                case 4:   //显示源码文件 字符串标红
                    richGetCodeContent(1);
                    break;
                case 5:   //显示源码文件  方法体标红
                    richGetCodeFun();
                    break;
                default:   //不可辨识命令
                    break;
            }
            
        }
        /// <summary>
        /// 填充RichTextBox控件中的字符显示
        /// </summary>
        public void richGetCodeContent()
        {
            foreach (DataRow dr in CodeFilter.strDt.Rows)
            {
                richTextBox1.AppendText(string.Format("{0,-6}", dr[0]) + "|");
                richTextBox1.AppendText(dr[1].ToString());
                richTextBox1.AppendText(Environment.NewLine);
            }
        }

        /// <summary>
        /// 填充RichTextBox控件中的字符显示
        /// </summary>
        /// <param name="lineNum"></param>
        /// <param name="content"></param>
        public void richGetCodeContent(string lineNum, string content)
        {
            try
            {
                content = '"' + content + '"';
                this.lineNum = Convert.ToInt32(lineNum);
                this.lineNum -= displayNum;
                DataRow[] drs = CodeFilter.strDt.Select("lineNum >=" + "'" + this.lineNum + "'");
                for (int i = 0; i < drs.Length; i++)
                {
                    int lenght = richTextBox1.Text.Length;
                    richTextBox1.AppendText(drs[i][0] + "|" + drs[i][1] + System.Environment.NewLine);
                    if (drs[i][0].ToString() == lineNum)
                    {
                        if (richTextBox1.Lines[i].Contains(content))
                        {
                            richTextBox1.Select(lenght + richTextBox1.Lines[i].IndexOf(content), content.Length);
                            richTextBox1.SelectionColor = Color.Red;
                        }
                    }
                    if (i >= displayNum * 2)
                    {
                        break;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        /// <summary>
        /// 填充RichTextBox控件中的字符显示
        /// </summary>
        /// <param name="lineNum"></param>
        /// <param name="content"></param>
        public void richGetCodeFun(string lineNum, string content)
        {
            try
            {
                //content = '"' + content + '"';
                this.lineNum = Convert.ToInt32(lineNum);
                this.lineNum -= displayNum;
                DataRow[] drs = GuideBack.strDt.Select("lineNum >=" + "'" + this.lineNum + "'");
                for (int i = 0; i < drs.Length; i++)
                {
                    int lenght = richTextBox1.Text.Length;
                    richTextBox1.AppendText(drs[i][0] + "|" + drs[i][1] + System.Environment.NewLine);
                    if (drs[i][0].ToString() == lineNum)
                    {
                        if (richTextBox1.Lines[i].Contains(content))
                        {
                            richTextBox1.Select(lenght + richTextBox1.Lines[i].IndexOf(content), content.Length);
                            richTextBox1.SelectionColor = Color.Red;
                        }
                    }
                    if (i >= displayNum * 2)
                    {
                        break;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }


        /// <summary>
        /// 填充RichTextBox控件中的字符显示
        /// </summary>
        /// <param name="contentDt"></param>
        public void richGetCodeFun()
        {
            int i = 0;
            getContent(1);
            foreach (DataRow dr in GuideBack.strDt.Rows)
            {
                richTextBox1.AppendText(string.Format("{0,-6}", dr[0]) + "|");
                if (dr[0].ToString() == dtContentLineNum)
                {
                    textSign(dr[0].ToString(), dr[1].ToString(),1);
                }
                else
                {
                    richTextBox1.AppendText(dr[1].ToString());
                }
                richTextBox1.AppendText(Environment.NewLine);
                i++;
            }
        }
        
        /// <summary>
        /// 填充RichTextBox控件中的字符显示
        /// </summary>
        /// <param name="contentDt"></param>
        public void richGetCodeContent(int x)
        {

            int i = 0;
            getContent();
            foreach (DataRow dr in CodeFilter.strDt.Rows)
            {
                this.BeginInvoke(new EventHandler(delegate
                {
                    richTextBox1.AppendText(string.Format("{0,-6}", dr[0]) + "|");
                    if (dr[0].ToString() == dtContentLineNum)
                    {
                        textSign(dr[0].ToString(), dr[1].ToString());
                    }
                    else
                    {
                        richTextBox1.AppendText(dr[1].ToString());
                    }
                    richTextBox1.AppendText(Environment.NewLine);
                    i++;
                }));
            }
        }


        /// <summary>
        /// 表的行索引
        /// </summary>
        int rowindex = 0;

        /// <summary>
        /// 字符串所在行索引
        /// </summary>
        string dtContentLineNum = "0";

        /// <summary>
        /// 字符串内容
        /// </summary>
        string dtContent = "";

        /// <summary>
        /// 获取字符串内容
        /// </summary>
        AutoSizeFormClass asf = new AutoSizeFormClass();
        public void getContent()
        {
            if (this.strContentDt.Rows.Count < 1)
            {
                return;
            }
            if (this.strContentDt.Rows.Count <= rowindex)
            {
                dtContentLineNum = "-1";
                return;
            }
            dtContentLineNum = this.strContentDt.Rows[rowindex][2].ToString();
            dtContent = '"' + this.strContentDt.Rows[rowindex][3].ToString() + '"';
            rowindex++;
        }

        public void getContent(int value)
        {
            if (this.strContentDt.Rows.Count < 1)
            {
                return;
            }
            if (this.strContentDt.Rows.Count <= rowindex)
            {
                dtContentLineNum = "-1";
                return;
            }
            dtContentLineNum = this.strContentDt.Rows[rowindex][1].ToString();
            dtContent =  this.strContentDt.Rows[rowindex][2].ToString();
            rowindex++;
        }
        /// <summary>
        /// RichTextBox中字符串标红
        /// </summary>
        /// <param name="strDtLine"></param>
        /// <param name="lineStr"></param>
        public void textSign(string strDtLine, string lineStr)
        {
            string strContent = dtContent;
            int strEndIndex = lineStr.IndexOf(strContent) + strContent.Length;  //行中字符串结束后索引
            int y = lineStr.Substring(strEndIndex).IndexOf('"');      //第一个字符串结束后‘索引’ 
            string z = lineStr.Substring(strEndIndex);
            int richTextLeght = richTextBox1.Text.Length;   //文本添加之前的长度

            getContent();
            if (y != -1 && strDtLine == dtContentLineNum)
            {
                richTextBox1.AppendText(lineStr.Substring(0, strEndIndex + y));
            }
            else
            {
                richTextBox1.AppendText(lineStr);
            }
            richTextBox1.Select(richTextLeght + lineStr.IndexOf(strContent), strContent.Length);
            richTextBox1.SelectionColor = Color.Red;

            if (strDtLine != dtContentLineNum)
            {
                return;
            }
            string newLine = lineStr.Substring(strEndIndex + y);
            textSign(strDtLine, newLine);
        }

        public void textSign(string strDtLine, string lineStr ,int value)
        {
            string strContent = dtContent;
            int strEndIndex = lineStr.IndexOf(strContent) + strContent.Length;  //行中字符串结束后索引
            
            string z = lineStr.Substring(strEndIndex);
            int richTextLeght = richTextBox1.Text.Length;   //文本添加之前的长度

            getContent(1);
            int nextIndex = lineStr.Substring(strEndIndex).IndexOf(dtContent);      //第一个字符串结束后‘索引’ 
            if (nextIndex !=-1 && strDtLine == dtContentLineNum)
            {
                richTextBox1.AppendText(lineStr.Substring(0, strEndIndex + nextIndex));
            }
            else
            {
                richTextBox1.AppendText(lineStr);
            }
            richTextBox1.Select(richTextLeght + lineStr.IndexOf(strContent), strContent.Length );
            richTextBox1.SelectionColor = Color.Red;

            if (strDtLine != dtContentLineNum)
            {
                return;
            }
            string newLine = lineStr.Substring(strEndIndex + nextIndex);
            textSign(strDtLine, newLine,1);
        }
       
        private void StrDetailed_SizeChanged(object sender, EventArgs e)
        {
            asf.controlAutoSize(this);
        }
    }
}
