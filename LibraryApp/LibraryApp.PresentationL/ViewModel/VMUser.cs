using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryApp.PresentationL.ViewModel
{
    internal class VMUser : PropertyChange
    {
        private int id;
        private string name;

        public VMUser()
        {
            id = 0;
            name = string.Empty;
        }

        public VMUser(int id, string name)
        {
            this.id = id;
            this.name = name;
        }

        public int Id
        {
            get => id;
            set => SetProperty(ref id, value);
        }

        public string Name
        {
            get => name;
            set => SetProperty(ref name, value);
        }
    }
}
