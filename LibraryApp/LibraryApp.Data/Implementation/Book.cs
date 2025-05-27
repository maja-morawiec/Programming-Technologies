using System.Runtime.CompilerServices;
using LibraryApp.Data.API;
[assembly: InternalsVisibleTo("LibraryApp.Data.Test")]

namespace LibraryApp.Data.Implementation
{
    internal class Book : IProduct
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Quantity { get; set; }
        public Book(int id, string name, int quantity)
        {
            this.Id = id;
            this.Quantity = quantity;
            this.Name = name;
        }
    }
}
