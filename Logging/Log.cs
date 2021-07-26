using System;
using System.Diagnostics;
using System.Text;

namespace Real.Xamarin.Forms.Extensions.Logging
{
    public static class Log
    {
        public static LogLevel ActiveLogLevel { get; set; }
        public static EventHandler<LogEventArgs> NewLogEntry;

        public static void WriteEntry(string message)
        {
            WriteEntry(LogLevel.Debug, "", message);
        }

        public static void WriteEntry(Exception ex)
        {
            WriteEntry(LogLevel.Error, ex.Source, ex.Message, ex);
        }

        public static void WriteEntry(string source, string message)
        {
            WriteEntry(LogLevel.Debug, source, message);
        }

        public static void WriteEntry(LogLevel level, string source, string message, Exception ex = null)
        {
            if ((ActiveLogLevel == LogLevel.Error) && (level != LogLevel.Error))
                return;
            else if ((ActiveLogLevel == LogLevel.Debug) && (level == LogLevel.Info))
                return;

            if (ex != null)
            {
                PrintToConsole(level, source, message, ex);
                NewLogEntry?.Invoke(new object(), new LogEventArgs(DateTime.Now, GetLogLevelString(level), source, message, ex));
            }
            else
            {
                PrintToConsole(level, source, message);
                NewLogEntry?.Invoke(new object(), new LogEventArgs(DateTime.Now, GetLogLevelString(level), source, message));
            }
        }

        private static void PrintToConsole(LogLevel level, string source, string message, Exception ex = null)
        {
            var sb = new StringBuilder();
            sb.AppendFormat("{0:G}", DateTime.Now);
            sb.Append(" [" + GetLogLevelString(level) + "] ");
            sb.Append(" [" + source + "] ");
            sb.Append(" " + message + " ");
            Debug.WriteLine(sb.ToString());
            if (ex != null)
            {
                Debug.WriteLine("Exception: " + ex.Message);
                Debug.WriteLine(ex.StackTrace);
            }
        }

        private static string GetLogLevelString(LogLevel level)
        {
            switch (level)
            {
                case LogLevel.Debug:
                    return "DEBUG";
                case LogLevel.Error:
                    return "ERROR";
                case LogLevel.Info:
                    return "INFO";
                default:
                    return "DEBUG";
            }
        }

        private static LogLevel GetLogLevelFromString(string level)
        {
            var str = level.ToUpper();
            if (str.Equals(GetLogLevelString(LogLevel.Debug)))
                return LogLevel.Debug;
            else if (str.Equals(GetLogLevelString(LogLevel.Error)))
                return LogLevel.Error;
            else if (str.Equals(GetLogLevelString(LogLevel.Info)))
                return LogLevel.Info;
            else
                return LogLevel.Debug;
        }
    }
}
