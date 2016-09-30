using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KeyValueProvider
{
    internal class KeyValueProvider : IKeyValueProvider
    {
        private int _capacity;
        private Dictionary<string, string> _elements;
        private Dictionary<string, LinkedListNode<string>> _keys = new Dictionary<string, LinkedListNode<string>>();
        private LinkedList<string> _timestamps = new LinkedList<string>();

        public KeyValueProvider(int nElementCount)
        {
            this._capacity = nElementCount;
            this._elements = new Dictionary<string, string>(nElementCount);
        }
        public bool Put(string key, string value)
        {
            if (this._elements.ContainsKey(key))
            {
                this._elements[key] = value;
                this._timestamps.Remove(this._keys[key]);
                this._timestamps.AddLast(this._keys[key]);
            }
            else
            {
                if (this._elements.Count >= this._capacity)
                {
                    var toRemove = this._timestamps.First;
                    this._timestamps.Remove(this._keys[toRemove.Value]);
                    this._keys.Remove(toRemove.Value);
                    this._elements.Remove(toRemove.Value);
                }
                this._elements.Add(key, value);
                var t = this._timestamps.AddLast(key);
                this._keys.Add(key, t);
            }
            return true;
        }

        public bool Get(string key, out string value)
        {
            bool ret = this._elements.TryGetValue(key, out value);
            if (ret)
            {
                this._timestamps.Remove(this._keys[key]);
                this._timestamps.AddLast(this._keys[key]);
            }
            return ret;
        }
    }

    public class KeyValueProviderFactory
    {
        public IKeyValueProvider CreateKeyValueProvider(int nElementCount)
        {
            return new KeyValueProvider(nElementCount);
        }
    }
}
