using System;
using System.Collections.ObjectModel;

namespace spreadsHeArc.Model
{
    /// <summary>
    /// Module class has name, average, list of all branches in module and function to compute average
    /// </summary>
    public class Module : Model
    {
        /// <summary>
        /// Construct module with a name
        /// </summary>
        /// <param name="name"></param>
        public Module(string name)
        {
            this.NameModule = name;
            ListBranch = new ObservableCollection<Branch>();
        }

        private string _nameModule;
        public string NameModule
        {
            get => _nameModule;
            set
            {
                _nameModule = value;
                RaisePropertyChanged("NameModule");
            }
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

        private ObservableCollection<Branch> _listBranch;
        public ObservableCollection<Branch> ListBranch
        {
            get => _listBranch;
            set => _listBranch = value;
        }
       
        public float ProcessAverage()
        {
            int sumWeight = 0;
            float sumAverage = 0;
            foreach (Branch branch in ListBranch)
            {
                sumWeight += branch.WeightBranch;
                sumAverage += branch.AverageBranch * branch.WeightBranch;
            }

            AverageModule = sumAverage / sumWeight;
            return AverageModule;
        }
    }
}
