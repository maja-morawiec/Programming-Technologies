using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using LibraryApp.PresentationL.Model.API;

namespace LibraryApp.PresentationL.Model.Implementation
{
    internal class ProductDto : IProductDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public int Year { get; set; }
    }
}

