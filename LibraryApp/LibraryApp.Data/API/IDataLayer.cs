using System;
using System.Collections.Generic;
using LibraryApp.Data.Implementation;

namespace LibraryApp.Data.API
{
    public abstract class IDataLayer
    {
        // --- Users ---
        public abstract void AddUser(int id, string name);
        public abstract void RemoveUser(int id);
        public abstract void UpdateUser(int id, string name);
        public abstract IUser GetUser(int id);
        public abstract IEnumerable<IUser> GetAllUsers();

        // --- Products ---
        public abstract void AddProduct(int id, string name, int quantity);
        public abstract void RemoveProduct(int id);
        public abstract void UpdateProduct(int id, string name, int quantity);
        public abstract IProduct GetProduct(int id);
        public abstract IEnumerable<IProduct> GetAllProducts();

        // --- Events ---
        public abstract void AddEvent(int id, string description, DateTime timestamp);
        public abstract void RemoveEvent(int id);
        public abstract void UpdateEvent(int id, string description, DateTime timestamp);

        public abstract IEvent GetEvent(int id);
        public abstract IEnumerable<IEvent> GetAllEvents();

        // --- Persistence ---
        public abstract void SaveChanges();
        public abstract void BorrowProduct(int productId);

        // --- Factory ---
        public static IDataLayer CreateDataLayer()
        {
            return new DataLayer();
        }
    }

}
