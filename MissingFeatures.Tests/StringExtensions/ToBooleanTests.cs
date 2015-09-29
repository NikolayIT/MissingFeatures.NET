namespace MissingFeatures.Tests.StringExtensions
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class ToBooleanTests
    {
        [TestMethod]
        public void ToBooleanWithEmptyStringShouldReturnFalse()
        {
            var str = string.Empty;
            var actual = str.ToBoolean();
            Assert.AreEqual(false, actual);
        }

        [TestMethod]
        public void ToBooleanWithWrongStringShouldReturnFalse()
        {
            var str = "WrongString";
            var actual = str.ToBoolean();
            Assert.AreEqual(false, actual);
        }

        [TestMethod]
        public void ToBooleanWithStringTrueShouldReturnTrue()
        {
            var str = "true";
            var actual = str.ToBoolean();
            Assert.AreEqual(true, actual);
        }

        [TestMethod]
        public void ToBooleanWithStringTrueCapitalLettersShouldReturnTrue()
        {
            var str = "TRUE";
            var actual = str.ToBoolean();
            Assert.AreEqual(true, actual);
        }

        [TestMethod]
        public void ToBooleanWithStringOkShouldReturnTrue()
        {
            var str = "ok";
            var actual = str.ToBoolean();
            Assert.AreEqual(true, actual);
        }

        [TestMethod]
        public void ToBooleanWithStringOkCapitalLettersShouldReturnTrue()
        {
            var str = "OK";
            var actual = str.ToBoolean();
            Assert.AreEqual(true, actual);
        }

        [TestMethod]
        public void ToBooleanWithStringYesShouldReturnTrue()
        {
            var str = "yes";
            var actual = str.ToBoolean();
            Assert.AreEqual(true, actual);
        }

        [TestMethod]
        public void ToBooleanWithStringYesCapitalLettersShouldReturnTrue()
        {
            var str = "YES";
            var actual = str.ToBoolean();
            Assert.AreEqual(true, actual);
        }

        [TestMethod]
        public void ToBooleanWithStringDaShouldReturnTrue()
        {
            var str = "да";
            var actual = str.ToBoolean();
            Assert.AreEqual(true, actual);
        }

        [TestMethod]
        public void ToBooleanWithStringDaCapitalLettersShouldReturnTrue()
        {
            var str = "ДА";
            var actual = str.ToBoolean();
            Assert.AreEqual(true, actual);
        }

        [TestMethod]
        public void ToBooleanWithStringOneShouldReturnTrue()
        {
            var str = "1";
            var actual = str.ToBoolean();
            Assert.AreEqual(true, actual);
        }
    }
}
