using spreadsHeArc.Model;
using System;
using System.Collections.ObjectModel;

namespace spreadsHeArc.ViewModel
{
    /// <summary>
    /// ModuleViewModel is designed with Singleton pattern. It references all modules
    /// </summary>
    public class ModuleViewModel : ViewModel
    {
        /// <summary>
        /// Private constructor due to Singleton pattern.
        /// </summary>
        private ModuleViewModel()
        {
            ListModules = new ObservableCollection<Module>();
        }

        public static ModuleViewModel GetInstance()
        {
            if (_instance == null)
                _instance = new ModuleViewModel();
            return _instance;
        }

        private static ModuleViewModel _instance;

        private ObservableCollection<Module> _listModules;
        public ObservableCollection<Module> ListModules
        {
            get => _listModules;
            set { _listModules = value; Console.WriteLine(_listModules); }
        }
        
        /// <summary>
        /// AddModule adds new module in list of all modules.
        /// </summary>
        /// <param name="name"></param>
        public void AddModule(string name)
        {
            ListModules.Add(new Module(name));
        }
    }
}
