using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Xml;

namespace LanguagesManage
{
    public partial class GuideBackPreview : Form
    {

        #region 全局变量

        /// <summary>
        /// xml文件操作对象
        /// </summary>
        UseLanguageXml useXml;

        /// <summary>
        /// 数据库操作对象
        /// </summary>
        DataOperation dbOperat;

        /// <summary>
        /// 测试文件路径
        /// </summary>
        string testFilePath = Environment.CurrentDirectory.ToString() + "\\EditXml\\LanguageEditXml.xml";

        /// <summary>
        /// 文件路径
        /// </summary>
        string filePath;

        /// <summary>
        /// 文件名
        /// </summary>
        string fileName;
         
        /// <summary>
        /// 数据表
        /// </summary>
        DataTable dtRead = new DataTable();

        /// <summary>
        /// 语言缩写数组
        /// </summary>
        string[] languageAb;

        /// <summary>
        /// 键值队数组 Key:TypeID,Value:列名
        /// </summary>
        DictionaryEntry[] typeDes;

        /// <summary>
        /// 存放数据库操作语句
        /// </summary>
        List<DictionaryEntry> SQLlist ;

        Hashtable hs = new Hashtable();
        #endregion
        

        public GuideBackPreview()
        {
            InitializeComponent();
            this.filePath = testFilePath;
        }

        /// <summary>
        /// 构造函数获取文件路径
        /// </summary>
        /// <param name="filePath"></param>
        public GuideBackPreview(string filePath)
        {
            InitializeComponent();
            this.filePath = filePath;
            this.fileName = filePath.Substring(filePath.LastIndexOf("\\")+1); //文件名
           // this.filePath = testFilePath;
        }


        private void GuideBackPreview_Load(object sender, EventArgs e)
        {
            useXml = new UseLanguageXml();
            dbOperat = new DataOperation();
            readXmlFIle();
        }

        /// <summary>
        /// 读取文件信息
        /// </summary>
        public void readXmlFIle()
        {
            try
            {
                dtRead = new DataTable();
                //Type
                useXml.readType(this.filePath, ref dtRead, ref languageAb, ref typeDes);

                //Script
                useXml.readScript(this.filePath, ref dtRead, ref languageAb, ref typeDes);

                //XmlInfo
                string[] xmlInfo = useXml.readXmlInfo(this.filePath);
                //lblCreater.Text = xmlInfo[0];
                txtCreater.Text = xmlInfo[0];

                //lblCreateTime.Text = xmlInfo[1];
                txtCreateTime.Text = xmlInfo[1];

                txtRemarks.Text = xmlInfo[2];

                txtFileName.Text = this.fileName;

                dgvXml.DataSource = dtRead;
            }
            catch 
            {
                MessageBox.Show("文件格式不正确");
                this.Close();
            }
            
        }


        #region old读取信息
        public void getType()
        {
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load(this.testFilePath);

            XmlNode rootNode = xmlDoc.FirstChild;//根节点

            XmlNode typeNodes = rootNode.SelectSingleNode("LanguageType");
            dtRead.Columns.Add("ID");
            dtRead.Columns.Add("简体中文");
            XmlNodeList typeLists = typeNodes.ChildNodes;
            languageAb = new string[typeLists.Count ];
            typeDes = new DictionaryEntry[typeLists.Count ];
            int z = 0;
            foreach (XmlElement xe in typeLists)
            {
                string x =  xe.GetAttribute("中文名称").ToString();
                dtRead.Columns.Add(x);
                languageAb[z] = xe.GetAttribute("语言缩写");
                typeDes[z].Key = xe.GetAttribute("typeID");
                typeDes[z].Value = x;
                hs.Add(xe.GetAttribute("typeID"), x);
                z++;
            }
        }

