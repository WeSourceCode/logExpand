using log4net;
using log4net.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace logExpand
{
    public class LogMethod
    {
        public delegate void AddProperties(string key, string value);
        public static event AddProperties addproperties;

        static LogMethod()
        {
            LogMethod.addproperties += new LogMethod.AddProperties(LogMethod._Properties);
        }
        private ILog logger;
        public LogMethod(ILog log)
        {
           
            this.logger = log;
        }
        public virtual void Debug(object message)
        {
            this.logger.Debug(message);
        }
        public virtual void Error(object message)
        {

            this.logger.Error(message);
        }
        public virtual void Info(object message)
        {
            this.logger.Info(message);
        }
        public virtual void Warn(object message)
        {
            this.logger.Warn(message);
        }

        public virtual void Fatal(object message)
        {
            this.logger.Fatal(message);
        }

        /// <summary>
        /// 设定新的传入数据库中的键值对
        /// </summary>
        /// <param name="key">键</param>
        /// <param name="value">值</param>
        public static void Properties(string key, string value)
        {
            //使用线程相关属性设定自定义信息
            addproperties?.Invoke(key, value);
        }

        private static void _Properties(string key,string value)
        {
            log4net.ThreadContext.Properties[key] = value;
        }


        public static LogMethod LogInfo = Log.GetLogger("default_output");

        #region DEBUG 指出细粒度信息事件对调试应用程序是非常有帮助的，主要用于开发过程中打印一些运行信息。
        public static void debug(string write)
        {

            LogInfo.Debug("日志记录:" + write);
        }
        public static void debug(string write, Exception ex)
        {
            LogInfo.Debug("日志记录:" + write + "。错误记载：" + ex.ToString());
        }
        #endregion
        #region INFO 消息在粗粒度级别上突出强调应用程序的运行过程。打印一些你感兴趣的或者重要的信息，这个可以用于生产环境中输出程序运行的一些重要信息，
        /// <summary>
        /// 1
        /// </summary>
        /// <param name="write"></param>
        public static void Info(string write)
        {
            LogInfo.Info("日志记录:" + write);
        }
        public static void Info(string write, Exception ex)
        {
            LogInfo.Info("日志记录:" + write + "。错误记载：" + ex.ToString());
        }
        #endregion
        #region WARN 表明会出现潜在错误的情形，有些信息不是错误信息，但是也要给程序员的一些提示。，可以使用这个级别。
        public static void warn(string write)
        {
            LogInfo.Warn("日志记录:" + write);
        }
        public static void warn(string write, Exception ex)
        {
            LogInfo.Warn("日志记录:" + write + "。错误记载：" + ex.ToString());
        }
        #endregion

        #region ERROR 指出虽然发生错误事件，但仍然不影响系统的继续运行。打印错误和异常信息，如果不想输出太多的日志，可以使用这个级别。
        public static void error(string write)
        {
            LogInfo.Error("日志记录:" + write);
        }
        public static void error(string write, Exception ex)
        {

            LogInfo.Error("日志记录:" + write + "。错误记载：" + ex.ToString());
        }
        #endregion
        #region FATAL 指出每个严重的错误事件将会导致应用程序的退出。这个级别比较高了。重大错误，这种级别你可以直接停止程序了。
        public static void fatal(string write)
        {
            LogInfo.Fatal("日志记录:" + write);
        }
        public static void fatal(string write, Exception ex)
        {
            LogInfo.Fatal("日志记录:" + write + "。错误记载：" + ex.ToString());
        }

        #endregion

    }
}
