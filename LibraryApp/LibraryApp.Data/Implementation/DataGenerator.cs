using System;
using System.Runtime.CompilerServices;
using LibraryApp.Data.API;

[assembly: InternalsVisibleTo("LibraryApp.Tests")]

namespace LibraryApp.Data.Implementation
{
    internal class DataGenerator : IDataGenerator
    {
        public IUser CreateUser(int id, string name) => new Reader (id, name);
        public IProduct CreateProduct(int id, string name, int quantity) => new Book (id, name, quantity);
        public IEvent CreateBorrowEvent(int id, string description) => new BorrowEvent (id, description, DateTime.Now);
    }
}
