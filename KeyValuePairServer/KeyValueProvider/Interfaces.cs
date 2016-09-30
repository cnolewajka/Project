using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KeyValueProvider
{
    public interface IKeyValueProvider
    {
        bool Put(string key, string value);
        bool Get(string key, out string value);
    }
}
