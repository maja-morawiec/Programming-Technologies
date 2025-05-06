namespace LibraryApp.Data.API
{
    public interface IProduct
    {
        int Id { get; }
        string Name { get; }
        int Quantity { get; set; }
    }
}
