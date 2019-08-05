using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace LanguagesManage
{
    public class CodeFile
    {
        /// <summary>
        /// 文件路径
        /// </summary>
        string filePath;

        public string FilePath
        {
            get { return filePath; }
            set { filePath = value; }
        }

        /// <summary>
        /// 文件名称
        /// </summary>
        string fileName;

        public string FileName
        {
            get { return fileName; }
            set { fileName = value; }
        }

        /// <summary>
        /// 文件名称
        /// </summary>
        int positionID;

        public int PositionID
        {
            get { return positionID; }
            set { positionID = value; }
        }

        /// <summary>
        /// 操作状态
        /// </summary>
        int operationState;

        public int OperationState
        {
            get { return operationState; }
            set { operationState = value; }
        }

        /// <summary>
        /// 操作状态文本
        /// </summary>
        string operationStateStr;

        public string OperationStateStr
        {
            get { return operationStateStr; }
            set { operationStateStr = value; }
        }

        /// <summary>
        /// 表示字符中的数量
        /// </summary>
        int strNum = 0;

        public int StrNum
        {
            get { return strNum; }
            set { strNum = value; }
        }

        /// <summary>
        /// 记录文件中每行的文字
        /// </summary>
        DataTable fileLineDt = new DataTable();

        public DataTable FileLineDt
        {
            get { return fileLineDt; }
            set { fileLineDt = value; }
        }

        List<string> codeViewSource = new List<string>();

        public List<string> CodeViewSource
        {
            get { return codeViewSource; }
            set { CodeViewSource = value; }
        }


        /// <summary>
        /// 存放选中的字符串
        /// </summary>
        List<StrMsg> strContents = new List<StrMsg>();

        internal List<StrMsg> StrContents
        {
            get { return strContents; }
            set { strContents = value; }
        }

        /// <summary>
        /// 是否存在多行注释
        /// </summary>
        private bool multiLineNote = false;

        public class StrMsg
        {
            public int lineNum { get; set; }

            public string strContent { get; set; }

            public string dbContent { get; set; }
        }

        /// <summary>
        /// 数据库操作对象
        /// </summary>
        DataOperation dbOperat;

        /// <summary>
        /// 替换后的数量
        /// </summary>
        int replaceCount;

        public int ReplaceCount
        {
            get { return replaceCount; }
            set { replaceCount = value; }
        }


        /// <summary>
        /// 实例化对象
        /// </summary>
        /// <param name="filePath"></param>
        /// <param name="fileName"></param>
        public CodeFile(string filePath, string fileName)
        {
            this.filePath = filePath;
            this.fileName = fileName;
            dtInit();
            dbOperat = new DataOperation();
        }

        public void dtInit()
        {
            fileLineDt.Columns.Add("lineNum", typeof(int));    //行号
            fileLineDt.Columns.Add("lineStr", typeof(string));
        }

        int lineNum=0;
        /// <summary>
        /// 读取源码中的字符串
        /// </summary>
        public void readCodeStr()
        {
            if (fileName == null)
            {
                operationState = 1;
                operationStateStr = "文件名为空";
                return;
            }
            try
            {
                using (StreamReader sr = new StreamReader(filePath, Encoding.UTF8)) //文件读取
                {
                    multiLineNote = false;
                    this.lineNum = 0; //行号
                    string lineStr;
                    strNum = 0;
                    strContents.Clear();
                    fileLineDt.Rows.Clear();  //文件表数据清空
                    CodeViewSource.Clear();
                    CodeViewSource.Add(Environment.NewLine);
                    while ((lineStr = sr.ReadLine()) != null) //循环读取直至为空
                    {
                        this.lineNum++;
                        addfileStrDt(this.lineNum, lineStr);
                        //getStrsContent(filterNotes(lineStr), this.lineNum);
                        //filterNotes(lineStr);
                        filterContent(lineStr);
                        CodeViewSource.Add(lineStr);
                    }
                }
            }
            catch (Exception ex)
            {
                OperationState = -1;
                operationStateStr = ex.Message;
            }
        }

        /// <summary>
        /// 获取字符串
        /// </summary>
        /// <param name="lineStr"></param>
        /// <param name="lineNum"></param>
        public void getStrsContent(string lineStr, int lineNum)
        {
            string[] strs = lineStr.Split('"');//通过( " )转换为数组
            for (int i = 0; i < strs.Length; i++)
            {
                if (i % 2 == 1)
                {
                    if (!selectStr(strs[i], strs[i - 1])) //筛选字符串
                    {
                        continue;
                    }
                    strNum++;
                    StrMsg s = new StrMsg();
                    s.lineNum = lineNum;
                    s.strContent = strs[i];
                    strContents.Add(s);
                }
            }
        }

        /// <summary>
        /// 筛选字符
        /// </summary>
        public bool selectStr(string str, string frontStr)
        {
            if (string.IsNullOrEmpty(str)) //是否为空
            {
                return false;
            }

            if (CodeFilter.onlyChinese && !strHasChinese(str)) //至显示中文
            {
                return false;
            }
            if (!CodeFilter.controlName && isControlName(frontStr)) //是否问控件名称
            {
                return false;
            }
            if (!CodeFilter.sqlSentence && isSql(str))  //判断是不是SQL语句
            {
                return false;
            }
            if (!CodeFilter.fontSet && isFontSet(frontStr))  //是否为字体设置
            {
                return false;
            }
            if (!CodeFilter.imageSet && isImageSet(frontStr))  //是否为图片设置
            {
                return false;
            }
            if (Static.ParaSet.FilterResourcesGetStringEnable && frontStr.EndsWith("resources.GetString("))
            {
                return false;
            }
            return true;
        }


        /// <summary>
        /// 判断是否为中文
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static bool strHasChinese(string str)
        {
            return Regex.IsMatch(str, @"[\u4e00-\u9fa5]");
        }

        /// <summary>
        /// 判断是否为中文名（通过数组的前一个字符判断判断）
        /// </summary>
        /// <param name="frontStr"></param>
        /// <returns></returns>
        public bool isControlName(string frontStr)
        {
            int controlNameIndex = frontStr.IndexOf(".Name");
            if (controlNameIndex == -1)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        /// <summary>
        /// 判断是否为SQL语句
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public bool isSql(string str)
        {
            string strLower = str.ToLower();
            if (strLower.IndexOf("select") != -1) // 查询语句
            {
                return true;
            }
            if (strLower.IndexOf("update") != -1) // 更新语句 
            {
                return true;
            }
            if (strLower.IndexOf("insert into") != -1) //插入语句
            {
                return true;
            }
            if (strLower.IndexOf("delete") != -1) //删除语句
            {
                return true;
            }
            if (strLower.IndexOf("order") != -1)  //order by 
            {
                return true;
            }

            if (strLower.IndexOf("desc") != -1)  //desc
            {
                return true;
            }
            if (strLower.IndexOf("and") != -1)   //and
            {
                return true;
            }
            return false;
        }

        /// <summary>
        /// 判断是否为字体设置
        /// </summary>
        /// <returns></returns>
        public bool isFontSet(string frontStr)
        {
            int fontSetIndex = frontStr.IndexOf("Drawing.Font(");
            if (fontSetIndex == -1)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public bool isImageSet(string frontStr)
        {
            int imageSetIndex = frontStr.IndexOf(".Image");
            if (imageSetIndex == -1)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        /// <summary>
        /// 表中添加行数据
        /// </summary>
        /// <param name="lineNum"></param>
        /// <param name="lineStr"></param>
        public void addfileStrDt(int lineNum, string lineStr)
        {
            DataRow dr = fileLineDt.NewRow();
            dr["lineNum"] = lineNum;
            dr["lineStr"] = lineStr;
            fileLineDt.Rows.Add(dr);
        }

        /// <summary>
        /// 过滤注释文字
        /// </summary>
        /// <param name="lineStr"></param>
        /// <returns></returns>
        public string filterNotes(string lineStr)
        {
            if (multiLineNote) //是否存在多行注释
            {
                lineStr = isEndMultiNote(lineStr);
            }
            int singleNoteIndex = lineStr.IndexOf(@"//");  //单行注释索引
            int multiNodeIndex = lineStr.IndexOf(@"/*");   //多行注释索引
            if (singleNoteIndex == multiNodeIndex) //都不存在(返回结果同为-1)
            {
                return lineStr;
            }
            if (multiNodeIndex == -1) // 不存在多行注释
            {
                lineStr = lineStr.Substring(0, singleNoteIndex);
                return lineStr;
            }
            if (singleNoteIndex == -1) //不存在单行注释
            {
                multiLineNote = true; //多行注释模式
                string noteLineStr = lineStr.Substring(multiNodeIndex);
                lineStr = lineStr.Substring(0, multiNodeIndex);
                lineStr += filterNotes(noteLineStr);
                return lineStr;
            }
            //两种情况都存在
            if (singleNoteIndex < multiNodeIndex)   //单行注释在前
            {
                lineStr = lineStr.Substring(0, singleNoteIndex);
                return lineStr;
            }
            else //多行注释在前
            {
                multiLineNote = true; //多行注释模式
                string noteLineStr = lineStr.Substring(multiNodeIndex);
                lineStr = lineStr.Substring(0, multiNodeIndex);
                lineStr += filterNotes(noteLineStr);
                return lineStr;
            }
        }


        public void filterContent(string lineStr)
        {
            if (multiLineNote) //是否存在多行模式 
            { 
                //查找*/代表结束
                lineStr = isEndMultiNote(lineStr);
            }
            int singleNoteIndex = lineStr.IndexOf(@"//"); //单行注释索引
            int multiNoteIndex = lineStr.IndexOf(@"/*");  //多行注释索引
            int strIndex = lineStr.IndexOf('"');     //字符串索引
            int charIndex = lineStr.IndexOf("'");    //字符型索引

            int[] indexs = new int[4];
            indexs[0] = singleNoteIndex;
            indexs[1] = multiNoteIndex;
            indexs[2] = strIndex;
            indexs[3] = charIndex;
            int operIndex=0;
            int operType = getOperType(indexs, ref operIndex);

            switch (operType)
            {
                case -1:  //不存需要查找的字符
                    //不做操作
                    break;
                case 0:  //单行注释
                    //不做操作
                    break;
                case 1:  //多行注释
                    //进入查找多行注释状态（寻找结束符）
                    multiLineNote = true;
                    lineStr = lineStr.Substring(operIndex + 2);
                    filterContent(lineStr);
                    break;
                case 2:  //字符串
                    //string frontStr = lineStr.Substring(0, operIndex);
                    lineStr = getContent(lineStr, operIndex);
                    filterContent(lineStr);
                    break;
                case 3:  //字符
                    lineStr = lineStr.Substring(operIndex + 3);
                    filterContent(lineStr);
                    break;
            }


            //if (!selectStr(strs[i], strs[i - 1])) //筛选字符串
            //{
            //    continue;
            //}
            //strNum++;
            //StrMsg s = new StrMsg();
            //s.lineNum = lineNum;
            //s.strContent = strs[i];
            //strContents.Add(s);
            //return operType;
        }

        /// <summary>
        /// 获取操作操作符,对操作索引进行赋值
        /// 0.单行注释索引 1.多行注释索引 2.字符串索引 4.字符型索引
        /// </summary>
        /// <param name="indexs"></param>
        /// <param name="operIndex"></param>
        /// <returns></returns>
        public int getOperType(int[] indexs, ref int operIndex)
        {
            if (indexs[0] == indexs[1] && indexs[0] == indexs[2] && indexs[0] == indexs[3])
            {
                operIndex = -1;
                return -1;
            }
            operIndex = indexs[0];
            for (int i = 1; i < indexs.Length; i++)
            {
                if (indexs[i] != -1)
                {
                    if (operIndex == -1)
                    {
                        operIndex = indexs[i];
                    }
                    else
                    {
                        if (indexs[i] < operIndex)
                        {
                            operIndex = indexs[i];
                        }
                    }
                }
            }
            return Array.IndexOf(indexs, operIndex);
        }

        /// <summary>
        /// 多行注释是否结束
        /// </summary>
        public string isEndMultiNote(string lineStr)
        {
            int multiNoteEnd = lineStr.IndexOf(@"*/"); //结束符索引
            if (multiNoteEnd == -1) //多行注释未结束
            {
                lineStr = "";
            }
            else
            {
                multiLineNote = false;//多行注释结束
                lineStr = lineStr.Substring(multiNoteEnd + 2); //返回注释结束后的字符
            }
            return lineStr;
        }

        /// <summary>
        /// 获取字符串
        /// </summary>
        /// <param name="lineStr"></param>
        /// <param name="operIndex"></param>
        /// <returns></returns>
        public string getContent(string lineStr, int operIndex)
        {
            string forntStr = lineStr.Substring(0,operIndex);
            lineStr = lineStr.Substring(operIndex + 1);
            string contentStr = lineStr.Substring(0, lineStr.IndexOf('"'));
            lineStr = lineStr.Substring(lineStr.IndexOf('"') + 1);
            if(selectStr(contentStr,forntStr))
            {
                strNum++;
                StrMsg s = new StrMsg();
                s.lineNum = this.lineNum;
                s.strContent=contentStr;
                strContents.Add(s);
            }
            return lineStr;
            //if (!selectStr(strs[i], strs[i - 1])) //筛选字符串
            //{
            //    continue;
            //}
            //strNum++;
            //StrMsg s = new StrMsg();
            //s.lineNum = lineNum;
            //s.strContent = strs[i];
            //strContents.Add(s);
        }

        public string getChar(string lineStr)
        {


            return lineStr;
        }


        #region 替换字符串
        DataRow[] strContentRows;

        /// <summary>
        /// 替换完成后的字符串
        /// </summary>
        StringBuilder sb;
        public void replaceFile(DataRow[] strContentRows)
        {
            try
            {
                replaceCount = 0;
                rowIndex = 0;
                this.positionID = Convert.ToInt32(dbOperat.getPositionID(fileName,CodeFilter.projectID));
                //替换字符串
                this.strContentRows = strContentRows;
                multiLineNote = false; //重置判断标志
                string tempFilePath = getTempPath(); //获取临时文件夹路径
                string buckupFilePath = getBuckupPath(); //获取备份文件路径
                using (FileStream fs = new FileStream(tempFilePath, FileMode.Create)) //文件存在则进行覆盖
                {
                    using (StreamWriter sw = new StreamWriter(fs))
                    {
                        nextContentLineNum(); //获取下一行字符信息
                        foreach (DataRow dr in fileLineDt.Rows)
                        {
                            sb = new StringBuilder();
                            if (dr[0].ToString() == dtContentLineNum) //是否是同一行
                            {
                                filter(dr[1].ToString());
                                nextContentLineNum();
                            }
                            else
                            {
                                sb.Append(dr[1].ToString());
                            }
                            sw.WriteLine(sb.ToString());
                        }
                    }
                }
                //备份文件
                File.Copy(filePath, buckupFilePath, true);
                //替换文本
                File.Copy(tempFilePath, filePath, true);
                //MessageBox.Show(replaceCount.ToString());
            }
            catch (Exception ex)
            {
                //MessageBox.Show(ex.ToString());
                throw ex;
            }
        }

        /// <summary>
        /// 获取临时文件路径
        /// </summary>
        /// <returns></returns>
        public string getTempPath()
        {
            string filePath = Environment.CurrentDirectory.ToString() + "\\temp";
            if (Directory.Exists(filePath))
            {

            }
            else
            {
                DirectoryInfo dirInfo = new DirectoryInfo(filePath);
                dirInfo.Create();
            }
            return filePath + "\\" + fileName;
        }

        public string getBuckupPath()
        {
            string filePath = Environment.CurrentDirectory.ToString() + "\\buckup";
            if (Directory.Exists(filePath))
            {

            }
            else
            {
                DirectoryInfo dirInfo = new DirectoryInfo(filePath);
                dirInfo.Create();
            }
            return filePath + "\\" + DateTime.Now.ToString("yyMMdd_hhmm") + fileName;
        }

        /// <summary>
        /// 字符串表行索引
        /// </summary>
        int rowIndex = 0;

        /// <summary>
        /// 字符串行索引
        /// </summary>
        string dtContentLineNum = "0";

        /// <summary>
        /// 字符串内容
        /// </summary>
        string dtContent = "";

        /// <summary>
        /// 获取下一个字符
        /// </summary>
        public void nextContent()
        {
            if (this.strContentRows == null || this.strContentRows.Length < 1)
            {
                return;
            }
            if (this.strContentRows.Length <= rowIndex)
            {
                dtContentLineNum = "-1";
                return;
            }
            dtContentLineNum = this.strContentRows[rowIndex][1].ToString();
            dtContent = '"' + this.strContentRows[rowIndex][2].ToString() + '"';
            rowIndex++;
        }

        /// <summary>
        /// 获取存在字符串的行的行号
        /// </summary>
        public void nextContentLineNum()
        {
            string outDtContentLineNum = dtContentLineNum;
            if (this.strContentRows == null || this.strContentRows.Length < 1)
            {
                return;
            }
            if (this.strContentRows.Length <= rowIndex)
            {
                dtContentLineNum = "-1";
                return;
            }
            dtContentLineNum = this.strContentRows[rowIndex][2].ToString();
            dtContent = '"' + this.strContentRows[rowIndex][3].ToString() + '"';
            rowIndex++;
            if (outDtContentLineNum == dtContentLineNum)
            {
                nextContentLineNum();
            }
        }


        /// <summary>
        /// 过滤替换时的文本
        /// </summary>
        /// <param name="fileLineDtLine"></param>
        public void filter(string fileLineDtLine)
        {
            if (multiLineNote) //是否处于多行注释状态
            {
                string[] receStrs = isEndMultiLineNote(fileLineDtLine);
                if (receStrs.Length == 1)
                {
                    //return receStrs[0];
                    sb.Append(receStrs[0]);
                    return;
                }
                else
                {
                    sb.Append(receStrs[0]);
                    fileLineDtLine = receStrs[1];
                }
            }
            int singleFilterIndex = fileLineDtLine.IndexOf(@"//"); //单行注释索引
            int multiFilterIndex = fileLineDtLine.IndexOf(@"/*"); //多行注释索引

            if (singleFilterIndex == multiFilterIndex) //不存在注释，索引都为-1
            {
                //替换完成后返回
                sb.Append(WirteLIne(fileLineDtLine));
                return;
            }
            if (multiFilterIndex == -1) //不存在多行注释
            {
                string useLine = fileLineDtLine.Substring(0, singleFilterIndex); //需要替换操作的行
                //替换操作后返回
                sb.Append(WirteLIne(useLine));
                sb.Append(fileLineDtLine.Substring(singleFilterIndex));
                return;
            }

            if (multiFilterIndex == -1)//不存在单行,存在多行注释
            {
                multiLineNote = true;  //表示处于多行模式
                string useLine = fileLineDtLine.Substring(0, multiFilterIndex); //需要替换操作的行
                //替换操作后返回
                sb.Append(WirteLIne(useLine));

                filter(fileLineDtLine.Substring(multiFilterIndex));
                return;
            }

            if (singleFilterIndex < multiFilterIndex)
            {
                string useLine = fileLineDtLine.Substring(0, singleFilterIndex); //需要替换操作的行
                //替换操作后返回
                sb.Append(WirteLIne(useLine));

                sb.Append(fileLineDtLine.Substring(singleFilterIndex));
                return;
            }
            else
            {
                multiLineNote = true;  //表示处于多行模式
                string useLine = fileLineDtLine.Substring(0, multiFilterIndex); //需要替换操作的行
                //替换操作后返回
                sb.Append(WirteLIne(useLine));
                filter(fileLineDtLine.Substring(multiFilterIndex));
                return;
            }
        }

        /// <summary>
        /// 多行注释结束判断
        /// </summary>
        /// <param name="lineStr"></param>
        /// <returns></returns>
        public string[] isEndMultiLineNote(string lineStr)
        {
            string[] retuStrs;
            int endMultiEndIndex = lineStr.IndexOf(@"*/");
            if (endMultiEndIndex == -1) //多行注释未结束
            {
                retuStrs = new string[1];
                retuStrs[0] = lineStr;
                return retuStrs;
            }
            else  //多行注释结束
            {
                multiLineNote = false;
                retuStrs = new string[2];
                retuStrs[0] = lineStr.Substring(0, endMultiEndIndex + 2); //注释语句
                retuStrs[1] = lineStr.Substring(endMultiEndIndex + 2);    //未注释语句
                return retuStrs;

            }
        }

        /// <summary>
        /// 替换文本
        /// </summary>
        /// <param name="lineStr"></param>
        /// <returns></returns>
        public string WirteLIne(string lineStr)
        {
            string[] strs;
            int scriptID = 0;

            strs = lineStr.Split('"');
            for (int i = 1; i < strs.Length; i = i + 2)  //数组下表为奇数是为字符串内容
            {
                if (!selectStr(strs[i], strs[i - 1])) //筛选不符合的字符串
                {
                    strs[i] = '"' + strs[i] + '"';
                    continue;
                }
                //TODO:将字符串中的内容进行赋值(赋值到表中进行选择)
                scriptID = dbOperat.existsBasicScript(strs[i], this.positionID);
                if (scriptID == 0)
                {
                    strs[i] = '"' + strs[i] + '"';
                    continue;
                }
                string Temp_strValue = strs[i];

                //if (CodeFilter.dbText)  //判断选择转换的是xml或者是DB
                //{
                //    strs[i] = "LanguageGet.getContentFromDB(" + scriptID + ")";
                //    //replaceCount++;
                //}
                //else
                //{
                //    strs[i] = "XmlLanguageGet.getContent(" + scriptID + ")";
                //}
                strs[i] = "resources.GetString(\"" + Temp_strValue + "\")";
                replaceCount++;
            }
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < strs.Length; i++)
            {
                sb.Append(strs[i]);
            }
            return sb.ToString();
        }

        /// <summary>
        /// 替换文本 (递归)
        /// </summary>
        public void textReplace(string fileLineDtNum, string fileLineDtLine)
        {
            string strContent = dtContent;
            int strEndIndex = fileLineDtLine.IndexOf(strContent) + strContent.Length;   //行中字符串结束后索引
            int strOutputIndex = fileLineDtLine.Substring(strEndIndex).IndexOf('"');
            int lineLenght = sb.Length; //添加之前文本长度
            nextContent();
            if (strOutputIndex != -1 && fileLineDtLine == dtContentLineNum)  //判断是否存在下一个字符
            {
                sb.Append(fileLineDtLine.Substring(0, strEndIndex + strOutputIndex));
            }
            else
            {
                sb.Append(fileLineDtLine);
            }
            if (fileLineDtNum != dtContentLineNum)
            {
                return;
            }
            string newFileLineDtLine = fileLineDtNum.Substring(strEndIndex + strOutputIndex);
            textReplace(fileLineDtNum, newFileLineDtLine);
        }
        #endregion



        #region  导回

        /// <summary>
        /// 读取源码中的字符串
        /// </summary>
        public void readCodeFun()
        {
            if (fileName == null)
            {
                operationState = 1;
                operationStateStr = "文件名为空";
                return;
            }
            try
            {
                using (StreamReader sr = new StreamReader(filePath, Encoding.UTF8)) //文件读取
                {
                    multiLineNote = false;
                    int lineNum = 0; //行号
                    string lineStr;
                    strNum = 0;
                    strContents.Clear();
                    fileLineDt.Rows.Clear();  //文件表数据清空
                    while ((lineStr = sr.ReadLine()) != null) //循环读取直至为空
                    {
                        lineNum++;
                        addfileStrDt(lineNum, lineStr);
                        getBackFun(filterNotesBack(lineStr), lineNum);
                    }
                }
            }
            catch (Exception ex)
            {
                OperationState = -1;
                operationStateStr = ex.Message;
            }
        }

        /// <summary>
        /// 过滤注释文字
        /// </summary>
        /// <param name="lineStr"></param>
        /// <returns></returns>
        public string filterNotesBack(string lineStr)
        {
            if (multiLineNote) //是否存在多行注释
            {
                lineStr = isEndMultiNote(lineStr);
            }
            int singleNoteIndex = lineStr.IndexOf(@"//");  //单行注释索引
            int multiNodeIndex = lineStr.IndexOf(@"/*");   //多行注释索引
            if (singleNoteIndex == multiNodeIndex) //都不存在(返回结果同为-1)
            {
                return lineStr;
            }
            if (multiNodeIndex == -1) // 不存在多行注释
            {
                lineStr = lineStr.Substring(0, singleNoteIndex);
                return lineStr;
            }
            if (singleNoteIndex == -1) //不存在单行注释
            {
                multiLineNote = true; //多行注释模式
                string noteLineStr = lineStr.Substring(multiNodeIndex);
                lineStr = lineStr.Substring(0, multiNodeIndex);
                lineStr += filterNotes(noteLineStr);
                return lineStr;
            }
            //两种情况都存在
            if (singleNoteIndex < multiNodeIndex)   //单行注释在前
            {
                lineStr = lineStr.Substring(0, singleNoteIndex);
                return lineStr;
            }
            else //多行注释在前
            {
                multiLineNote = true; //多行注释模式
                string noteLineStr = lineStr.Substring(multiNodeIndex);
                lineStr = lineStr.Substring(0, multiNodeIndex);
                lineStr += filterNotes(noteLineStr);
                return lineStr;
            }
        }

        string dbFunName = "LanguageGet.getContentFromDB(";
        string funName = "GetScript.GetScript.getScript(";

        /// <summary>
        /// 导回筛选
        /// </summary>
        /// <param name="lineStr"></param>
        /// <param name="lineNum"></param>
        public void getBackFun(string lineStr, int lineNum)
        {
            int dbFunIndex = lineStr.IndexOf(dbFunName);
            int xmlFunIndex = lineStr.IndexOf(funName);
            if (dbFunIndex == xmlFunIndex)  //同为-1,都不存在
            {
                return;
            }
            int index;
            int funNameIndex = 0;
            if (dbFunIndex == -1)
            {
                index = xmlFunIndex;
                funNameIndex = funName.Length;
            }
            else if (xmlFunIndex == -1)
            {
                index = dbFunIndex;
                funNameIndex = dbFunName.Length;
            }
            else
            {
                index = dbFunIndex < xmlFunIndex ? dbFunIndex : xmlFunIndex;
                funNameIndex = dbFunIndex < xmlFunIndex ? dbFunName.Length : funName.Length;
            }

            lineStr = lineStr.Substring(index);
            int endIndex = lineStr.IndexOf(")"); //方法结束
            string strFun = lineStr.Substring(0, endIndex + 1); //方法主体
            string scriptIdStr = lineStr.Substring(funNameIndex, endIndex - funNameIndex);
            int scriptId = Convert.ToInt32(scriptIdStr);
            string content = dbOperat.getScriptContent(scriptId, GuideBack.backTypeId);
            if (string.IsNullOrEmpty(content))
            {
                content = "TextNotExists";
            }
            StrMsg s = new StrMsg();
            s.lineNum = lineNum;
            s.strContent = strFun;
            s.dbContent = content;
            strContents.Add(s);
            lineStr = lineStr.Substring(endIndex + 1);
            getBackFun(lineStr, lineNum);
        }

        /// <summary>
        /// 导回文件
        /// </summary>
        /// <param name="strContentRows"></param>
        public void guideBack(DataRow[] strContentRows)
        {
            try
            {
                replaceCount = 0;
                string tempFilePath = getTempPath();  //替换文件路径
                string buckupFilePath = getBuckupPath(); //获取备份文件路径
                using (FileStream fs = new FileStream(tempFilePath, FileMode.Create))
                {
                    using (StreamWriter sw = new StreamWriter(fs))
                    {
                        nextContentLineNum();
                        sb = new StringBuilder();
                        foreach (DataRow dr in fileLineDt.Rows)
                        {
                            sb = new StringBuilder();
                            filterBack(dr[1].ToString());
                            sw.WriteLine(sb.ToString());
                        }

                    }
                }
                //备份文件
                File.Copy(filePath, buckupFilePath, true);
                //替换文本
                File.Copy(tempFilePath, filePath, true);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// 替换导回字符
        /// </summary>
        /// <param name="lineStr"></param>
        public void filterBack(string lineStr)
        {
            int dbFunIndex = lineStr.IndexOf(dbFunName);
            int xmlFunIndex = lineStr.IndexOf(funName);
            if (dbFunIndex == xmlFunIndex)  //同为-1,都不存在
            {
                sb.Append(lineStr);
                return;
            }
            int index;
            int funNameIndex = 0;
            if (dbFunIndex == -1)
            {
                index = xmlFunIndex;
                funNameIndex = funName.Length;
            }
            else if (xmlFunIndex == -1)
            {
                index = dbFunIndex;
                funNameIndex = dbFunName.Length;
            }
            else
            {
                index = dbFunIndex < xmlFunIndex ? dbFunIndex : xmlFunIndex;
                funNameIndex = dbFunIndex < xmlFunIndex ? dbFunName.Length : funName.Length;
            }
            sb.Append(lineStr.Substring(0, index));
            lineStr = lineStr.Substring(index);
            int endIndex = lineStr.IndexOf(")"); //方法结束
            string strFun = lineStr.Substring(0, endIndex + 1); //方法主体
            string scriptIdStr = lineStr.Substring(funNameIndex, endIndex - funNameIndex);
            int scriptId = Convert.ToInt32(scriptIdStr);
            string content = dbOperat.getScriptContent(scriptId, GuideBack.backTypeId);
            if (string.IsNullOrEmpty(content))
            {
                content = "TextNotExists";
            }
            replaceCount++;

            sb.Append('"' + content + '"');
            lineStr = lineStr.Substring(endIndex + 1);
            filterBack(lineStr);


        }

        #endregion 



    }
}
