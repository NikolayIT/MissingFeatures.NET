namespace MissingFeatures.Tests.DirectoryHelper.ShimBehaviors
{
    using System;
    using System.IO.Abstractions;
    using System.IO.Abstractions.TestingHelpers;
    using System.Linq;
    using System.Reflection;

    using Microsoft.QualityTools.Testing.Fakes.Shims;

    public class MockDirectoryShimBehavior : IShimBehavior
    {
        private readonly MockDirectory mockDirectory;

        public MockDirectoryShimBehavior(IMockFileDataAccessor fileDataAccessor, FileBase fileBase, string currentDirectory)
        {
            this.mockDirectory = new MockDirectory(fileDataAccessor, fileBase, currentDirectory);
        }

        public bool TryGetShimMethod(MethodBase method, out Delegate shim)
        {
            // TODO: think what happens when a static method is called
            if (method is MethodInfo)
            {
                var methodParameterTypes = method.GetParameters().Select(p => p.ParameterType).ToArray();
                var methodInfo = typeof(MockDirectory).GetMethod(method.Name, methodParameterTypes);

                shim = methodInfo.CreateDelegate(this.mockDirectory);
                return true;
            }

            // No shim method for constuctors.
            shim = null;
            return false;
        }
    }
}
