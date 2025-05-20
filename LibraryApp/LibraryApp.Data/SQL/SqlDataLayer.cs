using System;
using System.Collections.Generic;
using System.Linq;
using LibraryApp.Data.API;
using LibraryApp.Data.Implementation;

namespace LibraryApp.Data
{
    public class SqlDataLayer : IDataLayer
    {
        private readonly DataClasses1DataContext _context;

        public SqlDataLayer()
        {
            _context = new DataClasses1DataContext();
        }

        // --- USERS ---

        public override void AddUser(int id, string name)
        {
            var entity = new Users
            {
                Id = id,
                Name = name
            };
            _context.Users.InsertOnSubmit(entity);
        }

        public override void RemoveUser(int id)
        {
            var user = _context.Users.FirstOrDefault(u => u.Id == id);
            if (user != null)
                _context.Users.DeleteOnSubmit(user);
        }

        public override void UpdateUser(int id, string name)
        {
            var user = _context.Users.FirstOrDefault(u => u.Id == id);
            if (user != null)
                user.Name = name;
        }

        public override IUser GetUser(int id)
        {
            var user = _context.Users.FirstOrDefault(u => u.Id == id);
            if (user == null)
                return null;

            return new Reader(user.Id, user.Name);
        }

        public override IEnumerable<IUser> GetAllUsers()
        {
            return _context.Users
                .Select(u => new Reader(u.Id, u.Name))
                .Cast<IUser>()
                .ToList();
        }

        // --- PRODUCTS ---

        public override void AddProduct(int id, string name, int quantity)
        {
            var entity = new Products
            {
                Id = id,
                Name = name,
                Quantity = quantity
            };
            _context.Products.InsertOnSubmit(entity);
        }

        public override void RemoveProduct(int id)
        {
            var product = _context.Products.FirstOrDefault(p => p.Id == id);
            if (product != null)
                _context.Products.DeleteOnSubmit(product);
        }

        public override void UpdateProduct(int id, string name, int quantity)
        {
            var product = _context.Products.FirstOrDefault(p => p.Id == id);
            if (product != null)
            {
                product.Name = name;
                product.Quantity = quantity;
            }
        }

        public override IProduct GetProduct(int id)
        {
            var product = _context.Products.FirstOrDefault(p => p.Id == id);
            if (product == null)
                return null;

            // Bezpieczne rzutowanie z int? i obsługa nullable
            int quantity = product.Quantity ?? 0;

            return new Book(product.Id, product.Name, quantity);
        }

        public override IEnumerable<IProduct> GetAllProducts()
        {
            return _context.Products
                .Select(p => new Book(p.Id, p.Name, p.Quantity ?? 0))
                .Cast<IProduct>()
                .ToList();
        }

        // --- EVENTS ---

        public override void AddEvent(int id, string description, DateTime timestamp)
        {
            var entity = new Events
            {
                Id = id,
                Description = description,
                Timestamp = timestamp
            };
            _context.Events.InsertOnSubmit(entity);
        }

        public override void RemoveEvent(int id)
        {
            var ev = _context.Events.FirstOrDefault(e => e.Id == id);
            if (ev != null)
                _context.Events.DeleteOnSubmit(ev);
        }

        public override void UpdateEvent(int id, string description, DateTime timestamp)
        {
            var ev = _context.Events.FirstOrDefault(e => e.Id == id);
            if (ev != null)
            {
                ev.Description = description;
                ev.Timestamp = timestamp;
            }
        }

        public override IEvent GetEvent(int id)
        {
            var ev = _context.Events.FirstOrDefault(e => e.Id == id);
            if (ev == null)
                return null;

            // Bezpieczne rzutowanie DateTime? na DateTime
            DateTime timestamp = ev.Timestamp ?? DateTime.MinValue;

            return new BorrowEvent(ev.Id, ev.Description, timestamp);
        }

        public override IEnumerable<IEvent> GetAllEvents()
        {
            return _context.Events
                .Select(e => new BorrowEvent(e.Id, e.Description, e.Timestamp ?? DateTime.MinValue))
                .Cast<IEvent>()
                .ToList();
        }

        // --- BorrowProduct ---

        public override void BorrowProduct(int productId)
        {
            var product = _context.Products.FirstOrDefault(p => p.Id == productId);
            if (product == null)
                throw new KeyNotFoundException("Product not found.");

            int quantity = product.Quantity ?? 0;
            if (quantity <= 0)
                throw new InvalidOperationException("Product is out of stock.");

            product.Quantity = quantity - 1;
        }

        // --- Save ---

        public override void SaveChanges()
        {
            _context.SubmitChanges();
        }
    }
}
