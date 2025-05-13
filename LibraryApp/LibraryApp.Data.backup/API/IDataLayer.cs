using System.Collections.Generic;

namespace LibraryApp.Data.API
{
    public interface IDataLayer
    {
        List<IUser> Users { get; }
        Dictionary<int, IProduct> Catalog { get; }
        List<IEvent> Events { get; }
    }
}

