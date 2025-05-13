using System.Collections.Generic;
using System.Runtime.CompilerServices;
using LibraryApp.Data.API;

[assembly: InternalsVisibleTo("LibraryApp.Tests")]

namespace LibraryApp.Data.Implementation
{
    internal class DataLayer : IDataLayer
    {
        public List<IUser> Users { get; } = new List<IUser>();
        public Dictionary<int, IProduct> Catalog { get; } = new Dictionary<int, IProduct>();
        public List<IEvent> Events { get; } = new List<IEvent>();
    }
}
