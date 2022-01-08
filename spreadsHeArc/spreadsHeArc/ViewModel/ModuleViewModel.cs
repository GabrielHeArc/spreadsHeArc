using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Collections.ObjectModel;
using System.ComponentModel;
using spreadsHeArc.Model;

namespace spreadsHeArc.ViewModel
{
    public class ModuleViewModel : ViewModel
    {                
        private ModuleViewModel()
        {
            ListModules = new ObservableCollection<Module>();
        }

        private ObservableCollection<Module> _listModules;

        public ObservableCollection<Module> ListModules
        {
            get => _listModules;
            set
            {
                _listModules = value;
                RaisePropertyChanged("ListeModule");
            }
        }

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
