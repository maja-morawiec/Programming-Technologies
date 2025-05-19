using System;
using System.Collections.Generic;
using System.Linq;
using LibraryApp.Data.API;
using LibraryApp.Data.Implementation;
using LibraryApp.Logic.DTO;

namespace LibraryApp.Logic
{
    internal class BusinessLogic : IBusinessLogic
    {
        private readonly IDataLayer _data;

        public BusinessLogic(IDataLayer data)
        {
            _data = data;
        }

        // --- USERS ---

        public IEnumerable<IUserDTO> GetAllUsers() =>
            _data.Users.Select(u => new UserDTO { Id = u.Id, Name = u.Name });

        public void AddUser(IUserDTO userDto)
        {
            var user = new Data.Implementation.Reader { Id = userDto.Id, Name = userDto.Name };
            _data.AddUser(user);
            _data.SaveChanges();
        }

        public void UpdateUser(IUserDTO userDto)
        {
            var user = new Data.Implementation.Reader { Id = userDto.Id, Name = userDto.Name };
            _data.UpdateUser(user);
            _data.SaveChanges();
        }

        public void DeleteUser(int userId)
        {
            _data.RemoveUser(userId);
            _data.SaveChanges();
        }

        // --- PRODUCTS ---

        public IEnumerable<IProductDTO> GetAllProducts() =>
            _data.Catalog.Values.Select(p => new ProductDTO { Id = p.Id, Name = p.Name, Quantity = p.Quantity });

        public void AddProduct(IProductDTO productDto)
        {
            var product = new Data.Implementation.Book
            {
                Id = productDto.Id,
                Name = productDto.Name,
                Quantity = productDto.Quantity
            };
            _data.AddProduct(product);
            _data.SaveChanges();
        }

        public void UpdateProduct(IProductDTO productDto)
        {
            var product = new Data.Implementation.Book
            {
                Id = productDto.Id,
                Name = productDto.Name,
                Quantity = productDto.Quantity
            };
            _data.UpdateProduct(product);
            _data.SaveChanges();
        }

        public void DeleteProduct(int productId)
        {
            _data.RemoveProduct(productId);
            _data.SaveChanges();
        }

        // --- EVENTS ---

        public IEnumerable<IEventDTO> GetAllEvents() =>
            _data.Events.Select(e => new EventDTO
            {
                Id = e.Id,
                Description = e.Description,
                Timestamp = e.Timestamp
            });

        public void AddEvent(IEventDTO eventDto)
        {
            var ev = new Data.Implementation.BorrowEvent
            {
                Id = eventDto.Id,
                Description = eventDto.Description,
                Timestamp = eventDto.Timestamp
            };
            _data.AddEvent(ev);
            _data.SaveChanges();
        }

        public void UpdateEvent(IEventDTO eventDto)
        {
            var ev = new Data.Implementation.BorrowEvent
            {
                Id = eventDto.Id,
                Description = eventDto.Description,
                Timestamp = eventDto.Timestamp
            };
            _data.UpdateEvent(ev);
            _data.SaveChanges();
        }

        public void DeleteEvent(int eventId)
        {
            _data.RemoveEvent(eventId);
            _data.SaveChanges();
        }

        // --- BORROW PRODUCT ---

        public void BorrowProduct(int productId)
        {
            if (!_data.Catalog.TryGetValue(productId, out var product) || product.Quantity <= 0)
            {
                throw new InvalidOperationException("Product unavailable");
            }

            product.Quantity -= 1;

            var borrowEvent = new Data.Implementation.BorrowEvent
            {
                Id = _data.Events.Count + 1,
                Description = $"Product {product.Name} borrowed",
                Timestamp = DateTime.Now
            };

            _data.UpdateProduct(product);
            _data.AddEvent(borrowEvent);
            _data.SaveChanges();
        }
    }
}
