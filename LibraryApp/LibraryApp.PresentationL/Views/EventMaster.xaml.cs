using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using LibraryApp.PresentationL.Model.API;
using LibraryApp.PresentationL.ViewModel;

namespace LibraryApp.PresentationL.Views
{
    public partial class EventMaster : UserControl
    {
        public EventMaster(IModel model)
        {
            InitializeComponent();
            DataContext = new VMEventList(model);
        }
    }
}
