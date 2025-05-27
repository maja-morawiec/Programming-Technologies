using System;
using System.Runtime.CompilerServices;
using LibraryApp.Data.API;
[assembly: InternalsVisibleTo("LibraryApp.Data.Test")]
namespace LibraryApp.Data.Implementation
{
    internal class BorrowEvent : IEvent
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public DateTime Timestamp { get; set; }
        public BorrowEvent(int id, string description, DateTime timestamp)
        {
            this.Description = description;
            this.Timestamp = timestamp;
            this.Id = id;
        }
    }
}
