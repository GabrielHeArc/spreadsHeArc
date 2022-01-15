using System.Collections.ObjectModel;
using System.Collections.Generic;
using System.ComponentModel;
using spreadsHeArc.Utils;
using System.Windows;

namespace spreadsHeArc.Model
{
    public class Branch //: INotifyPropertyChanged
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
                _average = value;
            }
        }

        private List<float>[] _dictRating = new List<float>[11];
        public List<float>[] DictRating
        {
            get => _dictRating;
            set
            {
                _dictRating = value;
                //RaisePropertyChanged("DictRating");
                //foreach(var x in _)
            }
        }

        public Branch(string name, int weight)
        {
            this.NameBranch = name;
            this.Weight = weight;

            this.DictRating = new List<float>[11];

            for (int i = 0; i < 11; i++)
                this.DictRating[i] = new List<float>();

           /* this.DictRating[1].Add(2);
            this.DictRating[1].Add(3);
            this.DictRating[1].Add(4);

            this.DictRating[2].Add(2);

            this.DictRating[6].Add(6);

            this.DictRating[8].Add(8);
           */


            /*for (int i = 1; i < 12; i++)
            {
                if (DictRating[i].Count > 0)
                { 
                    foreach (var x in DictRating[i])
                    {
                        MessageBox.Show(x.ToString());
                    }
                }
            }*/
        }
    }
}