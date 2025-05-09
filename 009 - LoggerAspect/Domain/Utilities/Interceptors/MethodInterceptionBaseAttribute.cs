using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Castle.DynamicProxy;

namespace Domain.Utilities.Interceptors
{
    [AttributeUsage(AttributeTargets.Class|AttributeTargets.Method,AllowMultiple = true,Inherited = true)]
    public abstract class MethodInterceptionBaseAttribute : Attribute,IInterceptor
    {
        public int Priority { get; set; }

        public virtual void Intercept(IInvocation invocation)
        {
            
        }
    }
}