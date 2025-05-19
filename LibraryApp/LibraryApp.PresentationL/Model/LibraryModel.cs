using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibraryApp.Logic;

namespace LibraryApp.PresentationL.Model
{
    class LibraryModel //cos tu nie dziala to narazie sie pozbylam
    {
        /*private readonly IBusinessLogic _logic;

        public LibraryModel(IBusinessLogic logic)
        {
            _logic = logic;
        }

        // --- Users ---
        public List<UserDto> GetUsers() =>
            _logic.GetAllUsers().Select(u => new UserDto { Id = u.Id, Name = u.Name }).ToList();

        public void AddUser(UserDto dto) => _logic.AddUser(dto.Id, dto.Name);
        public void DeleteUser(int id) => _logic.DeleteUser(id);

        // --- Events ---
        public List<EventDto> GetEvents() =>
            _logic.GetAllEvents().Select(e => new EventDto { Id = e.Id, Title = e.Title }).ToList();

        public void AddEvent(EventDto dto) => _logic.AddEvent(dto.Id, dto.Title);
        public void DeleteEvent(int id) => _logic.DeleteEvent(id);

        // --- Products ---
        public List<ProductDto> GetProducts() =>
            _logic.GetAllProducts().Select(p => new ProductDto { Id = p.Id, Name = p.Name }).ToList();

        public void AddProduct(ProductDto dto) => _logic.AddProduct(dto.Id, dto.Name);
        public void DeleteProduct(int id) => _logic.DeleteProduct(id);*/
    }
}
