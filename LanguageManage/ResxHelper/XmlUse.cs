using LanguagesManage.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace LanguagesManage.ResxHelper
{
    public class XmlUse
    {
        //<data name="测试" xml:space="preserve">
        //    <value>123</value>
        //    <comment>456</comment>
        //</data>

        private static XmlDocument GetDocument(string strFilePath)
        {
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load(strFilePath);
            return xmlDoc;
        }


        #region 增



        public static bool AppendDataNode(string strPath, ResxData data)
        {
            string strFilePath = strPath;
            XmlDocument xmlDoc = GetDocument(strPath);
            AppendDataNode(xmlDoc, data);
            xmlDoc.Save(strFilePath);
            return true;
        }

        public static bool AppendDataNode(string strPath, List<ResxData> lstData)
        {
            string strFilePath = strPath;
            XmlDocument xmlDoc = GetDocument(strPath);
            foreach (ResxData data in lstData)
            {
                AppendDataNode(xmlDoc, data);
            }
            xmlDoc.Save(strFilePath);
            return true;
        }


        private static bool AppendDataNode(XmlDocument xmlDoc, ResxData data)
        {
            XmlNode nodeParent = xmlDoc.SelectSingleNode("root");   //父节点
            XmlElement node = xmlDoc.CreateElement("data");
            node.SetAttribute("name", data.Name);
            node.SetAttribute("xml:space", data.xml_space);
            if (data.datatype != 0)
            {
                node.SetAttribute("datatype", Convert.ToString(data.datatype));
            }
            XmlElement nodeValue = xmlDoc.CreateElement("value");
            nodeValue.InnerXml = data.Value;
            node.AppendChild(nodeValue);
            XmlElement nodeComment = xmlDoc.CreateElement("comment");
            nodeComment.InnerXml = data.Comment;
            node.AppendChild(nodeComment);
            nodeParent.AppendChild(node);
            
            return true;
        }

        #endregion


        #region 改

        public static bool UpdataDataNode(string strPath,ResxData data)
        {
            bool bolResult = false;
            XmlDocument xmlDoc = GetDocument(strPath);
            XmlNode Temp_node = xmlDoc.SelectSingleNode("/root/data[@name='" + data.Name + "']");
            XmlNode nodeValue =Temp_node.SelectSingleNode("value");
            nodeValue.InnerXml = data.Value;
            XmlNode nodeComment = Temp_node.SelectSingleNode("comment");
            nodeComment.InnerXml = data.Comment;
            xmlDoc.Save(strPath);
            return bolResult;
        }



        #endregion

        public static ResxData GetDataValue(string strPath,string strName)
        {
            ResxData data = null;
            XmlDocument xmlDoc = GetDocument(strPath);
            XmlNode nodeParent = xmlDoc.SelectSingleNode("root");   //父节点
            XmlNode Temp_node = xmlDoc.SelectSingleNode("/root/data[@name='" + strName + "']");
            if (Temp_node != null)
            {
                data = GetResxData(Temp_node);
            }
            return data;
        }


        public static List<ResxData> GetResxDataList(string strPath)
        {
            List<ResxData> result = new List<ResxData>();
            XmlDocument xmlDoc = GetDocument(strPath);
            XmlNode nodeParent = xmlDoc.SelectSingleNode("root");   //父节点
            XmlNodeList Temp_node = nodeParent.SelectNodes("data");
            foreach (XmlNode node in Temp_node)
            {
                result.Add(GetResxData(node));
            }
            return result;
        }

        public static ResxData GetResxData(XmlNode node)
        {
            ResxData data = null;
            
            if (node != null)
            {
                data = new ResxData();
                data.Name = node.Attributes["name"].Value;
                XmlAttribute atter = node.Attributes["xml:space"];
                if (atter != null)
                {
                    data.xml_space = atter.Value;
                }
                XmlAttribute atter1 = node.Attributes["datatype"];
                if (atter1 != null)
                {
                    data.datatype = Convert.ToInt32(atter1.Value);
                }
                XmlNode nodeValue = node.SelectSingleNode("value");
                if (nodeValue != null)
                {
                    data.Value = nodeValue.InnerText;
                }
                XmlNode nodeComment = node.SelectSingleNode("comment");
                if (nodeComment != null)
                {
                    data.Comment = nodeComment.InnerText;
                }
            }
            return data;
        }





    }
}
