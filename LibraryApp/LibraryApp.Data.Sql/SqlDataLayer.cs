using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibraryApp.Data.API;
using LibraryApp.Data.Sql;

namespace LibraryApp.Data.Sql
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
            _context.SubmitChanges();
        }

        public void AddProduct(IProduct product)
        {
            _context.Products.InsertOnSubmit((Products)product);
            _context.SubmitChanges();
        }

        public void AddEvent(IEvent evt)
        {
            _context.Events.InsertOnSubmit((Events)evt);
            _context.SubmitChanges();
        }
    }
}
