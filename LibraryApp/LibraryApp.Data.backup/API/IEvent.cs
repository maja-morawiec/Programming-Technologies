using System;

namespace LibraryApp.Data.API
{
    public interface IEvent
    {
        int Id { get; }
        string Description { get; }
        DateTime Timestamp { get; }
    }
}
