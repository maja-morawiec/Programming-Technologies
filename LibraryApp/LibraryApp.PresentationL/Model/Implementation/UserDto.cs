using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using LibraryApp.PresentationL.Model.API;

namespace LibraryApp.PresentationL.Model.Implementation
{
    public class UserDto : IUserDto
    {
        public UserDto(int id, string name) 
        {
            this.Id = id;
            this.Name = name;
        }
        public int Id { get; set; }
        public string Name { get; set; }
    }
}

