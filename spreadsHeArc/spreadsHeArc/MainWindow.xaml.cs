using spreadsHeArc.View;
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

        private void MenuItem_Click_Add_Branch(object sender, RoutedEventArgs e)
        {
            var dialog = new AddBranchWindow();
            dialog.ShowDialog();
        }

        private void MenuItem_Click_Add_Rating(object sender, RoutedEventArgs e)
        {
            var dialog = new AddRatingWindow();
            dialog.ShowDialog();
        }

        private void MenuItem_Click_Edit_Module(object sender, RoutedEventArgs e)
        {
            var dialog = new EditModuleWindow();
            dialog.ShowDialog();
        }

        private void MenuItem_Click_Edit_Name_Branch(object sender, RoutedEventArgs e)
        {
            var dialog = new EditBranchName();
            dialog.ShowDialog();
        }

        private void MenuItem_Click_Edit_Weight_Branch(object sender, RoutedEventArgs e)
        {
            var dialog = new EditBranchWeight();
            dialog.ShowDialog();
        }

        private void MenuItem_Click_Save_Data(object sender, RoutedEventArgs e)
        {
            Model.SaveData.Export();
        }

        private void MenuItem_Click_Import_Data(object sender, RoutedEventArgs e)
        {
            Model.SaveData.Import();
        }
    }
}
