using System;

namespace spreadsHeArc.Model
{
    public class Rating : Model
    {        
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

        private int _weightMark;
        public int WeightMark
        {
            get => _weightMark;
            set
            {
                if (value < 0)
                    throw new Exception("La pondération de la note doit être une valeur positive");
                else
                    _weightMark = value;
            }
        }

        public Rating(float mark, int weight)
        {
            this.Mark = mark;

            this.WeightMark = weight;
        }
    }
}
