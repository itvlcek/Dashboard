using System;
using System.Collections.Generic;

namespace Dashboard.Shared.Model
{
    public class LogObject : ILogObject
    {     
        public string Application { get; set; }                        

        public string Message { get; set; }

        public DateTime TimeStamp { get; set; }

        public IDictionary<string, string> Properties { get; set; }

        public LogLevel Level { get; set; }

        public string Logger { get; set; }

        public string ExceptionInner { get; set; }

        public string ExceptionMessage { get; set; }

        public string ExceptionStack { get; set; }

        public string UserInfo { get; set; }
    }
}
