using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Collections.ObjectModel;

namespace spreadsHeArc.ViewModel
{
    sealed class ModuleViewModel
    {                
        private ModuleViewModel()
        {
            ListModules = new ObservableCollection<Module>();

            // ------------- debug ----------
            
            

            // ------------- end debug ----------
        }

        public ObservableCollection<Module> ListModules;

        private static ModuleViewModel _instance;

        public static ModuleViewModel GetInstance()
        {
            if (_instance == null)
                _instance = new ModuleViewModel();
            return _instance;
        }


        internal void AddModule(string name)
        {
            ListModules.Add(new Module(name));            
        }        
    }
}
