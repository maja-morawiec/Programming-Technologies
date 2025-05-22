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

        private int newEventId;
        private string newEventDescription;

        public int NewEventId
        {
            get => newEventId;
            set => SetProperty(ref newEventId, value);
        }

        public string NewEventDescription
        {
            get => newEventDescription;
            set => SetProperty(ref newEventDescription, value);
        }

        public ICommand RefreshCommand { get; }
        public ICommand AddCommand { get; }
        public ICommand RemoveCommand { get; }
        public ICommand UpdateCommand { get; }

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

        public VMEventList()
        {
            _model = IModel.CreateNewModel();
            eventVMList = new ObservableCollection<VMEvent>();
            RefreshCommand = new RelayCommand(_ => RefreshEvents(), _ => true);

            AddCommand = new RelayCommand(async _ => await AddEvent());
            RemoveCommand = new RelayCommand(async _ => await DeleteEvent(), _ => SelectedVMEvent != null);
            UpdateCommand = new RelayCommand(async _ => await UpdateEvent(), _ => SelectedVMEvent != null);

            RefreshEvents();
        }

        public VMEventList(IModel model)
        {
            //_ = RefreshEvents();
            _model = model;
            eventVMList = new ObservableCollection<VMEvent>();
            RefreshCommand = new RelayCommand(_ => RefreshEvents(), _ => true);
        }

        private async Task RefreshEvents()
        {
            var events = _model.GetAllEvents();
            EventVMList.Clear();

            foreach (var e in events)
            {
                EventVMList.Add(new VMEvent(e.Id, e.Description, e.Timestamp));
            }
        }

        private async Task AddEvent()
        {
            await _model.AddEvent(NewEventId, NewEventDescription, DateTime.Now);
            await RefreshEvents();

            // Czyść pola wejściowe
            NewEventId = 0;
            NewEventDescription = string.Empty;
        }

        private async Task DeleteEvent()
        {
            if (SelectedVMEvent == null) return;

            await _model.RemoveEvent(SelectedVMEvent.Id);
            await RefreshEvents();
        }

        private async Task UpdateEvent()
        {
            if (SelectedVMEvent == null) return;

            await _model.UpdateEvent(SelectedVMEvent.Id, SelectedVMEvent.Description, SelectedVMEvent.Timestamp);
            await RefreshEvents();
        }
    }
}
