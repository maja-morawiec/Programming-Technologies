using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using LibraryApp.PresentationL.Model.API;
using LibraryApp.Service;
using LibraryApp.Service.API;
using LibraryApp.Service.Implementation;
using System.Xml.Linq;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("LibraryApp.PresentationL.Test")]


namespace LibraryApp.PresentationL.Model.Implementation
{
    internal class ModelDefault : IModel
    {
        private IBusinessLogic _logic;

        internal ModelDefault(IBusinessLogic logic = null)
        {
            _logic = logic ?? IBusinessLogic.CreateNewService();
        }

        // ----------- Mappers -----------

        private IUserDto UserToModel(IUserDTO u) =>
            u == null ? null : new UserDto(u.Id, u.Name);

        private IProductDto ProductToModel(IProductDTO p) =>
            p == null ? null : new ProductDto(p.Id, p.Name, p.Quantity);

        private IEventDto EventToModel(IEventDTO e) =>
            e == null ? null : new EventDto(e.Id, e.Description, e.Timestamp);

        // ----------- Users -----------

        public override List<IUserDto> GetAllUsers()
        {
            var users = _logic.GetAllUsers();
            var result = new List<IUserDto>();
            foreach (var u in users)
                result.Add(UserToModel(u));
            return result;
        }

        public async override Task AddUser(int id, string name)
        {
            //var user = new UserDTO(id, name);
            await Task.Run(() => _logic.AddUser(id, name));
        }

        public async override Task UpdateUser(int id, string name)
        {
            await Task.Run(() => _logic.UpdateUser(id, name));
        }

        public async override Task RemoveUser(int userId)
        {
            await Task.Run(() => _logic.RemoveUser(userId));
        }

        // ----------- Products -----------

        public override List<IProductDto> GetAllProducts()
        {
            var products = _logic.GetAllProducts();
            var result = new List<IProductDto>();
            foreach (var p in products)
                result.Add(ProductToModel(p));
            return result;
        }

        public async override Task AddProduct(int id, string name, int quantity)
        {
            //var product = new ProductDTO(id, name, quantity);
            await Task.Run(() => _logic.AddProduct(id, name, quantity));
        }

        public async override Task UpdateProduct(int id, string name, int quantity)
        {
            await Task.Run(() => _logic.UpdateProduct(id, name, quantity));
        }

        public async override Task RemoveProduct(int productId)
        {
            await Task.Run(() => _logic.RemoveProduct(productId));
        }

        // ----------- Events -----------

        public override List<IEventDto> GetAllEvents()
        {
            var events = _logic.GetAllEvents();
            var result = new List<IEventDto>();
            foreach (var e in events)
                result.Add(EventToModel(e));
            return result;
        }

        public async override Task AddEvent(int id, string description, DateTime timestamp)
        {
            //var evt = new EventDTO(id, description, timestamp);
            await Task.Run(() => _logic.AddEvent(id, description, timestamp));
        }

        public async override Task UpdateEvent(int id, string description, DateTime timestamp)
        {
            await Task.Run(() => _logic.UpdateEvent(id, description, timestamp));
        }

        public async override Task RemoveEvent(int eventId)
        {
            await Task.Run(() => _logic.RemoveEvent(eventId));
        }

        // ----------- Business Logic -----------

        public async override Task BorrowProduct(int productId)
        {
            await Task.Run(() => _logic.BorrowProduct(productId));
        }
    }
}
