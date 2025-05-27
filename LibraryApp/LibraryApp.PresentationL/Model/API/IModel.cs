using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibraryApp.Service.API;
using LibraryApp.Service.Implementation;

using LibraryApp.PresentationL.Model.Implementation;

namespace LibraryApp.PresentationL.Model.API
{
    public abstract class IModel
    {
        public abstract List<IUserDto> GetAllUsers();
        public abstract Task AddUser(int id, string name);
        public abstract Task UpdateUser(int id, string name);
        public abstract Task RemoveUser(int userId);

        public abstract List<IProductDto> GetAllProducts();
        public abstract Task AddProduct(int id, string name, int quantity);
        public abstract Task UpdateProduct(int id, string name, int quantity);
        public abstract Task RemoveProduct(int productId);

        public abstract List<IEventDto> GetAllEvents();
        public abstract Task AddEvent(int id, string description, DateTime timestamp);
        public abstract Task UpdateEvent(int id, string description, DateTime timestamp);
        public abstract Task RemoveEvent(int eventId);

        public abstract Task BorrowProduct(int productId);

        public static IModel CreateNewModel()
        {
            return new ModelDefault();
        }
    }
}
