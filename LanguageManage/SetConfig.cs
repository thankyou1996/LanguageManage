using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LanguagesManage
{
    class SetConfig
    {
        /// <summary>
        /// 翻页显示的数量设置
        /// </summary>
        public static int PageSize = 0;

        static Configuration config;
        /// <summary>
        /// 设置信息
        /// </summary>
        public static void getConfigInfo()
        {
            config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            PageSize =Convert.ToInt32(config.AppSettings.Settings["PageSize"].Value);  //分页的显示数量

            //#region 界面参数赋值
            //txtDbIP.Text = config.ConnectionStrings.ConnectionStrings["dbIP"].ConnectionString;
            //txtDbPort.Text = config.ConnectionStrings.ConnectionStrings["dbPort"].ConnectionString;
            //txtUserID.Text = config.ConnectionStrings.ConnectionStrings["dbUser"].ConnectionString;
            //txtPwd.Text = config.ConnectionStrings.ConnectionStrings["dbPwd"].ConnectionString;
            //#endregion
        }


        public static void setConfigInfo(int pageSize)
        {
            config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            config.AppSettings.Settings["PageSize"].Value =Convert.ToString(pageSize);
            SetConfig.PageSize = pageSize;
            config.Save(ConfigurationSaveMode.Modified);
            ConfigurationManager.RefreshSection("appSettings");
            //config.ConnectionStrings.ConnectionStrings["dbIP"].ConnectionString = this.dbIP;
            //config.ConnectionStrings.ConnectionStrings["dbPort"].ConnectionString = this.dbPort;
            //config.ConnectionStrings.ConnectionStrings["dbUser"].ConnectionString = this.userID;
            //config.ConnectionStrings.ConnectionStrings["dbPwd"].ConnectionString = this.password;
            //config.Save(ConfigurationSaveMode.Modified);
            //ConfigurationManager.RefreshSection("connectionStrings");
        }
    }
}
