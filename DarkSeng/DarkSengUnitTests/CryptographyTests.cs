using Microsoft.VisualStudio.TestTools.UnitTesting;
using DarkSeng.Cryptography;
using System;
using System.Text;

namespace DarkSengUnitTests
{
    [TestClass]
    public class CryptographyTests
    {
        [TestMethod]
        public void XorStandard()
        {
            string input = "that is a test";
            byte[] password = Encoding.ASCII.GetBytes(Guid.NewGuid().ToString());
            byte[] encrypted = Xor.Cipher(password, Encoding.ASCII.GetBytes(input));
            string expected = input;
            string actual = Encoding.ASCII.GetString(Xor.Cipher(password, encrypted));

            Assert.AreEqual(expected, actual);
            Assert.AreNotEqual(Encoding.ASCII.GetString(encrypted), input);
        }
    }
}
