namespace MissingFeatures.Tests.StringExtensions
{
    using System;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class ConvertCyrillicToLatinLettersTests
    {
        [TestMethod]
        public void ConvertCyrillicToLatinLetters_ParseEmptyString_ShouldReturnEmptyString()
        {
            string expected = string.Empty;
            string value = string.Empty;
            string actual = value.ConvertCyrillicToLatinLetters();
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void ConvertCyrillicToLatinLetters_ParseCyrillicWokaround_ShouldReturnRightWorkaround()
        {
            string expected = "ShtURKELUT";
            string value = "ЩЪРКЕЛЪТ";
            string actual = value.ConvertCyrillicToLatinLetters();
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void ConvertCyrillicToLatinLetters_ParseCyrillicExplorer_ShouldReturnRightExplorer()
        {
            string expected = "Lyulyak";
            string value = "Люляк";
            string actual = value.ConvertCyrillicToLatinLetters();
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void ConvertCyrillicToLatinLetters_ParseCyrillicAlphabet_ShouldReturnRightAlphabet()
        {
            string expected = "abvgdejziyklmnoprstufhcchshshtuiyuya";
            string value = "абвгдежзийклмнопрстуфхцчшщъьюя";
            string actual = value.ConvertCyrillicToLatinLetters();
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void ConvertCyrillicToLatinLetters_ParseCyrillicAlphabetCapitalLetters_ShouldReturnRightAlphabetCapitalLetters()
        {
            string expected = "ABVGDEJZIYKLMNOPRSTUFHCChShShtUIYuYa";
            string value = "АБВГДЕЖЗИЙКЛМНОПРСТУФХЦЧШЩЪЬЮЯ";
            string actual = value.ConvertCyrillicToLatinLetters();
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void ConvertCyrillicToLatinLetters_ParseTwoAlphabetCapitalLetters_ShouldReturnRightTwoAlphabetCapitalLetters()
        {
            string expected = "ABVGDEJZIYKLMNOPRSTUFHCChShShtUIYuYaABCDEFGHIJKLMNOPQRSTUVWXYZ";
            string value = "АБВГДЕЖЗИЙКЛМНОПРСТУФХЦЧШЩЪЬЮЯABCDEFGHIJKLMNOPQRSTUVWXYZ";
            string actual = value.ConvertCyrillicToLatinLetters();
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void ConvertCyrillicToLatinLetters_ParseTwoAlphabetSmallLetters_ShouldReturnRightTwoAlphabetSmallLetters()
        {
            string expected = "abvgdejziyklmnoprstufhcchshshtuiyuyaabcdefghijklmnopqrstuvwxyz";
            string value = "абвгдежзийклмнопрстуфхцчшщъьюяabcdefghijklmnopqrstuvwxyz";
            string actual = value.ConvertCyrillicToLatinLetters();
            Assert.AreEqual(expected, actual);
        }
    }
}
