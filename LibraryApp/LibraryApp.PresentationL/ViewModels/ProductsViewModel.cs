using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace LibraryApp.PresentationL.ViewModels
{
    class ProductsViewModel : BaseViewModel
    {
        private ProductModel _selectedProduct;

        public ObservableCollection<ProductModel> Products { get; set; }

        public ProductModel SelectedProduct
        {
            get => _selectedProduct;
            set
            {
                if (_selectedProduct != value)
                {
                    _selectedProduct = value;
                    OnPropertyChanged();
                    (SaveProductCommand as RelayCommand)?.RaiseCanExecuteChanged();
                }
            }
        }

        public ICommand SaveProductCommand { get; }

        public ProductsViewModel()
        {
            Products = new ObservableCollection<ProductModel>
            {
                new ProductModel { Id = 1, Title = "Book A", Author = "Author A", Year = 2020 },
                new ProductModel { Id = 2, Title = "Book B", Author = "Author B", Year = 2021 }
            };

            SaveProductCommand = new RelayCommand(SaveProduct, () => SelectedProduct != null);
        }

        private void SaveProduct()
        {
            // Logika zapisu produktu (np. do bazy lub innej warstwy)
        }
    }
}
