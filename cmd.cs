using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sys = Cosmos.System;
using System.IO;
using Cosmos.System.FileSystem.VFS;
using Cosmos.System.FileSystem;
using Banner.util.Crash;
using Banner.util.Edit;
using Banner.util.BScript;


namespace Banner.cmd
{
    class cmd
    {
        static CosmosVFS fs = new Sys.FileSystem.CosmosVFS();
		static Disk disk;

		public static void readCmd(string inp)
		{
			int partition = 0;
			string[] prInp = inp.Split(' ');
			switch (prInp[0])
            {
				case "help":
					Console.ForegroundColor = ConsoleColor.Blue;
					Console.WriteLine("help: this command");
					Console.WriteLine("dir: Displays directory list");
					Console.WriteLine("cat: displays the contents of the file, format: cat [file name with extention]");
					Console.WriteLine("run: Runs a BScript file, format: run [file name with extention]");
                    Console.WriteLine("runL: Runs BScript format: run [script]");
					Console.WriteLine("cr: creates a file, format: cr [filename and extention]");
					Console.WriteLine("edit: edits a file, format: edit [filename with extention]");
					Console.WriteLine("format: Formats the drive to FAT32 (WARNING all data will be lost!) (NOT WORKING)");
					Console.WriteLine("freeSpace: gets free space");
					Console.WriteLine("gurl: Basic version of curl, format: gurl [url] -[param] (NOT FINISHED)");
					Console.WriteLine("lsDisk: gets all disks");
					Console.WriteLine("restart: Self explainatory");
					Console.WriteLine("shutdown: Self explainatory");
					Console.ForegroundColor = ConsoleColor.Gray;
					break;
				case "format":
					disk.FormatPartition(partition, "FAT32", true);
					break;
				case "lsDisk":
					int counter = 0;
					foreach (var disk1 in fs.GetDisks())
					{
						Console.WriteLine("Disk #: " + counter);

						counter++;
					}
					break;
				case "freeSpace":
					long available_space = VFSManager.GetAvailableFreeSpace("0:\\");
                    Console.WriteLine("Available Free Space: " + available_space);
					break;
				case "edit":
					Edit.Editor(prInp[1]);
					Console.WriteLine("Saved");
					break;
				case "run":
					try
					{
						string scrFile = File.ReadAllText(@"0:\" + prInp[1]);
						BScript.Run(scrFile);
					}
					catch (Exception e)
					{
						Crash.BChk(e.ToString());
					}
					break;
				case "runL":
					BScript.Run(prInp[1]);
					break;
				case "restart":
					Sys.Power.Reboot();
					break;
				case "shutdown":
					Sys.Power.Shutdown();
					break;
				case "cr":
					try
					{
                        VFSManager.CreateFile(@"0:\" + prInp[1]);
					}
					catch (Exception e)
					{
						Console.WriteLine(e.ToString());
					}
					break;
				case "dir":
					Console.ForegroundColor = ConsoleColor.Blue;
					var directory_list = Directory.GetFiles(@"0:\");
					Console.WriteLine("Directory list of 0:");
					foreach (var file in directory_list)
					{
						Console.WriteLine(file);
					}
					Console.ForegroundColor = ConsoleColor.Gray;
					break;
				case "cat":
					Console.ForegroundColor = ConsoleColor.Blue;
					try
					{
						Console.WriteLine(File.ReadAllText(@"0:\"+prInp[1]));
					}
					catch (Exception e)
					{
						Crash.BChk(e.ToString());
					}
					Console.ForegroundColor = ConsoleColor.Gray;
					break;
				default:
					Console.ForegroundColor = ConsoleColor.Blue;
					Console.WriteLine("Invalid command, try typing it in again.");
					Console.ForegroundColor = ConsoleColor.Gray;
					break;
			}
		}
	}
}
