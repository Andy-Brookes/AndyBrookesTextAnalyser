

using Domain;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;

namespace IntegrationTest
{
    [TestClass]
    public class TextAnalyserTests
    {
        private readonly Mock<ILogger> _mockLogger = new();

        [TestMethod]
        [DataRow(null)]
        [DataRow("")]
        [DataRow(" ")]
        public void SortWordsAlphabetically_ThrowsArgumentExceptionWhenInputIsNullEmptyOrWhitespace(string? input)
        {
            var sut = CreateSut();

            var exception = Assert.ThrowsException<ArgumentException>(() => sut.SortWordsAlphabetically(input));
            Assert.AreEqual("Invalid data", exception.Message);
        }

        [TestMethod]
        [DataRow("Zoom Boom", "Boom Zoom")]
        [DataRow("boom Boom", "Boom boom")]
        [DataRow("b, b", "b b")]
        [DataRow("Go baby, go", "baby Go go")]
        [DataRow("CBA, abc aBc ABC cba CBA.", "ABC aBc abc CBA CBA cba")]
        public void SortWordsAlphabetically_ReturnsExpectedValue(string input, string expected)
        {
            var sut = CreateSut();

            var actual = sut.SortWordsAlphabetically(input);

            Assert.AreEqual(expected, actual);
        }

        private TextAnalyser CreateSut()
        {
            return new TextAnalyser(_mockLogger.Object);
        }
    }
}