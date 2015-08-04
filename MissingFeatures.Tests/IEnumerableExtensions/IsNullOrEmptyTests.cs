namespace MissingFeatures.Tests.IEnumerableExtensions
{
    using System.Collections.Generic;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class IsNullOrEmptyTests
    {
        [TestMethod]
        public void TestNullSource_ShouldReturnTrue()
        {
            IEnumerable<int> source = null;

            var result = source.IsNullOrEmpty();

            Assert.IsTrue(result);
        }

        [TestMethod]
        public void TestEmptySource_ShouldReturnTrue()
        {
            IEnumerable<int> source = new int[0];

            var result = source.IsNullOrEmpty();

            Assert.IsTrue(result);
        }

        [TestMethod]
        public void TestSourceWithOneItem_ShouldReturnFalse()
        {
            IEnumerable<int> source = new[] { 1 };

            var result = source.IsNullOrEmpty();

            Assert.IsFalse(result);
        }

        [TestMethod]
        public void TestSourceWithMultipleItems_ShouldReturnFalse()
        {
            IEnumerable<int> source = new[] { 1, 2, 3, 4, 5 };

            var result = source.IsNullOrEmpty();

            Assert.IsFalse(result);
        }
    }
}
