using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LanguagesManage.ResxHelper
{
               public class PubMethod
    {
      
        /// <summary>
        /// 获取目录下的resx文件
        /// </summary>
        /// <param name="strPath"></param>
        /// <returns></returns>
        public static List<string> GetResxList(string strPath)
        {
            List<string> result = new List<string>();
        
            // 参数:E:\c#\LanguageManage\Login.cs
            //1.获取文件夹路径  获取到  E:\c#\LanguageManage
            string Temp_str = strPath.Substring(0,strPath.LastIndexOf("\\"));

            //1.1 获取文件名称    Login.



            //2.获取文件夹下的所有文件
            DirectoryInfo root = new DirectoryInfo(Temp_str);
            FileInfo[] files = root.GetFiles();


            //3.遍历进行配置
            foreach (FileInfo item in files)
            {
                if (item.Name.StartsWith("lo") && item.Name.EndsWith("gin")) 
                {
                    result.add();
                }
            }




            return result; 
        }  
    }
}
