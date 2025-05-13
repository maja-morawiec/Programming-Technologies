using System;
using System.Runtime.CompilerServices;
using LibraryApp.Data.API;

[assembly: InternalsVisibleTo("LibraryApp.Tests")]

namespace LibraryApp.Data.Implementation
{
    internal class DataGenerator : IDataGenerator
    {
        public IUser CreateUser(int id, string name) => new Reader { Id = id, Name = name };
        public IProduct CreateProduct(int id, string name, int quantity) => new Book { Id = id, Name = name, Quantity = quantity };
        public IEvent CreateBorrowEvent(int id, string description) => new BorrowEvent { Id = id, Description = description, Timestamp = DateTime.Now };
    }
}
