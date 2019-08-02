using LanguagesManage.ResxHelper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LanguagesManage.Model
{
    public class ResxFile
    {

        private string strFilePath = "";

        /// <summary>
        /// 文件地址
        /// </summary>
        public string FilePtah
        {
            get { return strFilePath; }
            set { strFilePath = value; }
        }



        private string strFileName = "";

        /// <summary>
        /// 文件名称
        /// </summary>
        public string FileName
        {
            get { return strFileName; }
            set { strFileName = value; }
        }


        List<ResxData> dataSource = new List<ResxData>();

        public List<ResxData> DataSource
        {
            get { return dataSource; }
            set { dataSource = value; }
        }

    }
}
