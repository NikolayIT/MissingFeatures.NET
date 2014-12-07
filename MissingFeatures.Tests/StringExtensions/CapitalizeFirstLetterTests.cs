namespace MissingFeatures.Tests.StringExtensions
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class CapitalizeFirstLetterTests
    {
        [TestMethod]
        public void CapitalizeFirstLetter_ParseEmptyString_ShouldReturnEmptyString()
        {
            string expected = string.Empty;
            string input = string.Empty;
            string actual = input.CapitalizeFirstLetter();
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void CapitalizeFirstLetter_ParseStringWithSmallFirstLetter_ShouldReturnCapitalizedFirstLetter()
        {
            string expected = "FirstCapitalLetter";
            string input = "firstCapitalLetter";
            string actual = input.CapitalizeFirstLetter();
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void CapitalizeFirstLetter_ParseStringBeginWithSpace_ShouldReturnSameString()
        {
            string expected = " testString";
            string input = " testString";
            string actual = input.CapitalizeFirstLetter();
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void CapitalizeFirstLetter_ParseStringBeginWithCapitalLetter_ShouldReturnSameString()
        {
            string expected = "TestString";
            string input = "TestString";
            string actual = input.CapitalizeFirstLetter();
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void CapitalizeFirstLetter_ParseStringBeginWithCyrillicSmallLetter_ShouldReturnCapitalizedFirstLetter()
        {
            string expected = "Академия";
            string input = "академия";
            string actual = input.CapitalizeFirstLetter();
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void CapitalizeFirstLetter_ParseStringBeginWithCyrillicSmallLetter_ShouldReturnSameString()
        {
            string expected = "Академия";
            string input = "Академия";
            string actual = input.CapitalizeFirstLetter();
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void CapitalizeFirstLetter_ParseStringBeginWithSpecialSymbol_ShouldReturnSameString()
        {
            string expected = "@TestString";
            string input = "@TestString";
            string actual = input.CapitalizeFirstLetter();
            Assert.AreEqual(expected, actual);
        }
    }
}
