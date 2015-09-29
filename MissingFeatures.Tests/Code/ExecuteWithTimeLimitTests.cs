namespace MissingFeatures.Tests.Code
{
    using System;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    using Code = MissingFeatures.Code;

    [TestClass]
    public class ExecuteWithTimeLimitTests
    {
        [TestMethod]
        public void EmptyActionShouldReturnTrue()
        {
            var result = Code.ExecuteWithTimeLimit(
                TimeSpan.FromSeconds(1),
                () =>
                    {
                    });

            Assert.IsTrue(result);
        }

        [TestMethod]
        [Timeout(2000)]
        public void TestEndlessLoopShouldNotBlockAndReturnFalse()
        {
            var result = Code.ExecuteWithTimeLimit(
                TimeSpan.FromSeconds(1),
                () =>
                {
                    while (true)
                    {
                    }
                });

            Assert.IsFalse(result);
        }
    }
}
