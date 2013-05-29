namespace MissingFeatures.Tests
{
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class DateTimeExtensionsTests
    {
        [TestMethod]
        public void GetMonday_Monday()
        {
            DateTime date = new DateTime(2013, 2, 11, 10, 0, 0);
            DateTime result = date.GetMonday();
            Assert.AreEqual(date.Day, result.Day);
            Assert.AreEqual(date.Month, result.Month);
            Assert.AreEqual(date.Year, result.Year);
        }

        [TestMethod]
        public void GetMonday_Tuesday()
        {
            DateTime date = new DateTime(2013, 2, 12, 10, 0, 0);
            DateTime result = date.GetMonday();
            Assert.AreEqual(11, result.Day);
            Assert.AreEqual(date.Month, result.Month);
            Assert.AreEqual(date.Year, result.Year);
        }

        [TestMethod]
        public void GetMonday_Wednesday()
        {
            DateTime date = new DateTime(2013, 2, 13, 10, 0, 0);
            DateTime result = date.GetMonday();
            Assert.AreEqual(11, result.Day);
            Assert.AreEqual(date.Month, result.Month);
            Assert.AreEqual(date.Year, result.Year);
        }

        [TestMethod]
        public void GetMonday_Thursday()
        {
            DateTime date = new DateTime(2013, 2, 14, 10, 0, 0);
            DateTime result = date.GetMonday();
            Assert.AreEqual(11, result.Day);
            Assert.AreEqual(date.Month, result.Month);
            Assert.AreEqual(date.Year, result.Year);
        }

        [TestMethod]
        public void GetMonday_Friday()
        {
            DateTime date = new DateTime(2013, 2, 15, 10, 0, 0);
            DateTime result = date.GetMonday();
            Assert.AreEqual(11, result.Day);
            Assert.AreEqual(date.Month, result.Month);
            Assert.AreEqual(date.Year, result.Year);
        }

        [TestMethod]
        public void GetMonday_Saturday()
        {
            DateTime date = new DateTime(2013, 2, 16, 10, 0, 0);
            DateTime result = date.GetMonday();
            Assert.AreEqual(11, result.Day);
            Assert.AreEqual(date.Month, result.Month);
            Assert.AreEqual(date.Year, result.Year);
        }

        [TestMethod]
        public void GetMonday_Sunday()
        {
            DateTime date = new DateTime(2013, 2, 17, 10, 0, 0);
            DateTime result = date.GetMonday();
            Assert.AreEqual(11, result.Day);
            Assert.AreEqual(date.Month, result.Month);
            Assert.AreEqual(date.Year, result.Year);
        }

        [TestMethod]
        public void GetMonday_EnsureKeepingHoursMinutesAndSeconds()
        {
            DateTime date = new DateTime(2013, 2, 17, 23, 24, 25);
            DateTime result = date.GetMonday();
            Assert.AreEqual(date.Hour, result.Hour);
            Assert.AreEqual(date.Minute, result.Minute);
            Assert.AreEqual(date.Second, result.Second);
        }
    }
}
