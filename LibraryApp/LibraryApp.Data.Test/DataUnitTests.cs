using Microsoft.VisualStudio.TestTools.UnitTesting;
using LibraryApp.Data.API;
using LibraryApp.Data.Implementation;
using System;
using System.Linq;

namespace LibraryApp.Data.Test
{
    [TestClass]
    public class DataUnitTest
    {
        private ISqlDataLayer repo;

        [TestInitialize]
        public void Setup()
        {
            repo = new SqlDataLayer();

            
            try
            {
                repo.RemoveUser(1);
                repo.RemoveProduct(1);
                repo.RemoveEvent(1);
                repo.SaveChanges();
            }
            catch { /* ignore if not present */ }
        }

        [TestMethod]
        public void UserTests()
        {
            repo.AddUser(1, "TestUser");
            repo.SaveChanges();

            var user = repo.GetUser(1);
            Assert.IsNotNull(user);
            Assert.AreEqual("TestUser", user.Name);

            repo.RemoveUser(1);
            repo.SaveChanges();
            Assert.IsNull(repo.GetUser(1));
        }

        [TestMethod]
        public void ProductTests()
        {
            repo.AddProduct(1, "TestProduct", 10);
            repo.SaveChanges();

            var product = repo.GetProduct(1);
            Assert.IsNotNull(product);
            Assert.AreEqual("TestProduct", product.Name);
            Assert.AreEqual(10, product.Quantity);

            repo.RemoveProduct(1);
            repo.SaveChanges();
            Assert.IsNull(repo.GetProduct(1));
        }

        [TestMethod]
        public void EventTests()
        {
            ISqlDataLayer repo = new SqlDataLayer();

            repo.AddUser(1, "TestUser");
            repo.AddEvent(1, "Test Event", DateTime.Now); 
            repo.SaveChanges();

            var evt = repo.GetEvent(1);

            Assert.IsNotNull(evt);
            Assert.AreEqual("Test Event", evt.Description);

            repo.RemoveEvent(1);
            repo.RemoveUser(1);
            repo.SaveChanges();
        }



    }
}
