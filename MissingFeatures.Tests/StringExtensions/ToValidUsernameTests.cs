namespace MissingFeatures.Tests.StringExtensions
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class ToValidUsernameTests
    {
        [TestMethod]
        public void ToValidUsername_CyrilicLetters()
        {
            string expected = "Nikolay_Kostov";
            string actual = "Николай_Костов".ToValidUsername();
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void ToValidUsername_CyrilicLetters_FirstLetterTranscriptsToMoreThanOneCharacter()
        {
            string expected = "Yashu_Shterev";
            string actual = "Яшу_Щерев".ToValidUsername();
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void ToValidUsername_CyrilicLetters_EmptyUsername()
        {
            string expected = string.Empty;
            string actual = string.Empty.ToValidUsername();
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void ToValidUsername_CyrilicLetters_LowercaseUsername()
        {
            string expected = "stamo";
            string actual = "стамо".ToValidUsername();
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void ToValidUsername_CyrilicLetters_UppercaseUsername()
        {
            string expected = "STAMO";
            string actual = "СТАМО".ToValidUsername();
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void ToValidUsername_CyrilicLetters_UsernameWith30Characters()
        {
            string expected = "StamoStamoStamoStamoStamoStamo";
            string actual = "СтамоСтамоСтамоСтамоСтамоСтамо".ToValidUsername();
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void ToValidUsername_CyrilicLetters_UsernameWithSpace()
        {
            string expected = "StamoGochev";
            string actual = "Стамо Гочев".ToValidUsername();
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void ToValidUsername_CyrilicLetters_UsernameWithSpacesAtTheBeginningAndAtTheEnd()
        {
            string expected = "StamoGochev";
            string actual = " Стамо Гочев ".ToValidUsername();
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void ToValidUsername_CyrilicLetters_UsernameWithUnderscore()
        {
            string expected = "Stamo_Gochev";
            string actual = " Стамо_Гочев ".ToValidUsername();
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void ToValidUsername_CyrilicLetters_UsernameStartingWithUnderscore()
        {
            string expected = "_Stamo_Gochev";
            string actual = "_Стамо_Гочев".ToValidUsername();
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void ToValidUsername_CyrilicLetters_UsernameWithDash()
        {
            string expected = "StamoGochev";
            string actual = "Стамо-Гочев".ToValidUsername();
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void ToValidUsername_CyrilicLetters_UsernameWithDot()
        {
            string expected = "Stamo.Gochev";
            string actual = "Стамо.Гочев".ToValidUsername();
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void ToValidUsername_CyrilicLetters_UsernameWithDots()
        {
            string expected = ".Stamo.Gochev";
            string actual = ".Стамо.Гочев".ToValidUsername();
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void ToValidUsername_CyrilicLetters_UsernameWithVowels()
        {
            string expected = "UuU";
            string actual = "УъУ".ToValidUsername();
            Assert.AreEqual(expected, actual);
        }
    }
}
