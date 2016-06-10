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
using WPFSample.User.ViewModel;

namespace WPFSample
{
    /// <summary>
    ///show and hide selected data and load data in dropdown.
    /// </summary>
    public partial class MainWindow : Window
    {
        private UserViewModel viewModel;
        public MainWindow()
        {
            InitializeComponent();
            viewModel = new UserViewModel();
            this.DataContext = viewModel;            
            viewModel._isCheck = false;            
            dgUsers.ItemsSource = viewModel.users;
            dgUsers.Columns[3].Visibility = Visibility.Hidden;
           
        }
        private void ComboBox_Loaded(object sender, RoutedEventArgs e)
        {
            var comboBox = sender as ComboBox;
            var id = viewModel.users.Select(i => i.userId).Distinct();
            comboBox.ItemsSource = id.ToList();
            if(viewModel!=null)
            {
                viewModel = null;
                GC.Collect();
            }
        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var comboBox = sender as ComboBox;                     
            viewModel = new UserViewModel();
            var selectedItems = viewModel.users.Where(i => i.userId == Convert.ToInt16(comboBox.SelectedItem)).ToList();
            dgUsers.ItemsSource = selectedItems;
            dgUsers.Columns[3].Visibility = Visibility.Visible;   
        }
        private void ShowHideDetails(object sender, RoutedEventArgs e)
        {
            CopyContents OP = new CopyContents();
            var host = new Window();
            host.Content = OP;
            host.Show();        
        }
    }
}
