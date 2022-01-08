using System.Collections.ObjectModel;
using System.ComponentModel;


namespace spreadsHeArc.Model
{
    public class Module// : INotifyPropertyChanged
    {
        private string _nameModule;
        public string NameModule
        {
            get => _nameModule;
            set => _nameModule = value;
        }

        private float _average;

        public float Average
        {
            get => _average;
            set {
                _average = value;
                //RaisePropertyChanged("Average");
            }            
        }


        /// <summary>
        /// Nom de la branche et pondération dans le module
        /// </summary>
        public ObservableCollection<Branch> ListBranch
        {
            get => _listBranch;
            set
            {
                _listBranch = value;
                //RaisePropertyChanged("ListBranch");
            }
        }   

        private ObservableCollection<Branch> _listBranch;
        

        public Module(string name)
        {
           this.NameModule = name;
           ListBranch = new ObservableCollection<Branch>();
        }

        /*private void RaisePropertyChanged(string property)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(property));
            }
        }*/
    }
}
