using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace LanguagesManage.Static
{
    public class ResxHelper1
    {
        public static void Test()
        {
            string strFilePath = @"G:\Working\SK3000\Cu\CUCode\接警客户端\FormLogin.resx";
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load(strFilePath);
            XmlNode nodeParent = xmlDoc.SelectSingleNode("root");   //父节点
            XmlNodeList result= nodeParent.SelectNodes("data");

        }


        public static void AppendDataNode()
        {
            //<data name="测试" xml:space="preserve">
            //    <value>123</value>
            //    <comment>456</comment>
            //</data>
            string strFilePath = @"G:\Working\SK3000\Cu\CUCode\接警客户端\FormMain.byn.resx";
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load(strFilePath);
            XmlNode nodeParent = xmlDoc.SelectSingleNode("root");   //父节点

            string strName = "测试Name";
            string strValue = "测试Value";
            string strComment = "测试Comment";
            XmlElement node = xmlDoc.CreateElement("data");
            node.SetAttribute("name", strName);
            node.SetAttribute("xml:space", "preserve");

            XmlElement nodeValue = xmlDoc.CreateElement("value");
            nodeValue.InnerXml = strValue;
            node.AppendChild(nodeValue);
            XmlElement nodeComment = xmlDoc.CreateElement("comment");
            nodeComment.InnerXml = strComment;
            node.AppendChild(nodeComment);
            nodeParent.AppendChild(node);
            xmlDoc.Save(strFilePath);
        }

        //public XmlNode Find

    }
}
