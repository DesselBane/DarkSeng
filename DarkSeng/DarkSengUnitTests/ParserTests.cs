using Microsoft.VisualStudio.TestTools.UnitTesting;
using DarkSeng.Parsing;

namespace DarkSengUnitTests
{
    [TestClass]
    public class ParserTests
    {
        [TestMethod]
        public void RemoveNumbersStandard()
        {
            string input = "sdhj324jh340ßd9fkljl23ßa0sd";
            string expected = "sdhjjhßdfkljlßasd";
            string actual = Parser.RemoveNumbers(input);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void GetStringBetweenStandard()
        {
            string input = "that is a test";
            string left = "that";
            string right = "test";
            string expected = " is a ";
            string actual = Parser.GetStringBetween(input, left, right);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void GetStringBetweenNonExisting()
        {
            string input = "that is a test";
            string left = "nonExisting";
            string right = "test";
            string expected = "";
            string actual = Parser.GetStringBetween(input, left, right);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void GetStringBetweenLeftAndRightAreTheSame()
        {
            string input = "that is a test";
            string left = "is";
            string right = "is";
            string expected = "";
            string actual = Parser.GetStringBetween(input, left, right);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void GetStringBetweenLeftIsMoreRightThanRight()
        {
            string input = "that is a test";
            string left = "test";
            string right = "that";
            string expected = "";
            string actual = Parser.GetStringBetween(input, left, right);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void GetStringBetweenCasing()
        {
            string input = "that is a test";
            string left = "tHaT";
            string right = "TeSt";
            string expected = " is a ";
            string actual = Parser.GetStringBetween(input, left, right);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void SubstituteStandaloneWordStandard()
        {
            string input = "that is a test";
            string word = "is";
            string expected = "that a test";
            string actual = Parser.SubstituteStandaloneWord(input, word);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void SubstituteStandaloneWordNonStandaloneWord()
        {
            string input = "that is a test";
            string word = "is a";
            string expected = "that is a test";
            string actual = Parser.SubstituteStandaloneWord(input, word);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void SubstituteStandaloneWordOnLeft()
        {
            string input = "that is a test";
            string word = "that";
            string expected = "is a test";
            string actual = Parser.SubstituteStandaloneWord(input, word);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void SubstituteStandaloneWordOnRight()
        {
            string input = "that is a test";
            string word = "test";
            string expected = "that is a";
            string actual = Parser.SubstituteStandaloneWord(input, word);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void SubstituteStandaloneWordCasing()
        {
            string input = "that is a test";
            string word = "tEsT";
            string expected = "that is a";
            string actual = Parser.SubstituteStandaloneWord(input, word);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void ParseCharactersStandard()
        {
            string input = "abcdefabdef";
            char[] parseChars = new char[] { 'a', 'e', 'z' };
            string expected = "bcdfbdf";
            string actual = Parser.ParseCharacters(input, parseChars);
            Assert.AreEqual(expected, actual);
        }
    }
}