namespace MissingFeatures.Tests.DirectoryHelper
{
    using System;
    using System.IO.Abstractions;
    using System.IO.Abstractions.TestingHelpers;
    using System.Linq;
    using System.Reflection;

    using Microsoft.QualityTools.Testing.Fakes.Shims;

    public class MockFileShimBehavior : IShimBehavior
    {
        private readonly MockFile mockFile;

        public MockFileShimBehavior(IMockFileDataAccessor fileDataAccessor)
        {
            this.mockFile = new MockFile(fileDataAccessor);
        }

        public bool TryGetShimMethod(MethodBase method, out Delegate shim)
        {
            if (method is MethodInfo)
            {
                var methodParameterTypes = method.GetParameters().Select(p => p.ParameterType).ToArray();
                var methodInfo = typeof(MockFile).GetMethod(method.Name, methodParameterTypes);

                shim = methodInfo.CreateDelegate(this.mockFile);
                return true;
            }

            // No shim method for constuctors.
            shim = null;
            return false;
        }
    }
}
