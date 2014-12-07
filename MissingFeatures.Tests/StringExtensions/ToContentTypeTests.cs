namespace MissingFeatures.Tests.StringExtensions
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    public class ToContentTypeTests
    {
        [TestMethod]
        public void ToContentType_TestEmptyString_ShouldReturnOctetStream()
        {
            string expected = "application/octet-stream";
            string fileExtension = string.Empty;
            string actual = fileExtension.ToContentType();
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void ToContentType_TestInvalidString_ShouldReturnOctedStream()
        {
            string expected = "application/octet-stream";
            string fileExtension = "invalid";
            string actual = fileExtension.ToContentType();
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void ToContentType_TestJpg_ShouldReturnImageJpeg()
        {
            string expected = "image/jpeg";
            string fileExtension = "jpg";
            string actual = fileExtension.ToContentType();
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void ToContentType_TestJpgAndSpaces_ShouldReturnImageJpeg()
        {
            string expected = "image/jpeg";
            string fileExtension = " jpg  ";
            string actual = fileExtension.ToContentType();
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void ToContentType_TestJpegAndSpaces_ShouldReturnImageJpeg()
        {
            string expected = "image/jpeg";
            string fileExtension = "jpeg";
            string actual = fileExtension.ToContentType();
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void ToContentType_TestPng_ShouldReturnImageXpng()
        {
            string expected = "image/x-png";
            string fileExtension = "png";
            string actual = fileExtension.ToContentType();
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void ToContentType_TestDocx_ShouldReturnOffice()
        {
            string expected = "application/vnd.openxmlformats-officedocument.wordprocessingml.document";
            string fileExtension = "docx";
            string actual = fileExtension.ToContentType();
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void ToContentType_TestDoc_ShouldReturnApplicationDoc()
        {
            string expected = "application/msword";
            string fileExtension = "doc";
            string actual = fileExtension.ToContentType();
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void ToContentType_TestPdf_ShouldReturnApplicationPdf()
        {
            string expected = "application/pdf";
            string fileExtension = "pdf";
            string actual = fileExtension.ToContentType();
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void ToContentType_TestTxt_ShouldReturnApplicationTxt()
        {
            string expected = "text/plain";
            string fileExtension = "txt";
            string actual = fileExtension.ToContentType();
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void ToContentType_TestRtf_ShouldReturnApplicationRtf()
        {
            string expected = "application/rtf";
            string fileExtension = "rtf";
            string actual = fileExtension.ToContentType();
            Assert.AreEqual(expected, actual);
        }
    }
}