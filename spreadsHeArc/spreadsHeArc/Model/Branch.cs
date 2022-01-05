using System.Collections.Generic;

namespace spreadsHeArc
{
    public class Branch
    {
        private string _name;
        public string Name {
            get => _name;
            set => _name = value; 
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
            set => _average = value;
        }

        private Dictionary<float, int> DictRating = new Dictionary<float, int>();


        public Branch(string name, int weight)
        {
            this.Name = name;
            this.Weight = weight;
        }
    }
}