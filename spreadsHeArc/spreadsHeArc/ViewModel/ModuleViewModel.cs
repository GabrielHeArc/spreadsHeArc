using spreadsHeArc.Model;
using System;
using System.Collections.Generic;
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
            //ListModules = new ObservableCollection<Module>();
        }

        public static ModuleViewModel GetInstance()
        {
            if (_instance == null)
                _instance = new ModuleViewModel();
            return _instance;
        }

        private static ModuleViewModel _instance;

        public ObservableCollection<Module> ListModules { get; set; } = new ObservableCollection<Module>();

        public Dictionary<string, Module> DictNameModule { get; set; } = new Dictionary<string, Module>();


        public Module TryAdd(string nameModule)
        {
            if(DictNameModule.ContainsKey(nameModule))
            {
                return DictNameModule[nameModule];
            }
            else
            {
                Module newModule = new Module(nameModule);
                ListModules.Add(newModule);
                DictNameModule.Add(nameModule, newModule);
                return newModule;
            }
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
