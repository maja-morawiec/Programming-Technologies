using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryApp.PresentationL.Model.API
{
    public interface IProductDto
    {
        int Id { get; set; }
        string Title { get; set; }
        string Author { get; set; }
        int Year { get; set; }
    }
}

