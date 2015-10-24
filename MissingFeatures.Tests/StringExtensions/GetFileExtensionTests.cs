namespace MissingFeatures.Tests.StringExtensions
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class GetFileExtensionTests
    {
        [TestMethod]
        public void GetFileExtensionShouldReturnEmptyStringWhenEmptyStringIsPassed()
        {
            var expected = string.Empty;
            var value = string.Empty;
            var actual = value.GetFileExtension();
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void GetFileExtensionShouldReturnEmptyStringWhenNullIsPassed()
        {
            var expected = string.Empty;
            string value = null;

            // ReSharper disable once ExpressionIsAlwaysNull
            var actual = value.GetFileExtension();
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void GetFileExtensionShouldReturnJpgWhenValidImageIsPassed()
        {
            var expected = "jpg";
            var value = "pic.jpg";
            var actual = value.GetFileExtension();
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void GetFileExtensionShouldReturnPpgWhenValidImageWithManyDotsIsPassed()
        {
            var expected = "png";
            var value = "pic.test.value.jpg.png";
            var actual = value.GetFileExtension();
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void GetFileExtensionShouldReturnEmptyStringWhenFileDoesNotHaveExtension()
        {
            var expected = string.Empty;
            var value = "testing";
            var actual = value.GetFileExtension();
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void GetFileExtensionShouldReturnEmptyStringWhenFileEndsInADot()
        {
            var expected = string.Empty;
            var value = "testing.";
            var actual = value.GetFileExtension();
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void GetFileExtensionShouldReturnEmptyStringWhenFileContainsManyDotsAndEndsInADot()
        {
            var expected = string.Empty;
            var value = "testing.jpg.value.gosho.";
            var actual = value.GetFileExtension();
            Assert.AreEqual(expected, actual);
        }
    }
}
