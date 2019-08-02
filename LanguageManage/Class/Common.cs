using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace LanguagesManage
{
    class Common
    {
        /// <summary>
        /// 控制DataGridView控件的列宽模式
        /// </summary>
        /// <param name="dgv"></param>
        public static void gridViewModeControl(DataGridView dgv)
        {
            //dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;
            //int width = 0;
            //for (int i = 0; i < dgv.Columns.Count; i++)
            //{
            //    dgv.AutoResizeColumn(i, DataGridViewAutoSizeColumnMode.DisplayedCells); //调整列的宽的模式
            //    if (!dgv.Columns[i].Visible)
            //    {
            //        continue;
            //    }
            //    width += dgv.Columns[i].Width;   //统计列的宽度
            //}
            //if (width >= dgv.Size.Width+30) //判断列宽是否大于表格长度
            //{
            //    dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;// 调整列宽为自动
            //}
            //else
            //{
            //    dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;          //调整列宽模式为填充
            //}
        }
    }
}
