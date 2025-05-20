using System;
using LibraryApp.Data.API;

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
