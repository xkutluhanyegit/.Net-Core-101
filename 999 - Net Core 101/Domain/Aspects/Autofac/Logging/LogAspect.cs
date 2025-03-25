using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Castle.DynamicProxy;
using Domain.CrossCutting.Logging;
using Domain.Utilities.Interceptors;

namespace Domain.Aspects.Autofac.Logging
{
    public class LogAspect : MethodInterception
    {
        private readonly ILoggerService _loggerService;
        private readonly LogLevel _logLevel;

        public LogAspect(Type loggerServiceType, LogLevel logLevel)
        {
            _loggerService = (ILoggerService)Activator.CreateInstance(loggerServiceType);
            _logLevel = logLevel;
        }

        protected override void OnAfter(IInvocation invocation)
        {
            var logDetail = GetLogDetail(invocation);

            switch (_logLevel)
            {
                case LogLevel.Info:
                    _loggerService.Info(logDetail);
                    break;
                case LogLevel.Debug:
                    _loggerService.Debug(logDetail);
                    break;
                case LogLevel.Warning:
                    _loggerService.Warn(logDetail);
                    break;
                case LogLevel.Error:
                    _loggerService.Error(logDetail);
                    break;
                case LogLevel.Fatal:
                    _loggerService.Fatal(logDetail);
                    break;
                default:
                    _loggerService.Debug(logDetail);
                    break;
            }
        }

        protected override void OnBefore(IInvocation invocation)
        {
            var logDetail = GetLogDetail(invocation);

            switch (_logLevel)
            {
                case LogLevel.Info:
                    _loggerService.Info(logDetail);
                    break;
                case LogLevel.Debug:
                    _loggerService.Debug(logDetail);
                    break;
                case LogLevel.Warning:
                    _loggerService.Warn(logDetail);
                    break;
                case LogLevel.Error:
                    _loggerService.Error(logDetail);
                    break;
                case LogLevel.Fatal:
                    _loggerService.Fatal(logDetail);
                    break;
                default:
                    _loggerService.Debug(logDetail);
                    break;
            }
        }


        protected override void OnException(IInvocation invocation, Exception e)
        {
            var logDetail = GetLogDetail(invocation);
            switch (_logLevel)
            {
                case LogLevel.Info:
                    _loggerService.Info(logDetail);
                    break;
                case LogLevel.Debug:
                    _loggerService.Debug(logDetail);
                    break;
                case LogLevel.Warning:
                    _loggerService.Warn(logDetail);
                    break;
                case LogLevel.Error:
                    _loggerService.Error(logDetail);
                    break;
                case LogLevel.Fatal:
                    _loggerService.Fatal(logDetail);
                    break;
                default:
                    _loggerService.Debug(logDetail);
                    break;
            }

            
        }

        

            LogDetail GetLogDetail(IInvocation invocation)
            {
                var logParameters = invocation.Arguments.Select((arg, index) => new LogParameter
                {
                    Name = invocation.GetConcreteMethod().GetParameters()[index].Name,
                    Value = arg,
                    Type = arg.GetType().Name
                }).ToList();

                return new LogDetail
                {
                    MethodName = invocation.Method.Name,
                    ClassName = invocation.Method.DeclaringType?.Name,
                    Parameters = logParameters,
                    LogDate = DateTime.UtcNow,
                    User = "System" // Bu kısım JWT veya başka bir auth mekanizması ile doldurulabilir
                };
            }

            
    }
}