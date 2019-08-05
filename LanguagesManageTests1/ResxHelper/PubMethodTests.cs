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
    public class PubMethodTests
    {
        [TestMethod()]
        public void GetResxListTest()
        {
            string strPath = @"E:\c#\LanguageManage\Login.cs";
            //List<string> result = PubMethod.GetResxList(strPath);
            List<string> result = PubMethod.GetResxList(strPath);
            Assert.AreEqual(result[0],2);
        }
    }
}