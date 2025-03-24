using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Castle.DynamicProxy;

namespace Domain.Utilities.Interceptors
{
    public class AspectInterceptorSelector : IInterceptorSelector
    {
        public IInterceptor[] SelectInterceptors(Type type, MethodInfo method, IInterceptor[] interceptors)
        {
            var classAttributes = type.GetCustomAttributes<MethodInterceptionBaseAttribute>(true).ToList();
            var methodInfo = type.GetMethod(method.Name);
            var methodAttributes = methodInfo != null 
                ? methodInfo.GetCustomAttributes<MethodInterceptionBaseAttribute>(true) 
                : Enumerable.Empty<MethodInterceptionBaseAttribute>();
            classAttributes.AddRange(methodAttributes);

            return (IInterceptor[])classAttributes.OrderBy(x => x.Priority).ToArray();
        }
    }
}