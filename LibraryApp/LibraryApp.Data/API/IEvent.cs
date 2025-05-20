using System;

namespace LibraryApp.Data.API
{
    public interface IEvent
    {
        int Id { get; set; }
        string Description { get; set; }
        DateTime Timestamp { get; set; }
    }
}
