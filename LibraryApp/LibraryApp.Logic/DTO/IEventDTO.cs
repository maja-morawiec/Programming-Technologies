using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryApp.Logic.DTO
{
    public interface IEventDTO
    {
        int Id { get; }
        string Description { get; }
        DateTime Timestamp { get; }
    }
}
