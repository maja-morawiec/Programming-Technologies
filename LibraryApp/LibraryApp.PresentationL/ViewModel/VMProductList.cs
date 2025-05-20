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
    internal class VMProductList : PropertyChange
    {
        private IModel _model;
        private ObservableCollection<VMProduct> products;
        private VMProduct _selectedProduct;

        public ICommand RefreshCommand { get; }

        public VMProductList()
        {
            _model = IModel.CreateNewModel();
            products = new ObservableCollection<VMProduct>();
            RefreshCommand = new RelayCommand(_ => GetProducts(), _ => true);
        }

        public VMProductList(IModel model)
        {
            _model = model;
            products = new ObservableCollection<VMProduct>();
            RefreshCommand = new RelayCommand(_ => GetProducts(), _ => true);
        }

        public ObservableCollection<VMProduct> Products
        {
            get => products;
            set
            {
                products = value;
                OnPropertyChanged(nameof(Products));
            }
        }

        public VMProduct SelectedProduct
        {
            get => _selectedProduct;
            set
            {
                _selectedProduct = value;
                OnPropertyChanged(nameof(SelectedProduct));
            }
        }

        private VMProduct ProductToPresentation(IProductDto p)
        {
            return p == null ? null : new VMProduct(p.Id, p.Name, p.Quantity);
        }

        public void GetProducts()
        {
            Products.Clear();
            foreach (var p in _model.GetAllProducts())
            {
                Products.Add(ProductToPresentation(p));
            }
            OnPropertyChanged(nameof(Products));
        }
    }
}
