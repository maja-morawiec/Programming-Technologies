using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryApp.PresentationL.Model.API
{
    public interface IEventDto
    {
        int Id { get; set; }
        string Description { get; set; }
        DateTime Timestamp { get; set; }
    }
}

