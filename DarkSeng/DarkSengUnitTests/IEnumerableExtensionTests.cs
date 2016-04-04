using Microsoft.VisualStudio.TestTools.UnitTesting;
using DarkSeng.Extensions;
using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;

namespace DarkSengUnitTests
{
    [TestClass]
    public class IEnumerableExtensionTests
    {
        [TestMethod]
        public void ShuffleTest()
        {
            List<int> orderedNumbers = new List<int>() { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            List<int> unorderedNumbers = orderedNumbers.Shuffle().ToList();

            Assert.AreNotEqual(orderedNumbers, unorderedNumbers);
        }
    }
}
