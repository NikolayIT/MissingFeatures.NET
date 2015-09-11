namespace MissingFeatures
{
    using System;
    using System.Linq;
    using System.Linq.Expressions;
    using System.Reflection;

    public static class MethodInfoExtensions
    {
        public static Delegate CreateDelegate(this MethodInfo methodInfo, object target = null)
        {
            if (methodInfo == null)
            {
                throw new ArgumentNullException(nameof(methodInfo));
            }

            var delegateTypeArgs = methodInfo
                .GetParameters()
                .Select(p => p.ParameterType)
                .Concat(new[] { methodInfo.ReturnType })
                .ToArray();

            var delegateType = Expression.GetDelegateType(delegateTypeArgs);

            var @delegate = Delegate.CreateDelegate(delegateType, target, methodInfo);
            return @delegate;
        }
    }
}