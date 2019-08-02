using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LanguagesManage.Model
{
    public class ResxData
    {
        public string Name
        {
            get;
            set;
        }

        /// <summary>
        /// 值
        /// </summary>
        public string Value
        {
            get;
            set;
        }

        /// <summary>
        /// 注释
        /// </summary>
        public string Comment
        {
            get;
            set;
        }
        /// <summary>
        /// xml:space 属性
        /// </summary>
        public string xml_space
        {
            get;
            set;
        }

        /// <summary>
        /// 数据类型 
        /// 0系统生成（默认） 1 源码数据
        /// </summary>
        public int datatype
        {
            get;
            set;
        }
    }
}
