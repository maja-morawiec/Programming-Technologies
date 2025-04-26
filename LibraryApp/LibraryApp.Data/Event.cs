using System;

namespace LibraryApp.Data
{
    public abstract class Event //tu?
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public DateTime Timestamp { get; set; }
    }
}
