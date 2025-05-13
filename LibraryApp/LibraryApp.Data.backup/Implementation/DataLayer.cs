using System.Collections.Generic;
using System.Runtime.CompilerServices;
using LibraryApp.Data.API;

[assembly: InternalsVisibleTo("LibraryApp.Tests")]

namespace LibraryApp.Data.Implementation
{
    internal class DataLayer : IDataLayer
    {
        public List<IUser> Users { get; } = new();
        public Dictionary<int, IProduct> Catalog { get; } = new();
        public List<IEvent> Events { get; } = new();
    }
}
