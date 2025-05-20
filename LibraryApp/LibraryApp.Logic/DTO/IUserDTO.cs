using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryApp.Logic.DTO
{
    public interface IUserDTO
    {
        int Id { get; set; }
        string Name { get; set; }
    }
}
