using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LanguagesManage;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Data;
namespace LanguagesManage.Tests
{
    [TestClass()]
    public class DataOperationTests
    {
        DataOperation dbOperat = new DataOperation();
        [TestMethod()]
        public void existsBasicScriptTest()
        {
         int retuInt=  dbOperat.existsBasicScript("你好",7);
         Assert.AreEqual(retuInt, 1);
        }

        [TestMethod()]
        public void getScriptCloneTest()
        {
            //Assert.Fail();
            DataTable dt = dbOperat.getScriptClone().Tables[0];
            int colNum = dt.Columns.Count;
            Assert.AreEqual(colNum, 1);
        }

        [TestMethod()]
        public void dbExistsTest()
        {
            Assert.AreEqual(DataOperation.dbExists(), 1);
        }

        [TestMethod()]
        public void getV_ScriptTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void getV_ScriptTest1()
        {
            string languageName="中文繁体,英文";
            int pageSize=1000;
            int pageIndex=0;
            DataSet ds = dbOperat.getV_Script(languageName,1,pageSize,pageIndex);
            DataTable dt = ds.Tables[0];
            int row = dt.Rows.Count;
            int count = Convert.ToInt32(ds.Tables[1].Rows[0][0]);
            Assert.AreEqual(row, 1);
        }

        [TestMethod()]
        public void getBasicScriptTest()
        {
            int projectId = 1;
            int position = 0;
            int pageSize = 1000;
            int pageIndex = 0;
            DataSet ds = dbOperat.getBasicScript(projectId, position, pageSize, pageIndex);
            int row = ds.Tables[0].Rows.Count;
            int count = Convert.ToInt32(ds.Tables[1].Rows[0][0]);
            Assert.AreEqual(row, 1);
        }

        [TestMethod()]
        public void getV_ScripttTest()
        {
            string languageName = dbOperat.getLanguageName();
            string languageName2 = null;
            int projectId = 1;
            string position=Convert.ToString(dbOperat.getPosition(projectId).Tables[0].Rows[0]["Position"]);
            int pageSize = 1000;
            int pageIndex = 0;
            DataSet ds = dbOperat.getV_Scriptt(languageName, projectId, position, pageSize, pageIndex);
            DataTable dt = ds.Tables[0];
            int row = dt.Rows.Count;
            int count = Convert.ToInt32(ds.Tables[1].Rows[0][0]);
            Assert.AreEqual(row, 1);
        }

        [TestMethod()]
        public void getProjectIdTest()
        {
            string projectName = "test";
            string solutionName="test";

            int projectId = dbOperat.getProjectId(projectName, solutionName);
            Assert.AreEqual(projectId, 1);
        }
    }
}
