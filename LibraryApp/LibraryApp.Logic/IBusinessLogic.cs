using System;
using System.Collections.Generic;
using LibraryApp.Data.API;
using LibraryApp.Logic.DTO;

namespace LibraryApp.Logic
{
    public interface IBusinessLogic
    {
        // Users
        IEnumerable<IUserDTO> GetAllUsers();
        void AddUser(IUserDTO user);
        void UpdateUser(IUserDTO user);
        void DeleteUser(int userId);

        // Products
        IEnumerable<IProductDTO> GetAllProducts();
        void AddProduct(IProductDTO product);
        void UpdateProduct(IProductDTO product);
        void DeleteProduct(int productId);

        // Events
        IEnumerable<IEventDTO> GetAllEvents();
        void AddEvent(IEventDTO evt);
        void UpdateEvent(IEventDTO evt);
        void DeleteEvent(int eventId);

        // Logic
        void BorrowProduct(int productId);
    }
}
