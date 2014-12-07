namespace MissingFeatures.Tests.StringExtensions
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class ToBooleanTests
    {
        [TestMethod]
        public void ToBoolean_TestEmptyString_ShouldReturnFalse()
        {
            bool expected = false;
            string str = string.Empty;
            bool actual = str.ToBoolean();
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void ToBoolean_TestWrongString_ShouldReturnFalse()
        {
            bool expected = false;
            string str = "WrongString";
            bool actual = str.ToBoolean();
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void ToBoolean_TestStringTrue_ShouldReturnTrue()
        {
            bool expected = true;
            string str = "true";
            bool actual = str.ToBoolean();
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void ToBoolean_TestStringTrueCapitalLetters_ShouldReturnTrue()
        {
            bool expected = true;
            string str = "TRUE";
            bool actual = str.ToBoolean();
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void ToBoolean_TestStringOk_ShouldReturnTrue()
        {
            bool expected = true;
            string str = "ok";
            bool actual = str.ToBoolean();
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void ToBoolean_TestStringOkCapitalLetters_ShouldReturnTrue()
        {
            bool expected = true;
            string str = "OK";
            bool actual = str.ToBoolean();
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void ToBoolean_TestStringYes_ShouldReturnTrue()
        {
            bool expected = true;
            string str = "yes";
            bool actual = str.ToBoolean();
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void ToBoolean_TestStringYesCapitalLetters_ShouldReturnTrue()
        {
            bool expected = true;
            string str = "YES";
            bool actual = str.ToBoolean();
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void ToBoolean_TestStringDa_ShouldReturnTrue()
        {
            bool expected = true;
            string str = "да";
            bool actual = str.ToBoolean();
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void ToBoolean_TestStringDaCapitalLetters_ShouldReturnTrue()
        {
            bool expected = true;
            string str = "ДА";
            bool actual = str.ToBoolean();
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void ToBoolean_TestStringOne_ShouldReturnTrue()
        {
            bool expected = true;
            string str = "1";
            bool actual = str.ToBoolean();
            Assert.AreEqual(expected, actual);
        }
    }
}
