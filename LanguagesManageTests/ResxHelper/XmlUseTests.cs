using Microsoft.VisualStudio.TestTools.UnitTesting;
using LanguagesManage.ResxHelper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LanguagesManage.Model;

namespace LanguagesManage.ResxHelper.Tests
{
    [TestClass()]
    public class XmlUseTests
    {
        [TestMethod()]
        public void GetDataValueTest()
        {
            string strFilePath = @"G:\Working\SK3000\Cu\CUCode\接警客户端\FormLogin.resx";
            string strName = "测试Name";
            ResxData data = XmlUse.GetDataValue(strFilePath, strName);
            Assert.AreEqual(data.Value, "测试Vau1e");
        }

        [TestMethod()]
        public void AppendDataNodeTest()
        {
            ResxData data = new ResxData
            {
                Name = "测试Name",
                Value = "测试Value",
                xml_space = "preserve",
                Comment = "测试Comment"
            };
            string strFilePath = @"G:\Working\SK3000\Cu\CUCode\接警客户端\FormLogin.resx";
            XmlUse.AppendDataNode(strFilePath, data);
            Assert.Fail();
        }

        [TestMethod()]
        public void GetResxDataListTest()
        {
            string strFilePath = @"G:\Working\SK3000\Cu\CUCode\接警客户端\FormLogin.resx";
            List<ResxData> Temp_source = XmlUse.GetResxDataList(strFilePath);
            Assert.AreEqual(Temp_source.Count(item => item.datatype == 1), 1);
        }

        [TestMethod()]
        public void UpdataDataNodeTest()
        {
            string strFilePath = @"C:\Users\hongdongcheng\Desktop\test\FormLogin.en.resx";
            ResxData data = new ResxData
            {
                Name= "取消",
                Value="Cancel",
                Comment="取消"
            };
            XmlUse.UpdataDataNode(strFilePath, data);
            Assert.Fail();
        }
    }
}