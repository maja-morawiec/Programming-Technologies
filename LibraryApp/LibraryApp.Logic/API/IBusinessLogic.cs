using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using LibraryApp.Data.API;
using LibraryApp.Service.API;
using LibraryApp.Service.Implementation;

namespace LibraryApp.Service
{
    public abstract class IBusinessLogic
    {
        // ----------- Users ------------
        public abstract Task AddUser(int id, string name);
        public abstract Task UpdateUser(int id, string name);
        public abstract Task RemoveUser(int userId);
        public abstract List<IUserDTO> GetAllUsers();

        // ----------- Products ----------
        public abstract Task AddProduct(int id, string name, int quantity);
        public abstract Task UpdateProduct(int id, string name, int quantity);
        public abstract Task RemoveProduct(int productId);
        public abstract List<IProductDTO> GetAllProducts();

        // ------------ Events -----------
        public abstract Task AddEvent(int id, string description, DateTime timestamp);
        public abstract Task UpdateEvent(int id, string description, DateTime timestamp);
        public abstract Task RemoveEvent(int eventId);
        public abstract List<IEventDTO> GetAllEvents();

        // ---------- Business Logic ----------
        public abstract Task BorrowProduct(int productId);

        // ----------- Factory --------------
        public static IBusinessLogic CreateNewService(IDataLayer layer)
        {
            return new BusinessLogic(layer);
        }

        public static IBusinessLogic CreateNewService()
        {
            return new BusinessLogic();
        }
    }
}
