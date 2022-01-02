using System.Collections.Generic;

namespace spreadsHeArc
{
    public class Branch
    {
        public string name;
        public string weight;
        public float average;

        public Branch(string name, string weight)
        {
            this.name = name;
            this.weight = weight;
        }
        string Name { get; set; }
        private Dictionary<float, int> DictRating = new Dictionary<float, int>();
        
    }
}