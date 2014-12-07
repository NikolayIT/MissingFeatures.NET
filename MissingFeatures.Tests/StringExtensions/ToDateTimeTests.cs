namespace MissingFeatures.Tests.StringExtensions
{
    using System;
    using System.Globalization;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    public class ToDateTimeTests
    {
        [TestMethod]
        public void ToDateTime_TestInvalidValidInput_ShouldReturnFirstDateTime()
        {
            DateTime expected = new DateTime(1, 1, 1, 0, 0, 0);
            string str = "invalid";
            DateTime actual = str.ToDateTime();
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void ToDateTime_TestValidFullDateTime_ShouldReturnCorrectDateTime()
        {
            DateTime expected = new DateTime(1988, 7, 6, 5, 4, 3);
            string str = "July 6, 1988 5:04:03";
            DateTime actual = str.ToDateTime();
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void ToDateTime_TestValidShortDate_ShouldReturnCorrectDate()
        {
            DateTime expected = new DateTime(1988, 7, 6, new GregorianCalendar());
            string str = "July 6, 1988";
            DateTime actual = str.ToDateTime();
            Assert.AreEqual(expected, actual);
        }
    }
}