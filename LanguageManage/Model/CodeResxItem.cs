using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LanguagesManage.Model
{
    public class CodeResxItem
    {

        public List<string> CodeViewSource
        {
            get;
            set;
        }

        /// <summary>
        /// 行数
        /// </summary>
        public int Line
        {
            get;
            set;
        }

        public ResxData ResxData
        {
            get;
            set;
        }

    }
}
