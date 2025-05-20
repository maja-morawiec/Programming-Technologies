namespace LibraryApp.Data.API
{
    public interface IProduct
    {
        int Id { get; set;  }
        string Name { get; set; }
        int Quantity { get; set; }
    }
}
