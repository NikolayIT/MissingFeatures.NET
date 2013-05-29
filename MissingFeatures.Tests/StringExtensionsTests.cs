namespace MissingFeatures.Tests
{
    using System;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class StringExtensionsTests
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
            string expected = "";
            string actual = "".ToValidUsername();
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

        [TestMethod]
        public void ToLong_ParseInvalidInput_ShouldReturnZero()
        {
            long expected = 0L;
            string input = "invalid";
            long actual = input.ToLong();
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void ToLong_ParseValidInput_ShouldReturnValidLongValue()
        {
            long expected = 999123456789L;
            string input = "999123456789";
            long actual = input.ToLong();
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void GetFileExtension_ShouldReturnEmptyStringWhenEmptyStringIsPassed()
        {
            string expected = String.Empty;
            string value = String.Empty;
            string actual = value.GetFileExtension();
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void GetFileExtension_ShouldReturnEmptyStringWhenNullIsPassed()
        {
            string expected = String.Empty;
            string value = null;
            string actual = value.GetFileExtension();
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void GetFileExtension_ShouldReturnJpgWhenValidImageIsPassed()
        {
            string expected = "jpg";
            string value = "pic.jpg";
            string actual = value.GetFileExtension();
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void GetFileExtension_ShouldReturnPpgWhenValidImageWithManyDotsIsPassed()
        {
            string expected = "png";
            string value = "pic.test.value.jpg.png";
            string actual = value.GetFileExtension();
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void GetFileExtension_ShouldReturnEmptyStringWhenFileDoesNotHaveExtension()
        {
            string expected = String.Empty;
            string value = "testing";
            string actual = value.GetFileExtension();
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void GetFileExtension_ShouldReturnEmptyStringWhenFileEndsInADot()
        {
            string expected = String.Empty;
            string value = "testing.";
            string actual = value.GetFileExtension();
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void GetFileExtension_ShouldReturnEmptyStringWhenFileContainsManyDotsAndEndsInADot()
        {
            string expected = String.Empty;
            string value = "testing.jpg.value.gosho.";
            string actual = value.GetFileExtension();
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void ConvertLatinToCyrillicKeyboard_ShouldReturnEmptyStringForEmptyString()
        {
            string expected = String.Empty;
            string value = String.Empty;
            string actual = value.ConvertLatinToCyrillicKeyboard();
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void ConvertLatinToCyrillicKeyboard_ShouldReturnRightForWorkaround()
        {
            string expected = "Воркароунд";
            string value = "Workaround";
            string actual = value.ConvertLatinToCyrillicKeyboard();
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void ConvertLatinToCyrillicKeyboard_ShouldReturnRightForExplorer()
        {
            string expected = "Еьплорер";
            string value = "Explorer";
            string actual = value.ConvertLatinToCyrillicKeyboard();
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void ConvertLatinToCyrillicKeyboard_ShouldReturnRightForZylenvrytqui()
        {
            string expected = "Зъленжрътяуи";
            string value = "Zylenvrytqui";
            string actual = value.ConvertLatinToCyrillicKeyboard();
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void ConvertLatinToCyrillicKeyboard_ShouldReturnRightForWholeAlphabet()
        {
            string expected = "абцдефгхийклмнопярстужвьъз";
            string value = "abcdefghijklmnopqrstuvwxyz";
            string actual = value.ConvertLatinToCyrillicKeyboard();
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void ConvertLatinToCyrillicKeyboard_ShouldReturnRightForWholeCapitalAlphabet()
        {
            string expected = "АБЦДЕФГХИЙКЛМНОПЯРСТУЖВЬЪЗ";
            string value = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            string actual = value.ConvertLatinToCyrillicKeyboard();
            Assert.AreEqual(expected, actual);
        }

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
            string expected = String.Empty;
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
            string expected = String.Empty;
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
            string expected = String.Empty;
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

        [TestMethod]
        public void CapitalizeFirstLetter_ParseEmptyString_ShouldReturnEmptyString()
        {
            string expected = string.Empty;
            string input = string.Empty;
            string actual = input.CapitalizeFirstLetter();
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void CapitalizeFirstLetter_ParseStringWithSmallFirstLetter_ShouldReturnCapitalizedFirstLetter()
        {
            string expected = "FirstCapitalLetter";
            string input = "firstCapitalLetter";
            string actual = input.CapitalizeFirstLetter();
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void CapitalizeFirstLetter_ParseStringBeginWithSpace_ShouldReturnSameString()
        {
            string expected = " testString";
            string input = " testString";
            string actual = input.CapitalizeFirstLetter();
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void CapitalizeFirstLetter_ParseStringBeginWithCapitalLetter_ShouldReturnSameString()
        {
            string expected = "TestString";
            string input = "TestString";
            string actual = input.CapitalizeFirstLetter();
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void CapitalizeFirstLetter_ParseStringBeginWithCyrillicSmallLetter_ShouldReturnCapitalizedFirstLetter()
        {
            string expected = "Академия";
            string input = "академия";
            string actual = input.CapitalizeFirstLetter();
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void CapitalizeFirstLetter_ParseStringBeginWithCyrillicSmallLetter_ShouldReturnSameString()
        {
            string expected = "Академия";
            string input = "Академия";
            string actual = input.CapitalizeFirstLetter();
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void CapitalizeFirstLetter_ParseStringBeginWithSpecialSymbol_ShouldReturnSameString()
        {
            string expected = "@TestString";
            string input = "@TestString";
            string actual = input.CapitalizeFirstLetter();
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void ConvertCyrillicToLatinLetters_ParseEmptyString_ShouldReturnEmptyString()
        {
            string expected = String.Empty;
            string value = String.Empty;
            string actual = value.ConvertCyrillicToLatinLetters();
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void ConvertCyrillicToLatinLetters_ParseCyrillicWokaround_ShouldReturnRightWorkaround()
        {
            string expected = "ShtURKELUT";
            string value = "ЩЪРКЕЛЪТ";
            string actual = value.ConvertCyrillicToLatinLetters();
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void ConvertCyrillicToLatinLetters_ParseCyrillicExplorer_ShouldReturnRightExplorer()
        {
            string expected = "Lyulyak";
            string value = "Люляк";
            string actual = value.ConvertCyrillicToLatinLetters();
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void ConvertCyrillicToLatinLetters_ParseCyrillicAlphabet_ShouldReturnRightAlphabet()
        {
            string expected = "abvgdejziyklmnoprstufhcchshshtuiyuya";
            string value = "абвгдежзийклмнопрстуфхцчшщъьюя";
            string actual = value.ConvertCyrillicToLatinLetters();
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void ConvertCyrillicToLatinLetters_ParseCyrillicAlphabetCapitalLetters_ShouldReturnRightAlphabetCapitalLetters()
        {
            string expected = "ABVGDEJZIYKLMNOPRSTUFHCChShShtUIYuYa";
            string value = "АБВГДЕЖЗИЙКЛМНОПРСТУФХЦЧШЩЪЬЮЯ";
            string actual = value.ConvertCyrillicToLatinLetters();
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void ConvertCyrillicToLatinLetters_ParseTwoAlphabetCapitalLetters_ShouldReturnRightTwoAlphabetCapitalLetters()
        {
            string expected = "ABVGDEJZIYKLMNOPRSTUFHCChShShtUIYuYaABCDEFGHIJKLMNOPQRSTUVWXYZ";
            string value = "АБВГДЕЖЗИЙКЛМНОПРСТУФХЦЧШЩЪЬЮЯABCDEFGHIJKLMNOPQRSTUVWXYZ";
            string actual = value.ConvertCyrillicToLatinLetters();
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void ConvertCyrillicToLatinLetters_ParseTwoAlphabetSmallLetters_ShouldReturnRightTwoAlphabetSmallLetters()
        {
            string expected = "abvgdejziyklmnoprstufhcchshshtuiyuyaabcdefghijklmnopqrstuvwxyz";
            string value = "абвгдежзийклмнопрстуфхцчшщъьюяabcdefghijklmnopqrstuvwxyz";
            string actual = value.ConvertCyrillicToLatinLetters();
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void ToValidLatinFileName_TransformEmptyName_ShouldReturnEmptyName()
        {
            string expected = string.Empty;
            string str = string.Empty; ;
            string actual = str.ToValidLatinFileName();
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void ToValidLatinFileName_TransformCorectName_ShouldReturnSameName()
        {
            string expected = "FileName.ext";
            string str = "FileName.ext"; ;
            string actual = str.ToValidLatinFileName();
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void ToValidLatinFileName_TransformNameWithLowLine_ShouldReturnCorrectName()
        {
            string expected = "File_Name.ext";
            string str = "File_Name.ext"; ;
            string actual = str.ToValidLatinFileName();
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void ToValidLatinFileName_TransformNameWithOneSpace_ShouldReturnCorrectName()
        {
            string expected = "File-Name.ext";
            string str = "File Name.ext"; ;
            string actual = str.ToValidLatinFileName();
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void ToValidLatinFileName_TransformNameWithTwoSpaces_ShouldReturnCorrectName()
        {
            string expected = "File--Name.ext";
            string str = "File  Name.ext"; ;
            string actual = str.ToValidLatinFileName();
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void ToValidLatinFileName_TransformNameWithNumberSign_ShouldReturnCorrectName()
        {
            string expected = "FileName.ext";
            string str = "File#Name.ext"; ;
            string actual = str.ToValidLatinFileName();
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void ToValidLatinFileName_TransformNameWithAtSign_ShouldReturnCorrectName()
        {
            string expected = "FileName.ext";
            string str = "File@Name.ext"; ;
            string actual = str.ToValidLatinFileName();
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void ToValidLatinFileName_TransformCirillicName_ShouldReturnCorrectName()
        {
            string expected = "FileName.doc";
            string str = "ФилеНаме.доц"; ;
            string actual = str.ToValidLatinFileName();
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void ToValidLatinFileName_TransformCirillicAndLatinName_ShouldReturnCorrectName()
        {
            string expected = "FileName.doc";
            string str = "ФилеName.доц"; ;
            string actual = str.ToValidLatinFileName();
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void ToValidLatinFileName_TransformCirillicAndLatinNameAndTwoDots_ShouldReturnCorrectName()
        {
            string expected = "File.Name.doc";
            string str = "Филе.Name.доц"; ;
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

        [TestMethod]
        public void GetFirstCharacters_InputEmptyString_ShouldReturnEmptyString()
        {
            string expected = string.Empty;
            string str = string.Empty;
            int charsCount = 1;
            string actual = str.GetFirstCharacters(charsCount);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void GetFirstCharacters_GetZeroSymbols_ShouldReturnEmptyString()
        {
            string expected = string.Empty;
            string str = "testedString";
            int charsCount = 0;
            string actual = str.GetFirstCharacters(charsCount);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void GetFirstCharacters_GetOneSymbol_ShouldReturnOneSymbol()
        {
            string expected = "1";
            string str = "123testedString";
            int charsCount = 1;
            string actual = str.GetFirstCharacters(charsCount);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void GetFirstCharacters_GetThreeSymbols_ShouldReturnThreeSymbols()
        {
            string expected = "123";
            string str = "123testedString";
            int charsCount = 3; // 3
            string actual = str.GetFirstCharacters(charsCount);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void GetFirstCharacters_GetSymbolsEqualToLenght_ShouldReturnInputString()
        {
            string expected = "1234567890";
            string str = "1234567890";
            int charsCount = 10;
            string actual = str.GetFirstCharacters(charsCount);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void GetFirstCharacters_GetSymbolsMoreThanLenght_ShouldReturnInputString()
        {
            string expected = "1234567890";
            string str = "1234567890";
            int charsCount = 15;
            string actual = str.GetFirstCharacters(charsCount);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void ToBoolean_TestEmptyString_ShouldReturnFalse()
        {
            bool expected = false;
            string str = string.Empty;
            bool actual = str.ToBoolean();
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void ToBoolean_TestWrongString_ShouldReturnFalse()
        {
            bool expected = false;
            string str = "WrongString";
            bool actual = str.ToBoolean();
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void ToBoolean_TestStringTrue_ShouldReturnTrue()
        {
            bool expected = true;
            string str = "true";
            bool actual = str.ToBoolean();
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void ToBoolean_TestStringTrueCapitalLetters_ShouldReturnTrue()
        {
            bool expected = true;
            string str = "TRUE";
            bool actual = str.ToBoolean();
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void ToBoolean_TestStringOk_ShouldReturnTrue()
        {
            bool expected = true;
            string str = "ok";
            bool actual = str.ToBoolean();
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void ToBoolean_TestStringOkCapitalLetters_ShouldReturnTrue()
        {
            bool expected = true;
            string str = "OK";
            bool actual = str.ToBoolean();
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void ToBoolean_TestStringYes_ShouldReturnTrue()
        {
            bool expected = true;
            string str = "yes";
            bool actual = str.ToBoolean();
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void ToBoolean_TestStringYesCapitalLetters_ShouldReturnTrue()
        {
            bool expected = true;
            string str = "YES";
            bool actual = str.ToBoolean();
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void ToBoolean_TestStringDa_ShouldReturnTrue()
        {
            bool expected = true;
            string str = "да";
            bool actual = str.ToBoolean();
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void ToBoolean_TestStringDaCapitalLetters_ShouldReturnTrue()
        {
            bool expected = true;
            string str = "ДА";
            bool actual = str.ToBoolean();
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void ToBoolean_TestStringOne_ShouldReturnTrue()
        {
            bool expected = true;
            string str = "1";
            bool actual = str.ToBoolean();
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void ToShort_TestZero_ShouldReturnZero()
        {
            short expected = 0;
            string str = "0";
            short actual = str.ToShort();
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void ToShort_TestInvalidInput_ShouldReturnZero()
        {
            short expected = 0;
            string str = "invalid";
            short actual = str.ToShort();
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void ToShort_TestValidInput_ShouldReturnSameValue()
        {
            short expected = 1234;
            string str = "1234";
            short actual = str.ToShort();
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void ToInteger_TestZero_ShouldReturnZero()
        {
            int expected = 0;
            string str = "0";
            int actual = str.ToInteger();
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void ToInteger_TestInvalidInput_ShouldReturnZero()
        {
            int expected = 0;
            string str = "invalid";
            int actual = str.ToInteger();
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void ToInteger_TestValidInput_ShouldReturnSameValue()
        {
            int expected = 1234567890;
            string str = "1234567890";
            int actual = str.ToInteger();
            Assert.AreEqual(expected, actual);
        }

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
            DateTime expected = new DateTime(1988, 7, 6, new System.Globalization.GregorianCalendar());
            string str = "July 6, 1988";
            DateTime actual = str.ToDateTime();
            Assert.AreEqual(expected, actual);
        }

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

        [TestMethod]
        public void ToKendoSafeString_TestNumberSign_ShouldReturnSlashSlashNumberSign()
        {
            string expected = @"\\#";
            string str = "#";
            string actual = str.ToKendoSafeString();
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void ToKendoSafeString_TestNumberSignInBegin_ShouldReturnSlashSlashNumberSign()
        {
            string expected = @"\\#TestString";
            string str = "#TestString";
            string actual = str.ToKendoSafeString();
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void ToKendoSafeString_TestNumberSignInTheMiddle_ShouldReturnSlashSlashNumberSign()
        {
            string expected = @"TestString\\#TestString";
            string str = "TestString#TestString";
            string actual = str.ToKendoSafeString();
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void ToKendoSafeString_TestNumberSignInTheEnd_ShouldReturnSlashSlashNumberSign()
        {
            string expected = @"TestString\\#";
            string str = "TestString#";
            string actual = str.ToKendoSafeString();
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void StrippingHtmlTags_TestEmptyString_ShouldReturnEmptyString()
        {
            string expected = string.Empty;
            string str = string.Empty;
            string actual = str.StripHtmlTags();
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void StrippingHtmlTags_TestHtmlString_ShouldReturnTestString()
        {
            string expected = "Test";
            string str = @"<head></head><html><body><div>Test</div></body></html>";
            string actual = str.StripHtmlTags();
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void StrippingHtmlTags_TestHtmlString_ShouldReturnEmptyString()
        {
            string expected = string.Empty;
            string str = @"<head></head><html><body><div></div></body></html>";
            string actual = str.StripHtmlTags();
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void StrippingHtmlTags_TestInvalidHtmlString_ShouldReturnEmptyString()
        {
            string expected = "Test";
            string str = @"<head></head><html><body>Test</div></body></html>";
            string actual = str.StripHtmlTags();
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void StrippingHtmlTags_TestHtmlString_ShouldReturnHtmlString()
        {
            string expected = "Html";
            string str = @"<head></head><html><body>Html</body></html>";
            string actual = str.StripHtmlTags();
            Assert.AreEqual(expected, actual);
        }
    }
}
