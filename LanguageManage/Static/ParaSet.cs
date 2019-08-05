using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LanguagesManage.Static
{
    public class ParaSet
    {

        private static bool bolFilterResourcesGetStringEnable = true;

        /// <summary>
        /// 过滤代码中的已经替换的Reources.GetString的文本
        /// True 过滤  False不过滤
        /// </summary>
        public static bool FilterResourcesGetStringEnable
        {
            get { return bolFilterResourcesGetStringEnable; }
            set { bolFilterResourcesGetStringEnable = value; }
        }

        /// <summary>
        /// 中文过滤
        /// </summary>
        public static bool onlyChinese = false;

        /// <summary>
        /// 控件名称过滤
        /// </summary>
        public static bool controlName = false;

        /// <summary>
        /// Sql语句过滤
        /// </summary>
        public static bool sqlSentence = false;

        /// <summary>
        /// 字体过滤
        /// </summary>
        public static bool fontSet = false;

        /// <summary>
        /// 图片设置过滤
        /// </summary>
        public static bool imageSet = false;


        /// <summary>
        /// 替换的字符串
        /// </summary>
        public static bool dbText = true;
    }
}
