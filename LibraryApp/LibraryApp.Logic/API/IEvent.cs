using System;

namespace LibraryApp.Logic.API
{
    public interface IEvent
    {
        int Id { get; }
        string Description { get; }
        DateTime Timestamp { get; }
    }
}
