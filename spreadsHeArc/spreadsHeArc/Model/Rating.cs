using Newtonsoft.Json;
using System;
using System.Windows;

namespace spreadsHeArc.Model
{
    [JsonObject(MemberSerialization.OptIn)]
    public class Rating : Model
    {
        /// <summary>
        /// Rating object contains mark and its weight.
        /// </summary>
        /// <param name="mark">Mark in branch</param>
        /// <param name="weight">Weight of a mark in branch</param>
        public Rating(float mark, int weight)
        {
            this.Mark = mark;
            this.WeightMark = weight;
        }

        private float _mark;

        [JsonProperty]
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

        [JsonProperty]
        public int WeightMark
        {
            get => _weightMark;
            set
            {
                /*if (value <= 0)
                 * MessageBox.Show("Le poids de la note doit être supérieur à 0");
                else
                    _weightMark = value;
                */
            }
        }
    }
}
