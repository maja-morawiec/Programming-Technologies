using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using LibraryApp.Service.API;
using LibraryApp.Service.Test.Mock;

namespace LibraryApp.Service.Test
{
    [TestClass]
    public class ServiceUnitTest
    {
        private IBusinessLogic _service;

        [TestInitialize]
        public void Setup()
        {
            _service = IBusinessLogic.CreateNewService(new MockDataLayer());
        }

        [TestMethod]
        public void AddUser_ShouldNotThrow()
        {
            _service.AddUser(1, "Alice");
            Assert.IsTrue(true); 
        }

        [TestMethod]
        public void AddProduct_ShouldNotThrow()
        {
            _service.AddProduct(2, "Book", 5);
            Assert.IsTrue(true);
        }

        [TestMethod]
        public void AddEvent_ShouldNotThrow()
        {
            _service.AddEvent(3, "Borrowed", DateTime.Now);
            Assert.IsTrue(true);
        }

        [TestMethod]
        public void UpdateUser_ShouldNotThrow()
        {
            _service.AddUser(4, "Before");
            _service.UpdateUser(4, "After");
            Assert.IsTrue(true);
        }

        [TestMethod]
        public void UpdateProduct_ShouldNotThrow()
        {
            _service.AddProduct(5, "Pen", 2);
            _service.UpdateProduct(5, "Pencil", 3);
            Assert.IsTrue(true);
        }

        [TestMethod]
        public void UpdateEvent_ShouldNotThrow()
        {
            _service.AddEvent(6, "Old", DateTime.Now);
            _service.UpdateEvent(6, "New", DateTime.Now.AddDays(1));
            Assert.IsTrue(true);
        }

        [TestMethod]
        public void BorrowProduct_ShouldNotThrow()
        {
            _service.AddProduct(7, "Notebook", 1);
            _service.BorrowProduct(7);
            Assert.IsTrue(true);
        }
    }
}
