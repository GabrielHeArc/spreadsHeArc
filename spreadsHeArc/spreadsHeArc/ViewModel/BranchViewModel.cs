using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace spreadsHeArc.ViewModel
{
    public sealed class BranchViewModel
    {
        public List<Branch> ListBranches;
        private BranchViewModel()
        {
            ListBranches = new List<Branch>();
        }
        private static BranchViewModel _instance;

        
        public static BranchViewModel getInstance()
        {
            if (_instance == null)
                _instance = new BranchViewModel();
            return _instance;
        }
        
        internal void AddBranch(string name, int weight, Module module)
        {
            Branch newBranch = new Branch(name, weight);
            ListBranches.Add(newBranch);
            try
            {
                module.DictBranch.Add(newBranch, weight);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erreur : Aucun module n'est renseigné.");
                MessageBox.Show("Les modifications n'ont pas été enregistrées.");
            }
        }        
    }
}
