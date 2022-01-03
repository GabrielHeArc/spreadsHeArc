using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace spreadsHeArc
{
    public class Module
    {
        string Name;
        int Weight;
        private string weight;
        float average;

        Dictionary<Branch, int> DictBranch = new Dictionary<Branch, int>();

        public Module(string name, string weight)
        {
            Name = name;
            this.weight = weight;
        }
    }
}
