using Dashboard.Shared.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Dashboard.Logic.DbModel
{
    public class LogInfo : ILogObject
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

        [NotMapped]
        public IDictionary<string, string> Properties
        {
            get
            {
                return string.IsNullOrEmpty(PropertiesSerialized) ? null : JsonConvert.DeserializeObject<Dictionary<string, string>>(PropertiesSerialized);
            }
            set
            {
                PropertiesSerialized = JsonConvert.SerializeObject(value);
            }
        }

        public string PropertiesSerialized { get; set; }


        public LogLevel Level { get; set; }
    }
}
