using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace spreadsHeArc.ViewModel
{
    sealed class ModuleViewModel
    {
        List<Module> ListModule;
        private ModuleViewModel()
        {
            ListModule = new List<Module>();
        }
        private static ModuleViewModel _instance;


        public static ModuleViewModel getInstance()
        {
            if (_instance == null)
                _instance = new ModuleViewModel();
            return _instance;
        }

        internal void AddBranch(string name, string weight)
        {
            ListModule.Add(new Module(name, weight));
            MessageBox.Show(ListModule.Count.ToString());
            MessageBox.Show(ListModule.ToString());
            Console.WriteLine(ListModule.ToString());
        }
    }
}
