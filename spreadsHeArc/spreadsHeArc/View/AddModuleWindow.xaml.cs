using spreadsHeArc.ViewModel;
using System.Windows;

namespace spreadsHeArc.View.Module
{
    /// <summary>
    /// Logique d'interaction pour AddModuleWindow.xaml
    /// </summary>
    public partial class AddModuleWindow : Window
    {

        private string _newModuleName;
        public string NewModuleName
        {
            get => _newModuleName;
            set => _newModuleName = value;
        }

        public AddModuleWindow()
        {
            InitializeComponent();
        }

        private void OkButton_Click(object sender, RoutedEventArgs e)
        {
            NewModuleName = new_module_name_text_box.Text;

            ModuleViewModel moduleViewModel = ModuleViewModel.GetInstance();
            moduleViewModel.AddModule(NewModuleName);
            this.DialogResult = true;
        }
    }
}
