namespace MissingFeatures.Tests.StringExtensions
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class GetStringBetweenTests
    {
        [TestMethod]
        public void GetStringBetween_ParseWithStartStringAndEndString_ShouldReturnBetweenString()
        {
            string expected = "Between";
            string str = "123startBetweenEnd4567"; // start End
            string startString = "start";
            string endString = "End";
            int startFrom = 0;
            string actual = str.GetStringBetween(startString, endString, startFrom);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void GetStringBetween_ParseWithStartStringAndEndStringAndStartFrom_ShouldReturnBetweenString()
        {
            string expected = "Between";
            string str = "123startBetweenEnd4567"; // 123startBetweenEnd4567
            string startString = "start";
            string endString = "End";
            int startFrom = 2;
            string actual = str.GetStringBetween(startString, endString, startFrom);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void GetStringBetween_ParseWithStartAndEndStringAndBadStartFrom_ShouldReturnEmptyString()
        {
            string expected = string.Empty;
            string str = "123startBetweenEnd4567";
            string startString = "start";
            string endString = "End";
            int startFrom = 5; // start from 5
            string actual = str.GetStringBetween(startString, endString, startFrom);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void GetStringBetween_ParseWithoutStartString_ShouldReturnEmptyString()
        {
            string expected = string.Empty;
            string str = "123starrBetweenEnd4567"; // starr
            string startString = "start";
            string endString = "End";
            int startFrom = 0;
            string actual = str.GetStringBetween(startString, endString, startFrom);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void GetStringBetween_ParseWithoutEndString_ShouldReturnEmptyString()
        {
            string expected = string.Empty;
            string str = "123startBetweenEnt4567"; // Ent
            string startString = "start";
            string endString = "End";
            int startFrom = 0;
            string actual = str.GetStringBetween(startString, endString, startFrom);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void GetStringBetween_ParseWithoutStartStringAndWithoutEndString_ShouldReturnEmptyString()
        {
            string expected = string.Empty;
            string str = "123starrBetweenEnt4567"; // starr Ent
            string startString = "start";
            string endString = "End";
            int startFrom = 0;
            string actual = str.GetStringBetween(startString, endString, startFrom);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void GetStringBetween_ParseWhenEndStringIsPartOfStartString_ShouldReturnBetweenString()
        {
            string expected = "Between";
            string str = "123startBetweenart4567"; // start art
            string startString = "start";
            string endString = "art";
            int startFrom = 0;
            string actual = str.GetStringBetween(startString, endString, startFrom);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void GetStringBetween_ParseWhenEndStringFollowStartString_ShouldReturnEmptyString()
        {
            string expected = string.Empty;
            string str = "startEnd"; // startEnd
            string startString = "start";
            string endString = "End";
            int startFrom = 0;
            string actual = str.GetStringBetween(startString, endString, startFrom);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void GetStringBetween_ParseWhenEndStringIsPartOfStartStringAndWithoutBetweenString1_ShouldReturnEmptyString()
        {
            string expected = string.Empty;
            string str = "start"; // start
            string startString = "start";
            string endString = "art";
            int startFrom = 0;
            string actual = str.GetStringBetween(startString, endString, startFrom);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void GetStringBetween_ParseWhenEndStringIsPartOfStartStringAndWithoutBetweenString2_ShouldReturnEmptyString()
        {
            string expected = string.Empty;
            string str = "startart"; // startart
            string startString = "start";
            string endString = "art";
            int startFrom = 0;
            string actual = str.GetStringBetween(startString, endString, startFrom);
            Assert.AreEqual(expected, actual);
        }
    }
}
