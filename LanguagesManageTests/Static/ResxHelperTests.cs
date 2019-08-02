using Microsoft.VisualStudio.TestTools.UnitTesting;
using LanguagesManage.Static;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LanguagesManage.Static.Tests
{
    [TestClass()]
    public class ResxHelperTests
    {
        [TestMethod()]
        public void TestTest()
        {
            ResxHelper1.Test();
            Assert.Fail();
        }

        [TestMethod()]
        public void AppendDataNodeTest()
        {
            ResxHelper1.AppendDataNode();
            Assert.Fail();
        }
    }
}