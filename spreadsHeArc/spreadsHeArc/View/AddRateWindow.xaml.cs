using spreadsHeArc.Model;
using spreadsHeArc.ViewModel;
using System;
using System.Windows;
using System.Windows.Controls;


namespace spreadsHeArc.View.Branch
{
    /// <summary>
    /// Logique d'interaction pour AddRateWindow.xaml
    /// </summary>
    public partial class AddRateWindow : Window
    {
        private Model.Branch _branch;
        public Model.Branch Branche
        {
            get => _branch;
            set => _branch = value;
        }

        private float _newRate;
        public float NewRate
        {
            get => _newRate;
            set => _newRate = value;
        }

        private int _newRateWeight;
        public int NewRateWeight
        {
            get => _newRateWeight;
            set => _newRateWeight = value;
        }

        public AddRateWindow()
        {
            InitializeComponent();
            BranchViewModel branch = BranchViewModel.GetInstance();

            list_branches.ItemsSource = branch.ListBranches;
            list_branches.DisplayMemberPath = "NameBranch";
            list_branches.SelectedIndex = 0;

        }

        private void okButton_Click(object sender, RoutedEventArgs e)
        {            
            try
            {
                NewRate = float.Parse(new_rate_text_box.Text.Replace('.', ','));
                NewRateWeight = int.Parse(new_rate_weight_text_box.Text.Replace('.', ','));
                BranchViewModel branchViewModel = BranchViewModel.GetInstance();
                branchViewModel.AddRate(Branche, NewRate, NewRateWeight);
                this.DialogResult = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }                        
        }

        private void list_branches_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Branche = (sender as ComboBox).SelectedItem as Model.Branch;
        }
    }
}
