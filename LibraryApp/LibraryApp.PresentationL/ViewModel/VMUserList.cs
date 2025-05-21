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
    internal class VMUserList : PropertyChange
    {
        private IModel _model;
        private ObservableCollection<VMUser> users;

        private VMUser _selectedUser;

        private int newUserId;
        private string newUserName;

        public int NewUserId
        {
            get => newUserId;
            set => SetProperty(ref newUserId, value);
        }

        public string NewUserName
        {
            get => newUserName;
            set => SetProperty(ref newUserName, value);
        }


        public ICommand RefreshCommand { get; }
        public ICommand AddUserCommand { get; }
        public ICommand UpdateUserCommand { get; }
        public ICommand RemoveUserCommand { get; }


        public VMUserList()
        {
            _model = IModel.CreateNewModel();  // jeśli masz fabrykę modelu, albo wstrzyknij inaczej
            users = new ObservableCollection<VMUser>();
            RefreshCommand = new RelayCommand(_ => GetUsers(), _ => true);

            AddUserCommand = new RelayCommand(async _ => await AddUser());
            UpdateUserCommand = new RelayCommand(async _ => await UpdateUser(), _ => SelectedUser != null);
            RemoveUserCommand = new RelayCommand(async _ => await RemoveUser(), _ => SelectedUser != null);

            GetUsers();

        }

        public VMUserList(IModel model)
        {
            _model = model;
            users = new ObservableCollection<VMUser>();
            RefreshCommand = new RelayCommand(_ => GetUsers(), _ => true);
        }

        public ObservableCollection<VMUser> Users
        {
            get => users;
            set
            {
                users = value;
                OnPropertyChanged(nameof(Users));
            }
        }

        public VMUser SelectedUser
        {
            get => _selectedUser;
            set
            {
                _selectedUser = value;
                OnPropertyChanged(nameof(SelectedUser));
            }
        }

        private VMUser UserToPresentation(IUserDto u)
        {
            return u == null ? null : new VMUser(u.Id, u.Name);
        }

        public void GetUsers()
        {
            Users.Clear();
            foreach (var u in _model.GetAllUsers())
            {
                Users.Add(UserToPresentation(u));
            }
            OnPropertyChanged(nameof(Users));
        }

        private async Task AddUser()
        {
            await _model.AddUser(NewUserId, NewUserName);
            GetUsers();
        }

        private async Task UpdateUser()
        {
            if (SelectedUser == null) return;
            await _model.UpdateUser(SelectedUser.Id, SelectedUser.Name);
            GetUsers();
        }

        private async Task RemoveUser()
        {
            if (SelectedUser == null) return;
            await _model.RemoveUser(SelectedUser.Id);
            GetUsers();
        }

    }

}
