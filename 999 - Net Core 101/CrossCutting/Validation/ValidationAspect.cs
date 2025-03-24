using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Castle.DynamicProxy;
using FluentValidation;
using FluentValidation.Results;

namespace CrossCutting.Validation
{
    public class ValidationAspect : IInterceptor
    {
        private readonly Type _validatorType;

        public ValidationAspect(Type validatorType)
        {
            if (!typeof(IValidator).IsAssignableFrom(validatorType))
            {
                throw new ArgumentException("This is not a validation class", nameof(validatorType));
            }

            _validatorType = validatorType;
        }

        public void Intercept(IInvocation invocation)
        {
            var validator = (IValidator)Activator.CreateInstance(_validatorType);
            var entityType = _validatorType.BaseType.GetGenericArguments()[0];
            var entities = invocation.Arguments.Where(arg => arg != null && arg.GetType() == entityType);

            foreach (var entity in entities)
            {
                ValidationContext<object> context = new ValidationContext<object>(entity);
                ValidationResult result = validator.Validate(context);
                if (!result.IsValid)
                {
                    throw new ValidationException(result.Errors);
                }
            }

            invocation.Proceed();
        }
    }
}