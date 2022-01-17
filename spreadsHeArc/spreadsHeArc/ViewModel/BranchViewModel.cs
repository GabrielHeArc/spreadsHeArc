using spreadsHeArc.Model;
using System;
using System.Collections.Generic;
using System.Windows;

namespace spreadsHeArc.ViewModel
{
    public class BranchViewModel : ViewModel
    {
        private List<Branch> _listBranches = new List<Branch>();
        public List<Branch> ListBranches
        {
            get => _listBranches;
            set => _listBranches = value;
        }

        private static BranchViewModel _instance;

        private BranchViewModel()
        {
            ListBranches = new List<Branch>();
        }        

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

        public void AddRate(Branch branch, Rating rate)
        {
            branch.ListRate.Add(rate);
            branch.ProcessAverage();
            branch.Module.ProcessAverage();
        }
    }
}
