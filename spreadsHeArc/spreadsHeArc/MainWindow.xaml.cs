using spreadsHeArc.View.Branch;
using spreadsHeArc.View.Module;
using spreadsHeArc.ViewModel;
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

namespace spreadsHeArc
{
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {                        
            DataContext = ModuleViewModel.GetInstance();
            InitializeComponent();


            //gridViewModel.show();
            //CanvaGrid.Children.Add(new TextBox());
        }

        private void MenuItem_Click_Add_Module(object sender, RoutedEventArgs e)
        {            
            var dialog = new AddModuleWindow();
            dialog.ShowDialog();
        }

        private void MenuItem_Click_Edit_Module(object sender, RoutedEventArgs e)
        {
            //var dialog = new EditModuleWindow();
            //dialog.ShowDialog();
        }

        private void MenuItem_Click_Add_Branch(object sender, RoutedEventArgs e)
        {
            var dialog = new AddBranchWindow();
            dialog.ShowDialog();
        }

        private void MenuItem_Click_Edit_Branch(object sender, RoutedEventArgs e)
        {
            //var dialog = new EditBranchWindow();
            //dialog.ShowDialog();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            GridViewModel grid = new GridViewModel();
            grid.buildGrid();
        }
        
        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {

        }

        private void MenuItem_Click_Add_Rate(object sender, RoutedEventArgs e)
        {
            var dialog = new AddRateWindow();
            dialog.ShowDialog();
        }
    }
}
