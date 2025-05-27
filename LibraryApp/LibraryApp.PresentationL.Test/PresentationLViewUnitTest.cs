using LibraryApp.PresentationL.Model.API;
using LibraryApp.PresentationL.ViewModel;
using LibraryApp.PresentationL.ViewModels;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace LibraryApp.PresentationL.Test
{
    [TestClass]
    public class PresentationLViewUnitTest
    {
        private readonly MockModel model = new MockModel();

        [TestMethod]
        public void UserPresentationTest()
        {
            VMUserList list = new VMUserList(model);
            VMUser user = new VMUser(1, "TestUser");

            model.AddUser(2, "AnotherUser");
            list.Users.Add(user);

            Assert.AreEqual(1, list.Users.Count);
            Assert.AreEqual(1, list.Users[0].Id);
            Assert.AreEqual("TestUser", list.Users[0].Name);

            list.Users.Remove(user);
            model.RemoveUser(2);

            Assert.AreEqual(0, list.Users.Count);
        }

        [TestMethod]
        public void ProductPresentationTest()
        {
            VMProductList list = new VMProductList(model);
            VMProduct product = new VMProduct(1, "TestProduct", 10);

            model.AddProduct(2, "AnotherProduct", 5);
            list.Products.Add(product);

            Assert.AreEqual(1, list.Products.Count);
            Assert.AreEqual(1, list.Products[0].Id);
            Assert.AreEqual("TestProduct", list.Products[0].Name);
            Assert.AreEqual(10, list.Products[0].Quantity);

            list.Products.Remove(product);
            model.RemoveProduct(2);

            Assert.AreEqual(0, list.Products.Count);
        }

        [TestMethod]
        public void EventPresentationTest()
        {
            VMEventList list = new VMEventList(model);
            VMEvent ev = new VMEvent(1, "Test Event", DateTime.Now);

            model.AddEvent(2, "Another Event", DateTime.Now.AddHours(-1));
            list.EventVMList.Add(ev);

            Assert.AreEqual(1, list.EventVMList.Count);
            Assert.AreEqual(1, list.EventVMList[0].Id);
            Assert.AreEqual("Test Event", list.EventVMList[0].Description);

            list.EventVMList.Remove(ev);
            model.RemoveEvent(2);

            Assert.AreEqual(0, list.EventVMList.Count);
        }
    }
}
