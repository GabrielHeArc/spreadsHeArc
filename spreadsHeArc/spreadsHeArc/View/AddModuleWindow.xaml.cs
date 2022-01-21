using spreadsHeArc.ViewModel;
using System;
using System.Windows;

namespace spreadsHeArc.View.Module
{
    /// <summary>
    /// Initialize window to add module in programm.
    /// </summary>
    public partial class AddModuleWindow : Window
    {
        public AddModuleWindow()
        {
            InitializeComponent();
        }

        private string _newModuleName;
        public string NewModuleName
        {
            get => _newModuleName;
            set => _newModuleName = value;
        }
       
        private void OkButton_Click(object sender, RoutedEventArgs e)
        {
            try { 
                NewModuleName = new_module_name_text_box.Text;
                
                if (string.IsNullOrEmpty(NewModuleName))
                    throw new Exception("Le nom du module ne peut pas être vide");
                
                ModuleViewModel moduleViewModel = ModuleViewModel.GetInstance();
                moduleViewModel.AddModule(NewModuleName);
                this.DialogResult = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
