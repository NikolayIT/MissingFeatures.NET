namespace MissingFeatures.Tests.RandomGenerator
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    using RandomGenerator = MissingFeatures.RandomGenerator;

    [TestClass]
    public class NextStringTests
    {
        [TestMethod]
        public void NextStringShouldReturnStringWithSameNumberOfCharactersAsMethodParameter()
        {
            const int NumberOfCharacters = 7;
            var randomGenerator = new RandomGenerator();
            var result = randomGenerator.NextString(NumberOfCharacters);
            Assert.AreEqual(NumberOfCharacters, result.Length);
        }
    }
}
