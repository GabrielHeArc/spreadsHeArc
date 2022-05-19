using spreadsHeArc.Model;
using spreadsHeArc.ViewModel;
using System;
using System.Windows;
using System.Windows.Controls;


namespace spreadsHeArc.View.Branch
{
    /// <summary>
    /// Initialize window to add rating in programm.
    /// </summary>
    public partial class AddRatingWindow : Window
    {
        public AddRatingWindow()
        {
            InitializeComponent();
            BranchViewModel branch = BranchViewModel.GetInstance();

            list_branches.ItemsSource = branch.ListBranches;
            list_branches.DisplayMemberPath = "NameBranch";
            list_branches.SelectedIndex = 0;
        }

        private Model.Branch _branch;
        public Model.Branch Branche
        {
            get => _branch;
            set => _branch = value;
        }

        private float _newMark;
        public float NewMark
        {
            get => _newMark;
            set => _newMark = value;
        }

        private int _newMarkWeight;
        public int NewMarkWeight
        {
            get => _newMarkWeight;
            set => _newMarkWeight = value;
        }
       
        private void OkButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                NewMark = float.Parse(new_rate_text_box.Text.Replace('.', ','));
                NewMarkWeight = int.Parse(new_rate_weight_text_box.Text.Replace('.', ','));
                BranchViewModel branchViewModel = BranchViewModel.GetInstance();
                Rating newRate = new Rating(NewMark, NewMarkWeight);
                branchViewModel.AddRating(Branche, newRate);
                this.DialogResult = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void List_branches_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Branche = (sender as ComboBox).SelectedItem as Model.Branch;
        }
    }
}
