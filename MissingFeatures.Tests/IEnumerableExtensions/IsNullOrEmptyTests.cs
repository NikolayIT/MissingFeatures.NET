namespace MissingFeatures.Tests.IEnumerableExtensions
{
    using System.Collections.Generic;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class IsNullOrEmptyTests
    {
        [TestMethod]
        public void TestNullSourceShouldReturnTrue()
        {
            IEnumerable<int> source = null;

            // ReSharper disable once ExpressionIsAlwaysNull
            var result = source.IsNullOrEmpty();

            Assert.IsTrue(result);
        }

        [TestMethod]
        public void TestEmptySourceShouldReturnTrue()
        {
            IEnumerable<int> source = new int[0];

            var result = source.IsNullOrEmpty();

            Assert.IsTrue(result);
        }

        [TestMethod]
        public void TestSourceWithOneItemShouldReturnFalse()
        {
            IEnumerable<int> source = new[] { 1 };

            var result = source.IsNullOrEmpty();

            Assert.IsFalse(result);
        }

        [TestMethod]
        public void TestSourceWithMultipleItemsShouldReturnFalse()
        {
            IEnumerable<int> source = new[] { 1, 2, 3, 4, 5 };

            var result = source.IsNullOrEmpty();

            Assert.IsFalse(result);
        }
    }
}
