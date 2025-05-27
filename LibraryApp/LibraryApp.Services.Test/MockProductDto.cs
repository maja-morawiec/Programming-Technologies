using System.Runtime.CompilerServices;
using LibraryApp.Data.API;
[assembly: InternalsVisibleTo("LibraryApp.Service.Test")]

namespace LibraryApp.Service.Test.Mock
{
    internal class MockProduct : IProduct
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Quantity { get; set; }

        public MockProduct(int id, string name, int quantity)
        {
            Id = id;
            Name = name;
            Quantity = quantity;
        }
    }
}
