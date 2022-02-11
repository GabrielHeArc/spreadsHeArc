using Newtonsoft.Json;
using System;
using System.Collections.ObjectModel;
using System.Windows;

namespace spreadsHeArc.Model
{
    /// <summary>
    /// Module class has name, average, list of all branches in module and function to compute average
    /// </summary>
    [JsonObject(MemberSerialization.OptIn)]
    public class Module : Model
    {
        /// <summary>
        /// Construct module with a name
        /// </summary>
        /// <param name="name">Name of module</param>
        public Module(string name)
        {
            this.NameModule = name;            
        }

        private string _nameModule;
        
        [JsonProperty]
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
                _averageModule = (float)Math.Round(value, 2);
                RaisePropertyChanged("AverageModule");
            }
        }

        [JsonProperty]
        public ObservableCollection<Branch> ListBranch { get; set; } = new ObservableCollection<Branch>();

        public void ProcessAverage()
        {
            int sumWeight = 0;
            float sumAverage = 0;
            foreach (Branch branch in ListBranch)
            {
                sumWeight += branch.WeightBranch;
                sumAverage += branch.AverageBranch * branch.WeightBranch;
            }

            AverageModule = sumAverage / sumWeight;            
        }
    }
}
