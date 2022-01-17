using System;
using System.Collections.ObjectModel;

namespace spreadsHeArc.Model
{
    public class Branch : Model
    {
        private string _nameBranch;
        public string NameBranch
        {
            get => _nameBranch;
            set => _nameBranch = value;
        }

        private int _weightBranch;
        public int Weight
        {
            get => _weightBranch;
            set => _weightBranch = value;
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

        public Module Module
        {
            get => _module;
            set => _module = value;
        }

        private ObservableCollection<Rating> _listRate = new ObservableCollection<Rating>();
        public ObservableCollection<Rating> ListRate
        {
            get => _listRate;
            set => _listRate = value;            
        }

        public Branch(string name, int weight, Module module)
        {
            NameBranch = name;
            Weight = weight;
            Module = module;

            ListRate = new ObservableCollection<Rating>();
        }

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