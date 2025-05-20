using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibraryApp.PresentationL.Model.API;
using LibraryApp.PresentationL.ViewModels;
using System.Windows.Input;

namespace LibraryApp.PresentationL.ViewModel
{
    internal class VMEventList : PropertyChange
    {
        private readonly IModel _model;

        private ObservableCollection<VMEvent> eventVMList;
        private VMEvent selectedVMEvent;

        public ObservableCollection<VMEvent> EventVMList
        {
            get => eventVMList;
            set => SetProperty(ref eventVMList, value);
        }

        public VMEvent SelectedVMEvent
        {
            get => selectedVMEvent;
            set => SetProperty(ref selectedVMEvent, value);
        }

        public ICommand RefreshCommand { get; }

        public VMEventList(IModel model)
        {
            _model = model ?? throw new ArgumentNullException(nameof(model));
            RefreshCommand = new RelayCommand(async _ => await RefreshEvents());
            _ = RefreshEvents();
        }

        private async Task RefreshEvents()
        {
            // Jeśli masz async metodę modelu, możesz ją wywołać asynchronicznie
            // Tutaj przykładowo zakładam synchroniczne GetAllEvents(), dostosuj jeśli trzeba
            var events = _model.GetAllEvents();

            EventVMList.Clear();
            foreach (var e in events)
            {
                EventVMList.Add(new VMEvent(e.Id, e.Description, e.Timestamp));
            }
        }
    }
}
