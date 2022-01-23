using spreadsHeArc.ViewModel;
using System;
using System.Windows;
using System.Windows.Controls;

namespace spreadsHeArc.View
{
    /// <summary>
    /// Initialize window to edit existing branch name.
    /// </summary>
    public partial class EditBranchName : Window
    {
        public EditBranchName()
        {
            InitializeComponent();

            BranchViewModel branch = BranchViewModel.GetInstance();

            list_branches.ItemsSource = branch.ListBranches;
            list_branches.DisplayMemberPath = "NameBranch";
            list_branches.SelectedIndex = 0;
        }

        private string _newNameBranch;
        public string NewNameBranch
        {
            get => _newNameBranch;
            set => _newNameBranch = value;
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

                NewNameBranch = _new_name_branch_text_box.Text;

                if (string.IsNullOrEmpty(NewNameBranch))
                    throw new Exception("Le nom de la branche ne peut pas être vide");

                branchViewModel.ListBranches[IndexOfModule].NameBranch = NewNameBranch;                

                this.DialogResult = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
