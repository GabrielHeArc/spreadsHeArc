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
        List<Branch> ListBranches;
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
        
        internal void AddBranch(string name, string weight)
        {
            ListBranches.Add(new Branch(name, weight));
            MessageBox.Show(ListBranches.Count.ToString());
            MessageBox.Show(ListBranches.ToString());
            Console.WriteLine(ListBranches.ToString());
        }        
    }
}
