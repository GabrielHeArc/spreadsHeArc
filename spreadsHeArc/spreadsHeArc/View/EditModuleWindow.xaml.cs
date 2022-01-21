using spreadsHeArc.ViewModel;
using System;
using System.Windows;
using System.Windows.Controls;

namespace spreadsHeArc.View
{
    /// <summary>
    /// Initialize window to edit existing module name.
    /// </summary>
    public partial class EditModuleWindow : Window
    {
        public EditModuleWindow()
        {
            InitializeComponent();
            ModuleViewModel module = ModuleViewModel.GetInstance();

            list_modules.ItemsSource = module.ListModules;
            list_modules.DisplayMemberPath = "NameModule";
            list_modules.SelectedIndex = 0;
        }

        private string _newNameModule;
        public string NewNameModule
        {
            get => _newNameModule;
            set => _newNameModule = value;
        }

        private Model.Module _module;
        public Model.Module Module
        {
            get => _module;
            set => _module = value;
        }        

        private void OkButton_Click(object sender, RoutedEventArgs e)
        {
            ModuleViewModel moduleViewModel = ModuleViewModel.GetInstance();
            try
            {                
                int IndexOfModule = moduleViewModel.ListModules.IndexOf(Module);
                if (IndexOfModule == -1)
                    throw new Exception("Le module à modifier n'existe pas");

                NewNameModule = _new_name_module_text_box.Text;
                moduleViewModel.ListModules[IndexOfModule].NameModule = NewNameModule;

                this.DialogResult = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void List_modules_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Module = (sender as ComboBox).SelectedItem as Model.Module;
        }
    }
}
