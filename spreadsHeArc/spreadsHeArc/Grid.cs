using spreadsHeArc.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace spreadsHeArc
{
    public class Grid
    {
        public Module Module
        { 
            get => _module;
            set => _module = value;
        }

        private Module _module;

        public long Lines
        { 
            get => _lines;
            set => _lines = value;
        }

        private long _lines;

        public Grid(Module Module)
        {
            this._module = Module;
            //this._lines = this._module.DictBranch.LongCount();
        }

    }
}
