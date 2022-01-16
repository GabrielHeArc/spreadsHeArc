using spreadsHeArc.Model;
using System;
using System.Collections.Generic;
using System.Windows;

namespace spreadsHeArc.ViewModel
{
    public class BranchViewModel : ViewModel
    {
        public List<Branch> ListBranches
        {
            get => _listbranches;
            set => _listbranches = value;
        }

        private List<Branch> _listbranches = new List<Branch>();
        private BranchViewModel()
        {
            ListBranches = new List<Branch>();
        }
        private static BranchViewModel _instance;

        public static BranchViewModel GetInstance()
        {
            if (_instance == null)
                _instance = new BranchViewModel();
            return _instance;
        }

        public void AddBranch(string name, int weight, Module module)
        {
            Branch newBranch = new Branch(name, weight, module);
            ListBranches.Add(newBranch);
            try
            {
                module.ListBranch.Add(newBranch);
            }
            catch (Exception)
            {
                MessageBox.Show("Erreur : Aucun module n'est renseigné.");
                MessageBox.Show("Les modifications n'ont pas été enregistrées.");
            }
        }

        public void AddRate(Branch branch, Rate rate)
        {
            branch.ListRate.Add(rate);
            branch.ProcessAverage();
            branch.Module.ProcessAverage();
        }
    }
}
