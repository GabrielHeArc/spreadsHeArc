using spreadsHeArc.View.Branch;
using spreadsHeArc.View.Module;
using spreadsHeArc.ViewModel;
using System.Windows;

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


        private void MenuItem_Click_Add_Rate(object sender, RoutedEventArgs e)
        {
            var dialog = new AddRateWindow();
            dialog.ShowDialog();
        }
    }
}
