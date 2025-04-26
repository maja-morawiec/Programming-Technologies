using System.Collections.Generic;

namespace LibraryApp.Data
{
    public interface IDataLayer //czy tu tez abstract??
    {
        List<User> Users { get; }
        Dictionary<int, Product> Catalog { get; }
        List<Event> Events { get; }
    }
}
