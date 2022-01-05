using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace spreadsHeArc
{
    public class Module
    {
        private string _nameModule;
        public string NameModule
        {
            get => _nameModule;
            set => _nameModule = value;
        }

        /// <summary>
        /// Nom de la branche et pondération dans le module
        /// </summary>
        public Dictionary<Branch, int> DictBranch = new Dictionary<Branch, int>();

        public Module(string name)
        {
           this.NameModule = name;
        }
    }
}
