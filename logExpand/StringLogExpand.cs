using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace logExpand
{
    public static class StringLogExpand
    {
        static LogMethod log = Log.GetLogger("StringLogExpand");
        static StringLogExpand()
        {
           
        }
        /// <summary>
        /// log写入拓展
        /// </summary>
        /// <param name="logstr">写入内容</param>
        /// <param name="LogName">日志名</param>
        public static void LogDebug(this string logstr, string LogName = null)
        {
            if (!(LogName is null))
            {
                log = Log.GetLogger(LogName);
            }
            log.Debug(logstr);
        }

        /// <summary>
        /// log写入拓展
        /// </summary>
        /// <param name="logstr">写入内容</param>
        /// <param name="LogName">日志名</param>
        public static void LogError(this string logstr, string LogName = null)
        {
            if (!(LogName is null))
            {
                log = Log.GetLogger(LogName);
            }
            log.Error(logstr);
        }


        /// <summary>
        /// log写入拓展
        /// </summary>
        /// <param name="logstr">写入内容</param>
        /// <param name="LogName">日志名</param>
        public static void LogInfo(this string logstr, string LogName = null)
        {
            if (!(LogName is null))
            {
                log = Log.GetLogger(LogName);
            }
            log.Info(logstr);
        }

        /// <summary>
        /// log写入拓展
        /// </summary>
        /// <param name="logstr">写入内容</param>
        /// <param name="LogName">日志名</param>
        public static void LogWarn(this string logstr, string LogName = null)
        {
            if (!(LogName is null))
            {
                log = Log.GetLogger(LogName);
            }
            log.Warn(logstr);
        }


        /// <summary>
        /// log写入拓展
        /// </summary>
        /// <param name="logstr">写入内容</param>
        /// <param name="LogName">日志名</param>
        public static void LogFatal(this string logstr, string LogName = null)
        {
            if (!(LogName is null))
            {
                log = Log.GetLogger(LogName);
            }
            log.Fatal(logstr);
        }
    }
}
