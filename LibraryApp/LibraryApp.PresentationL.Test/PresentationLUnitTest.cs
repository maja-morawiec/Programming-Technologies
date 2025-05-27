using LibraryApp.PresentationL.Model.API;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Threading.Tasks;

namespace LibraryApp.PresentationL.Test
{
    [TestClass]
    public sealed class PresentationLUnitTest
    {
        private readonly IModel model = IModel.CreateNewModel();

        [TestMethod]
        public async Task UserModelTest()
        {
            await model.AddUser(10, "Test");
            Assert.IsNotNull(model.GetAllUsers());
            await model.RemoveUser(10);
        }

        [TestMethod]
        public async Task ProductModelTest()
        {
            await model.AddProduct(10, "TestProduct", 5);
            Assert.IsNotNull(model.GetAllProducts());
            await model.RemoveProduct(10);
        }

        [TestMethod]
        public async Task EventModelTest()
        {
            await model.AddEvent(10, "Test Event", DateTime.Now);
            Assert.IsNotNull(model.GetAllEvents());
            await model.RemoveEvent(10);
        }

        [TestMethod]
        public async Task BorrowTest()
        {
            await model.AddProduct(11, "Camera", 1);
            await model.BorrowProduct(11);
            await model.RemoveProduct(11);
        }
    }
}
