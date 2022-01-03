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
        private BranchViewModel branchViewModel;
        private string NewBranchName
        {
            get;
            set;
        }

        public string NewBranchWeight
        {
            get;
            set;
        }

        public AddBranchWindow()
        {
            InitializeComponent();            
        }

        private void okButton_Click(object sender, RoutedEventArgs e)
        {
            NewBranchName = new_branch_name_text_box.Text;
            NewBranchWeight = new_branch_weight_text_box.Text;
            //MessageBox.Show(NewBranchName);
            //MessageBox.Show(NewBranchWeight);
            BranchViewModel branchViewModel = BranchViewModel.getInstance();
            branchViewModel.AddBranch(NewBranchName, NewBranchWeight);
            this.DataContext = branchViewModel;
        }
    }
}
