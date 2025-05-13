using System;
using System.Collections.Generic;
using System.Linq;
using LibraryApp.Data.API;
using LibraryApp.Data.Implementation;

namespace LibraryApp.Logic
{
    internal class BusinessLogic : IBusinessLogic
    {
        private readonly IDataLayer _data;

        public BusinessLogic(IDataLayer data)
        {
            _data = data;
        }

        public IEnumerable<IUser> GetAllUsers() => _data.Users;

        public void AddUser(int id, string name)
        {
            var user = new Reader { Id = id, Name = name };
            _data.AddUser(user);
            _data.SaveChanges();
        }

        public void UpdateUser(IUser user)
        {
            _data.UpdateUser(user);
            _data.SaveChanges();
        }

        public void DeleteUser(int userId)
        {
            _data.RemoveUser(userId);
            _data.SaveChanges();
        }

        public IEnumerable<IProduct> GetAllProducts() => _data.Catalog.Values;

        public void AddProduct(int id, string name, int quantity)
        {
            var product = new Book { Id = id, Name = name, Quantity = quantity };
            _data.AddProduct(product);
            _data.SaveChanges();
        }

        public void UpdateProduct(IProduct product)
        {
            _data.UpdateProduct(product);
            _data.SaveChanges();
        }

        public void DeleteProduct(int productId)
        {
            _data.RemoveProduct(productId);
            _data.SaveChanges();
        }

        public IEnumerable<IEvent> GetAllEvents() => _data.Events;

        public void AddEvent(int id, string description, DateTime timestamp)
        {
            var evt = new BorrowEvent { Id = id, Description = description, Timestamp = timestamp };
            _data.AddEvent(evt);
            _data.SaveChanges();
        }

        public void UpdateEvent(IEvent evt)
        {
            _data.UpdateEvent(evt);
            _data.SaveChanges();
        }

        public void DeleteEvent(int eventId)
        {
            _data.RemoveEvent(eventId);
            _data.SaveChanges();
        }

        public void BorrowProduct(int productId)
        {
            IProduct product = null;
            if (_data.Catalog.ContainsKey(productId))
                product = _data.Catalog[productId];

            if (product == null || product.Quantity <= 0)
                throw new InvalidOperationException("Product unavailable");

            product.Quantity -= 1;

            var evt = new BorrowEvent
            {
                Id = _data.Events.Count + 1,
                Description = $"Product {product.Name} borrowed",
                Timestamp = DateTime.Now
            };

            _data.AddEvent(evt);
            _data.SaveChanges();
        }

        public List<IUser> GetUsers() => _data.Users;

        public List<IProduct> GetProducts() => _data.Catalog.Values.ToList();

        public List<IEvent> GetEvents() => _data.Events;

    }
}
