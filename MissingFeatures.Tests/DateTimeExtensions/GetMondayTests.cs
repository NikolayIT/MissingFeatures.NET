namespace MissingFeatures.Tests.DateTimeExtensions
{
    using System;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class GetMondayTests
    {
        [TestMethod]
        public void GetMondayWhereDayOfWeekIsMonday()
        {
            var date = new DateTime(2013, 2, 11, 10, 0, 0);
            var result = date.GetMonday();
            Assert.AreEqual(date.Day, result.Day);
            Assert.AreEqual(date.Month, result.Month);
            Assert.AreEqual(date.Year, result.Year);
        }

        [TestMethod]
        public void GetMondayWhereDayOfWeekIsTuesday()
        {
            var date = new DateTime(2013, 2, 12, 10, 0, 0);
            var result = date.GetMonday();
            Assert.AreEqual(11, result.Day);
            Assert.AreEqual(date.Month, result.Month);
            Assert.AreEqual(date.Year, result.Year);
        }

        [TestMethod]
        public void GetMondayWhereDayOfWeekIsWednesday()
        {
            var date = new DateTime(2013, 2, 13, 10, 0, 0);
            var result = date.GetMonday();
            Assert.AreEqual(11, result.Day);
            Assert.AreEqual(date.Month, result.Month);
            Assert.AreEqual(date.Year, result.Year);
        }

        [TestMethod]
        public void GetMondayWhereDayOfWeekIsThursday()
        {
            var date = new DateTime(2013, 2, 14, 10, 0, 0);
            var result = date.GetMonday();
            Assert.AreEqual(11, result.Day);
            Assert.AreEqual(date.Month, result.Month);
            Assert.AreEqual(date.Year, result.Year);
        }

        [TestMethod]
        public void GetMondayWhereDayOfWeekIsFriday()
        {
            var date = new DateTime(2013, 2, 15, 10, 0, 0);
            var result = date.GetMonday();
            Assert.AreEqual(11, result.Day);
            Assert.AreEqual(date.Month, result.Month);
            Assert.AreEqual(date.Year, result.Year);
        }

        [TestMethod]
        public void GetMondayWhereDayOfWeekIsSaturday()
        {
            var date = new DateTime(2013, 2, 16, 10, 0, 0);
            var result = date.GetMonday();
            Assert.AreEqual(11, result.Day);
            Assert.AreEqual(date.Month, result.Month);
            Assert.AreEqual(date.Year, result.Year);
        }

        [TestMethod]
        public void GetMondayWhereDayOfWeekIsSunday()
        {
            var date = new DateTime(2013, 2, 17, 10, 0, 0);
            var result = date.GetMonday();
            Assert.AreEqual(11, result.Day);
            Assert.AreEqual(date.Month, result.Month);
            Assert.AreEqual(date.Year, result.Year);
        }

        [TestMethod]
        public void GetMondayEnsureKeepingHoursMinutesAndSeconds()
        {
            var date = new DateTime(2013, 2, 17, 23, 24, 25);
            var result = date.GetMonday();
            Assert.AreEqual(date.Hour, result.Hour);
            Assert.AreEqual(date.Minute, result.Minute);
            Assert.AreEqual(date.Second, result.Second);
        }
    }
}
