using System;
using System.Collections.Generic;
using System.Text;
using Sys = Cosmos.System;
using Banner.cmd;
using System.IO;
using Cosmos.System.FileSystem.VFS;
using Cosmos.System.FileSystem;

namespace Banner
{
    public class Kernel : Sys.Kernel
    {
        CosmosVFS fs = new CosmosVFS();

        protected override void BeforeRun()
        {
            Sys.FileSystem.VFS.VFSManager.RegisterVFS(fs);
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine("Banner v0.1");
            Console.WriteLine("");
        }

        protected override void Run()
        {
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.Write("banner");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("-$ ");
            Console.ForegroundColor = ConsoleColor.Gray;
            var input = Console.ReadLine();
            cmd.cmd.readCmd(input);
        }
    }
}
