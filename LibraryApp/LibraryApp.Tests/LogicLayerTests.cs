using Microsoft.VisualStudio.TestTools.UnitTesting;
using LibraryApp.Data;
using LibraryApp.Logic;
using System;

namespace LibraryApp.Tests
{
    [TestClass]
    public class BusinessLogicTests
    {
        private DataLayer _dataLayer;
        private BussinessLogic _logic;

        [TestInitialize]
        public void Setup()
        {
            _dataLayer = new DataLayer();
            _logic = new BussinessLogic(_dataLayer);
        }

        [TestMethod]
        public void AddUser_ShouldAddUserToList()
        {
            _logic.AddUser(1, "Alice");

            Assert.AreEqual(1, _dataLayer.Users.Count);
            Assert.AreEqual("Alice", _dataLayer.Users[0].Name);
        }

        [TestMethod]
        public void AddProduct_ShouldAddProductToCatalog()
        {
            _logic.AddProduct(10, "Book", 3);

            Assert.IsTrue(_dataLayer.Catalog.ContainsKey(10));
            Assert.AreEqual("Book", _dataLayer.Catalog[10].Name);
            Assert.AreEqual(3, _dataLayer.Catalog[10].Quantity);
        }

        [TestMethod]
        public void BorrowProduct_ShouldDecreaseQuantityAndAddEvent()
        {
            _logic.AddProduct(20, "Pen", 5);

            _logic.BorrowProduct(20);

            Assert.AreEqual(4, _dataLayer.Catalog[20].Quantity);
            Assert.AreEqual(1, _dataLayer.Events.Count);
            Assert.IsTrue(_dataLayer.Events[0].Description.Contains("borrowed"));
        }

        [TestMethod]
        public void BorrowProduct_WhenUnavailable_ShouldThrowException()
        {
            Assert.ThrowsException<InvalidOperationException>(() =>
            {
                _logic.BorrowProduct(99);
            });
        }

        [TestMethod]
        public void ReturnProduct_ShouldIncreaseQuantityAndAddEvent()
        {
            _logic.AddProduct(30, "Notebook", 1);

            _logic.ReturnProduct(30);

            Assert.AreEqual(2, _dataLayer.Catalog[30].Quantity);
            Assert.AreEqual(1, _dataLayer.Events.Count);
            Assert.IsTrue(_dataLayer.Events[0].Description.Contains("returned"));
        }
    }
}
