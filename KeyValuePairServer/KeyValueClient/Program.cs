using KeyValueProvider;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KeyValueClient
{
    class Program
    {
        static void Main(string[] args)
        {
            var server = new KeyValuePairServer();
            server.Initialize(5);

            string[] cmds = new string[]
            {
                "PUT\nkey1\nvalue1\n",
                "PUT\nkey2\nvalue2\n",
                "PUT\nkey3\nvalue3\n",
                "PUT\nkey4\nvalue4\n",
                "PUT\nkey5\nvalue5\n",
                "PUT\nkey6\nvalue6\n",
                "GET\nkey2\n",
                "PUT\nkey9\nvalue9\n",
                "GET\nkey1\n",
                "GET\nkey2\n",
                "GET",
                "PUT\nkey9",
            };

            foreach (var cmd in cmds)
            {
                var res = server.Execute(cmd);
                Console.WriteLine("Command:\n{0}\nResult:\n{1}\n", cmd.Replace("\n", "\\n"), res.Replace("\n", "\\n"));
            }
            Console.ReadLine();
        }
    }
}
