using Dashboard.Logic.DbModel;
using Dashboard.Shared.Model;
using Dashboard.ViewModel;
using System.Collections.Generic;

namespace Dashboard.Converters
{
    public class LogInfoConverter
    {
        public LogInfoViewModel Convert(LogInfo info)
        {
            return new LogInfoViewModel
            {
                Application = info.Application,
                ExceptionInner = info.ExceptionInner,
                ExceptionMessage = info.ExceptionMessage,
                ExceptionStack = info.ExceptionStack,
                Id = info.Id,
                Level = info.Level,
                Logger = info.Logger,
                Message = info.Message,
                Properties = (Dictionary<string,string>)info.Properties,
                TimeStamp = info.TimeStamp,
                UserInfo = info.UserInfo
            };
        }

        public LogInfo Convert(ILogObject info)
        {
            return new LogInfo
            {
                Application = info.Application,
                ExceptionInner = info.ExceptionInner,
                ExceptionMessage = info.ExceptionMessage,
                ExceptionStack = info.ExceptionStack,
                Level = info.Level,
                Logger = info.Logger,
                Message = info.Message,
                Properties = (Dictionary<string, string>)info.Properties,
                TimeStamp = info.TimeStamp,
                UserInfo = info.UserInfo
            };
        }
    }
}
