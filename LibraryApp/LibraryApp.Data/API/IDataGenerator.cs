namespace LibraryApp.Data.API
{
    public interface IDataGenerator
    {
        IUser CreateUser(int id, string name);
        IProduct CreateProduct(int id, string name, int quantity);
        IEvent CreateBorrowEvent(int id, string description);
    }
}
