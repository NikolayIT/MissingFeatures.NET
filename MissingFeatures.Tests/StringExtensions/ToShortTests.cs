namespace MissingFeatures.Tests.StringExtensions
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class ToShortTests
    {
        [TestMethod]
        public void ToShort_TestZero_ShouldReturnZero()
        {
            short expected = 0;
            string str = "0";
            short actual = str.ToShort();
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void ToShort_TestInvalidInput_ShouldReturnZero()
        {
            short expected = 0;
            string str = "invalid";
            short actual = str.ToShort();
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void ToShort_TestValidInput_ShouldReturnSameValue()
        {
            short expected = 1234;
            string str = "1234";
            short actual = str.ToShort();
            Assert.AreEqual(expected, actual);
        }
    }
}