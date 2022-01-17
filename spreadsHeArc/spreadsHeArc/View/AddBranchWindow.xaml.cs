﻿using spreadsHeArc.ViewModel;
using System;
using System.Windows;
using System.Windows.Controls;


namespace spreadsHeArc.View.Branch
{
    /// <summary>
    /// Logique d'interaction pour AddBranch.xaml
    /// </summary>
    public partial class AddBranchWindow : Window
    {
        private string _newBranchName;
        public string NewBranchName
        {
            get => _newBranchName;
            set => _newBranchName = value;
        }

        private int _newBranchWeight;
        public int NewBranchWeight
        {
            get => _newBranchWeight;
            set => _newBranchWeight = value;
        }

        private Model.Module _module;
        public Model.Module Module
        {
            get => _module;
            set => _module = value;
        }

        public AddBranchWindow()
        {
            InitializeComponent();
            ModuleViewModel module = ModuleViewModel.GetInstance();

            list_modules.ItemsSource = module.ListModules;
            list_modules.DisplayMemberPath = "NameModule";
            list_modules.SelectedIndex = 0;
        }

        private void OkButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                NewBranchName = new_branch_name_text_box.Text;
                NewBranchWeight = int.Parse(new_branch_weight_text_box.Text);
                BranchViewModel branchViewModel = BranchViewModel.GetInstance();
                branchViewModel.AddBranch(NewBranchName, NewBranchWeight, Module);

                this.DialogResult = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void list_modules_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Module = (sender as ComboBox).SelectedItem as Model.Module;
        }
    }
}