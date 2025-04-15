using Microsoft.VisualStudio.TestTools.UnitTesting;
using LibraryApp.Data;

namespace LibraryApp.Tests
{
    [TestClass]
    public class DataLayerTests
    {
        [TestMethod]
        public void SeedUsers_ShouldAddTwoUsers()
        {
            var dataLayer = new DataLayer();
            dataLayer.SeedUsers();

            Assert.AreEqual(2, dataLayer.Users.Count);
            Assert.AreEqual("Anna", dataLayer.Users[0].Name);
            Assert.AreEqual("Tom", dataLayer.Users[1].Name);
        }

        [TestMethod]
        public void SeedCatalog_ShouldAddTwoProducts()
        {
            var dataLayer = new DataLayer();
            dataLayer.SeedCatalog();

            Assert.AreEqual(2, dataLayer.Catalog.Count);
            Assert.IsTrue(dataLayer.Catalog.ContainsKey(1));
            Assert.IsTrue(dataLayer.Catalog.ContainsKey(2));
            Assert.AreEqual("Book", dataLayer.Catalog[1].Name);
            Assert.AreEqual("Pen", dataLayer.Catalog[2].Name);
        }
    }
}
