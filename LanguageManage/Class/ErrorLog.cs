using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace LanguagesManage
{
    class ErrorLog
    {
        /********************************************************  
  
        //创建日期:2015-12-15
         
        //作者:陈青海 
  	
        //內容说明:　用于异常时记录异常日志
  
        ********************************************************/
        /// <summary>
        /// 防止对象同步操作的
        /// </summary>
        public static object locker = new object();

        public static object locker2 = new object();
        /// <summary>
        /// 异常日志输出到文件
        /// </summary>
        /// <param name="ex">执行程序发送的错误</param>
        /// <param name="Tag">自己标注的异常处</param>
        /// <param name="LogAddress"></param>
        public static void WriteLog(Exception ex, string Tag = "", string LogAddress = "")
        { 
            lock(locker)
            {
                //如果日志文件为空,则在默认的Debug目录下新建 YYYY-mm-dd_Log.log文件
                if(LogAddress=="")
                {
                    //日志文件路径
                    LogAddress = Environment.CurrentDirectory + '\\' +
                        DateTime.Now.Year + '-' +
                        DateTime.Now.Month + '-' +
                        "Mon_Log.log";                 
                }
                //把异常信息输出到文件
                StreamWriter sw = new StreamWriter(LogAddress, true);
                sw.WriteLine(String.Concat('[', DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss fff"), "]  Tag:" + Tag));
                sw.WriteLine("异常信息：" + ex.Message);
                sw.WriteLine("异常对象：" + ex.Source);
                sw.WriteLine("调用堆栈： \n" + ex.StackTrace.Trim());
                sw.WriteLine("触发方法：" + ex.TargetSite);
                sw.WriteLine();
                sw.Close(); 
            }
        }

        /// <summary>
        /// 服务器信息日志
        /// </summary>
        /// <param name="ErrorInfo"></param>
        /// <param name="LogAddress"></param>
        public static void ServiceLog(string ErrorInfo,string LogAddress="")
        {
            lock (locker2)
            {
                //文件地址
                if (LogAddress == "")
                { 
                 LogAddress=Environment.CurrentDirectory+'\\'+
                     DateTime.Now.Year+'-'+
                     DateTime.Now.Month+'-'+
                     "_ServiceLog.log";
                }
                //把服务器异常信息输出到文件
                StreamWriter sw = new StreamWriter(LogAddress, true);
                sw.WriteLine(String.Concat('[', DateTime.Now.ToString("yy-MM-dd hh:mm:ss fff"), ']'));
                sw.WriteLine(ErrorInfo);
                sw.WriteLine();
                sw.Close();
            }
        }

        /// <summary>
        /// 监控端信息日志。
        /// </summary>
        /// <param name="UseInfo"></param>
        /// <param name="LogAddress"></param>
        public static void UseLog(string UseInfo,string LogAddress="")
        { 
            //文件地址
            if(LogAddress=="")
            {
                LogAddress = Environment.CurrentDirectory + '\\' +
                    DateTime.Now.Year + '-' +
                    DateTime.Now.Month + '-' +
                    "_UseLog.log";
            }
            StreamWriter sw = new StreamWriter(LogAddress, true);
            sw.WriteLine(String.Concat('[', DateTime.Now.ToString("yy-MM-dd hh:mm:ss fff"), ']'));
            sw.WriteLine(UseInfo);
            sw.WriteLine();
            sw.Close();
        }
    }
}
