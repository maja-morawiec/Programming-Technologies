using LibraryApp.PresentationL.Model.API;
using LibraryApp.PresentationL.Model.Implementation;
using LibraryApp.Logic.DTO;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LibraryApp.PresentationL.Test
{
    public class MockModel : IModel
    {
        private readonly IModel _model;

        public MockModel(IModel model = null)
        {
            _model = model ?? new ModelDefault(); // Fallback to real model if not mocked
        }

        // --- USERS ---
        public override Task AddUser(int id, string name)
        {
            return _model.AddUser(id, name);
        }

        public override Task UpdateUser(int id, string name)
        {
            return _model.UpdateUser(id, name);
        }

        public override Task RemoveUser(int userId)
        {
            return _model.RemoveUser(userId);
        }

        public override List<IUserDto> GetAllUsers()
        {
            return _model.GetAllUsers();
        }

        // --- PRODUCTS ---
        public override Task AddProduct(int id, string name, int quantity)
        {
            return _model.AddProduct(id, name, quantity);
        }

        public override Task UpdateProduct(int id, string name, int quantity)
        {
            return _model.UpdateProduct(id, name, quantity);
        }

        public override Task RemoveProduct(int productId)
        {
            return _model.RemoveProduct(productId);
        }

        public override List<IProductDto> GetAllProducts()
        {
            return _model.GetAllProducts();
        }

        // --- EVENTS ---
        public override Task AddEvent(int id, string description, DateTime timestamp)
        {
            return _model.AddEvent(id, description, timestamp);
        }

        public override Task UpdateEvent(int id, string description, DateTime timestamp)
        {
            return _model.UpdateEvent(id, description, timestamp);
        }

        public override Task RemoveEvent(int eventId)
        {
            return _model.RemoveEvent(eventId);
        }

        public override List<IEventDto> GetAllEvents()
        {
            return _model.GetAllEvents();
        }

        // --- BUSINESS ---
        public override Task BorrowProduct(int productId)
        {
            return _model.BorrowProduct(productId);
        }
    }
}
