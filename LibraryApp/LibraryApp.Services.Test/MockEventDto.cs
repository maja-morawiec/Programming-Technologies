using LibraryApp.Data.API;
using System;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("LibraryApp.Service.Test")]
namespace LibraryApp.Service.Test.Mock
{
    internal class MockEvent : IEvent
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public DateTime Timestamp { get; set; }

        public MockEvent(int id, string description, DateTime timestamp)
        {
            Id = id;
            Description = description;
            Timestamp = timestamp;
        }
    }
}
