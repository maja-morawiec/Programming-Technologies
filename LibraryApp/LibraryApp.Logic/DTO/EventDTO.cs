using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryApp.Logic.DTO
{
    class EventDTO : IEventDTO
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public DateTime Timestamp { get; set; }
        public EventDTO(int id, string description, DateTime timestamp)
        {
            this.Id = id;
            this.Description = description;
            this.Timestamp = timestamp;
        }
    }
}
