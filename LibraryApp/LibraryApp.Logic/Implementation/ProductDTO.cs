using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibraryApp.Service.API;

namespace LibraryApp.Service.Implementation
{
    internal class ProductDTO : IProductDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Quantity { get; set; }

        public ProductDTO(int id, string name, int quantity)
        {
            this.Id = id;
            this.Name = name;
            this.Quantity = quantity;
        }
    }
}