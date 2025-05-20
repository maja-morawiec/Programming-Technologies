using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using LibraryApp.PresentationL.Model.API;

namespace LibraryApp.PresentationL.Model.Implementation
{
    public class ProductDto : IProductDto
    {
        public ProductDto(int id, string name, int quantity)
        {
            this.Id = id;
            this.Name = name;
            this.Name = name;
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public int Quantity { get; set; }
    }
}

