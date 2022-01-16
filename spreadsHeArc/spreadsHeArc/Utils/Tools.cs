namespace spreadsHeArc.Utils
{
    using System.Collections.Generic;
    /// <summary>
    /// Source : https://www.dotnetperls.com/multimap
    /// </summary>
    /// <typeparam name="V"></typeparam>
    public class MultiMap<V>
    {
        Dictionary<float, List<V>> _dictionary =
            new Dictionary<float, List<V>>();

        public void Add(float key, V value)
        {
            // Add a key.
            List<V> list;
            if (this._dictionary.TryGetValue(key, out list))
            {
                list.Add(value);
            }
            else
            {
                list = new List<V>();
                list.Add(value);
                this._dictionary[key] = list;
            }
        }

        public IEnumerable<float> Keys
        {
            get
            {
                // Get all keys.
                return this._dictionary.Keys;
            }
        }

        public List<V> this[float key]
        {
            get
            {
                // Get list at a key.
                List<V> list;
                if (!this._dictionary.TryGetValue(key, out list))
                {
                    list = new List<V>();
                    this._dictionary[key] = list;
                }
                return list;
            }
        }
    }
}
