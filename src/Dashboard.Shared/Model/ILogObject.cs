using System;
using System.Collections.Generic;

namespace Dashboard.Shared.Model
{
    public interface ILogObject
    {
        string Application { get; set; }

        string Logger { get; set; }

        string ExceptionInner { get; set; }

        string ExceptionMessage  { get; set; }

        string ExceptionStack { get; set; }

        string UserInfo { get; set; }

        string Message { get; set; }

        DateTime TimeStamp { get; set; }

        IDictionary<string, string> Properties { get; set; }
        
        LogLevel Level { get; set; }
    }
}
