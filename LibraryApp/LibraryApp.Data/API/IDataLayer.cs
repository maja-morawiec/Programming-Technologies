using System.Collections.Generic;

namespace LibraryApp.Data.API
{
    public interface IDataLayer
    {
        List<IUser> Users { get; }
        Dictionary<int, IProduct> Catalog { get; }
        List<IEvent> Events { get; }

        void AddUser(IUser user);
        void RemoveUser(int id);
        void UpdateUser(IUser user);

        void AddProduct(IProduct product);
        void RemoveProduct(int id);
        void UpdateProduct(IProduct product);

        void AddEvent(IEvent evt);
        void RemoveEvent(int id);
        void UpdateEvent(IEvent evt);

        void SaveChanges();
    }

}
