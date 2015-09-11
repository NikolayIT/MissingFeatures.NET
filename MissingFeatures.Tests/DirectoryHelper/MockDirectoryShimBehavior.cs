namespace MissingFeatures.Tests.DirectoryHelper
{
    using System;
    using System.Reflection;

    using Microsoft.QualityTools.Testing.Fakes.Shims;

    public class MockDirectoryShimBehavior : IShimBehavior
    {
        public bool TryGetShimMethod(MethodBase method, out Delegate shim)
        {
            throw new NotImplementedException();
        }
    }
}
