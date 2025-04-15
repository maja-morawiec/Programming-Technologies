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
            Users.Add(new User { Id = 1, Name = "Anna" });
            Users.Add(new User { Id = 2, Name = "Tom" });
        }

        
        public void SeedCatalog()
        {
            Catalog[1] = new Product { Id = 1, Name = "Book", Quantity = 5 };
            Catalog[2] = new Product { Id = 2, Name = "Pen", Quantity = 10 };
        }
    }
}
