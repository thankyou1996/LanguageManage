using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace LanguagesManage
{
    public partial class CodeFilter_Resx : Form
    {
        public CodeFilter_Resx()
        {
            InitializeComponent();
        }
        int projectId = -1;
        public CodeFilter_Resx(int projectId)
        {
            InitializeComponent();
            this.projectId = projectId;
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
        /// 存放语言类型ID
        /// </summary>
        int[] typeIDs;




        AutoSizeFormClass asf = new AutoSizeFormClass();

        #endregion

        private void Form1_Load(object sender, EventArgs e)
        {
            asf.controlInitializeSize(this);
            CodeFilter.onlyChinese = chkOnlyChines.Checked;
            dbOperat = new DataOperation();
            try
            {
                dtInitlal();
                dgvSetup();
                cmbBind();
                if (this.projectId == -1)
                {

                }
                else
                {
                    cmbProject.SelectedValue = this.projectId;
                }
            }
            catch
            {
                //MessageBox.Show("数据库不存在");
            }
        }

        /// <summary>
        /// dgv的设置
        /// </summary>
        public void dgvSetup()
        {
            dgvStrContent.DataSource = dtContent;
            DataGridViewCheckBoxColumn checkCol = new DataGridViewCheckBoxColumn();
            checkCol.HeaderText = "选择";
            //checkCol.SortMode = DataGridViewColumnSortMode.Automatic;
            dgvStrContent.Columns.Add(checkCol);
            this.dgvStrContent.Columns[3].SortMode = dgvStrContent.Columns[1].SortMode;
            dgvStrContent.Columns[0].ReadOnly = true;
            dgvStrContent.Columns[1].ReadOnly = true;
            dgvStrContent.Columns[2].ReadOnly = true;
            dgvStrContent.Columns[3].ReadOnly = true;
            dgvStrContent.Columns[0].Width = 60;
            dgvStrContent.Columns[2].Width = 60;
            dgvStrContent.Columns[4].Width = 60;
        }

        /// <summary>
        /// 对表进行初始化
        /// </summary>
        public void dtInitlal()
        {
            dtContent.Columns.Add("ID");
            dtContent.Columns.Add("文件名");
            dtContent.Columns.Add("所在行");
            dtContent.Columns.Add("字符串内容");
            dtBasicScriptInsert = dbOperat.getBasicScript().Tables[0].Clone();
            dtScriptInsert = dbOperat.getScriptClone().Tables[0].Clone();
            getAllType();
            CodeFilter.strDt = new DataTable();
            CodeFilter.strDt.Columns.Add("lineNum", typeof(int));
            CodeFilter.strDt.Columns.Add("lineStr");
        }

        public void cmbBind()
        {
            try
            {
                DataTable dtProjects = dbOperat.getProjects().Tables[0];
                cmbProject.DisplayMember = "ProjectName";
                cmbProject.ValueMember = "ProjectID";
                cmbProject.DataSource = dtProjects;
                cmbProject.SelectedIndex = 0;
                CodeFilter.projectID = Convert.ToInt32(cmbProject.SelectedValue);
            }
            catch
            {
                MessageBox.Show("请至少添加一个项目后在进行[源码过滤]操作");
                this.Close();
            }            
        }


        /// <summary>
        /// 获取所有的语言类型
        /// </summary>
        public void getAllType()
        {
            using (DataTable typeDt = dbOperat.getType().Tables[0])
            {
                typeIDs = new int[typeDt.Rows.Count];
                for (int i = 0; i < typeIDs.Length; i++)
                {
                    typeIDs[i] = Convert.ToInt32(typeDt.Rows[i]["TypeID"]);
                }
            }
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

        void openFile_FileOk(object sender, CancelEventArgs e)
        {
            //throw new NotImplementedException();
            lastOpenPath = filePaths[0];
        }

        /// <summary>
        /// 写入数据库
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDbInputs_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvStrContent.Rows.Count < 1)
                {
                    MessageBox.Show("未添加数据");
                }
                dtBasicScriptInsert.Clear();
                int strNum = getDbNum();
                StringBuilder sb = new StringBuilder();
                sb.Append("当前项目["+cmbProject.Text+" ]\n");
                sb.Append("选中了" + strNum + "行数据\n");
                sb.Append("确定添加？");
                if (MessageBox.Show(sb.ToString(), "系统提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {

                    object result = WaitWindow.WaitWindow.Show(this.WorkMethod, "操作中，请等待");
                    TimeSpan ts=(TimeSpan)result;
                    MessageBox.Show("录入完成"+Environment.NewLine +"耗时："+string.Format("{0}时{1}分{2}秒",ts.Hours,ts.Minutes,ts.Seconds)+"实际操作："+operatCount);
                    //dbdtAddInfo("Admin");
                    //if (dbOperat.updateBasicDt(dtBasicScriptInsert))
                    //{

                    //}
                    //else
                    //{
                    //    MessageBox.Show("添加失败");
                    //}
                }
                else
                {
                    return;
                }
                //getAllBasicScriptS(); //添加语言库
                //dbOperat.updateScriptDt(dtScriptInsert);
                //MessageBox.Show("添加成功");

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void WorkMethod(object sender, WaitWindow.WaitWindowEventArgs e)
        {
            DateTime startTime = DateTime.Now;
            dbdtAddInfo("Admin");
            dbOperat.updateBasicDt(dtBasicScriptInsert);
            getAllBasicScriptS(startTime);
            dbOperat.updateScriptDt(dtScriptInsert);
            DateTime endTime = DateTime.Now;

            if (e.Arguments.Count > 0)
            {
                e.Result = e.Arguments[0].ToString();
            }
            else
            {
                TimeSpan ts = endTime - startTime;
                e.Result = ts;
            }
        }

        int operatCount = 0;
        /// <summary>
        /// 数据库更新的表进行赋值(中文)
        /// </summary>
        public void dbdtAddInfo(string adminName)
        {
            int posID = 0;
            string positionName = "";
            string positionname2 = "";
            for (int i = 0; i < dtBasicScriptInsert.Rows.Count; i++)
            {
                positionName = dtBasicScriptInsert.Rows[i]["Reserved_3"].ToString();
                if (positionName != positionname2)
                {
                    posID = getPositionID(positionName);
                    positionname2 = positionName;
                }
                dtBasicScriptInsert.Rows[i]["PositionID"] = posID;
                dtBasicScriptInsert.Rows[i]["AdminName"] = adminName;
                dtBasicScriptInsert.Rows[i]["Reserved_3"] = null;

                string basicText = dtBasicScriptInsert.Rows[i]["BasicText"].ToString();
                if (dbOperat.existsBasicScript(basicText, posID) != 0)
                {
                    dtBasicScriptInsert.Rows[i].Delete();
                    i--;
                    continue;
                }
            }
            string[] condition = new string[dtBasicScriptInsert.Columns.Count];
            for (int i = 0; i < condition.Length; i++)
            {
                condition[i] = dtBasicScriptInsert.Columns[i].ToString();
            }

            GetDistinctPrimaryKeyColumnTable(ref dtBasicScriptInsert, condition);
            operatCount = dtBasicScriptInsert.Rows.Count;
        }

        DataTable dtScript;
        /// <summary>
        ///  数据库更新的表进行赋值（脚本）
        /// </summary>
        public void getAllBasicScriptS(DateTime startTime)
        {
            dtScriptInsert.Clear();
            int scriptID = 0;
            DataTable newCreateDt = dbOperat.getBasicScriptID(startTime).Tables[0];
            dtScript = dbOperat.getScript().Tables[0];
            foreach (DataRow dr in newCreateDt.Rows)
            {
                //scriptID = dbOperat.existsBasic(dr["BasicText"].ToString(), Convert.ToInt32(dr["PositionID"].ToString()));
                scriptID = Convert.ToInt32(dr[0]);
                judgeScipt(scriptID);
            }
            string[] condition = new string[dtScriptInsert.Columns.Count];
            for (int i = 0; i < condition.Length; i++)
            {
                condition[i] = dtScriptInsert.Columns[i].ToString();
            }
            GetDistinctPrimaryKeyColumnTable(ref dtScriptInsert, condition);
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
                //int count = 0;
                //for (int i = 0; i < codeFiles.Count; i++)
                //{
                //    DataRow[] drs = dtContent.Select(" 文件名 =" + "'" + codeFiles[i].FileName + "'");
                //    codeFiles[i].replaceFile(drs);
                //    count += codeFiles[i].ReplaceCount;
                //}
                //MessageBox.Show("替换完成,共计"+count+"");
                object result = WaitWindow.WaitWindow.Show(this.replacesWorkMethod, "操作中，请等待");
                MessageBox.Show(result.ToString());
                //MessageBox.Show("录入完成" + Environment.NewLine + "耗时：" + string.Format("{0}时{1}分{2}秒", ts.Hours, ts.Minutes, ts.Seconds) + "实际操作：" + operatCount);
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
            int count = 0;
            DataTable Temp_dtSouece = new DataTable();
            Temp_dtSouece.Columns.Add("ID");
            Temp_dtSouece.Columns.Add("文件名");
            Temp_dtSouece.Columns.Add("所在行");
            Temp_dtSouece.Columns.Add("字符串内容");
            int checkCellIndex = dgvStrContent.Columns[dgvStrContent.ColumnCount - 1].Index;
            foreach (DataGridViewRow dgvr in dgvStrContent.Rows)
            {
                if (!Convert.ToBoolean(dgvr.Cells[checkCellIndex].Value))
                {
                    continue;
                }
                DataRow dr = Temp_dtSouece.NewRow();
                dr["ID"] = dgvr.Cells["ID"].Value;
                dr["文件名"] = dgvr.Cells["文件名"].Value;
                dr["所在行"] = dgvr.Cells["所在行"].Value;
                dr["字符串内容"] = dgvr.Cells["字符串内容"].Value;
                Temp_dtSouece.Rows.Add(dr);
            }

            for (int i = 0; i < codeFiles.Count; i++)
            {
                DataRow[] drs = Temp_dtSouece.Select(" 文件名 =" + "'" + codeFiles[i].FileName + "'");
                codeFiles[i].replaceFile(drs);
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
                e.Result = "替换完成" + Environment.NewLine + "耗时：" + string.Format("{0}时{1}分{2}秒", ts.Hours, ts.Minutes, ts.Seconds) + "替换数量：" + count;
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
            openFile.InitialDirectory = lastOpenPath;   //设置默认路径（最后打开路径）
            openFile.Filter = "所有文件(*.*)|*.*";
            openFile.FilterIndex = 2;
            openFile.RestoreDirectory = false;
            if (openFile.ShowDialog() == DialogResult.OK)
            {
                lastOpenPath = openFile.FileName;
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
        /// 全选按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAllSelected_Click(object sender, EventArgs e)
        {
            int checkCellIndex = dgvStrContent.Columns[dgvStrContent.ColumnCount - 1].Index;
            for (int i = 0; i < dgvStrContent.Rows.Count; i++)
            {
                dgvStrContent.Rows[i].Cells[checkCellIndex].Value = !Convert.ToBoolean(dgvStrContent.Rows[i].Cells[checkCellIndex].Value);
            }
        }

        #region 添加至中文库

        /// <summary>
        /// 统计添加至数据库的数量数据库的数量
        /// </summary>
        /// <returns></returns>
        public int getDbNum()
        {
            int checkCellIndex = dgvStrContent.Columns[dgvStrContent.ColumnCount - 1].Index;
            int selectedNum = 0; //操作的数量
            DataGridViewCheckBoxCell checkCell;
            DataRow dr;
            for (int i = 0; i < dgvStrContent.Rows.Count; i++)
            {
                checkCell = (DataGridViewCheckBoxCell)dgvStrContent.Rows[i].Cells[checkCellIndex];

                if (Convert.ToBoolean(checkCell.Value))
                {
                    selectedNum++;
                    dr = dtBasicScriptInsert.NewRow();
                    dr["BasicText"] = dgvStrContent.Rows[i].Cells[3].Value.ToString();
                    dr["Reserved_3"] = dgvStrContent.Rows[i].Cells[1].Value.ToString();
                    dtBasicScriptInsert.Rows.Add(dr);
                }
            }
            return selectedNum;
        }

        #endregion

        #region 添加至脚本库

      

        /// <summary>
        /// 判断脚本库中是否存在相同信息
        /// </summary>
        /// <param name="scriptID"></param>
        public void judgeScipt(int scriptID)
        {
            for (int i = 0; i < typeIDs.Length; i++)
            {
                if (dtScript.Select("ScriptID='"+scriptID+"' AND TypeID='"+typeIDs[i]+"'").Length<1)
                {
                    scriptDtInsert(scriptID, typeIDs[i], "admin");
                }
            }
        }

        /// <summary>
        /// 构建脚本库表
        /// </summary>
        /// <param name="scriptID"></param>
        /// <param name="TypeID"></param>
        /// <param name="adminName"></param>
        public void scriptDtInsert(int scriptID, int TypeID, string adminName)
        {
            DataRow dr = dtScriptInsert.NewRow();
            dr["ScriptID"] = scriptID;
            dr["TypeID"] = TypeID;
            dr["Content"] = "###";
            dr["AdminName"] = adminName;
            dtScriptInsert.Rows.Add(dr);
        }
        #endregion

        #region 公共操作
        /// <summary>
        /// 表中去除重复项
        /// </summary>
        /// <param name="dt"></param>
        /// <param name="PrimaryKeyColumns"></param>
        /// <returns></returns>
        public void GetDistinctPrimaryKeyColumnTable(ref DataTable dt, string[] PrimaryKeyColumns)
        {
            DataView dv = dt.DefaultView;
            dt = dv.ToTable(true, PrimaryKeyColumns);
            //第一个参数是关键,设置为 true，则返回的 System.Data.DataTable 将包含所有列都具有不同值的行。默认值为 false。
        }

        /// <summary>
        /// 将位置添加至数据库
        /// </summary>
        /// <param name="position"></param>
        public int getPositionID(string position)
        {
            int positionID = Convert.ToInt32(dbOperat.getPositionID(position, CodeFilter.projectID));
            if (positionID == 0)
            {
                dbOperat.insertPosition(position, CodeFilter.projectID, "Admin");
                positionID = Convert.ToInt32(dbOperat.getPositionID(position, CodeFilter.projectID));
            }
            return positionID;
        }


        /// <summary>
        /// 仅中文
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void chkOnlyChines_CheckedChanged(object sender, EventArgs e)
        {
            CodeFilter.onlyChinese = chkOnlyChines.Checked;
        }

        /// <summary>
        /// 控件名称
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void chkControl_CheckedChanged(object sender, EventArgs e)
        {
            CodeFilter.controlName = chkControl.Checked;
        }

        
        /// <summary>
        /// SQL语句
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void chkSql_CheckedChanged(object sender, EventArgs e)
        {
            CodeFilter.sqlSentence = chkSql.Checked;
        }

        /// <summary>
        /// 字体设置过滤
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void chkFontSet_CheckedChanged(object sender, EventArgs e)
        {
            CodeFilter.fontSet = chkFontSet.Checked;
        }

        /// <summary>
        /// 图片设置过滤
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void chkImageSet_CheckedChanged(object sender, EventArgs e)
        {
            CodeFilter.imageSet = chkImageSet.Checked;
        }
        /// <summary>
        /// 替换字符串的选择
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void rdoDb_CheckedChanged(object sender, EventArgs e)
        {
            CodeFilter.dbText = rdoDb.Checked;
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
                codeFiles[i].readCodeStr();

            }
            int ID = 1;
            for (int i = 0; i < codeFiles.Count; i++)
            {
                for (int j = 0; j < codeFiles[i].StrContents.Count; j++)
                {
                    DataRow dr = dtContent.NewRow();
                    dr["ID"] = ID++;
                    dr["文件名"] = codeFiles[i].FileName;
                    dr["所在行"] = codeFiles[i].StrContents[j].lineNum;
                    dr["字符串内容"] = codeFiles[i].StrContents[j].strContent;
                    dtContent.Rows.Add(dr);
                }
            }
            lblStrNum.Text = dtContent.Rows.Count.ToString();
            dgvStrContent.DataSource = dtContent;
        }
        #endregion

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
                CodeFilter.strDt = codeFiles[0].FileLineDt;
                fileName = lstPath.Items[0].ToString();
            }
            else
            {
                CodeFilter.strDt = codeFiles[lstIndex].FileLineDt;
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

                StrDetailed detailed = new StrDetailed(dt3, fileName,4);
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
                string fileName = dgvStrContent.Rows[rowIndex].Cells[1].Value.ToString();
                int codeFileIndex = getCodeFilesIndex(fileName);
                CodeFilter.strDt = codeFiles[codeFileIndex].FileLineDt;
                string lineNum = dgvStrContent.Rows[rowIndex].Cells[2].Value.ToString();
                string content = dgvStrContent.Rows[rowIndex].Cells[3].Value.ToString();
                StrDetailed detailed = new StrDetailed(lineNum, content,2);
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

        private void cmbProject_SelectedIndexChanged(object sender, EventArgs e)
        {
            CodeFilter.projectID = Convert.ToInt32(cmbProject.SelectedValue);
        }



        /// <summary>
        /// 导回窗口
        /// </summary>

        GuideBack guideBack;
        private void btnGuideBack_Click(object sender, EventArgs e)
        {
            if (guideBack == null || guideBack.IsDisposed)
            {
                guideBack = new GuideBack();
                guideBack.Show();
            }
            else
            {
                guideBack.Activate();
            }
        }

        private void LstPath_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
                e.Effect = DragDropEffects.Link;
            else
                e.Effect = DragDropEffects.None;
        }

        private void LstPath_DragDrop(object sender, DragEventArgs e)
        {
            string Temp_str = ((System.Array)e.Data.GetData(DataFormats.FileDrop)).GetValue(0).ToString();
            string Temp_strFileName = Temp_str.Substring(Temp_str.LastIndexOf("\\") + 1); //文件名
            CodeFile codeFile = new CodeFile(Temp_str, Temp_strFileName);
            codeFiles.Add(codeFile);
            lstItemSet();
            readStr();
        }

        public static List<string> GetResxFile(string strPath)
        {
            List<string> result = new List<string>();
            //string Temp_strFileName = strPath.Substring(strPath.LastIndexOf("\\") + 1); //文件名
            //var files =Directory.GetFiles
            return result;
        }
    }
}
