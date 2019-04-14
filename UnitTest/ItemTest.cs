using Microsoft.VisualStudio.TestTools.UnitTesting;
using PartStats;
using System;

namespace UnitTest
{
    [TestClass]
    public class ItemTest
    {
        [TestMethod]
        public void CorrectDataInput()
        {
            var item = new Item("drill,15");
            Assert.AreEqual(item.Name, "drill");
            Assert.AreEqual(item.Count, 15u);
        }

        [TestMethod]
        public void IncorrectDataInput()
        {
            Assert.ThrowsException<Exception>(() => new Item("drill,14,1"));
            Assert.ThrowsException<Exception>(() => new Item("drill,one"));
        }
    }
}