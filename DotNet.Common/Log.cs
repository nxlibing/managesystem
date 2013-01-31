using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using log4net.Config;
using log4net;

namespace DotNet.Common
{
    public class Log
    {
        private static log4net.ILog _log = null;

        private static object lockHelper = new object();
        private static log4net.ILog InnerLog
        {
            get
            {
                if (null == _log)
                {
                    lock (lockHelper)
                    {
                        if (null == _log)
                        {
                            XmlConfigurator.Configure(new System.IO.FileInfo(System.IO.Path.Combine(AppInfo.ApplicationStartPath, "config\\log4net.config")));
                            _log = LogManager.GetLogger("Logging");
                        }
                    }
                }
                return _log;
            }
        }

        public static void InitLog()
        {
            ILog l = InnerLog;
        }

        public static void Debug(object message, Exception exception)
        {
            InnerLog.Debug(message, exception);
        }

        public static void Debug(object message)
        {
            InnerLog.Debug(message);
        }

        public static void DebugFormat(IFormatProvider provider, string format, params object[] args)
        {
            InnerLog.DebugFormat(provider, format, args);
        }

        public static void DebugFormat(string format, object arg0, object arg1, object arg2)
        {
            InnerLog.DebugFormat(format, arg0, arg1, arg2);
        }

        public static void DebugFormat(string format, object arg0, object arg1)
        {
            InnerLog.DebugFormat(format, arg0, arg1);
        }

        public static void DebugFormat(string format, object arg0)
        {
            InnerLog.DebugFormat(format, arg0);
        }

        public static void DebugFormat(string format, params object[] args)
        {
            InnerLog.DebugFormat(format, args);
        }

        public static void Error(object message, Exception exception)
        {
            InnerLog.Error(message, exception);
        }

        public static void Error(object message)
        {
            InnerLog.Error(message);
        }

        public static void ErrorFormat(IFormatProvider provider, string format, params object[] args)
        {
            InnerLog.ErrorFormat(provider, format, args);
        }

        public static void ErrorFormat(string format, object arg0, object arg1, object arg2)
        {
            InnerLog.ErrorFormat(format, arg0, arg1, arg2);
        }

        public static void ErrorFormat(string format, object arg0, object arg1)
        {
            InnerLog.ErrorFormat(format, arg0, arg1);
        }

        public static void ErrorFormat(string format, object arg0)
        {
            InnerLog.ErrorFormat(format, arg0);
        }

        public static void ErrorFormat(string format, params object[] args)
        {
            InnerLog.ErrorFormat(format, args);
        }

        public static void Fatal(object message, Exception exception)
        {
            InnerLog.Fatal(message, exception);
        }

        public static void Fatal(object message)
        {
            InnerLog.Fatal(message);
        }

        public static void FatalFormat(IFormatProvider provider, string format, params object[] args)
        {
            InnerLog.FatalFormat(provider, format, args);
        }

        public static void FatalFormat(string format, object arg0, object arg1, object arg2)
        {
            InnerLog.FatalFormat(format, arg0, arg1, arg2);
        }

        public static void FatalFormat(string format, object arg0, object arg1)
        {
            InnerLog.FatalFormat(format, arg0, arg1);
        }

        public static void FatalFormat(string format, object arg0)
        {
            InnerLog.FatalFormat(format, arg0);
        }

        public static void FatalFormat(string format, params object[] args)
        {
            InnerLog.FatalFormat(format, args);
        }

        public static void Info(object message, Exception exception)
        {
            InnerLog.Info(message, exception);
        }

        public static void Info(object message)
        {
            InnerLog.Info(message);
        }

        public static void InfoFormat(IFormatProvider provider, string format, params object[] args)
        {
            InnerLog.InfoFormat(provider, format, args);
        }

        public static void InfoFormat(string format, object arg0, object arg1, object arg2)
        {
            InnerLog.InfoFormat(format, arg0, arg1, arg2);
        }

        public static void InfoFormat(string format, object arg0, object arg1)
        {
            InnerLog.InfoFormat(format, arg0, arg1);
        }

        public static void InfoFormat(string format, object arg0)
        {
            InnerLog.InfoFormat(format, arg0);
        }

        public static void InfoFormat(string format, params object[] args)
        {
            InnerLog.InfoFormat(format, args);
        }

        public static bool IsDebugEnabled
        {
            get { return InnerLog.IsDebugEnabled; }
        }

        public static bool IsErrorEnabled
        {
            get { return InnerLog.IsErrorEnabled; }
        }

        public static bool IsFatalEnabled
        {
            get { return InnerLog.IsFatalEnabled; }
        }

        public static bool IsInfoEnabled
        {
            get { return InnerLog.IsInfoEnabled; }
        }

        public static bool IsWarnEnabled
        {
            get { return IsWarnEnabled; }
        }

        public static void Warn(object message, Exception exception)
        {
            InnerLog.Warn(message, exception);
        }

        public static void Warn(object message)
        {
            InnerLog.Warn(message);
        }

        public static void WarnFormat(IFormatProvider provider, string format, params object[] args)
        {
            InnerLog.WarnFormat(provider, format, args);
        }

        public static void WarnFormat(string format, object arg0, object arg1, object arg2)
        {
            InnerLog.WarnFormat(format, arg0, arg1, arg2);
        }

        public static void WarnFormat(string format, object arg0, object arg1)
        {
            InnerLog.WarnFormat(format, arg0, arg1);
        }

        public static void WarnFormat(string format, object arg0)
        {
            InnerLog.WarnFormat(format, arg0);
        }

        public static void WarnFormat(string format, params object[] args)
        {
            InnerLog.WarnFormat(format, args);
        }
    }
}
