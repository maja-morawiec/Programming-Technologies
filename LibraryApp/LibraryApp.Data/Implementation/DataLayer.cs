using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using LibraryApp.Data.API;

[assembly: InternalsVisibleTo("LibraryApp.Tests")]
[assembly: InternalsVisibleTo("LibraryApp.Logic")]

namespace LibraryApp.Data.Implementation
{
    internal class DataLayer : IDataLayer
    {
        public List<IUser> Users { get; private set; }
        public Dictionary<int, IProduct> Catalog { get; private set; }
        public List<IEvent> Events { get; private set; }

        public DataLayer()
        {
            Users = new List<IUser>();
            Catalog = new Dictionary<int, IProduct>();
            Events = new List<IEvent>();
        }

        public void AddUser(IUser user)
        {
            Users.Add(user);
        }

        public void RemoveUser(int userId)
        {
            Users.RemoveAll(u => u.Id == userId);
        }

        public void UpdateUser(IUser user)
        {
            for (int i = 0; i < Users.Count; i++)
            {
                if (Users[i].Id == user.Id)
                {
                    Users[i] = user;
                    return;
                }
            }
        }

        public void AddProduct(IProduct product)
        {
            Catalog[product.Id] = product;
        }

        public void RemoveProduct(int productId)
        {
            Catalog.Remove(productId);
        }

        public void UpdateProduct(IProduct product)
        {
            if (Catalog.ContainsKey(product.Id))
            {
                Catalog[product.Id] = product;
            }
        }

        public void AddEvent(IEvent evt)
        {
            Events.Add(evt);
        }

        public void RemoveEvent(int eventId)
        {
            Events.RemoveAll(e => e.Id == eventId);
        }

        public void UpdateEvent(IEvent evt)
        {
            for (int i = 0; i < Events.Count; i++)
            {
                if (Events[i].Id == evt.Id)
                {
                    Events[i] = evt;
                    return;
                }
            }
        }

        public void SaveChanges()
        {
            
        }
    }
}
