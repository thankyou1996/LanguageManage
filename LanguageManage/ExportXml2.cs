using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace LanguagesManage
{
    public partial class ExportXml2 : Form
    {
        #region 全局变量
        /// <summary>
        /// 数据库操作对象
        /// </summary>
        DataOperation dbOperat;

        UseLanguageXml createXml;

        DataTable typeDt;
        #endregion
        public ExportXml2()
        {
            InitializeComponent();
        }

        private void ExportXml2_Load(object sender, EventArgs e)
        {
            dbOperat = new DataOperation();
            createXml = new UseLanguageXml();
            typeDt = dbOperat.getType().Tables[0];
            chklstTypeValue(typeDt);
            chklstProjectValue();
        }

        /// <summary>
        /// 语言选项的赋值
        /// </summary>
        /// <param name="typeDt"></param>
        private void chklstTypeValue(DataTable typeDt)
        {
            //chklistType.Items.Add("0|简体中文", true);
            foreach (DataRow dr in typeDt.Rows)
            {
                chklistType.Items.Add(dr["TypeID"].ToString() + "|" + dr["Reserved_1"].ToString(), false);
            }
        }

        /// <summary>
        /// 项目选项的赋值
        /// </summary>
        private void chklstProjectValue()
        {
            DataTable dtProjects = dbOperat.getProjects().Tables[0];
            foreach (DataRow dr in dtProjects.Rows)
            {
                chklistProject.Items.Add(dr["ProjectID"].ToString() + "|" + dr["ProjectName"].ToString());
            }
        }

        /// <summary>
        /// 生成事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCreateXml_Click(object sender, EventArgs e)
        {
            string xmlFileName = txtFileName.Text.Trim();
            if (string.IsNullOrEmpty(xmlFileName)) //文件名称
            {
                MessageBox.Show("请输入文件名称");
                return;
            }
            if (chklistType.CheckedItems.Count == 0) //选中语言
            {
                MessageBox.Show("未选中生成语言");
                return;
            }
            if (chklistProject.CheckedItems.Count == 0)
            {
                MessageBox.Show("未选中生成项目");
                return;
            }
            if (createXml.existEditXmlFile(xmlFileName)) //同名文件
            {
                if (MessageBox.Show("存在同名文件,是否覆盖？", "系统提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)  //点击确定
                {
                    exportXml(xmlFileName);
                    return;
                }
                else
                {
                    return;
                }
            }
            exportXml(xmlFileName);
        }

        /// <summary>
        /// 导出文件
        /// </summary>
        /// <param name="fileName"></param>
        public void exportXml(string fileName)
        {
            try
            {
                createXml.createEditXmlFile(fileName);
                exportXmlType(fileName);
                exportXmlProject(fileName);
                exportXmlScript(fileName);
                addXmlInfo(fileName);
                MessageBox.Show("生成成功");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        int[] typeIds;

        /// <summary>
        /// 添加选中语言的类型
        /// </summary>
        /// <param name="fileName"></param>
        public void exportXmlType(string fileName)
        {
            typeIds = new int[chklistType.CheckedItems.Count];
            string chkStr;  //选中列的文字
            for (int i = 0; i < typeIds.Length; i++)
            {
                chkStr = chklistType.CheckedItems[i].ToString();
                typeIds[i] = Convert.ToInt32(chkStr.Substring(0, chkStr.IndexOf("|")));
                //if (typeIds[i] == 0) //是否选中中文
                //{
                //    createXml.addTypeNode(fileName, typeIds[i].ToString(), "简体中文", "简体中文");
                //    continue;
                //}
                //DataRow[] drs = typeDt.Select("TypeID=" + typeIds[i]);
                //createXml.addTypeNode(fileName, typeIds[i].ToString(), drs[0]["Reserved_1"].ToString(), drs[0]["LanguageName"].ToString());
            }
            createXml.addEditTypeNodes(fileName, typeIds);
        }
        int[] projectIds;

        /// <summary>
        /// 添加选中的项目
        /// </summary>
        /// <param name="fileName"></param>
        public void exportXmlProject(string fileName)
        {
            projectIds = new int[chklistProject.CheckedItems.Count];
            string chkStr;
            for (int i = 0; i < projectIds.Length; i++)
            {
                chkStr = chklistProject.CheckedItems[i].ToString();
                projectIds[i] = Convert.ToInt32(chkStr.Substring(0, chkStr.IndexOf("|")));
            }
            createXml.addEditProjectNodes(fileName, projectIds);
        }


        /// <summary>
        /// 添加语言脚本
        /// </summary>
        /// <param name="fileName"></param>
        public void exportXmlScript(string fileName)
        {
            //if (typeIds[0] == 0) //选择了中文
            //{
            //    getBasicScript(fileName);
            //}
            //DataTable scriptDt = dbOperat.getScriptXml(typeIds).Tables[0];
            //foreach (DataRow dr in scriptDt.Rows)
            //{
            //    createXml.addScriptNode(fileName, dr["ScriptID"].ToString(), dr["TypeID"].ToString(), dr["Content"].ToString());
            //}
            createXml.addEditScriptNodes(fileName,typeIds,projectIds);
        }

        public void addXmlInfo(string fileName)
        {
            string xmlInfo = txtInfo.Text.Trim();
            createXml.addEditXmlInfo(fileName, Language.adminName, xmlInfo);
        }
    }
}
