using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using LibraryApp.Data.API;

[assembly: InternalsVisibleTo("LibraryApp.Tests")]
[assembly: InternalsVisibleTo("LibraryApp.Logic")]
[assembly: InternalsVisibleTo("LibraryApp.Data.Test")]

namespace LibraryApp.Data.Implementation
{
    internal class DataLayer : IDataLayer
    {
        private List<IUser> _users;
        private Dictionary<int, IProduct> _catalog;
        private List<IEvent> _events;

        public DataLayer()
        {
            _users = new List<IUser>();
            _catalog = new Dictionary<int, IProduct>();
            _events = new List<IEvent>();
        }
        // --- USERS ---

        public override void AddUser(int id, string name)
        {
            _users.Add(new Reader (id, name));
        }

        public override void RemoveUser(int id)
        {
            _users.RemoveAll(u => u.Id == id);
        }

        public override void UpdateUser(int id, string name)
        {
            var user = _users.FirstOrDefault(u => u.Id == id);
            if (user != null)
            {
                user.Name = name;
            }
        }

        public override IUser GetUser(int id)
        {
            return _users.FirstOrDefault(u => u.Id == id);
        }

        public override IEnumerable<IUser> GetAllUsers()
        {
            return _users;
        }

        // --- PRODUCTS ---

        public override void AddProduct(int id, string name, int quantity)
        {
            _catalog[id] = new Book (id, name, quantity);
        }

        public override void RemoveProduct(int id)
        {
            _catalog.Remove(id);
        }

        public override void UpdateProduct(int id, string name, int quantity)
        {
            if (_catalog.TryGetValue(id, out var product) && product is Book book)
            {
                book.Name = name;
                book.Quantity = quantity;
            }
        }

        public override IProduct GetProduct(int id)
        {
            return _catalog.TryGetValue(id, out var product) ? product : null;
        }

        public override IEnumerable<IProduct> GetAllProducts()
        {
            return _catalog.Values;
        }

        // --- EVENTS ---

        public override void AddEvent(int id, string description, DateTime timestamp)
        {
            _events.Add(new BorrowEvent (id, description, timestamp));
        }

        public override void RemoveEvent(int id)
        {
            _events.RemoveAll(e => e.Id == id);
        }

        public override void UpdateEvent(int id, string description, DateTime timestamp)
        {
            var evt = _events.FirstOrDefault(e => e.Id == id) as BorrowEvent;
            if (evt != null)
            {
                evt.Description = description;
                evt.Timestamp = timestamp;
            }
        }
        public override IEvent GetEvent(int id)
        {
            return _events.FirstOrDefault(e => e.Id == id);
        }

        public override IEnumerable<IEvent> GetAllEvents()
        {
            return _events;
        }

        public override void SaveChanges()
        {
            // No-op for in-memory
        }

        public override void BorrowProduct(int productId)
        {
            if (_catalog.TryGetValue(productId, out var product) && product is Book book)
            {
                if (book.Quantity > 0)
                {
                    book.Quantity--;
                }
                else
                {
                    throw new InvalidOperationException("Product is out of stock.");
                }
            }
            else
            {
                throw new KeyNotFoundException("Product not found.");
            }
        }
    }
}
