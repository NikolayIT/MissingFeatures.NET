namespace MissingFeatures.Tests.StringExtensions
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class ConvertCyrillicToLatinLettersTests
    {
        [TestMethod]
        public void ConvertCyrillicToLatinLettersParseEmptyStringShouldReturnEmptyString()
        {
            var expected = string.Empty;
            var value = string.Empty;
            var actual = value.ConvertCyrillicToLatinLetters();
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void ConvertCyrillicToLatinLettersParseCyrillicWokaroundShouldReturnRightWorkaround()
        {
            var expected = "ShtURKELUT";
            var value = "ЩЪРКЕЛЪТ";
            var actual = value.ConvertCyrillicToLatinLetters();
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void ConvertCyrillicToLatinLettersParseCyrillicExplorerShouldReturnRightExplorer()
        {
            var expected = "Lyulyak";
            var value = "Люляк";
            var actual = value.ConvertCyrillicToLatinLetters();
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void ConvertCyrillicToLatinLettersParseCyrillicAlphabetShouldReturnRightAlphabet()
        {
            var expected = "abvgdejziyklmnoprstufhcchshshtuiyuya";
            var value = "абвгдежзийклмнопрстуфхцчшщъьюя";
            var actual = value.ConvertCyrillicToLatinLetters();
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void ConvertCyrillicToLatinLettersParseCyrillicAlphabetCapitalLettersShouldReturnRightAlphabetCapitalLetters()
        {
            var expected = "ABVGDEJZIYKLMNOPRSTUFHCChShShtUIYuYa";
            var value = "АБВГДЕЖЗИЙКЛМНОПРСТУФХЦЧШЩЪЬЮЯ";
            var actual = value.ConvertCyrillicToLatinLetters();
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void ConvertCyrillicToLatinLettersParseTwoAlphabetCapitalLettersShouldReturnRightTwoAlphabetCapitalLetters()
        {
            var expected = "ABVGDEJZIYKLMNOPRSTUFHCChShShtUIYuYaABCDEFGHIJKLMNOPQRSTUVWXYZ";
            var value = "АБВГДЕЖЗИЙКЛМНОПРСТУФХЦЧШЩЪЬЮЯABCDEFGHIJKLMNOPQRSTUVWXYZ";
            var actual = value.ConvertCyrillicToLatinLetters();
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void ConvertCyrillicToLatinLettersParseTwoAlphabetSmallLettersShouldReturnRightTwoAlphabetSmallLetters()
        {
            var expected = "abvgdejziyklmnoprstufhcchshshtuiyuyaabcdefghijklmnopqrstuvwxyz";
            var value = "абвгдежзийклмнопрстуфхцчшщъьюяabcdefghijklmnopqrstuvwxyz";
            var actual = value.ConvertCyrillicToLatinLetters();
            Assert.AreEqual(expected, actual);
        }
    }
}
