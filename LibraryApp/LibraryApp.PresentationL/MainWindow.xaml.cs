using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using LibraryApp.Logic;
using LibraryApp.PresentationL.ViewModels;

namespace LibraryApp.PresentationL
{
    /// <summary>
    /// Logika interakcji dla klasy MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            /*IDataLayer data = new DataLayer(); // lub SqlDataLayer
            IBusinessLogic logic = new BusinessLogic(data);
            DataContext = new MainViewModel(logic);*/ //tu trzeba cos zmienic bo jeszcze nie dziala!!
        }
    }
}
