using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Serilog;

namespace Domain.CrossCutting.Logging
{
    public class SerilogLoggerService : ILoggerService
    {
        private readonly ILogger _logger;

        public SerilogLoggerService()
        {
            _logger = Log.Logger;
        }
        public void Info(LogDetail logDetail)
        {
            _logger.Information("{@LogDetail}", logDetail);
        }

        public void Debug(LogDetail logDetail)
        {
            _logger.Debug("{@LogDetail}", logDetail);
        }

        public void Warn(LogDetail logDetail)
        {
            _logger.Warning("{@LogDetail}", logDetail);
        }

        public void Error(LogDetail logDetail)
        {
            _logger.Error("{@LogDetail}", logDetail);
        }

        public void Fatal(LogDetail logDetail)
        {
            _logger.Fatal("{@LogDetail}", logDetail);
        }
    }
}