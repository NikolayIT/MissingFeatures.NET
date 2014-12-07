namespace MissingFeatures.Tests.StringExtensions
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class ToIntegerTests
    {
        [TestMethod]
        public void ToInteger_TestZero_ShouldReturnZero()
        {
            int expected = 0;
            string str = "0";
            int actual = str.ToInteger();
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void ToInteger_TestInvalidInput_ShouldReturnZero()
        {
            int expected = 0;
            string str = "invalid";
            int actual = str.ToInteger();
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void ToInteger_TestValidInput_ShouldReturnSameValue()
        {
            int expected = 1234567890;
            string str = "1234567890";
            int actual = str.ToInteger();
            Assert.AreEqual(expected, actual);
        }
    }
}