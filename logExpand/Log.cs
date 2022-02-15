using log4net;
using log4net.Appender;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace logExpand
{
    public class Log
    {

        /// <summary>
        /// 注册log4net的配置文件
        /// </summary>
        /// <param name="src">路径</param>
        /// <param name="relative">是否为相对路径</param>
        public static void Register(string src = null,bool relative =false)
        {
            FileInfo configFile;
            if (src is null)
            {
                configFile = new FileInfo(FileUrl.PathUrl("log4net.config"));

            }
            else
            {
                if (relative)
                {
                    configFile = new FileInfo(FileUrl.PathUrl(src));
                }
                else
                {
                    configFile = new FileInfo(src);
                }
            }
            log4net.Config.XmlConfigurator.Configure(configFile);
        }

        public static LogMethod GetLogger(Type type)
        {
            return new LogMethod(LogManager.GetLogger(type));
        }
        public static LogMethod GetLogger(string str)
        {
            return new LogMethod(LogManager.GetLogger(str));
        }
    }
}
