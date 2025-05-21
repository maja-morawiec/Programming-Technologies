using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibraryApp.PresentationL.Model.API;
using LibraryApp.PresentationL.ViewModels;
using System.Windows.Input;
using System.ComponentModel;
using System.Data.Odbc;

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
        public ICommand AddCommand { get; }
        public ICommand RemoveCommand { get; }
        public ICommand UpdateCommand { get; }

        public VMEventList(IModel model)
        {
            _model = model ?? throw new ArgumentNullException(nameof(model));
            EventVMList = new ObservableCollection<VMEvent>(); // <- to dodaj
            RefreshCommand = new RelayCommand(async _ => await RefreshEvents());
            AddCommand = new RelayCommand(_ => AddEvent());
            RemoveCommand = new RelayCommand(_ => DeleteEvent(), _ => selectedVMEvent  != null);
            UpdateCommand = new RelayCommand(_ => UpdateEvent(), _ => selectedVMEvent != null);

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

        private void AddEvent()
        {
            var newEvent = new VMEvent(0, "New Event", DateTime.Now);
            _model.AddEvent(newEvent.Id, newEvent.Description, newEvent.Timestamp);
            _ = RefreshEvents();
        }

        private void DeleteEvent()
        {
            if(selectedVMEvent != null)
            {
                EventVMList.Remove(selectedVMEvent);
                SelectedVMEvent = EventVMList.Count > 0 ? EventVMList[0] : null;
            }
        }

        private void UpdateEvent()
        {
            _model.UpdateEvent(selectedVMEvent.Id, selectedVMEvent.Description, selectedVMEvent.Timestamp);
        }
    }
}
