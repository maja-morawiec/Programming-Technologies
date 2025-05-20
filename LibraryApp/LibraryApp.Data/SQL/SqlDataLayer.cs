using System;
using System.Collections.Generic;
using System.Linq;
using LibraryApp.Data.API;

namespace LibraryApp.Data 
{
    public class SqlDataLayer : IDataLayer
    {
        private readonly DataClasses1DataContext _context;

        public SqlDataLayer()
        {
            _context = new DataClasses1DataContext();
        }

        public List<IUser> Users => _context.Users.Cast<IUser>().ToList();

        public Dictionary<int, IProduct> Catalog => _context.Products
            .Cast<IProduct>()
            .ToDictionary(p => p.Id);

        public List<IEvent> Events => _context.Events.Cast<IEvent>().ToList();

        public void AddUser(IUser user)
        {
            _context.Users.InsertOnSubmit((Users)user);
        }

        public void RemoveUser(int id)
        {
            var user = _context.Users.FirstOrDefault(u => u.Id == id);
            if (user != null)
            {
                _context.Users.DeleteOnSubmit(user);
            }
        }

        public void UpdateUser(IUser user)
        {
            var existing = _context.Users.FirstOrDefault(u => u.Id == user.Id);
            if (existing != null)
            {
                existing.Name = user.Name;
            }
        }

        public void AddProduct(IProduct product)
        {
            _context.Products.InsertOnSubmit((Products)product);
        }

        public void RemoveProduct(int id)
        {
            var product = _context.Products.FirstOrDefault(p => p.Id == id);
            if (product != null)
            {
                _context.Products.DeleteOnSubmit(product);
            }
        }

        public void UpdateProduct(IProduct product)
        {
            var existing = _context.Products.FirstOrDefault(p => p.Id == product.Id);
            if (existing != null)
            {
                existing.Name = product.Name;
                existing.Quantity = product.Quantity;
            }
        }

        public void AddEvent(IEvent evt)
        {
            _context.Events.InsertOnSubmit((Events)evt);
        }

        public void RemoveEvent(int id)
        {
            var ev = _context.Events.FirstOrDefault(e => e.Id == id);
            if (ev != null)
            {
                _context.Events.DeleteOnSubmit(ev);
            }
        }

        public void UpdateEvent(IEvent evt)
        {
            var existing = _context.Events.FirstOrDefault(e => e.Id == evt.Id);
            if (existing != null)
            {
                existing.Description = evt.Description;
                existing.Timestamp = evt.Timestamp;
            }
        }

        public void SaveChanges()
        {
            _context.SubmitChanges();
        }
    }
}
