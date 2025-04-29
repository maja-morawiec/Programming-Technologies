using System.Collections.Generic;

namespace LibraryApp.Data
{
    public class DataLayer : IDataLayer
    {
        public List<User> Users { get; } = new List<User>();
        public Dictionary<int, Product> Catalog { get; } = new Dictionary<int, Product>();
        public List<Event> Events { get; } = new List<Event>();

       
        
    }
}
