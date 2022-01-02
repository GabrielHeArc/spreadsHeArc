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
            InitializeComponent();
            Console.WriteLine("TEST");


        }

        private void MenuItem_Click_Add_Module(object sender, RoutedEventArgs e)
        {            
            var dialog = new AddModuleWindow();
            dialog.ShowDialog();
        }

        private void MenuItem_Click_Edit_Module(object sender, RoutedEventArgs e)
        {
            var dialog = new EditModuleWindow();
            dialog.ShowDialog();
        }

        private void MenuItem_Click_Add_Branch(object sender, RoutedEventArgs e)
        {
            var dialog = new AddBranchWindow();
            dialog.ShowDialog();
        }

        private void MenuItem_Click_Edit_Branch(object sender, RoutedEventArgs e)
        {
            var dialog = new EditBranchWindow();
            dialog.ShowDialog();
        }      
    }
}
