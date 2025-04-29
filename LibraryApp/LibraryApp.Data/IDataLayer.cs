using System.Collections.Generic;

namespace LibraryApp.Data
{
    public interface IDataLayer
    {
        List<User> Users { get; }
        Dictionary<int, Product> Catalog { get; }
        List<Event> Events { get; }
    }
}
