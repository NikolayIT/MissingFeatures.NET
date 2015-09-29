namespace MissingFeatures.Tests.StringExtensions
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class ToBooleanTests
    {
        [TestMethod]
        public void ToBoolean_TestEmptyString_ShouldReturnFalse()
        {
            var str = string.Empty;
            var actual = str.ToBoolean();
            Assert.AreEqual(false, actual);
        }

        [TestMethod]
        public void ToBoolean_TestWrongString_ShouldReturnFalse()
        {
            var str = "WrongString";
            var actual = str.ToBoolean();
            Assert.AreEqual(false, actual);
        }

        [TestMethod]
        public void ToBoolean_TestStringTrue_ShouldReturnTrue()
        {
            var str = "true";
            var actual = str.ToBoolean();
            Assert.AreEqual(true, actual);
        }

        [TestMethod]
        public void ToBoolean_TestStringTrueCapitalLetters_ShouldReturnTrue()
        {
            var str = "TRUE";
            var actual = str.ToBoolean();
            Assert.AreEqual(true, actual);
        }

        [TestMethod]
        public void ToBoolean_TestStringOk_ShouldReturnTrue()
        {
            var str = "ok";
            var actual = str.ToBoolean();
            Assert.AreEqual(true, actual);
        }

        [TestMethod]
        public void ToBoolean_TestStringOkCapitalLetters_ShouldReturnTrue()
        {
            var str = "OK";
            var actual = str.ToBoolean();
            Assert.AreEqual(true, actual);
        }

        [TestMethod]
        public void ToBoolean_TestStringYes_ShouldReturnTrue()
        {
            var str = "yes";
            var actual = str.ToBoolean();
            Assert.AreEqual(true, actual);
        }

        [TestMethod]
        public void ToBoolean_TestStringYesCapitalLetters_ShouldReturnTrue()
        {
            var str = "YES";
            var actual = str.ToBoolean();
            Assert.AreEqual(true, actual);
        }

        [TestMethod]
        public void ToBoolean_TestStringDa_ShouldReturnTrue()
        {
            var str = "да";
            var actual = str.ToBoolean();
            Assert.AreEqual(true, actual);
        }

        [TestMethod]
        public void ToBoolean_TestStringDaCapitalLetters_ShouldReturnTrue()
        {
            var str = "ДА";
            var actual = str.ToBoolean();
            Assert.AreEqual(true, actual);
        }

        [TestMethod]
        public void ToBoolean_TestStringOne_ShouldReturnTrue()
        {
            var str = "1";
            var actual = str.ToBoolean();
            Assert.AreEqual(true, actual);
        }
    }
}
