using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Banner.cmd;

namespace Banner.util.BScript
{
    class BScript
    {
        public static void Run(string script)
        {
            string[] parsed = script.Split(';');

            foreach (string Index in parsed)
            {
                cmd.cmd.readCmd(Index);
            }
        }
    }
}