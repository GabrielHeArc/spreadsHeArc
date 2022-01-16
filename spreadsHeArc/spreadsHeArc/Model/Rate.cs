using System;

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
            set
            {
                if (value < 0)
                    throw new Exception("La note doit être une valeur positive");
                else
                    _mark = value;
            }

        }

        private int _weight;
        public int Weight
        {
            get => _weight;
            set
            {
                if (value < 0)
                    throw new Exception("La pondération de la note doit être une valeur positive");
                else
                    _weight = value;
            }
        }
    }
}
