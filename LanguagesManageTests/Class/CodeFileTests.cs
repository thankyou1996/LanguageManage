using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LanguagesManage;
using Microsoft.VisualStudio.TestTools.UnitTesting;
namespace LanguagesManage.Tests
{
    [TestClass()]
    public class CodeFileTests
    {
        CodeFile code = new CodeFile("1","2");
        [TestMethod()]
        public void getOperTypeTest()
        {
            //Assert.Fail();
            //string oeprStr = "1234'56789";
            //int operIndex;
            //int operType = code.filterContent(oeprStr);
            //Assert.AreEqual(operType, 1);
        }
    }
}
