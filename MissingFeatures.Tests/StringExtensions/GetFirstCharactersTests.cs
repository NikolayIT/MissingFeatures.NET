namespace MissingFeatures.Tests.StringExtensions
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class GetFirstCharactersTests
    {
        [TestMethod]
        public void GetFirstCharacters_InputEmptyString_ShouldReturnEmptyString()
        {
            string expected = string.Empty;
            string str = string.Empty;
            int charsCount = 1;
            string actual = str.GetFirstCharacters(charsCount);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void GetFirstCharacters_GetZeroSymbols_ShouldReturnEmptyString()
        {
            string expected = string.Empty;
            string str = "testedString";
            int charsCount = 0;
            string actual = str.GetFirstCharacters(charsCount);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void GetFirstCharacters_GetOneSymbol_ShouldReturnOneSymbol()
        {
            string expected = "1";
            string str = "123testedString";
            int charsCount = 1;
            string actual = str.GetFirstCharacters(charsCount);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void GetFirstCharacters_GetThreeSymbols_ShouldReturnThreeSymbols()
        {
            string expected = "123";
            string str = "123testedString";
            int charsCount = 3; // 3
            string actual = str.GetFirstCharacters(charsCount);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void GetFirstCharacters_GetSymbolsEqualToLenght_ShouldReturnInputString()
        {
            string expected = "1234567890";
            string str = "1234567890";
            int charsCount = 10;
            string actual = str.GetFirstCharacters(charsCount);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void GetFirstCharacters_GetSymbolsMoreThanLenght_ShouldReturnInputString()
        {
            string expected = "1234567890";
            string str = "1234567890";
            int charsCount = 15;
            string actual = str.GetFirstCharacters(charsCount);
            Assert.AreEqual(expected, actual);
        }
    }
}
