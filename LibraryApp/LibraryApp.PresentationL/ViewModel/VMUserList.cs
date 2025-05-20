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

        public ICommand RefreshCommand { get; }

        public VMUserList()
        {
            _model = IModel.CreateNewModel();  // jeśli masz fabrykę modelu, albo wstrzyknij inaczej
            users = new ObservableCollection<VMUser>();
            RefreshCommand = new RelayCommand(_ => GetUsers(), _ => true);
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
    }
}
