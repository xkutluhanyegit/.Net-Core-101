using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.CrossCutting.Logging
{
    public class LogDetail
    {
        public string MethodName { get; set; }
        public string Message {get;set;}
        public string ClassName { get; set; }
        public List<LogParameter> Parameters { get; set; }
        public DateTime LogDate { get; set; }
        public string User { get; set; }
    }
}