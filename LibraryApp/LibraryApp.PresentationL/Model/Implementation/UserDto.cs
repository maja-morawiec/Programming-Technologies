using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using LibraryApp.PresentationL.Model.API;

namespace LibraryApp.PresentationL.Model.Implementation
{
    internal class UserDto : IUserDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}

