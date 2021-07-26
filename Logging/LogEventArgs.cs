// // ///-----------------------------------------------------------------
// // ///   Class:          LogEventArgs.cs
// // ///   Description:    <Description>
// // ///   Author:         Bastian Noffer                     Date: 31.08.2018
// // ///   Company:        ©2018 real GmbH
// // ///   Notes:          <Notes>
// // ///   Revision History:
// // ///-----------------------------------------------------------------
using System;
namespace Real.Xamarin.Forms.Extensions.Logging
{
    public class LogEventArgs : EventArgs
    {
        private DateTime _timestamp;
        private string _logLevel;
        private string _source;
        private string _message;
        private Exception _exception;

        public DateTime Timestamp { get => _timestamp; }
        public string LogLevel { get => _logLevel; }
        public string Source { get => _source; }
        public string Message { get => _message; }
        public Exception Exception { get => _exception; }

        public LogEventArgs(DateTime timestamp, string logLevel, string source, string message, Exception exception = null)
        {
            this._timestamp = timestamp;
            this._logLevel = logLevel;
            this._source = source;
            this._message = message;
            this._exception = exception;
        }
    }
}
