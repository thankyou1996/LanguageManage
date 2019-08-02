using Microsoft.VisualStudio.TestTools.UnitTesting;
using LanguagesManage.ResxHelper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LanguagesManage.ResxHelper.Tests
{
    [TestClass()]
    public class XmlUseTests
    {
        [TestMethod()]
        public void GetDataValueTest()
        {
            string strFilePath = @"G:\Working\SK3000\Cu\CUCode\接警客户端\FormMain.byn.resx";
            string strName = "测试Name";
            ResxData data = XmlUse.GetDataValue(strFilePath, strName);
            Assert.AreEqual(data.Value, "测试Value");
        }
    }
}