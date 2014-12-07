namespace MissingFeatures.Tests.StringExtensions
{
    using System;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class ConvertLatinToCyrillicKeyboardTests
    {
        [TestMethod]
        public void ConvertLatinToCyrillicKeyboard_ShouldReturnEmptyStringForEmptyString()
        {
            string expected = string.Empty;
            string value = string.Empty;
            string actual = value.ConvertLatinToCyrillicKeyboard();
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void ConvertLatinToCyrillicKeyboard_ShouldReturnRightForWorkaround()
        {
            string expected = "Воркароунд";
            string value = "Workaround";
            string actual = value.ConvertLatinToCyrillicKeyboard();
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void ConvertLatinToCyrillicKeyboard_ShouldReturnRightForExplorer()
        {
            string expected = "Еьплорер";
            string value = "Explorer";
            string actual = value.ConvertLatinToCyrillicKeyboard();
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void ConvertLatinToCyrillicKeyboard_ShouldReturnRightForZylenvrytqui()
        {
            string expected = "Зъленжрътяуи";
            string value = "Zylenvrytqui";
            string actual = value.ConvertLatinToCyrillicKeyboard();
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void ConvertLatinToCyrillicKeyboard_ShouldReturnRightForWholeAlphabet()
        {
            string expected = "абцдефгхийклмнопярстужвьъз";
            string value = "abcdefghijklmnopqrstuvwxyz";
            string actual = value.ConvertLatinToCyrillicKeyboard();
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void ConvertLatinToCyrillicKeyboard_ShouldReturnRightForWholeCapitalAlphabet()
        {
            string expected = "АБЦДЕФГХИЙКЛМНОПЯРСТУЖВЬЪЗ";
            string value = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            string actual = value.ConvertLatinToCyrillicKeyboard();
            Assert.AreEqual(expected, actual);
        }
    }
}
