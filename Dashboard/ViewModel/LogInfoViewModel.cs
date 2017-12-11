using Dashboard.Shared.Model;
using System;
using System.Collections.Generic;

namespace Dashboard.ViewModel
{
    public class LogInfoViewModel 
    {
        public int Id { get; set; }

        public string Application { get; set; }

        public string Logger { get; set; }

        public string ExceptionInner { get; set; }

        public string ExceptionMessage { get; set; }

        public string ExceptionStack{ get; set; }

        public string UserInfo { get; set; }

        public string Message { get; set; }

        public DateTime TimeStamp { get; set; }
        
        public Dictionary<string, string> Properties { get; set; }

        public LogLevel Level { get; set; }
    }
}
