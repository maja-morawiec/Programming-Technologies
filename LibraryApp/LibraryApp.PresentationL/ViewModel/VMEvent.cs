using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibraryApp.PresentationL.Model.Implementation;

namespace LibraryApp.PresentationL.ViewModel
{
    internal class VMEvent : PropertyChange
    {
        private int id;
        private string description;
        private DateTime timestamp;

        public VMEvent()
        {
            id = 0;
            description = string.Empty;
            timestamp = DateTime.MinValue;
        }

        public VMEvent(int id, string description, DateTime timestamp)
        {
            this.id = id;
            this.description = description;
            this.timestamp = timestamp;
        }

        public int Id
        {
            get => id;
            set => SetProperty(ref id, value);
        }

        public string Description
        {
            get => description;
            set => SetProperty(ref description, value);
        }

        public DateTime Timestamp
        {
            get => timestamp;
            set => SetProperty(ref timestamp, value);
        }
    }
}
