using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LibraryApp.Data.API;
using LibraryApp.Data.Implementation;
using LibraryApp.Service.API;
using LibraryApp.Service.Implementation;

namespace LibraryApp.Service
{
    internal class BusinessLogic : IBusinessLogic
    {
        private readonly IDataLayer _dataLayer;

        internal BusinessLogic(IDataLayer layer = null)
        {
            _dataLayer = layer ?? IDataLayer.CreateDataLayer();
        }

        // ----------- Users ----------

        public async override Task AddUser(int id, string name)
        {
            await Task.Run(() => _dataLayer.AddUser(id, name));
        }

        public async override Task UpdateUser(int id, string name)
        {
            await Task.Run(() => _dataLayer.UpdateUser(id, name));
        }

        public async override Task RemoveUser(int userId)
        {
            await Task.Run(() => _dataLayer.RemoveUser(userId));
        }

        public override List<IUserDTO> GetAllUsers()
        {
            var dataUsers = _dataLayer.GetAllUsers();
            var result = new List<IUserDTO>();
            foreach (var user in dataUsers)
            {
                result.Add(new UserDTO(user.Id, user.Name));
            }
            return result;
        }

        // ----------- Products ----------

        public async override Task AddProduct(int id, string name, int quantity)
        {
            await Task.Run(() => _dataLayer.AddProduct(id, name, quantity));
        }

        public async override Task UpdateProduct(int id, string name, int quantity)
        {
            await Task.Run(() => _dataLayer.UpdateProduct(id, name, quantity));
        }

        public async override Task RemoveProduct(int productId)
        {
            await Task.Run(() => _dataLayer.RemoveProduct(productId));
        }

        public override List<IProductDTO> GetAllProducts()
        {
            var dataProducts = _dataLayer.GetAllProducts();
            var result = new List<IProductDTO>();
            foreach (var product in dataProducts)
            {
                result.Add(new ProductDTO(product.Id, product.Name, product.Quantity));
            }
            return result;
        }

        // ----------- Events ------------

        public async override Task AddEvent(int id, string description, DateTime timestamp)
        {
            await Task.Run(() => _dataLayer.AddEvent(id, description, timestamp));
        }

        public async override Task UpdateEvent(int id, string description, DateTime timestamp)
        {
            await Task.Run(() => _dataLayer.UpdateEvent(id, description, timestamp));
        }

        public async override Task RemoveEvent(int eventId)
        {
            await Task.Run(() => _dataLayer.RemoveEvent(eventId));
        }

        public override List<IEventDTO> GetAllEvents()
        {
            var dataEvents = _dataLayer.GetAllEvents();
            if (dataEvents == null)
            {
                throw new InvalidOperationException("Metoda _dataLayer.GetAllEvents() zwróciła null!");
            }

            var result = new List<IEventDTO>();
            foreach (var evt in dataEvents)
            {
                result.Add(new EventDTO(evt.Id, evt.Description, evt.Timestamp));
            }
            return result;
        }


        // ----------- Business Logic ------------

        public async override Task BorrowProduct(int productId)
        {
            await Task.Run(() => _dataLayer.BorrowProduct(productId));
        }
    }
}
