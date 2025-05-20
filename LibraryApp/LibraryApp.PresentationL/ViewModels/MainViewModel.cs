using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using LibraryApp.Logic.DTO;
using LibraryApp.Logic;

namespace LibraryApp.PresentationL.ViewModels
{
    class MainViewModel : INotifyPropertyChanged
    {
        private readonly IBusinessLogic _logic;

        public ObservableCollection<IUserDTO> Users { get; } = new ObservableCollection<IUserDTO>();

        public MainViewModel(IBusinessLogic logic)
        {
            _logic = logic;
            LoadUsers();
        }

        private void LoadUsers()
        {
            Users.Clear();
            foreach (var user in _logic.GetAllUsers())
                Users.Add(user);
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged([CallerMemberName] string prop = "") =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
    }
}
