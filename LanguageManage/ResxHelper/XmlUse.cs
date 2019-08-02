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


        public static bool AppendDataNode(string strPath, ResxData data)
        {
            string strFilePath = strPath;
            XmlDocument xmlDoc = GetDocument(strPath);
            XmlNode nodeParent = xmlDoc.SelectSingleNode("root");   //父节点
            XmlElement node = xmlDoc.CreateElement("data");
            node.SetAttribute("name", data.Name);
            node.SetAttribute("xml:space", "preserve");
            XmlElement nodeValue = xmlDoc.CreateElement("value");
            nodeValue.InnerXml = data.Value;
            node.AppendChild(nodeValue);
            XmlElement nodeComment = xmlDoc.CreateElement("comment");
            nodeComment.InnerXml = data.Comment;
            node.AppendChild(nodeComment);
            nodeParent.AppendChild(node);
            xmlDoc.Save(strFilePath);
            return true;
        }


        public static ResxData GetDataValue(string strPath,string strName)
        {
            ResxData data = null;
            XmlDocument xmlDoc = GetDocument(strPath);
            XmlNode nodeParent = xmlDoc.SelectSingleNode("root");   //父节点
            XmlNode Temp_node = xmlDoc.SelectSingleNode("/root/data[@name='" + strName + "']");
            if (Temp_node != null)
            {
                data = new ResxData();
                data.Name = strName;
                XmlNode nodeValue = Temp_node.SelectSingleNode("value");
                if (nodeValue != null)
                {
                    data.Value = nodeValue.InnerText;
                }
                XmlNode nodeComment = Temp_node.SelectSingleNode("comment");
                if (nodeComment != null)
                {
                    data.Comment = nodeComment.InnerText;
                }
            }
            return data;
        }
    }
}
