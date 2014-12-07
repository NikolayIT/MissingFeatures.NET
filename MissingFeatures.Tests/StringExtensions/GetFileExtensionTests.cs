namespace MissingFeatures.Tests.StringExtensions
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class GetFileExtensionTests
    {
        [TestMethod]
        public void GetFileExtension_ShouldReturnEmptyStringWhenEmptyStringIsPassed()
        {
            string expected = string.Empty;
            string value = string.Empty;
            string actual = value.GetFileExtension();
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void GetFileExtension_ShouldReturnEmptyStringWhenNullIsPassed()
        {
            string expected = string.Empty;
            string value = null;
            string actual = value.GetFileExtension();
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void GetFileExtension_ShouldReturnJpgWhenValidImageIsPassed()
        {
            string expected = "jpg";
            string value = "pic.jpg";
            string actual = value.GetFileExtension();
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void GetFileExtension_ShouldReturnPpgWhenValidImageWithManyDotsIsPassed()
        {
            string expected = "png";
            string value = "pic.test.value.jpg.png";
            string actual = value.GetFileExtension();
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void GetFileExtension_ShouldReturnEmptyStringWhenFileDoesNotHaveExtension()
        {
            string expected = string.Empty;
            string value = "testing";
            string actual = value.GetFileExtension();
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void GetFileExtension_ShouldReturnEmptyStringWhenFileEndsInADot()
        {
            string expected = string.Empty;
            string value = "testing.";
            string actual = value.GetFileExtension();
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void GetFileExtension_ShouldReturnEmptyStringWhenFileContainsManyDotsAndEndsInADot()
        {
            string expected = string.Empty;
            string value = "testing.jpg.value.gosho.";
            string actual = value.GetFileExtension();
            Assert.AreEqual(expected, actual);
        }
    }
}
