using System;
using System.Collections.Generic;
using System.Linq;
using LibraryApp.Data.API;
using LibraryApp.Data.Implementation;


namespace LibraryApp.Logic
{
    public class BusinessLogic
    {
        private readonly IDataLayer _data;
        private readonly IDataGenerator _factory;

        public BusinessLogic(IDataLayer data, IDataGenerator factory)
        {
            _data = data;
            _factory = factory;
        }

        public void AddUser(int id, string name)
        {
            var user = _factory.CreateUser(id, name);
            _data.Users.Add(user);
        }

        public void AddProduct(int id, string name, int quantity)
        {
            var product = _factory.CreateProduct(id, name, quantity);
            _data.Catalog[id] = product;
        }

        public void BorrowProduct(int productId)
        {
            if (_data.Catalog.TryGetValue(productId, out var product) && product.Quantity > 0)
            {
                product.Quantity--;
                var evt = _factory.CreateBorrowEvent(_data.Events.Count + 1, $"Product ID {productId} borrowed.");
                _data.Events.Add(evt);
            }
            else
            {
                throw new InvalidOperationException("Product unavailable.");
            }
        }

        public List<IUser> GetUsers() => _data.Users;

        public List<IProduct> GetProducts() => _data.Catalog.Values.ToList();

        public List<IEvent> GetEvents() => _data.Events;

    }
}
