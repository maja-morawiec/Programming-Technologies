using System.Runtime.CompilerServices;
using System;
using System.Collections.Generic;
using System.Linq;
using LibraryApp.Data.API;
using LibraryApp.Data.Implementation;

[assembly: InternalsVisibleTo("LibraryApp.Data.Test")]

namespace LibraryApp.Data.Implementation
{
    internal class SqlDataLayer : ISqlDataLayer
    {
        private readonly DataClasses1DataContext _context;

        public SqlDataLayer()
        {
            _context = new DataClasses1DataContext();
        }

        // --- USERS ---

        public void AddUser(int id, string name)
        {
            var entity = new Users { Id = id, Name = name };
            _context.Users.InsertOnSubmit(entity);
        }

        public void RemoveUser(int id)
        {
            var user = _context.Users.FirstOrDefault(u => u.Id == id);
            if (user != null)
                _context.Users.DeleteOnSubmit(user);
        }

        public void UpdateUser(int id, string name)
        {
            var user = _context.Users.FirstOrDefault(u => u.Id == id);
            if (user != null)
                user.Name = name;
        }

        public IUser GetUser(int id)
        {
            var user = _context.Users.FirstOrDefault(u => u.Id == id);
            if (user == null)
                return null;

            return new Reader(user.Id, user.Name);
        }

        public IEnumerable<IUser> GetAllUsers()
        {
            return _context.Users
                .Select(u => new Reader(u.Id, u.Name))
                .Cast<IUser>()
                .ToList();
        }

        // --- PRODUCTS ---

        public void AddProduct(int id, string name, int quantity)
        {
            var entity = new Products { Id = id, Name = name, Quantity = quantity };
            _context.Products.InsertOnSubmit(entity);
        }

        public void RemoveProduct(int id)
        {
            var product = _context.Products.FirstOrDefault(p => p.Id == id);
            if (product != null)
                _context.Products.DeleteOnSubmit(product);
        }

        public void UpdateProduct(int id, string name, int quantity)
        {
            var product = _context.Products.FirstOrDefault(p => p.Id == id);
            if (product != null)
            {
                product.Name = name;
                product.Quantity = quantity;
            }
        }

        public IProduct GetProduct(int id)
        {
            var product = _context.Products.FirstOrDefault(p => p.Id == id);
            if (product == null)
                return null;

            int quantity = product.Quantity ?? 0;
            return new Book(product.Id, product.Name, quantity);
        }

        public IEnumerable<IProduct> GetAllProducts()
        {
            return _context.Products
                .Select(p => new Book(p.Id, p.Name, p.Quantity ?? 0))
                .Cast<IProduct>()
                .ToList();
        }

        // --- EVENTS ---

        public void AddEvent(int id, string description, DateTime timestamp)
        {
            var entity = new Events { Id = id, Description = description, Timestamp = timestamp };
            _context.Events.InsertOnSubmit(entity);
        }

        public void RemoveEvent(int id)
        {
            var ev = _context.Events.FirstOrDefault(e => e.Id == id);
            if (ev != null)
                _context.Events.DeleteOnSubmit(ev);
        }

        public void UpdateEvent(int id, string description, DateTime timestamp)
        {
            var ev = _context.Events.FirstOrDefault(e => e.Id == id);
            if (ev != null)
            {
                ev.Description = description;
                ev.Timestamp = timestamp;
            }
        }

        public IEvent GetEvent(int id)
        {
            var ev = _context.Events.FirstOrDefault(e => e.Id == id);
            if (ev == null)
                return null;

            DateTime timestamp = ev.Timestamp ?? DateTime.MinValue;
            return new BorrowEvent(ev.Id, ev.Description, timestamp);
        }

        public IEnumerable<IEvent> GetAllEvents()
        {
            return _context.Events
                .Select(e => new BorrowEvent(e.Id, e.Description, e.Timestamp ?? DateTime.MinValue))
                .Cast<IEvent>()
                .ToList();
        }

        // --- BORROW ---

        public void BorrowProduct(int productId)
        {
            var product = _context.Products.FirstOrDefault(p => p.Id == productId);
            if (product == null)
                throw new KeyNotFoundException("Product not found.");

            int quantity = product.Quantity ?? 0;
            if (quantity <= 0)
                throw new InvalidOperationException("Product is out of stock.");

            product.Quantity = quantity - 1;
        }

        // --- SAVE ---

        public void SaveChanges()
        {
            _context.SubmitChanges();
        }
    }
}
