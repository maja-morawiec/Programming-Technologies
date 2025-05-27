using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using LibraryApp.Service.API;
using LibraryApp.Service.Implementation;
using LibraryApp.PresentationL.ViewModel;
using System.Windows.Input;
using LibraryApp.PresentationL.Model.API;

namespace LibraryApp.PresentationL.ViewModels
{
    internal class MainViewModel : PropertyChange
    {
        private readonly IModel _model;

        private PropertyChange _selectedViewModel;
        public PropertyChange SelectedViewModel
        {
            get => _selectedViewModel;
            set
            {
                if (SetProperty(ref _selectedViewModel, value))
                    OnPropertyChanged(nameof(SelectedViewModel));
            }
        }

        public ICommand UpdateViewCommand { get; }

        public MainViewModel(IModel model)
        {
            _model = model;
            UpdateViewCommand = new RelayCommand(ChangeView);
            SelectedViewModel = new VMUserList(model); // <- domyślny widok
        }

        private void ChangeView(object parameter)
        {
            switch (parameter?.ToString())
            {
                case "UList":
                    SelectedViewModel = new VMUserList(_model);
                    break;
                case "CList":
                    SelectedViewModel = new VMProductList(_model);
                    break;
                case "EList":
                    SelectedViewModel = new VMEventList(_model); // ✅ tu model jest przekazany
                    break;
            }
        }
    }

}
