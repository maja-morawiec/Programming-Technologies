using System.Collections.Generic;

namespace LibraryApp.Data
{
    public class DataLayer : IDataLayer
    {
        public List<User> Users { get; } = new List<User>();
        public Dictionary<int, Product> Catalog { get; } = new Dictionary<int, Product>();
        public List<Event> Events { get; } = new List<Event>();

       
        public void SeedUsers()
        {
            Users.Add(new Reader { Id = 1, Name = "Anna" });
            Users.Add(new Reader { Id = 2, Name = "Tom" });
        }

        
        public void SeedCatalog()
        {
            Catalog[1] = new Book { Id = 1, Name = "Book", Quantity = 5 };
            Catalog[2] = new Book { Id = 2, Name = "Pen", Quantity = 10 };
        }
    }
}
