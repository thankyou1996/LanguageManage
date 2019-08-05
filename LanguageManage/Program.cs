using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace LanguagesManage
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            //登录窗口 在主程序显示之前

            //Application.EnableVisualStyles();
            //Application.SetCompatibleTextRenderingDefault(false);
            //Login login = new Login();
            //login.ShowDialog();
            //if (login.DialogResult == DialogResult.OK)//登录验证，验证成功进入主程序
            //{
            //    Application.Run(new Language());
            //}

            //防止多开

            string strProcessName = System.Diagnostics.Process.GetCurrentProcess().ProcessName;
            //获取版本号 
            //CommonData.VersionNumber = Application.ProductVersion; 
            //检查进程是否已经启动，已经启动则显示报错信息退出程序。 
            if (System.Diagnostics.Process.GetProcessesByName(strProcessName).Length > 1)
            {

                MessageBox.Show("程序已经运行！", "消息", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                Application.Exit();
                return;
            }

            //主程序
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            //object result = WaitWindow.WaitWindow.Show(WorkMethod, "数据库连接中");
            //if (flag)
            //{
            //Application.Run(new Language());
            Application.Run(new CodeFilter_Resx());
                //Application.Run(new FrmTest());
            //}
            //else
            //{
            //    MessageBox.Show(result.ToString());
            //}

            //Application.EnableVisualStyles();
            //Application.SetCompatibleTextRenderingDefault(false);
            //Application.Run(new Language());
        }
        static bool flag = false;

        private static void WorkMethod(object sender, WaitWindow.WaitWindowEventArgs e)
        {
            switch (DataOperation.dbExists())
            {
                case -1:
                    e.Result = "数据库连接异常\n请检查数据库服务是否开启,数据库连接字符串是否正确";
                    flag = false;
                    break;
                case 0:
                    e.Result = "数据库连接异常\n数据库不存在请执行数据库脚本";
                    flag = false;
                    break;
                case 1:
                    //数据库正常
                    e.Result = "";
                    flag = true;
                    break;
                default:
                    e.Result = "数据库连接异常\n未知异常";
                    flag = false;
                    break;
            }
        }
    }
}
