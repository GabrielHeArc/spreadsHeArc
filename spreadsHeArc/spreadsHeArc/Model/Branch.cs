using System.Collections.ObjectModel;
using System.Collections.Generic;
using System.ComponentModel;
using spreadsHeArc.Utils;

namespace spreadsHeArc.Model
{
    public class Branch //: INotifyPropertyChanged
    {
        private string _nameBranch;
        public string NameBranch {
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
            set { 
                _average = value;
                //RaisePropertyChanged("Average");
            }
        }

        //private Dictionary<int, List<float>> _dictRating = new Dictionary<int, List<float>>();
        private MultiMap<float> _dictRating = new MultiMap<float>();

        public MultiMap<float> DictRating
        {
            get => _dictRating;
            set
            {
                _dictRating = value;
                //RaisePropertyChanged("DictRating");
            } 
        }        

        public Branch(string name, int weight)
        {
            this.NameBranch = name;
            this.Weight = weight;

            //DictRating.Add(4, 1);
            //DictRating.Add(5, 2);
        }

        /*public void AddRate(float rate, int weight)
        {
            //DictRating.TryGetValue(rate)
            //RaisePropertyChanged("DictRating");
        }*/

        /*private void RaisePropertyChanged(string property)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(property));
            }
        }*/


    }
}