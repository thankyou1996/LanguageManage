using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml;

namespace LanguagesManage
{
    public  class UseLanguageXml
    {
        string  xmlFilePathtest= Environment.CurrentDirectory.ToString() + "\\LanguageXml.xml";

        string readXmlFilesPath = Environment.CurrentDirectory.ToString()+"\\ExportXml";

        string editXmlFilesPath = Environment.CurrentDirectory.ToString() + "\\EditXml";

        DataOperation dbOperat = new DataOperation();


        #region 导出程序读取文件 old

        /// <summary>
        /// 判断文件是否存在
        /// </summary>
        /// <param name="fileName"></param>
        /// <returns></returns>
        public bool existXmlFile(string fileName)
        {
            if (File.Exists(readXmlFilesPath))  //判读是否存在文件
            {

            }
            else  //不存在
            {
                DirectoryInfo dirInfo = new DirectoryInfo(readXmlFilesPath);
                dirInfo.Create();
            }
            if (File.Exists(readXmlFilesPath + "\\" + fileName + ".xml")) //判断文件存不存在
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// 创建文件
        /// </summary>
        /// <param name="xmlFilePath"></param>
        /// <returns></returns>
        public int createXmlFile(string fileName)
        {
            string xmlFilePath = readXmlFilesPath + "\\" + fileName + ".xml";
            try
            {
                XmlDocument languageXmlDoc = new XmlDocument();

                //根节点
                XmlElement rootElement = languageXmlDoc.CreateElement("Language");
                languageXmlDoc.AppendChild(rootElement);

                //语言类型节点
                XmlElement firstElement1 = languageXmlDoc.CreateElement("LanguageType");
                rootElement.AppendChild(firstElement1);

                XmlElement firstElement3 = languageXmlDoc.CreateElement("LanguageProjects");
                rootElement.AppendChild(firstElement3);

                //语言库节点
                XmlElement firstElement2 = languageXmlDoc.CreateElement("LanguageScript");
                rootElement.AppendChild(firstElement2);

                languageXmlDoc.Save(xmlFilePath);
                return 1;
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// 添加语言类型节点
        /// </summary>
        /// <param name="TypeID"></param>
        /// <param name="chineName"></param>
        /// <param name="languageName"></param>
        public int addTypeNode(string fileName, string TypeID, string chinaMean, string languageName)
        {
            string xmlFilePath = readXmlFilesPath + "\\" + fileName + ".xml";
            try
            {
                //打开XML文件
                XmlDocument languageXmlDoc = new XmlDocument();
                languageXmlDoc.Load(xmlFilePath);

                XmlNode typeNode = languageXmlDoc.FirstChild.SelectSingleNode("LanguageType"); //查找语言类型节点
                XmlElement newType = languageXmlDoc.CreateElement("Type"); //节点赋值
                newType.SetAttribute("chinaMean", chinaMean);
                newType.SetAttribute("typeID", TypeID);
                newType.InnerText = languageName;
                typeNode.AppendChild(newType); //添加节点
                languageXmlDoc.Save(xmlFilePath); //保存
                return 1;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            
        }

        /// <summary>
        /// 添加语言库节点
        /// </summary>
        /// <param name="filePath"></param>
        /// <param name="scriptID"></param>
        /// <param name="typeID"></param>
        /// <param name="content"></param>
        /// <returns></returns>
        public int addScriptNode(string fileName, string scriptID, string typeID, string content)
        {
            string xmlFilePath = readXmlFilesPath + "\\" + fileName + ".xml";
            try
            {
                //打开Xml文件
                XmlDocument languageXmlDoc = new XmlDocument();
                languageXmlDoc.Load(xmlFilePath);

                XmlNode scriptNode = languageXmlDoc.FirstChild.SelectSingleNode("LanguageScript"); //查找基本语言节点
                XmlElement newScript = languageXmlDoc.CreateElement("Script"); //节点赋值
                newScript.SetAttribute("scriptID", scriptID);
                newScript.SetAttribute("typeID", typeID);
                newScript.InnerText = content;
                scriptNode.AppendChild(newScript); //添加节点
                languageXmlDoc.Save(xmlFilePath);     //保存
                return 1;
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// 添加Xml文件信息
        /// </summary>
        /// <param name="fileName"></param>
        /// <param name="creater"></param>
        /// <param name="info"></param>
        public void addXmlInfo(string fileName, string creater, string info)
        {
            string xmlFilePath = readXmlFilesPath + "\\" + fileName + ".xml";
            XmlDocument languageXmlDoc = new XmlDocument();
            languageXmlDoc.Load(xmlFilePath);

            XmlNode rootNode = languageXmlDoc.FirstChild;

            XmlElement xmlInfo = languageXmlDoc.CreateElement("XmlInfo");
            xmlInfo.SetAttribute("Creater", creater);
            xmlInfo.SetAttribute("CreateTime", DateTime.Now.ToString());
            xmlInfo.InnerText = info;

            rootNode.AppendChild(xmlInfo);
            languageXmlDoc.Save(xmlFilePath);
        }

        #endregion

        #region 导出程序读取文件 
        
        /// <summary>
        /// 添加语言类型所有节点
        /// </summary>
        /// <param name="fileName"></param>
        /// <param name="typeIDs"></param>
        /// <returns></returns>
        public int addReadTypeNodes(string fileName,int[] typeIDs)
        {
            string xmlFilePath = readXmlFilesPath + "\\" + fileName + ".xml";
            try
            {
                DataTable dtType = dbOperat.getSelectedType(typeIDs).Tables[0];
                XmlDocument languageEdiXmlDoc = new XmlDocument(); //打开文件
                languageEdiXmlDoc.Load(xmlFilePath);

                XmlNode typeNode = languageEdiXmlDoc.FirstChild.SelectSingleNode("LanguageType"); //查找语言类型节点
                XmlElement newType;
                newType = languageEdiXmlDoc.CreateElement("Type");
                newType.SetAttribute("typeID","0");
                newType.SetAttribute("Name","简体中文");
                newType.SetAttribute("LanguageName", "简体中文");
                newType.SetAttribute("Abbreviations", "zh_CN");
                typeNode.AppendChild(newType);
                foreach (DataRow dr in dtType.Rows) //循环添加语言节点信息
                {
                    newType = languageEdiXmlDoc.CreateElement("Type"); //节点赋值
                    newType.SetAttribute("typeID", dr["TypeID"].ToString());
                    newType.SetAttribute("Name", dr["Reserved_1"].ToString());
                    newType.SetAttribute("LanguageName", dr["LanguageName"].ToString());
                    newType.SetAttribute("Abbreviations", dr["Reserved_2"].ToString());
                    typeNode.AppendChild(newType); //添加节点
                }
                languageEdiXmlDoc.Save(xmlFilePath); //保存
                return 1;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            //string xmlFilePath = xmlFilesPath + "\\" + fileName + ".xml";
            //try
            //{
            //    //打开XML文件
            //    XmlDocument languageXmlDoc = new XmlDocument();
            //    languageXmlDoc.Load(xmlFilePath);

            //    XmlNode typeNode = languageXmlDoc.FirstChild.SelectSingleNode("LanguageType"); //查找语言类型节点
            //    XmlElement newType = languageXmlDoc.CreateElement("Type"); //节点赋值
            //    newType.SetAttribute("chinaMean", chinaMean);
            //    newType.SetAttribute("typeID", TypeID);
            //    newType.InnerText = languageName;
            //    typeNode.AppendChild(newType); //添加节点
            //    languageXmlDoc.Save(xmlFilePath); //保存
            //    return 1;
            //}
            //catch (Exception ex)
            //{
            //    throw ex;
            //}
        }

        public int addReadProjectNodes(string fileName, int[] projectIDs)
        {
            string xmlFilePath = readXmlFilesPath + "\\" + fileName + ".xml";
            try
            {
                DataTable dtProjects = dbOperat.getSelectedProject(projectIDs).Tables[0];
                XmlDocument languageReadXmlDoc = new XmlDocument(); //打开文件
                languageReadXmlDoc.Load(xmlFilePath);

                XmlNode projectsNode = languageReadXmlDoc.FirstChild.SelectSingleNode("LanguageProjects");
                XmlElement newProject;

                foreach (DataRow dr in dtProjects.Rows)
                {
                    newProject = languageReadXmlDoc.CreateElement("Project");
                    newProject.SetAttribute("projectID", dr["ProjectID"].ToString());
                    newProject.SetAttribute("ProjectName", dr["ProjectName"].ToString());
                    newProject.SetAttribute("SolutionName", dr["SolutionName"].ToString());
                    projectsNode.AppendChild(newProject);
                }
                languageReadXmlDoc.Save(xmlFilePath);
                return 1;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void addReadScriptNodes(string fileName,int[] typeIDs,int[] projectIDs)
        {
            string xmlFilePath = readXmlFilesPath + "\\" + fileName + ".xml";
            try
            {
                using (DataTable dtBasic = dbOperat.getBasicScript(projectIDs).Tables[0])
                {
                    using (DataTable dtScript = dbOperat.getV_ScriptXml(typeIDs, projectIDs).Tables[0])
                    {
                        XmlDocument languageReadXmlDoc = new XmlDocument();
                        languageReadXmlDoc.Load(xmlFilePath);

                        XmlNode scriptNode = languageReadXmlDoc.FirstChild.SelectSingleNode("LanguageScript");
                        XmlElement newScript;
                        foreach(DataRow dr in dtBasic.Rows)
                        {
                            newScript = languageReadXmlDoc.CreateElement("Script");
                            newScript.SetAttribute("scriptID", dr["ScriptID"].ToString());
                            newScript.SetAttribute("typeID", "0");
                            newScript.InnerText = dr["BasicText"].ToString();
                            scriptNode.AppendChild(newScript);
                        }
                        foreach (DataRow dr in dtScript.Rows)
                        {
                            newScript = languageReadXmlDoc.CreateElement("Script");
                            newScript.SetAttribute("scriptID", dr["ScriptID"].ToString());
                            newScript.SetAttribute("typeID", dr["TypeID"].ToString());
                            newScript.InnerText = dr["Content"].ToString();
                            scriptNode.AppendChild(newScript);
                        }
                        languageReadXmlDoc.Save(xmlFilePath);
                    }
                }
            }
                // XmlDocument languageEdiXmlDoc = new XmlDocument(); //打开文件
                //languageEdiXmlDoc.Load(editXmlFilePath);

                //XmlNode scriptNode = languageEdiXmlDoc.FirstChild.SelectSingleNode("LanguageScript"); //查找基本语言节点
                //DataTable scriptDt = dbOperat.getV_ScriptXml(typeIds,projectIDs).Tables[0];
                //DataTable basicScriptDt = dbOperat.getBasicScript(projectIDs).Tables[0];
                //XmlElement newScript;

                //foreach (DataRow dr in basicScriptDt.Rows)
                //{

                //    newScript = languageEdiXmlDoc.CreateElement("Script"); //节点创建
                //    newScript.SetAttribute("ScriptID", dr["ScriptID"].ToString());
                //    newScript.SetAttribute("zh_CN", dr["BasicText"].ToString());
                //    DataRow[] drs = scriptDt.Select("scriptID='" + dr["ScriptID"] + "'");
                //    foreach (DataRow drr in drs)
                //    {
                //        newScript.SetAttribute(drr["LanguageAbbreviation"].ToString(), drr["Content"].ToString());
                //    }
                //    scriptNode.AppendChild(newScript);
                //}
                //languageEdiXmlDoc.Save(editXmlFilePath);
                
                //return 1;
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region  导出翻译人员编辑文件
        /// <summary>
        /// 判断文件是否存在
        /// </summary>
        /// <param name="fileName"></param>
        /// <returns></returns>
        public bool existEditXmlFile(string fileName)
        {
            if (File.Exists(editXmlFilesPath))  //判读是否存在文件
            {

            }
            else  //不存在
            {
                DirectoryInfo dirInfo = new DirectoryInfo(editXmlFilesPath);
                dirInfo.Create();
            }
            if (File.Exists(editXmlFilesPath + "\\" + fileName + ".xml")) //判断文件存不存在
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// 创建编辑文件
        /// </summary>
        /// <param name="fileName"></param>
        /// <returns></returns>
        public int createEditXmlFile(string fileName)
        {
            string editXmlFilePath = editXmlFilesPath + "\\" + fileName + ".xml";
            try
            {
                XmlDocument languageEditXmlDoc = new XmlDocument();

                //根节点
                XmlElement rootElement = languageEditXmlDoc.CreateElement("Language");
                languageEditXmlDoc.AppendChild(rootElement);

                //语言类型节点
                XmlElement firstElement1 = languageEditXmlDoc.CreateElement("LanguageType");
                rootElement.AppendChild(firstElement1);

                //项目节点
                XmlElement firstElement3 = languageEditXmlDoc.CreateElement("LanguageProjects");
                rootElement.AppendChild(firstElement3);

                //语言库节点
                XmlElement firstElement2 = languageEditXmlDoc.CreateElement("LanguageScript");
                rootElement.AppendChild(firstElement2);

                

                languageEditXmlDoc.Save(editXmlFilePath);
                return 1;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// 添加语言节点（所有选中的语言节点）
        /// </summary>
        /// <param name="fileName"></param>
        /// <param name="typeIds"></param>
        /// <returns></returns>
        public int addEditTypeNodes(string fileName,int[] typeIds)
        {
            string editXmlFilePath = editXmlFilesPath + "\\" + fileName + ".xml";
            try
            {
                DataTable dtType = dbOperat.getSelectedType(typeIds).Tables[0];
                XmlDocument languageEdiXmlDoc = new XmlDocument(); //打开文件
                languageEdiXmlDoc.Load(editXmlFilePath);

                XmlNode typeNode = languageEdiXmlDoc.FirstChild.SelectSingleNode("LanguageType"); //查找语言类型节点
                XmlElement newType;

                foreach (DataRow dr in dtType.Rows) //循环添加语言节点信息
                {
                    newType = languageEdiXmlDoc.CreateElement("Type"); //节点赋值
                    newType.SetAttribute("typeID", dr["TypeID"].ToString());
                    newType.SetAttribute("中文名称", dr["Reserved_1"].ToString());
                    newType.SetAttribute("外语名称", dr["LanguageName"].ToString());
                    newType.SetAttribute("语言缩写", dr["Reserved_2"].ToString());
                    typeNode.AppendChild(newType); //添加节点
                }
                languageEdiXmlDoc.Save(editXmlFilePath); //保存
                return 1;
            }
            catch(Exception ex)
            {
                throw ex;
            }

        }

        public int addEditProjectNodes(string fileName, int[] projectIds)
        {
            string editXmlFilePath = editXmlFilesPath + "\\" + fileName + ".xml";
            try
            {
                DataTable dtProjects = dbOperat.getSelectedProject(projectIds).Tables[0];
                XmlDocument languageEditXmlDoc = new XmlDocument(); //打开文件
                languageEditXmlDoc.Load(editXmlFilePath);

                XmlNode projectsNode = languageEditXmlDoc.FirstChild.SelectSingleNode("LanguageProjects");
                XmlElement newProject;

                foreach (DataRow dr in dtProjects.Rows)
                {
                    newProject = languageEditXmlDoc.CreateElement("Project");
                    newProject.SetAttribute("projectID", dr["ProjectID"].ToString());
                    newProject.SetAttribute("项目名称", dr["ProjectName"].ToString());
                    newProject.SetAttribute("解决方案名称", dr["SolutionName"].ToString());
                    projectsNode.AppendChild(newProject);
                }
                languageEditXmlDoc.Save(editXmlFilePath);
                return 1;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }



        /// <summary>
        /// 添加语言脚本节点
        /// </summary>
        /// <param name="fileName"></param>
        /// <param name="typeIds"></param>
        /// <returns></returns>
        public int addEditScriptNodes(string fileName,int[] typeIds,int[] projectIDs)
        {
            string editXmlFilePath = editXmlFilesPath + "\\" + fileName + ".xml";
            try
            {
                XmlDocument languageEdiXmlDoc = new XmlDocument(); //打开文件
                languageEdiXmlDoc.Load(editXmlFilePath);

                XmlNode scriptNode = languageEdiXmlDoc.FirstChild.SelectSingleNode("LanguageScript"); //查找基本语言节点
                DataTable scriptDt = dbOperat.getV_ScriptXml(typeIds,projectIDs).Tables[0];
                DataTable basicScriptDt = dbOperat.getBasicScript(projectIDs).Tables[0];
                XmlElement newScript;

                foreach (DataRow dr in basicScriptDt.Rows)
                {

                    newScript = languageEdiXmlDoc.CreateElement("Script"); //节点创建
                    newScript.SetAttribute("ScriptID", dr["ScriptID"].ToString());
                    newScript.SetAttribute("zh_CN", dr["BasicText"].ToString());
                    DataRow[] drs = scriptDt.Select("scriptID='" + dr["ScriptID"] + "'");
                    foreach (DataRow drr in drs)
                    {
                        newScript.SetAttribute(drr["LanguageAbbreviation"].ToString(), drr["Content"].ToString());
                    }
                    scriptNode.AppendChild(newScript);
                }
                languageEdiXmlDoc.Save(editXmlFilePath);
                
                return 1;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// 添加EditXml文件信息
        /// </summary>
        /// <param name="fileName"></param>
        /// <param name="creater"></param>
        /// <param name="info"></param>
        public void addEditXmlInfo(string fileName, string creater, string info)
        {
            string editXmlFilePath = editXmlFilesPath + "\\" + fileName + ".xml";
            XmlDocument languageXmlDoc = new XmlDocument();
            languageXmlDoc.Load(editXmlFilePath);

            XmlNode rootNode = languageXmlDoc.FirstChild;

            XmlElement xmlInfo = languageXmlDoc.CreateElement("XmlInfo");
            xmlInfo.SetAttribute("Creater", creater);
            xmlInfo.SetAttribute("CreateTime", DateTime.Now.ToString());
            xmlInfo.InnerText = info;

            rootNode.AppendChild(xmlInfo);
            languageXmlDoc.Save(editXmlFilePath);
        }
        #endregion 

        #region 导回编译人员编辑文件

        /// <summary>
        /// 获取文件中语言类型（设置表头,设置类型）
        /// </summary>
        /// <param name="filePath">文件路径</param>
        /// <param name="dtUse">显示的数据表</param>
        /// <param name="languageAb">语言缩写数组 Xml文件中属性</param>
        /// <param name="typeDes">key:TypeID value：表列名</param>
        public void readType(string filePath, ref DataTable dtUse, ref string[] languageAb, ref DictionaryEntry[] typeDes)
        {
            XmlDocument readXmlDoc = new XmlDocument();
            readXmlDoc.Load(filePath);

            XmlNode rootNode = readXmlDoc.FirstChild;//根节点
            XmlNode typeNodes = rootNode.SelectSingleNode("LanguageType"); //语言类型节点
            dtUse.Columns.Add("ID"); //ID
            dtUse.Columns.Add("简体中文"); //中文
            XmlNodeList typeLists = typeNodes.ChildNodes;
            languageAb = new string[typeLists.Count];
            typeDes = new DictionaryEntry[typeLists.Count];
            int index = 0;
            foreach (XmlElement xe in typeLists)
            {
                string colName = xe.GetAttribute("中文名称").ToString();
                dtUse.Columns.Add(colName);
                languageAb[index] = xe.GetAttribute("语言缩写");
                typeDes[index].Key = xe.GetAttribute("typeID");
                typeDes[index].Value = colName;
                index++;
            }
        }


        /// <summary>
        /// 获取文件中的脚本信息
        /// </summary>
        /// <param name="filePath"></param>
        /// <param name="dtUse"></param>
        /// <param name="languageAb"></param>
        /// <param name="typeDes"></param>
        public void readScript(string filePath, ref DataTable dtUse, ref string[] languageAb, ref DictionaryEntry[] typeDes)
        {
            XmlDocument readXmlDoc = new XmlDocument();
            readXmlDoc.Load(filePath);

            XmlNode rootNode = readXmlDoc.FirstChild; //根节点

            XmlNode scriptNodes = rootNode.SelectSingleNode("LanguageScript"); //语言脚本节点
            //for (int i = 2; i < dtUse.Columns.Count; i++)
            //{
            //    int typeID = Convert.ToInt32(deGetTypeID(TypeDes,dtUse.Columns[i].ToString()));

            //}
            XmlNodeList scriptList=scriptNodes.ChildNodes;
            DataRow newDr;
            foreach (XmlElement xe in scriptList)
            {
                newDr = dtUse.NewRow();
                newDr["ID"] = xe.GetAttribute("ScriptID");
                newDr["简体中文"] = xe.GetAttribute("zh_CN");
                for (int i = 0; i < languageAb.Length; i++)
                {
                    newDr[typeDes[i].Value.ToString()] = xe.GetAttribute(languageAb[i]);
                }
                dtUse.Rows.Add(newDr);
            }
        }

        /// <summary>
        /// 获取文件信息 0,创建人 1,创建时间 2,备注
        /// </summary>
        /// <param name="filePath"></param>
        /// <returns></returns>
        public string[] readXmlInfo(string filePath)
        {
            string[] xmlInfo = new string[3];

            XmlDocument readXmlDoc = new XmlDocument();
            readXmlDoc.Load(filePath);

            XmlNode rootNode = readXmlDoc.FirstChild; //根节点

            XmlNode xmlInfoNode = rootNode.SelectSingleNode("XmlInfo");  //文件信息节点
            xmlInfo[0] = xmlInfoNode.Attributes["Creater"].Value;
            xmlInfo[1] = xmlInfoNode.Attributes["CreateTime"].Value;
            xmlInfo[2] = xmlInfoNode.InnerText;

            return xmlInfo;

        }
        #endregion
    }
}
