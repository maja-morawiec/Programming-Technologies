using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using LibraryApp.Data.API;
using LibraryApp.Logic;
using System.Windows.Input;
using System.Collections.Generic;

namespace LibraryApp.Presentation
{
    public class LibraryViewModel : INotifyPropertyChanged
    {
        private readonly BusinessLogic _logic;

        public ObservableCollection<IUser> Users { get; set; } = new();
        public ObservableCollection<IProduct> Catalog { get; set; } = new();

        private IUser _selectedUser;
        public IUser SelectedUser
        {
            get => _selectedUser;
            set { _selectedUser = value; OnPropertyChanged(); }
        }

        private IProduct _selectedProduct;
        public IProduct SelectedProduct
        {
            get => _selectedProduct;
            set { _selectedProduct = value; OnPropertyChanged(); }
        }

        public ICommand AddUserCommand { get; }
        public ICommand AddBookCommand { get; }
        public ICommand BorrowBookCommand { get; }

        public LibraryViewModel(BusinessLogic logic)
        {
            _logic = logic;

            // Initial load
            Users = new ObservableCollection<IUser>(_logic.GetUsers());
            Catalog = new ObservableCollection<IProduct>(_logic.GetProducts());

            AddUserCommand = new RelayCommand(_ => AddUser());
            AddBookCommand = new RelayCommand(_ => AddBook());
            BorrowBookCommand = new RelayCommand(_ => BorrowBook());
        }

        private void AddUser()
        {
            int id = Users.Count + 1;
            _logic.AddUser(id, $"User {id}");
            Users.Add(_logic.GetUsers().Last());
        }

        private void AddBook()
        {
            int id = Catalog.Count + 1;
            _logic.AddProduct(id, $"Book {id}", 1);
            Catalog.Add(_logic.GetProducts().Last());
        }

        private void BorrowBook()
        {
            if (SelectedProduct != null)
            {
                _logic.BorrowProduct(SelectedProduct.Id);
                OnPropertyChanged(nameof(Catalog));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string name = null)
            => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
    }

    public class RelayCommand : ICommand
    {
        private readonly Action<object> _execute;
        public RelayCommand(Action<object> execute) => _execute = execute;

        public event EventHandler CanExecuteChanged;
        public bool CanExecute(object parameter) => true;
        public void Execute(object parameter) => _execute(parameter);
    }
}
