using Microsoft.VisualStudio.TestTools.UnitTesting;
using LibraryApp.Data.API;
using LibraryApp.Data.Implementation;
using LibraryApp.Logic;
using System;

namespace LibraryApp.Tests
{
    [TestClass]
    public class LogicLayerTests
    {
        private IDataLayer _dataLayer;
        private IDataGenerator _factory;
        private BusinessLogic _logic;

        [TestInitialize]
        public void Setup()
        {
            _dataLayer = new DataLayer();
            _logic = new BusinessLogic(_dataLayer);
        }

        [TestMethod]
        public void AddUser_ShouldAddUserToDataLayer()
        {
            _logic.AddUser(1, "Tom");

            Assert.AreEqual(1, _dataLayer.Users.Count);
            Assert.AreEqual("Tom", _dataLayer.Users[0].Name);
        }

        [TestMethod]
        public void AddProduct_ShouldAddProductToCatalog()
        {
            _logic.AddProduct(5, "Notebook", 3);

            Assert.IsTrue(_dataLayer.Catalog.ContainsKey(5));
            Assert.AreEqual("Notebook", _dataLayer.Catalog[5].Name);
            Assert.AreEqual(3, _dataLayer.Catalog[5].Quantity);
        }

        [TestMethod]
        public void BorrowProduct_ShouldDecreaseQuantityAndAddEvent()
        {
            _logic.AddProduct(2, "Pen", 2);
            _logic.BorrowProduct(2);

            Assert.AreEqual(1, _dataLayer.Catalog[2].Quantity);
            Assert.AreEqual(1, _dataLayer.Events.Count);
            Assert.IsTrue(_dataLayer.Events[0].Description.Contains("borrowed"));
        }

        [TestMethod]
        public void BorrowProduct_WhenUnavailable_ShouldThrow()
        {
            Assert.ThrowsException<InvalidOperationException>(() =>
            {
                _logic.BorrowProduct(99);
            });
        }
    }
}
