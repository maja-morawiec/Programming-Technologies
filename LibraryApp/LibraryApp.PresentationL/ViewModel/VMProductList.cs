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

        private int newProductId;
        private string newProductName;
        private int newProductQuantity;

        public int NewProductId
        {
            get => newProductId;
            set => SetProperty(ref newProductId, value);
        }

        public string NewProductName
        {
            get => newProductName;
            set => SetProperty(ref newProductName, value);
        }

        public int NewProductQuantity
        {
            get => newProductQuantity;
            set => SetProperty(ref newProductQuantity, value);
        }

        public ICommand RefreshCommand { get; }
        public ICommand AddProductCommand { get; }
        public ICommand RemoveProductCommand { get; }
        public ICommand UpdateProductCommand { get; }



        public VMProductList()
        {
            _model = IModel.CreateNewModel();
            products = new ObservableCollection<VMProduct>();
            RefreshCommand = new RelayCommand(_ => GetProducts(), _ => true);

            AddProductCommand = new RelayCommand(_ => AddProduct(), _ => true);
            RemoveProductCommand = new RelayCommand(_ => RemoveProduct(), _ => SelectedProduct != null);
            UpdateProductCommand = new RelayCommand(_ => UpdateProduct(), _ => SelectedProduct != null);
            //SelectedProduct = new VMProduct();

            GetProducts();
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

        /*public void AddProduct()
        {
            if (SelectedProduct != null)
            {
                _model.AddProduct(SelectedProduct.Id, SelectedProduct.Name, SelectedProduct.Quantity);
                GetProducts();
            }
        }*/

        private async Task AddProduct()
        {
            await _model.AddProduct(NewProductId, NewProductName, NewProductQuantity);
            GetProducts();
        }

        private async Task UpdateProduct()
        {
            if (SelectedProduct == null) return;
            await _model.UpdateProduct(SelectedProduct.Id, SelectedProduct.Name, SelectedProduct.Quantity);
            GetProducts();
        }

        private async Task RemoveProduct()
        {
            if(SelectedProduct == null) return;
            await _model.RemoveProduct(SelectedProduct.Id);
            GetProducts();
        }

        /*public void DeleteProduct()
        {
            if (SelectedProduct != null)
            {
                _model.RemoveProduct(SelectedProduct.Id);
                GetProducts();
            }
        }*/

        /*public void UpdateProduct()
        {
            if (SelectedProduct != null)
            {
                _model.UpdateProduct(SelectedProduct.Id, SelectedProduct.Name, SelectedProduct.Quantity);
                GetProducts();
            }
        }*/


    }
}
