using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KeyValueProvider
{
    public class KeyValuePairServer
    {
        private IKeyValueProvider _provider;
        private char[] _separators = new char[] { '\n' };

        public void Initialize(int nElementCount)
        {
            var factory = new KeyValueProviderFactory();
            this._provider = factory.CreateKeyValueProvider(nElementCount);
        }

        public void Initialize(IKeyValueProvider provider)
        {
            this._provider = provider;
        }

        public string Execute(string command)
        {
            var cmds = this.ParseCommand(command);
            if (null == cmds)
                return "\n";

            switch (cmds[0])
            {
                case "PUT":
                    if (cmds.Length < 3)
                        return "FAIL\n";
                    return this.Put(cmds[1], cmds[2]);
                case "GET":
                    if (cmds.Length < 2)
                        return "FAIL\n";
                    return this.Get(cmds[1]);
                default:
                    return "FAIL\n";
            }
        }

        private string Put(string key, string value)
        {
            if (this._provider.Put(key, value))
                return "OK\n";
            else
                return "FAIL\n";
        }

        private string Get(string key)
        {
            string val;
            if (this._provider.Get(key, out val))
                return val + "\n";
            else
                return "\n";
        }

        private string[] ParseCommand(string command)
        {
            var cmds = command.Split(this._separators);
            if (cmds.Length < 1)
                return null;
            return cmds;
        }
    }
}
