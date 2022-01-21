using spreadsHeArc.ViewModel;
using System;
using System.Windows;
using System.Windows.Controls;

namespace spreadsHeArc.View
{
    /// <summary>
    /// Initialize window to edit existing branch weight.
    /// </summary>
    public partial class EditBranchWeight : Window
    {
        public EditBranchWeight()
        {
            InitializeComponent();
            BranchViewModel branch = BranchViewModel.GetInstance();

            list_branches.ItemsSource = branch.ListBranches;
            list_branches.DisplayMemberPath = "NameBranch";
            list_branches.SelectedIndex = 0;
        }

        private int _newWeightBranch;
        public int NewWeightBranch
        {
            get => _newWeightBranch;
            set => _newWeightBranch = value;
        }

        private Model.Branch _branch;
        public Model.Branch Branche
        {
            get => _branch;
            set => _branch = value;
        }      

        private void List_branches_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Branche = (sender as ComboBox).SelectedItem as Model.Branch;
        }

        private void OkButton_Click(object sender, RoutedEventArgs e)
        {
            BranchViewModel branchViewModel = BranchViewModel.GetInstance();
            try
            {
                int IndexOfModule = branchViewModel.ListBranches.IndexOf(Branche);
                if (IndexOfModule == -1)
                    throw new Exception("La branche à modifier n'existe pas");

                NewWeightBranch = int.Parse(new_weight_branch_combo_box.Text);
                branchViewModel.ListBranches[IndexOfModule].WeightBranch = NewWeightBranch;
                this.DialogResult = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
