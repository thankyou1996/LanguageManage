using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace LanguagesManage
{
    class AutoSizeFormClass
    {
       /********************************************************  
  
        //创建日期:2016-03-22
  
        //作者:洪栋城
  	
        //內容说明:　界面控件自适应
        
        //注意事项：缩放倍数过大时，lable控件之间间距会变大
       ********************************************************/


        /// <summary>
        /// 声明结构体，代表控件对象，记录空间信息
        /// </summary>
        public struct controlRect
        {
            public int Left;     //初始位置
            public int Top;      //初始位置
            public int Width;    //宽
            public int Height;   //高
        }
        /// <summary>
        /// 记录窗体控件的对象
        /// </summary>
        public List<controlRect> oldCtrl = new List<controlRect>();
        int ctrlNo = 0;

        /// <summary>
        /// 用于窗体生成时，记录初始窗体信息
        /// </summary>
        /// <param name="mForm"></param>
        public void controlInitializeSize(Control mForm)
        {
            controlRect cR;   //窗体对象
            cR.Left = mForm.Left;
            cR.Top = mForm.Top;
            cR.Width = mForm.Width;
            cR.Height = mForm.Height;
            oldCtrl.Add(cR); //将窗体信息添加至list对象
            AddControl(mForm); //将窗体中的控件加进list对象
        }

        /// <summary>
        /// 记录窗体对象
        /// </summary>
        /// <param name="ctl">可以是窗体，也可以是一个容器</param>
        private void AddControl(Control ctl)
        {
            foreach (Control c in ctl.Controls) //循环添加控件信息
            {
                controlRect objCtrl;
                objCtrl.Left = c.Left;
                objCtrl.Top = c.Top;
                objCtrl.Width = c.Width;
                objCtrl.Height = c.Height;
                oldCtrl.Add(objCtrl);
                if (c.Controls.Count > 0) //判断是否存在子控件（容器）
                {
                    AddControl(c);       //存在子控件，递归调用
                }
            }
        }



        /// <summary>
        /// 控件自适应大小
        /// </summary>
        /// <param name="mForm"></param>
        public void controlAutoSize(Control mForm)
        {
            if (ctrlNo == 0)
            {
                controlRect cR;
                cR.Left = 0;
                cR.Top = 0;
                cR.Width = mForm.PreferredSize.Width;
                cR.Height = mForm.PreferredSize.Height;
                oldCtrl.Add(cR);
                AddControl(mForm);
            }
            float wScale = (float)mForm.Width / (float)oldCtrl[0].Width;  //计算窗体之间宽的比例
            float hScale = (float)mForm.Height / (float)oldCtrl[0].Height;// 计算窗体之间高的比例
            ctrlNo = 1;
            AutoScaleControl(mForm, wScale, hScale);
        }

        private void AutoScaleControl(Control ctl, float wScale, float hScale)
        {
            if (wScale < 1 || hScale<1) //判断是否需要缩放（小于初始大小则不进行缩放）
            {
                return;
            }
            int ctrlLeft0;
            int ctrlTop0;
            int ctrlWidth0;
            int ctrlHeight0;
            foreach (Control c in ctl.Controls)
            {
                //获取控件初始大小
                ctrlLeft0 = oldCtrl[ctrlNo].Left;
                ctrlTop0 = oldCtrl[ctrlNo].Top;
                ctrlWidth0 = oldCtrl[ctrlNo].Width;
                ctrlHeight0 = oldCtrl[ctrlNo].Height;

                //按比例控制界面控件大小
                c.Left = Convert.ToInt32(((ctrlLeft0) * wScale)); //计算控件位置
                c.Top = Convert.ToInt32(((ctrlTop0) * hScale));
                c.Width=Convert.ToInt32(((ctrlWidth0)*wScale)); //计算控件的大小
                c.Height = Convert.ToInt32(((ctrlHeight0) * hScale));

                ctrlNo++; //序号添加

                if (c.Controls.Count > 0) //判断是否有子控件
                {
                    AutoScaleControl(c, wScale, hScale); //递归调用,先缩放控件本身，在缩放其子控件。
                }
                if (ctl is DataGridView)  //判断控件是否是DataGridView
                {
                    DataGridView dgv = ctl as DataGridView;
                    Cursor.Current = Cursors.WaitCursor;

                    int widths = 0;
                    for (int i = 0; i < dgv.Columns.Count; i++) 
                    {
                        dgv.AutoResizeColumn(i, DataGridViewAutoSizeColumnMode.DisplayedCells); //自动调整列宽
                        widths += dgv.Columns[i].Width;//计算列的宽度
                    }
                    if (widths >= ctl.Size.Width) //调整后的列宽是否大于设定列宽
                    {
                        dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;//调整列的模式，自动
                    }
                    else
                    {
                        dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;//调整列的模式，自动
                    }
                    Cursor.Current = Cursors.Default;   //调整列的的模式，填充
                }

            }
        }

    }
}
