using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryApp.Data.API
{
    public interface ISqlDataLayer
    {
        // --- USERS ---
        void AddUser(int id, string name);
        void RemoveUser(int id);
        void UpdateUser(int id, string name);
        IUser GetUser(int id);
        IEnumerable<IUser> GetAllUsers();

        // --- PRODUCTS ---
        void AddProduct(int id, string name, int quantity);
        void RemoveProduct(int id);
        void UpdateProduct(int id, string name, int quantity);
        IProduct GetProduct(int id);
        IEnumerable<IProduct> GetAllProducts();

        // --- EVENTS ---
        void AddEvent(int id, string description, DateTime timestamp);
        void RemoveEvent(int id);
        void UpdateEvent(int id, string description, DateTime timestamp);
        IEvent GetEvent(int id);
        IEnumerable<IEvent> GetAllEvents();

        // --- BORROW ---
        void BorrowProduct(int productId);

        // --- SAVE ---
        void SaveChanges();
    }
}
