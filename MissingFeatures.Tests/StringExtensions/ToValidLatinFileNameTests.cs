namespace MissingFeatures.Tests.StringExtensions
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class ToValidLatinFileNameTests
    {
        [TestMethod]
        public void ToValidLatinFileName_TransformEmptyName_ShouldReturnEmptyName()
        {
            string expected = string.Empty;
            string str = string.Empty;
            string actual = str.ToValidLatinFileName();
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void ToValidLatinFileName_TransformCorectName_ShouldReturnSameName()
        {
            string expected = "FileName.ext";
            string str = "FileName.ext";
            string actual = str.ToValidLatinFileName();
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void ToValidLatinFileName_TransformNameWithLowLine_ShouldReturnCorrectName()
        {
            string expected = "File_Name.ext";
            string str = "File_Name.ext";
            string actual = str.ToValidLatinFileName();
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void ToValidLatinFileName_TransformNameWithOneSpace_ShouldReturnCorrectName()
        {
            string expected = "File-Name.ext";
            string str = "File Name.ext";
            string actual = str.ToValidLatinFileName();
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void ToValidLatinFileName_TransformNameWithTwoSpaces_ShouldReturnCorrectName()
        {
            string expected = "File--Name.ext";
            string str = "File  Name.ext";
            string actual = str.ToValidLatinFileName();
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void ToValidLatinFileName_TransformNameWithNumberSign_ShouldReturnCorrectName()
        {
            string expected = "FileName.ext";
            string str = "File#Name.ext";
            string actual = str.ToValidLatinFileName();
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void ToValidLatinFileName_TransformNameWithAtSign_ShouldReturnCorrectName()
        {
            string expected = "FileName.ext";
            string str = "File@Name.ext";
            string actual = str.ToValidLatinFileName();
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void ToValidLatinFileName_TransformCirillicName_ShouldReturnCorrectName()
        {
            string expected = "FileName.doc";
            string str = "ФилеНаме.доц";
            string actual = str.ToValidLatinFileName();
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void ToValidLatinFileName_TransformCirillicAndLatinName_ShouldReturnCorrectName()
        {
            string expected = "FileName.doc";
            string str = "ФилеName.доц";
            string actual = str.ToValidLatinFileName();
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void ToValidLatinFileName_TransformCirillicAndLatinNameAndTwoDots_ShouldReturnCorrectName()
        {
            string expected = "File.Name.doc";
            string str = "Филе.Name.доц";
            string actual = str.ToValidLatinFileName();
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void ToValidLatinFileName_TransformCirillicAndLatinNameAndAtSignsAndNumberSign_ShouldReturnCorrectName()
        {
            string expected = "FileName.doc";
            string str = "Филе@Name@.доц#";
            string actual = str.ToValidLatinFileName();
            Assert.AreEqual(expected, actual);
        }
    }
}
