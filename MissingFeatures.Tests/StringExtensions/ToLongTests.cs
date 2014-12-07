namespace MissingFeatures.Tests.StringExtensions
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class ToLongTests
    {
        [TestMethod]
        public void ToLong_ParseInvalidInput_ShouldReturnZero()
        {
            long expected = 0L;
            string input = "invalid";
            long actual = input.ToLong();
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void ToLong_ParseValidInput_ShouldReturnValidLongValue()
        {
            long expected = 999123456789L;
            string input = "999123456789";
            long actual = input.ToLong();
            Assert.AreEqual(expected, actual);
        }
    }
}
