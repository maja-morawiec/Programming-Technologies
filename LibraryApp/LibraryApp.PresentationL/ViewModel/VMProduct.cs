using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryApp.PresentationL.ViewModel
{
    internal class VMProduct : PropertyChange
    {
        private int id;
        private string name;
        private int quantity;

        public VMProduct()
        {
            id = 0;
            name = string.Empty;
            quantity = 0;
        }

        public VMProduct(int id, string name, int quantity)
        {
            this.id = id;
            this.name = name;
            this.quantity = quantity;
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

        public int Quantity
        {
            get => quantity;
            set => SetProperty(ref quantity, value);
        }
    }
}
