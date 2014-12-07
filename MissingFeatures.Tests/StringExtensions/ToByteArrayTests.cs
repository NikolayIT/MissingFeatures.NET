namespace MissingFeatures.Tests.StringExtensions
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class ToByteArrayTests
    {
        [TestMethod]
        public void ToByteArray_TestEmptyString_ShouldReturnByteArray()
        {
            byte[] expected = new byte[] { };
            string str = string.Empty;
            byte[] actual = str.ToByteArray();
            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void ToByteArray_TestTestString_ShouldReturnByteArray()
        {
            byte[] expected = new byte[] { 84, 0, 101, 0, 115, 0, 116, 0 };
            string str = "Test";
            byte[] actual = str.ToByteArray();
            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void ToByteArray_TestHelloWorldString_ShouldReturnByteArray()
        {
            byte[] expected = new byte[] { 72, 0, 101, 0, 108, 0, 108, 0, 111, 0, 32, 0, 87, 0, 111, 0, 114, 0, 108, 0, 100, 0, 33, 0 };
            string str = "Hello World!";
            byte[] actual = str.ToByteArray();
            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void ToByteArray_TestSpace_ShouldReturnByteArray()
        {
            byte[] expected = new byte[] { 32, 0 };
            string str = " ";
            byte[] actual = str.ToByteArray();
            CollectionAssert.AreEqual(expected, actual);
        }
    }
}