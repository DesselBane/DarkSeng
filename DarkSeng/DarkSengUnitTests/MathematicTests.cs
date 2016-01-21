using Microsoft.VisualStudio.TestTools.UnitTesting;
using DarkSeng.Mathematics;

namespace DarkSengUnitTests
{
    [TestClass]
    public class MathematicTests
    {
        [TestMethod]
        public void IsNumericStandard()
        {
            string input = "123";
            bool expected = true;
            bool actual = input.IsNumeric();
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void IsNumericWithNonNumeric()
        {
            string input = "123a";
            bool expected = false;
            bool actual = input.IsNumeric();
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void IsNumericNegativeNumber()
        {
            string input = "-123";
            bool expected = true;
            bool actual = input.IsNumeric();
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void IsNumericDoubleMinus()
        {
            string input = "-123-123";
            bool expected = false;
            bool actual = input.IsNumeric();
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void IsPalindromeEvenLength()
        {
            string input = "123321";
            bool expected = true;
            bool actual = input.IsPalindrome();
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void IsPalindromeOddLength()
        {
            string input = "12321";
            bool expected = true;
            bool actual = input.IsPalindrome();
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void IsPalindromeNotPalindromic()
        {
            string input = "123123";
            bool expected = false;
            bool actual = input.IsPalindrome();
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void IsPalindromeCharAndNumberMixed()
        {
            string input = "abc12321cba";
            bool expected = true;
            bool actual = input.IsPalindrome();
            Assert.AreEqual(expected, actual);
        }
    }
}
