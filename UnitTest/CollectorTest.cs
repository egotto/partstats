using Microsoft.VisualStudio.TestTools.UnitTesting;
using PartStats;

namespace UnitTest
{
    [TestClass]
    public class CollectorTest
    {
        [TestMethod]
        public void AddItemToCollection()
        {
            Collector.AddItem(new Item("сверло,11"));
            Assert.AreEqual(Collector.GetCountByName("сверло"), 11u);

            Collector.AddItem(new Item("Сверло,9"));
            Assert.AreEqual(Collector.GetCountByName("сверло"), 20u);
            Assert.IsTrue(Collector.GetResult().Count == 1);

            Collector.AddItem(new Item("nut,100"));
            Assert.IsTrue(Collector.GetResult().Count == 2);

            Collector.Clear();
        }
    }
}