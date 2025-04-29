using Microsoft.VisualStudio.TestTools.UnitTesting;
using LibraryApp.Data;

namespace LibraryApp.Tests
{
    [TestClass]
    public class DataLayerTests
    {
        [TestMethod]
        public void ManualUserAdd_ShouldAddTwoUsers()
        {
            var dataLayer = new DataLayer();
            dataLayer.Users.Add(new Reader { Id = 1, Name = "Anna" });
            dataLayer.Users.Add(new Reader { Id = 2, Name = "Tom" });

            Assert.AreEqual(2, dataLayer.Users.Count);
            Assert.AreEqual("Anna", dataLayer.Users[0].Name);
            Assert.AreEqual("Tom", dataLayer.Users[1].Name);
        }

        [TestMethod]
        public void ManualCatalogAdd_ShouldAddTwoProducts()
        {
            var dataLayer = new DataLayer();
            dataLayer.Catalog[1] = new Book { Id = 1, Name = "Book", Quantity = 5 };
            dataLayer.Catalog[2] = new Book { Id = 2, Name = "Pen", Quantity = 10 };

            Assert.AreEqual(2, dataLayer.Catalog.Count);
            Assert.AreEqual("Book", dataLayer.Catalog[1].Name);
            Assert.AreEqual("Pen", dataLayer.Catalog[2].Name);
        }

    }
}
