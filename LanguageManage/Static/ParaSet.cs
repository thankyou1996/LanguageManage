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
    }
}
