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
    public partial class ExportXml : Form
    {
        #region 全局变量
        /// <summary>
        /// 数据库操作类
        /// </summary>
        DataOperation dbOperat;

        /// <summary>
        /// Xml类
        /// </summary>
        UseLanguageXml createXml;

        /// <summary>
        /// 类型表
        /// </summary>
        DataTable typeDt;

        ///// <summary>
        ///// 脚本表
        ///// </summary>
        //DataTable scriptDt;

        #endregion
        public ExportXml()
        {
            InitializeComponent();
        }

        private void ExportXml_Load(object sender, EventArgs e)
        {
            dbOperat = new DataOperation();
            createXml = new UseLanguageXml();
            typeDt = dbOperat.getType().Tables[0];
            chklstValue(typeDt);
            chklstProjectValue();
        }

        /// <summary>
        /// 语言选项的赋值
        /// </summary>
        /// <param name="typeDt"></param>
        public void chklstValue(DataTable typeDt)
        {
            //chklistType.Items.Add("0|简体中文", true);
            foreach (DataRow dr in typeDt.Rows)
            {
                chklistType.Items.Add(dr["TypeID"].ToString() + "|" + dr["Reserved_1"].ToString(), false);
            }
        }

        public void chklstProjectValue()
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
            if (chklistProject.CheckedItems.Count == 0) //选中项目
            {
                MessageBox.Show("未选中生成项目");
                return;
            }
            exportXml(xmlFileName);
           
        }

        /// <summary>
        /// 导出文件
        /// </summary>
        /// <param name="fileName"></param>
        public void exportXml(string fileName)
        {
            if (rdoExportEdit.Checked)  //编辑
            {
                if (createXml.existEditXmlFile(fileName)) //同名文件
                {
                    if (MessageBox.Show("存在同名文件,是否覆盖？", "系统提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)  //点击确定
                    {
                        exportEditXml(fileName);
                        return;
                    }
                    else
                    {
                        return;
                    }
                }
                exportEditXml(fileName);
            }
            else       //读取
            {
                if (createXml.existXmlFile(fileName)) //同名文件
                {
                    if (MessageBox.Show("存在同名文件,是否覆盖？", "系统提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)  //点击确定
                    {
                        exportReadXml(fileName);
                        return;
                    }
                    else
                    {
                        return;
                    }
                }
                exportReadXml(fileName);
            }
        }

        public void exportEditXml(string fileName)
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

        public void exportReadXml(string fileName)
        {
            try
            {
                createXml.createXmlFile(fileName);
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
                //chkStr = chklistType.CheckedItems[i].ToString();
                //typeIds[i] = Convert.ToInt32(chkStr.Substring(0, chkStr.IndexOf("|")));
                //if (typeIds[i] == 0) //是否选中中文
                //{
                //    createXml.addTypeNode(fileName, typeIds[i].ToString(), "简体中文", "简体中文");
                //    continue;
                //}
                //DataRow[] drs = typeDt.Select("TypeID=" + typeIds[i]);
                //createXml.addTypeNode(fileName,typeIds[i].ToString(),drs[0]["Reserved_1"].ToString(),drs[0]["LanguageName"].ToString());
                chkStr = chklistType.CheckedItems[i].ToString();
                typeIds[i] = Convert.ToInt32(chkStr.Substring(0, chkStr.IndexOf("|")));
            }
            if (rdoExportEdit.Checked)  //编辑
            {
                createXml.addEditTypeNodes(fileName, typeIds);
            }
            else  //读取
            {
                createXml.addReadTypeNodes(fileName, typeIds);
            }
        }


        int[] projectIds;
        public void exportXmlProject(string fileName)
        {
            projectIds = new int[chklistProject.CheckedItems.Count];
            string chkStr;   //选中的文字
            for (int i = 0; i < projectIds.Length; i++)
            {
                chkStr = chklistProject.CheckedItems[i].ToString();
                projectIds[i] = Convert.ToInt32(chkStr.Substring(0, chkStr.IndexOf("|")));
            }
            if (rdoExportEdit.Checked)  //编辑
            {
                //createXml.addEditTypeNodes(fileName, projectIds);
                createXml.addEditProjectNodes(fileName, projectIds);
            }
            else   //读取
            {
                createXml.addReadProjectNodes(fileName, projectIds);
            }
        }



        /// <summary>
        /// 添加选中语言的脚本
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
            if (rdoExportEdit.Checked) //编辑
            {
                createXml.addEditScriptNodes(fileName, typeIds, projectIds);
            }
            else   //读取
            {
                createXml.addReadScriptNodes(fileName, typeIds, projectIds);
            }
            
        }


        public void addXmlInfo(string fileName)
        {
            string xmlInfo = txtInfo.Text.Trim();
            if (rdoExportEdit.Checked)  //编辑
            {
                createXml.addEditXmlInfo(fileName, Language.adminName, xmlInfo);
            }
            else   //读取
            {
                createXml.addXmlInfo(fileName, Language.adminName, xmlInfo);
            }
            
        }

        /// <summary>
        /// 编辑文件选项
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void rdoExportEdit_CheckedChanged(object sender, EventArgs e)
        {
            txtFileName.Text = "LanguageEditXml";
        }

        /// <summary>
        /// 读取文件选项
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void rdoExportRead_CheckedChanged(object sender, EventArgs e)
        {
            txtFileName.Text = "LanguageXml";
        }

        private void btnOpenEditFile_Click(object sender, EventArgs e)
        {
            string filePath = Environment.CurrentDirectory + "\\EditXml";
            System.Diagnostics.Process.Start("explorer.exe", filePath);
        }


        private void btnOpenReadFile_Click(object sender, EventArgs e)
        {
            string filePath = Environment.CurrentDirectory + "\\ExportXml";
            System.Diagnostics.Process.Start("explorer.exe", filePath);
        }
    }
}
