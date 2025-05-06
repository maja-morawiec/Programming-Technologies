using Microsoft.VisualStudio.TestTools.UnitTesting;
using LibraryApp.Data.API;
using LibraryApp.Data.Implementation;

namespace LibraryApp.Tests
{
    [TestClass]
    public class DataLayerTests
    {
        private IDataLayer _dataLayer;
        private IDataGenerator _factory;

        [TestInitialize]
        public void Setup()
        {
            _dataLayer = new DataLayer();
            _factory = new DataGenerator();
        }

        [TestMethod]
        public void AddUser_ShouldStoreUserInList()
        {
            var user = _factory.CreateUser(1, "Anna");
            _dataLayer.Users.Add(user);

            Assert.AreEqual(1, _dataLayer.Users.Count);
            Assert.AreEqual("Anna", _dataLayer.Users[0].Name);
        }

        [TestMethod]
        public void AddProduct_ShouldStoreProductInCatalog()
        {
            var product = _factory.CreateProduct(10, "Book", 5);
            _dataLayer.Catalog[10] = product;

            Assert.AreEqual(1, _dataLayer.Catalog.Count);
            Assert.AreEqual("Book", _dataLayer.Catalog[10].Name);
            Assert.AreEqual(5, _dataLayer.Catalog[10].Quantity);
        }

        [TestMethod]
        public void AddBorrowEvent_ShouldStoreEventInList()
        {
            var evt = _factory.CreateBorrowEvent(1, "Test event");
            _dataLayer.Events.Add(evt);

            Assert.AreEqual(1, _dataLayer.Events.Count);
            Assert.AreEqual("Test event", _dataLayer.Events[0].Description);
        }
    }
}
