namespace MissingFeatures.Tests.StringExtensions
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class ConvertLatinToCyrillicKeyboardTests
    {
        [TestMethod]
        public void ConvertLatinToCyrillicKeyboardShouldReturnEmptyStringForEmptyString()
        {
            var expected = string.Empty;
            var value = string.Empty;
            var actual = value.ConvertLatinToCyrillicKeyboard();
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void ConvertLatinToCyrillicKeyboardShouldReturnRightForWorkaround()
        {
            var expected = "Воркароунд";
            var value = "Workaround";
            var actual = value.ConvertLatinToCyrillicKeyboard();
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void ConvertLatinToCyrillicKeyboardShouldReturnRightForExplorer()
        {
            var expected = "Еьплорер";
            var value = "Explorer";
            var actual = value.ConvertLatinToCyrillicKeyboard();
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void ConvertLatinToCyrillicKeyboardShouldReturnRightForZylenvrytqui()
        {
            var expected = "Зъленжрътяуи";
            var value = "Zylenvrytqui";
            var actual = value.ConvertLatinToCyrillicKeyboard();
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void ConvertLatinToCyrillicKeyboardShouldReturnRightForWholeAlphabet()
        {
            var expected = "абцдефгхийклмнопярстужвьъз";
            var value = "abcdefghijklmnopqrstuvwxyz";
            var actual = value.ConvertLatinToCyrillicKeyboard();
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void ConvertLatinToCyrillicKeyboardShouldReturnRightForWholeCapitalAlphabet()
        {
            var expected = "АБЦДЕФГХИЙКЛМНОПЯРСТУЖВЬЪЗ";
            var value = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            var actual = value.ConvertLatinToCyrillicKeyboard();
            Assert.AreEqual(expected, actual);
        }
    }
}
