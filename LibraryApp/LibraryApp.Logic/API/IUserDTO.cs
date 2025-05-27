using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibraryApp.Service.Implementation;

namespace LibraryApp.Service.API
{
    public interface IUserDTO
    {
        int Id { get; set; }
        string Name { get; set; }
    }
}
