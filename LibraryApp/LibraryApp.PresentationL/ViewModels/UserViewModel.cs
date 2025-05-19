using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace LibraryApp.PresentationL.ViewModels
{
    class UserViewModel : BaseViewModel
    {
        private UserModel _selectedUser;
        public ObservableCollection<UserModel> Users { get; set; }

        public UserModel SelectedUser
        {
            get => _selectedUser;
            set
            {
                if (_selectedUser != value)
                {
                    _selectedUser = value;
                    OnPropertyChanged();
                    // Odśwież stan przycisku zapisu
                    (SaveUserCommand as RelayCommand)?.RaiseCanExecuteChanged();
                }
            }
        }

        public ICommand SaveUserCommand { get; }

        public UserViewModel()
        {
            Users = new ObservableCollection<UserModel>
            {
                new UserModel { Id = 1, Name = "Anna Kowalska" },
                new UserModel { Id = 2, Name = "Jan Nowak" }
            };

            SaveUserCommand = new RelayCommand(SaveUser, () => SelectedUser != null);
        }

        private void SaveUser()
        {
            // Tutaj logika zapisu użytkownika, np. do bazy danych lub innego źródła
        }
    }
}
