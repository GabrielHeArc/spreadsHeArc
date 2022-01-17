using System;
using System.Collections.ObjectModel;

namespace spreadsHeArc.Model
{
    public class Module : Model
    {
        private string _nameModule;
        public string NameModule
        {
            get => _nameModule;
            set => _nameModule = value;
        }

        private float _averageModule;

        public float AverageModule
        {
            get => _averageModule;
            set
            {
                _averageModule = (float)Math.Round(value, 1);
                RaisePropertyChanged("AverageModule");
            }
        }

        /// <summary>
        /// Nom de la branche et pondération dans le module
        /// </summary>
        public ObservableCollection<Branch> ListBranch
        {
            get => _listBranch;
            set => _listBranch = value;
        }

        private ObservableCollection<Branch> _listBranch;

        public Module(string name)
        {
            this.NameModule = name;
            ListBranch = new ObservableCollection<Branch>();
        }

        public void ProcessAverage()
        {
            int sumWeight = 0;
            float sumAverage = 0;
            foreach (Branch branch in ListBranch)
            {
                sumWeight += branch.Weight;
                sumAverage += branch.AverageBranch * branch.Weight;
            }

            AverageModule = sumAverage / sumWeight;            
        }
    }
}
