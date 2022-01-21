using System;

namespace spreadsHeArc.Model
{
    public class Rating : Model
    {
        /// <summary>
        /// Rating object contains mark and its weight.
        /// </summary>
        /// <param name="mark"></param>
        /// <param name="weight"></param>
        public Rating(float mark, int weight)
        {
            this.Mark = mark;

            this.WeightMark = weight;
        }

        private float _mark;
        public float Mark
        {
            get => _mark;
            set
            {
                if (value < 0)
                    throw new Exception("La note doit être une valeur positive");
                else if (value > 6)
                    throw new Exception("La note doit être inférieure à 6");
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
                if (value <= 0)
                    throw new Exception("La pondération de la note doit être une valeur positive");
                else
                    _weightMark = value;
            }
        }
    }
}
