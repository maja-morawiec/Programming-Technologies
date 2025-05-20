using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using LibraryApp.PresentationL.Model.API;

namespace LibraryApp.PresentationL.Model.Implementation
{
    public class EventDto : IEventDto
    {
        public EventDto(int id, string description, DateTime timestamp)
        {
            this.Id = id;
            this.Description = description;
            this.Timestamp = timestamp;
        }

        public int Id { get; set; }
        public string Description { get; set; }
        public DateTime Timestamp { get; set; }
    }
}

