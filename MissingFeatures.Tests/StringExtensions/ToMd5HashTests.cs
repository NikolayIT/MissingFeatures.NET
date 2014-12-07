namespace MissingFeatures.Tests.StringExtensions
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class ToMd5HashTests
    {
        [TestMethod]
        public void ToMd5Hash_TestEmptyString_ShouldReturnMd5Hash()
        {
            string expected = "d41d8cd98f00b204e9800998ecf8427e";
            string input = string.Empty;
            string actual = input.ToMd5Hash();
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void ToMd5Hash_TestHelloWord_ShouldReturnMd5Hash()
        {
            string expected = "ed076287532e86365e841e92bfc50d8c";
            string input = "Hello World!";
            string actual = input.ToMd5Hash();
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void ToMd5Hash_TestLongSTring_ShouldReturnMd5Hash()
        {
            string expected = "22c4e07f945f4f6841d1e582b094878b";
            string input = "АБВГДЕЖЗИЙКЛМНОПРСТУФХЦЧШЩЪЬЮЯABCDEFGHIJKLMNOPQRSTUVWXYZ";
            string actual = input.ToMd5Hash();
            Assert.AreEqual(expected, actual);
        }
    }
}