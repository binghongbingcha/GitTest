using System;
using System.IO;
using log4net;

namespace EcgViewPro
{
    /// <summary>
    /// 日志文件类
    /// </summary>
    public class WatchDog
    {
        static readonly ILog log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        static WatchDog()
        {
            var configFile = new FileInfo(AppDomain.CurrentDomain.BaseDirectory + @"AppConfig.config");//读取日志文件配置路径
            log4net.Config.XmlConfigurator.Configure(configFile);
        }

        /// <summary>
        /// 写入一般信息
        /// </summary>
        /// <param name="str"></param>
        public static void WriteMsg(string str)
        {
            log.InfoFormat("{0}", str);
            log.Info("-----------------------------------------------------分割线-----------------------------------------------------");
        }

        /// <summary>
        /// 一般消息（information）
        /// </summary>
        /// <param name="msg">描述内容</param>
        /// <param name="ex">异常对象</param>
        public static void Write(string msg, Exception ex)
        {
            log.Info(msg, ex);
            log.Info("-----------------------------------------------------分割线-----------------------------------------------------");
        }

        /// <summary>
        /// 调试信息
        /// </summary>
        /// <param name="msg">描述内容</param>
        /// <param name="ex">异常对象</param>
        public static void Debug(string msg, Exception ex)
        {
            log.Debug(msg, ex);
            log.Info("-----------------------------------------------------分割线-----------------------------------------------------");
        }

        /// <summary>
        /// 警告信息
        /// </summary>
        /// <param name="msg">描述内容</param>
        /// <param name="ex">异常对象</param>
        public static void Warn(string msg, Exception ex)
        {
            log.Warn(msg, ex);
            log.Info("-----------------------------------------------------分割线-----------------------------------------------------");
        }

        /// <summary>
        /// 错误信息
        /// </summary>
        /// <param name="msg">描述内容</param>
        /// <param name="ex">异常对象</param>
        public static void Error(string msg, Exception ex)
        {
            log.Error(msg, ex);
            log.Info("-----------------------------------------------------分割线-----------------------------------------------------");
        }

        /// <summary>
        /// 致命错误
        /// </summary>
        /// <param name="msg">描述内容</param>
        /// <param name="ex">异常对象</param>
        public static void Fatal(string msg, Exception ex)
        {
            log.Fatal(msg, ex);
            log.Info("-----------------------------------------------------分割线-----------------------------------------------------");
        }
    }
}
