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
    /// Logique d'interaction pour AddBranch.xaml
    /// </summary>
    public partial class AddBranchWindow : Window
    {       
        private string NewBranchName
        {
            get;
            set;
        }

        public int NewBranchWeight
        {
            get;
            set;
        }

        public Module Module
        {
            get;

            set;
        }

        public AddBranchWindow()
        {
            InitializeComponent();
            ModuleViewModel module = ModuleViewModel.GetInstance();            

            list_modules.ItemsSource = module.ListModules;
            list_modules.DisplayMemberPath = "NameModule";
            list_modules.SelectedIndex = 0;            
        }

        private void okButton_Click(object sender, RoutedEventArgs e)
        {
            NewBranchName = new_branch_name_text_box.Text;
            try
            {
                NewBranchWeight = int.Parse(new_branch_weight_text_box.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            BranchViewModel branchViewModel = BranchViewModel.getInstance();
            branchViewModel.AddBranch(NewBranchName, NewBranchWeight, Module);

            this.DialogResult = true;
        }

        private void list_modules_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Module = (sender as ComboBox).SelectedItem as Module;            
        }
    }
}