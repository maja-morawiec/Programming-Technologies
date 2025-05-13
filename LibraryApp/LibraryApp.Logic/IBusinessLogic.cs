using System;
using System.Collections.Generic;
using LibraryApp.Data.API;

namespace LibraryApp.Logic
{
    public interface IBusinessLogic
    {
        IEnumerable<IUser> GetAllUsers();
        void AddUser(int id, string name);
        void UpdateUser(IUser user);
        void DeleteUser(int userId);

        IEnumerable<IProduct> GetAllProducts();
        void AddProduct(int id, string name, int quantity);
        void UpdateProduct(IProduct product);
        void DeleteProduct(int productId);

        IEnumerable<IEvent> GetAllEvents();
        void AddEvent(int id, string description, DateTime timestamp);
        void UpdateEvent(IEvent evt);
        void DeleteEvent(int eventId);

        void BorrowProduct(int productId);
    }
}
