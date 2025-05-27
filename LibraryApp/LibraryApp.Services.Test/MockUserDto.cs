using System.Runtime.CompilerServices;
using LibraryApp.Data.API;
[assembly: InternalsVisibleTo("LibraryApp.Service.Test")]

namespace LibraryApp.Service.Test.Mock
{
    internal class MockUser : IUser
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public MockUser(int id, string name)
        {
            Id = id;
            Name = name;
        }
    }
}