        public void getScript()
        {
            try
            {
                XmlDocument xmlDoc = new XmlDocument();
                xmlDoc.Load(this.testFilePath);
                XmlNode rootNode = xmlDoc.FirstChild;//根节点

                XmlNode scriptNodes = rootNode.SelectSingleNode("LanguageScript");
                XmlNodeList scriptsLists = scriptNodes.ChildNodes;
                DataRow dr;
                foreach (XmlElement xe in scriptsLists)
                {
                    dr = dtRead.NewRow();
                    dr["ID"] = xe.GetAttribute("ScriptID");
                    dr["简体中文"] = xe.GetAttribute("zh_CN");
                    for (int x = 0; x < languageAb.Length; x++)
                    {
                        dr[typeDes[x].Value.ToString()] = xe.GetAttribute(languageAb[x]);
                    }
                    dtRead.Rows.Add(dr);
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            
        }

        public void getXmlInfo()
        {
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load(this.testFilePath);

            XmlNode rootNode = xmlDoc.FirstChild; //根节点

            XmlNode xmlInfoNode = rootNode.SelectSingleNode("XmlInfo");
            label1.Text = xmlInfoNode.Attributes["Creater"].Value;
            label2.Text = xmlInfoNode.Attributes["CreateTime"].Value;
        }

        #endregion

        /// <summary>
        /// 将信息导回数据库 
        /// 使用批量更新函数，程序读取数据库表,程序中
        /// </summary>
        public void guideBack1()
        {
            if (dtRead.Rows.Count < 0)
            {
                MessageBox.Show("没有数据");
                return;
            }
            int backNum = 0;
            DateTime startTime = DateTime.Now; //起始时间
            DataTable scriptDt = dbOperat.getScript().Tables[0];
            for (int i = 2; i < dtRead.Columns.Count; i++)
            {

                object obj= deGetTypeID(dtRead.Columns[i].ToString()); //获取TypeID
                foreach (DataRow dr in dtRead.Rows)
                {
                    DataRow[] drs = scriptDt.Select("ScriptID='" + dr["ID"] + "' AND TypeID='" + obj + "'");
                    if (drs.Length < 1) //查询没有数据跳过
                    {
                        continue;
                    }
                    //DataRow[] drs = scriptDt.Select("ScriptID  = 11");
                    int scriptIndex = scriptDt.Rows.IndexOf(drs[0]);
                    if (string.IsNullOrEmpty(dr[i].ToString())) //判断是否为空
                    {
                        scriptDt.Rows[scriptIndex]["Content"] = "###";
                        continue;
                    }
                    scriptDt.Rows[scriptIndex]["Content"] = dr[i];
                    //scriptDt.Rows[scriptIndex]["Content"] = "###";
                    backNum++;
                }
            }

            //int sId = 0;
            //int tId = 0;
            //foreach(DataRow dr in scriptDt.Rows)
            //{
            //    try
            //    {
            //        sId = Convert.ToInt32(dr["ScriptID"]);
            //        tId = Convert.ToInt32(dr["TypeID"]);
            //        string A = hs[tId.ToString()].ToString();
            //        dr["Content"] = dtUse.Select("ID='" + sId + "'")[0][A];
            //    }
            //    catch
            //    { 
                
            //    }
            //}
            dbOperat.updateScriptDt(scriptDt);
            DateTime endTime = DateTime.Now;  //完成时间
            TimeSpan ts = endTime - startTime;
            StringBuilder sb = new StringBuilder();
            sb.Append("实际导回数量：" + backNum+"\n");
            sb.Append("耗时：" + ts.ToString());
            MessageBox.Show(sb.ToString());
        }

        /// <summary>
        /// 将信息导回数据库
        /// </summary>
        public void guideBack2()
        {
            if (dtRead.Rows.Count < 0)
            {
                MessageBox.Show("没有数据");
                return;
            }
            SQLlist = new List<DictionaryEntry>(); //执行完成后重新实例化list对象
            DateTime startTime = DateTime.Now;
            DataTable scriptDt = dbOperat.getScript().Tables[0];
            DictionaryEntry de;
            for (int i = 2; i < dtRead.Columns.Count; i++)
            {
                int typeID = Convert.ToInt32(deGetTypeID(dtRead.Columns[i].ToString()));
                foreach (DataRow dr in dtRead.Rows)
                {
                    if (string.IsNullOrEmpty(dr[i].ToString())) //判断是否为空
                    {
                        //scriptDt.Rows[scriptIndex]["Content"] = "###";
                        de = dbOperat.paraAndSQLScriptUpdate(Convert.ToInt32(dr["ID"]), typeID, "###", Language.adminName);
                        SQLlist.Add(de);
                        continue;
                    }

                    de = dbOperat.paraAndSQLScriptUpdate(Convert.ToInt32(dr["ID"]), typeID, dr[i].ToString(), Language.adminName);
                    //de = dbOperat.paraAndSQLScriptUpdate(Convert.ToInt32(dr["ID"]), typeID, "want", Language.adminName);
                    //DataRow[] drs = scriptDt.Select("ScriptID  = 11");
                    //int scriptIndex = scriptDt.Rows.IndexOf(drs[0]);
                    //scriptDt.Rows[scriptIndex]["Content"] = dr[i];
                    SQLlist.Add(de);
                }
            }
            
            dbOperat.ExecuteSQLs(SQLlist);

           

            DateTime endTime = DateTime.Now; 

            TimeSpan TS = endTime - startTime;
            MessageBox.Show(TS.ToString());
            //dbOperat.updateScriptDt(scriptDt);
            //DateTime endTime = DateTime.Now; ;

            //TimeSpan TS = endTime - startTime;
            //MessageBox.Show(TS.ToString());
            //int scriptID = int.Parse(dgvScript.Rows[e.RowIndex].Cells[0].Value.ToString());//获取语句ID
            //string LanguageName = dgvScript.Columns[e.ColumnIndex].HeaderText; //获取姓名
            //int typeID = data.getTypeID(LanguageName); //获取语言ID
            //DictionaryEntry de = data.paraAndSQLScriptUpdate(scriptID, typeID, content, Language.adminName);//组建数据库语句
            ////（20160318 TODO:最后一项参数修改为登录管理员的姓名）
            //SQLlist.Add(de);
        }
       
        /// <summary>
        /// 通过列名获取TypeID
        /// </summary>
        /// <param name="colName"></param>
        /// <returns></returns>
        public object deGetTypeID(string colName)
        {
            foreach (DictionaryEntry de in typeDes)
            {
                if (de.Value.ToString() == colName)
                {
                    return de.Key;
                }
            }
            return 0;
        }

        /// <summary>
        /// 设置是否可以编辑
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnEdit_Click(object sender, EventArgs e)
        {
            dgvXml.ReadOnly = !dgvXml.ReadOnly;
            if (dgvXml.ReadOnly)
            {
                btnEdit.Text = "编辑模式";
            }
            else
            {
                btnEdit.Text = "关闭编辑";
            }
        }

        #region 界面按钮

        /// <summary>
        /// 刷新按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnFlush_Click(object sender, EventArgs e)
        {
            readXmlFIle();
        }

        /// <summary>
        /// 导回按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnGuideBack_Click(object sender, EventArgs e)
        {
            guideBack1();
        }

        #endregion

    }
}
