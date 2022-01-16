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

        private int _weight;
        public int Weight
        {
            get => _weight;
            set => _weight = value;
        }

        private float _average;
        public float Average
        {
            get => _average;
            set
            {
                _average = (float)Math.Round(value, 2);
                RaisePropertyChanged("Average");
            }
        }

        private Module _module;

        public Module Module
        {
            get => _module;
            set => _module = value;
        }

        private ObservableCollection<Rate> _listRate = new ObservableCollection<Rate>();
        public ObservableCollection<Rate> ListRate
        {
            get => _listRate;
            set
            {
                _listRate = value;
            }
        }

        public Branch(string name, int weight, Module module)
        {
            this.NameBranch = name;
            this.Weight = weight;
            this.Module = module;

            this.ListRate = new ObservableCollection<Rate>();
        }

        public void ProcessAverage()
        {
            int sumWeight = 0;
            float sumMark = 0;
            foreach (Rate rate in ListRate)
            {
                sumWeight += rate.Weight;
                sumMark += rate.Mark * rate.Weight;
            }

            Average = sumMark / sumWeight;
        }
    }
}