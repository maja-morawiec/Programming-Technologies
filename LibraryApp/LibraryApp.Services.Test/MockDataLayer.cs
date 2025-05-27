using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibraryApp.Data.API;
using LibraryApp.Data.Implementation;

namespace LibraryApp.Service.Test.Mock
{
    internal class MockDataLayer : IDataLayer
    {
        private readonly Dictionary<int, IUser> _users = new Dictionary<int, IUser>();
        private readonly Dictionary<int, IProduct> _products = new Dictionary<int, IProduct>();
        private readonly Dictionary<int, IEvent> _events = new Dictionary<int, IEvent>();

        // --- Users ---
        public override void AddUser(int id, string name)
        {
            _users[id] = new MockUser(id, name);
        }

        public override void RemoveUser(int id)
        {
            _users.Remove(id);
        }

        public override void UpdateUser(int id, string name)
        {
            if (_users.TryGetValue(id, out var user))
            {
                user.Name = name;
            }
        }


        public override IUser GetUser(int id)
        {
            return _users.TryGetValue(id, out var user) ? user : null;
        }

        public override IEnumerable<IUser> GetAllUsers()
        {
            return _users.Values.ToList();
        }

        // --- Products ---
        public override void AddProduct(int id, string name, int quantity)
        {
            _products[id] = new MockProduct(id, name, quantity);
        }

        public override void RemoveProduct(int id)
        {
            _products.Remove(id);
        }

        public override void UpdateProduct(int id, string name, int quantity)
        {
            if (_products.TryGetValue(id, out var product))
            {
                product.Name = name;
                product.Quantity = quantity;
            }
        }


        public override IProduct GetProduct(int id)
        {
            return _products.TryGetValue(id, out var product) ? product : null;
        }

        public override IEnumerable<IProduct> GetAllProducts()
        {
            return _products.Values.ToList();
        }

        // --- Events ---
        public override void AddEvent(int id, string description, DateTime timestamp)
        {
            _events[id] = new MockEvent(id, description, timestamp);
        }

        public override void RemoveEvent(int id)
        {
            _events.Remove(id);
        }

        public override void UpdateEvent(int id, string description, DateTime timestamp)
        {
            if (_events.TryGetValue(id, out var ev))
            {
                ev.Description = description;
                ev.Timestamp = timestamp;
            }
        }


        public override IEvent GetEvent(int id)
        {
            return _events.TryGetValue(id, out var ev) ? ev : null;
        }

        public override IEnumerable<IEvent> GetAllEvents()
        {
            return _events.Values.ToList();
        }

        
        public override void SaveChanges()
        {
            
        }

        public override void BorrowProduct(int productId)
        {
            if (_products.TryGetValue(productId, out var product))
            {
                product.Quantity -= 1;
            }
        }

    }
}
