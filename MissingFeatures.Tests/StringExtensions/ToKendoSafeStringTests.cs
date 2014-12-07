namespace MissingFeatures.Tests.StringExtensions
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class ToKendoSafeStringTests
    {
        [TestMethod]
        public void ToKendoSafeString_TestNumberSign_ShouldReturnSlashSlashNumberSign()
        {
            string expected = @"\\#";
            string str = "#";
            string actual = str.ToKendoSafeString();
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void ToKendoSafeString_TestNumberSignInBegin_ShouldReturnSlashSlashNumberSign()
        {
            string expected = @"\\#TestString";
            string str = "#TestString";
            string actual = str.ToKendoSafeString();
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void ToKendoSafeString_TestNumberSignInTheMiddle_ShouldReturnSlashSlashNumberSign()
        {
            string expected = @"TestString\\#TestString";
            string str = "TestString#TestString";
            string actual = str.ToKendoSafeString();
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void ToKendoSafeString_TestNumberSignInTheEnd_ShouldReturnSlashSlashNumberSign()
        {
            string expected = @"TestString\\#";
            string str = "TestString#";
            string actual = str.ToKendoSafeString();
            Assert.AreEqual(expected, actual);
        }
    }
}