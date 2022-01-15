using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace spreadsHeArc.Model
{
    public class Rate : Model
    {
        public Rate(float mark, int weight)
        {
            this.Mark = mark;

            this.Weight = weight;
        }

        private float _mark;
        public float Mark
        {
            get => _mark;
            set => _mark = value;
        }

        private int _weight;
        public int Weight
        {
            get => _weight;
            set => _weight = value;
        }
    }
}
