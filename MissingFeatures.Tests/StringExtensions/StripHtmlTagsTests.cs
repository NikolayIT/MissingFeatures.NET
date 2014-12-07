namespace MissingFeatures.Tests.StringExtensions
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    public class StripHtmlTagsTests
    {
        [TestMethod]
        public void StrippingHtmlTags_TestEmptyString_ShouldReturnEmptyString()
        {
            string expected = string.Empty;
            string str = string.Empty;
            string actual = str.StripHtmlTags();
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void StrippingHtmlTags_TestHtmlString_ShouldReturnTestString()
        {
            string expected = "Test";
            string str = @"<head></head><html><body><div>Test</div></body></html>";
            string actual = str.StripHtmlTags();
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void StrippingHtmlTags_TestHtmlString_ShouldReturnEmptyString()
        {
            string expected = string.Empty;
            string str = @"<head></head><html><body><div></div></body></html>";
            string actual = str.StripHtmlTags();
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void StrippingHtmlTags_TestInvalidHtmlString_ShouldReturnEmptyString()
        {
            string expected = "Test";
            string str = @"<head></head><html><body>Test</div></body></html>";
            string actual = str.StripHtmlTags();
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void StrippingHtmlTags_TestHtmlString_ShouldReturnHtmlString()
        {
            string expected = "Html";
            string str = @"<head></head><html><body>Html</body></html>";
            string actual = str.StripHtmlTags();
            Assert.AreEqual(expected, actual);
        }
    }
}