using Newtonsoft.Json;
using System;
using System.Collections.ObjectModel;

namespace spreadsHeArc.Model
{
    [JsonObject(MemberSerialization.OptIn)]
    public class Branch : Model
    {
        /// <summary>
        /// Construct new branch with name, weight and module membership
        /// </summary>
        /// <param name="name">Name of branch</param>
        /// <param name="weight">Weight of branch in module</param>
        /// <param name="module">Module instance of branch's</param>
        public Branch(string name, int weight, Module module)
        {
            NameBranch = name;
            WeightBranch = weight;
            Module = module;
            // init list rates of branch
            ListRate = new ObservableCollection<Rating>();
        }

        private string _nameBranch;

        [JsonProperty]
        public string NameBranch
        {
            get => _nameBranch;
            set
            {
                _nameBranch = value;
                RaisePropertyChanged("NameBranch");
            }
        }

        private int _weightBranch;

        [JsonProperty]
        public int WeightBranch
        {
            get => _weightBranch;
            set
            {
                _weightBranch = value;
                RaisePropertyChanged("WeightBranch");
            }
        }

        private float _averageBranch;

        public float AverageBranch
        {
            get => _averageBranch;
            set
            {
                _averageBranch = (float)Math.Round(value, 2);
                RaisePropertyChanged("AverageBranch");
            }
        }

        private Module _module;

        [JsonProperty]
        public Module Module
        {
            get => _module;
            set => _module = value;
        }

        private ObservableCollection<Rating> _listRate = new ObservableCollection<Rating>();

        [JsonProperty]
        public ObservableCollection<Rating> ListRate
        {
            get => _listRate;
            set => _listRate = value;
        }

        /// <summary>
        /// Process average for branch
        /// </summary>
        public void ProcessAverage()
        {
            int sumWeight = 0;
            float sumMark = 0;
            foreach (Rating rate in ListRate)
            {
                sumWeight += rate.WeightMark;
                sumMark += rate.Mark * rate.WeightMark;
            }

            AverageBranch = sumMark / sumWeight;
        }
    }
}