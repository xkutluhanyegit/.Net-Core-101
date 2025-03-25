using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.CrossCutting.Logging
{
    public interface ILoggerService
    {
        void Info(LogDetail logDetail);
        void Debug(LogDetail logDetail);
        void Warn(LogDetail logDetail);
        void Error(LogDetail logDetail);
        void Fatal(LogDetail logDetail);
    }
}