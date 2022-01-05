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
using System.Windows.Shapes;

namespace spreadsHeArc
{
    /// <summary>
    /// Logique d'interaction pour AddModuleWindow.xaml
    /// </summary>
    public partial class AddModuleWindow : Window
    {
        //private ModuleViewModel moduleViewModel;
        private string NewModuleName
        {
            get;
            set;
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
