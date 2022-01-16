using spreadsHeArc.Model;
using System.Collections.ObjectModel;

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
            }
        }

        private static ModuleViewModel _instance;

        public static ModuleViewModel GetInstance()
        {
            if (_instance == null)
                _instance = new ModuleViewModel();
            return _instance;
        }


        public void AddModule(string name)
        {
            ListModules.Add(new Module(name));
        }


    }
}
