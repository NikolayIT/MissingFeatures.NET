namespace MissingFeatures.Tests.RandomGenerator
{
    using System.Text;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    using RandomGenerator = MissingFeatures.RandomGenerator;

    [TestClass]
    public class NextStringTests
    {
        [TestMethod]
        public void NextStringShouldReturnStringWithLessThanOrTheSameNumberOfCharactersAsMethodParameterWhenNoEncodingIsSpecified()
        {
            const int MaxNumberOfCharacters = 7;
            var randomGenerator = new RandomGenerator();
            var result = randomGenerator.NextString(MaxNumberOfCharacters);
            Assert.IsTrue(result.Length <= MaxNumberOfCharacters);
        }

        [TestMethod]
        public void NextStringShouldReturnStringWithTheSameNumberOfCharactersAsMethodParameterWhenAsciiEncodingIsUsed()
        {
            const int NumberOfCharacters = 7;
            var randomGenerator = new RandomGenerator();
            var result = randomGenerator.NextString(NumberOfCharacters, Encoding.ASCII);
            Assert.AreEqual(NumberOfCharacters, result.Length);
        }
    }
}
