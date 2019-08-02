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
    public partial class GuideBack : Form
    {
        public GuideBack()
        {
            InitializeComponent();
        }
        #region 全局变量
        /// <summary>
        /// 存放文件路径
        /// </summary>
        string[] filePaths;

        /// <summary>
        /// 存放文件名
        /// </summary>
        string[] fileNames;

        /// <summary>
        /// 在行中读取的到数据进行赋值
        /// </summary>
        DataTable dtContent = new DataTable();

        /// <summary>
        /// 中文更新表
        /// </summary>
        DataTable dtBasicScriptInsert = new DataTable();

        /// <summary>
        /// 脚本更新表
        /// </summary>
        DataTable dtScriptInsert;

        /// <summary>
        /// 数据库操作对象
        /// </summary>
        DataOperation dbOperat = new DataOperation();

        /// <summary>
        /// 替换的字符串
        /// </summary>
        public static  bool dbText = true;

        public static DataTable strDt=new DataTable ();


        AutoSizeFormClass asf = new AutoSizeFormClass();

        public static int projectID;

        #endregion

        private void Form1_Load(object sender, EventArgs e)
        {
            asf.controlInitializeSize(this);
            dbOperat = new DataOperation();
            try
            {
                dtInitlal();
                dgvSetup();
                cmbBind();
            }
            catch
            {
                MessageBox.Show("数据库不存在");
            }
            
        }

        /// <summary>
        /// dgv的设置
        /// </summary>
        public void dgvSetup()
        {
            dgvStrContent.DataSource = dtContent;
            this.dgvStrContent.Columns[3].SortMode = dgvStrContent.Columns[1].SortMode;
            dgvStrContent.ReadOnly = true;
            dgvStrContent.Columns[1].Width = 60;
        }

        /// <summary>
        /// 对表进行初始化
        /// </summary>
        public void dtInitlal()
        {
            dtContent.Columns.Add("文件名");
            dtContent.Columns.Add("所在行");
            dtContent.Columns.Add("方法");
            dtContent.Columns.Add("导回内容");
            dtBasicScriptInsert = dbOperat.getBasicScript().Tables[0].Clone();
            dtScriptInsert = dbOperat.getScriptClone().Tables[0].Clone();
            strDt = new DataTable();
            strDt.Columns.Add("lineNum", typeof(int));
            strDt.Columns.Add("lineStr");
        }

        public void cmbBind()
        {
            DataTable dtType = dbOperat.getType().Tables[0];
            DataRow dr = dtType.NewRow();
            dr["TypeID"] = 0;
            dr["Reserved_1"] = "简体中文";
            dtType.Rows.InsertAt(dr, 0);
            cmbType.ValueMember = "TypeID";
            cmbType.DisplayMember = "Reserved_1";
            cmbType.DataSource = dtType;
        }

        /// <summary>
        /// 文件对象
        /// </summary>
        List<CodeFile> codeFiles = new List<CodeFile>();


        string lastOpenPath = Application.StartupPath;   

        /// <summary>
        /// 选择文件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnMulti_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFile = new OpenFileDialog();
            openFile.Multiselect = true; //设置是否可以选择多个文件
            openFile.InitialDirectory = lastOpenPath;   //设置默认路径（程序路径）
            openFile.RestoreDirectory = false;
            //openFile.FileOk += openFile_FileOk;
            openFile.Filter = "所有文件(*.*)|*.*";
            openFile.FilterIndex = 2;
            openFile.RestoreDirectory = false;
            if (openFile.ShowDialog() == DialogResult.OK)
            {
                lastOpenPath = openFile.FileName;
                if (openFile.FileNames.Length > 0)
                {
                    codeFiles.Clear(); //清除旧对象
                    filePaths = openFile.FileNames;
                    fileNames = new string[filePaths.Length];
                    CodeFile codeFile;
                    bool flag = true;
                    for (int i = 0; i < filePaths.Length; i++)
                    {
                        fileNames[i] = filePaths[i].Substring(filePaths[i].LastIndexOf("\\") + 1); //文件名
                        foreach (CodeFile cf in codeFiles)
                        {
                            if (cf.FileName == fileNames[i])
                            {
                                flag = false;
                                break;
                            }
                        }
                        if (flag)
                        {
                            codeFile = new CodeFile(filePaths[i], fileNames[i]);
                            codeFiles.Add(codeFile);
                        }
                    }
                    readStr();
                }
                else
                {
                    return;
                }
            }
            
            lstItemSet();
        }



       

        /// <summary>
        /// 替换按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnReplaces_Click(object sender, EventArgs e)
        {
            try
            {
                if (codeFiles.Count < 1)
                {
                    MessageBox.Show("未选中任何文件！");
                }
               
                object result = WaitWindow.WaitWindow.Show(this.replacesWorkMethod, "操作中，请等待");
                MessageBox.Show(result.ToString());
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        /// <summary>
        /// 替换操作
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void replacesWorkMethod(object sender, WaitWindow.WaitWindowEventArgs e)
        {
            DateTime startTime = DateTime.Now;
            //strToContent = true;
            int count = 0;
            for (int i = 0; i < codeFiles.Count; i++)
            {
                DataRow[] drs = dtContent.Select(" 文件名 =" + "'" + codeFiles[i].FileName + "'");
                codeFiles[i].readCodeStr();
                codeFiles[i].guideBack(drs);
                count += codeFiles[i].ReplaceCount;
            }
            DateTime endTime = DateTime.Now;

            if (e.Arguments.Count > 0)
            {
                e.Result = e.Arguments[0].ToString();
            }
            else
            {
                TimeSpan ts = endTime - startTime;
                e.Result = "导回完成" + Environment.NewLine + "耗时：" + string.Format("{0}时{1}分{2}秒", ts.Hours, ts.Minutes, ts.Seconds) + "替换数量：" + count;
            }
        }

        /// <summary>
        /// 刷新按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnFlushs_Click(object sender, EventArgs e)
        {
            readStr();
            lstItemSet();
        }

        /// <summary>
        /// 移除按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnRemove_Click(object sender, EventArgs e)
        {
            try
            {
                int index = lstPath.SelectedIndex;
                if (index == -1)
                {
                    return;
                }
                codeFiles.RemoveAt(index);
                readStr();
                lstItemSet();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

        }

        /// <summary>
        /// 添加按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAdd_Click(object sender, EventArgs e)
        {

            OpenFileDialog openFile = new OpenFileDialog();
            openFile.Multiselect = true; //设置是否可以选择多个文件
            openFile.InitialDirectory = Application.StartupPath;   //设置默认路径（程序路径）
            openFile.Filter = "所有文件(*.*)|*.*";
            openFile.FilterIndex = 2;
            openFile.RestoreDirectory = false;
            if (openFile.ShowDialog() == DialogResult.OK)
            {
                if (openFile.FileNames.Length > 0)
                {
                    filePaths = openFile.FileNames;
                    fileNames = new string[filePaths.Length];
                    CodeFile codeFile;
                    bool flag = true;
                    for (int i = 0; i < filePaths.Length; i++)
                    {
                        fileNames[i] = filePaths[i].Substring(filePaths[i].LastIndexOf("\\") + 1);
                        foreach (CodeFile cf in codeFiles)
                        {
                            if (cf.FileName == fileNames[i]) //判断是否重复
                            {
                                flag = false;
                                break;
                            }
                        }
                        if (flag)
                        {
                            codeFile = new CodeFile(filePaths[i], fileNames[i]);
                            codeFiles.Add(codeFile);
                        }
                    }
                    readStr();
                }
                else
                {
                    return;
                }
            }
            lstItemSet();
        }

        /// <summary>
        /// 清空按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnRemoveAll_Click(object sender, EventArgs e)
        {
            codeFiles.Clear();
            lstItemSet();
        }

        /// <summary>
        /// 获取对象中的索引通过fileName
        /// </summary>
        /// <param name="fileName"></param>
        /// <returns></returns>
        public int getCodeFilesIndex(string fileName)
        {
            for (int i = 0; i < codeFiles.Count; i++)
            {
                if (codeFiles[i].FileName == fileName)
                {
                    return i;
                }

            }
            return -1;

        }

        /// <summary>
        /// lstPath显示设置（刷新设置）
        /// </summary>
        public void lstItemSet()
        {
            lstPath.Items.Clear();
            if (codeFiles.Count < 1)
            {
                return;
            }
            for (int i = 0; i < codeFiles.Count; i++)
            {
                lstPath.Items.Add(codeFiles[i].FileName);
            }
        }

        /// <summary>
        /// 读取文件中的字符串
        /// </summary>
        public void readStr()
        {
            dtContent.Rows.Clear();
            for (int i = 0; i < codeFiles.Count; i++)
            {
                codeFiles[i].readCodeFun();

            }
            for (int i = 0; i < codeFiles.Count; i++)
            {
                for (int j = 0; j < codeFiles[i].StrContents.Count; j++)
                {
                    DataRow dr = dtContent.NewRow();
                    //dr["ID"] = ID++;
                    dr["文件名"] = codeFiles[i].FileName;
                    dr["所在行"] = codeFiles[i].StrContents[j].lineNum;
                    dr["方法"] = codeFiles[i].StrContents[j].strContent;
                    dr["导回内容"] = codeFiles[i].StrContents[j].dbContent;
                    dtContent.Rows.Add(dr);
                }
            }
            lblStrNum.Text = dtContent.Rows.Count.ToString();
            dgvStrContent.DataSource = dtContent;

        }


        /// <summary>
        /// 查看文件按钮(文件预览)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {

            //strDt = codeFiles[codeFileIndex].FileLineDt;
            int lstIndex = lstPath.SelectedIndex;
            string fileName = "";
            if (lstIndex == -1)
            {
                lstPath.SelectedIndex = 0;
                strDt = codeFiles[0].FileLineDt;
                fileName = lstPath.Items[0].ToString();
            }
            else
            {
                strDt = codeFiles[lstIndex].FileLineDt;
                fileName = lstPath.Items[lstIndex].ToString();
            }
            DataRow[] drs = dtContent.Select("文件名='" + fileName + "'");
            if (drs.Length < 1)
            {
                StrDetailed detailed = new StrDetailed(1);
                detailed.Show();
                return;
            }
            using (DataTable dt3 = drs.CopyToDataTable())
            {
                //foreach (DataRow dr in drs)
                //{
                //    dt3.Rows.Add(dr);
                //}
                //DataTable dt2 = dtContent.Copy();
                //int strNum = getDbNum();
                StrDetailed detailed = new StrDetailed(dt3, fileName, 5);
                detailed.Show();
            }
          
        }

        /// <summary>
        /// 行点击事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dataGridView1_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                int rowIndex = e.RowIndex;
                string fileName = dgvStrContent.Rows[rowIndex].Cells[0].Value.ToString();
                int codeFileIndex = getCodeFilesIndex(fileName);
                strDt = codeFiles[codeFileIndex].FileLineDt;
                string lineNum = dgvStrContent.Rows[rowIndex].Cells[1].Value.ToString();
                string content = dgvStrContent.Rows[rowIndex].Cells[2].Value.ToString();
                StrDetailed detailed = new StrDetailed(lineNum, content,3);
                detailed.Show();
            }
            catch
            {
                
            }
            
        }

        #region 筛选方法测试


        public int getStartCount(string codeStr )
        {
            int index=0;
            int startCount=0;
            while((index=codeStr.Substring(0).IndexOf("{"))!=-1)
            {
                startCount++;
            }
            return startCount;
        }

        public int getEndCount(string codeStr)
        {
            int index = 0;
            int endCount = 0;
            while ((index = codeStr.Substring(0).IndexOf("{")) != -1)
            {
                endCount++;
            }
            return endCount;
        }

        string funName = "无方法";
        public string getFunName(int startCount,int endCount,string codeStr)
        {
            if (startCount >= endCount)
            { 
            //寻找方法名
            }
            return funName;
        }


        #endregion

        private void Form1_SizeChanged(object sender, EventArgs e)
        {
            asf.controlAutoSize(this);
        }

        public static int backTypeId = 0;
        private void cmbType_SelectedIndexChanged(object sender, EventArgs e)
        {
            backTypeId = Convert.ToInt32(cmbType.SelectedValue);
        }
    }
}
