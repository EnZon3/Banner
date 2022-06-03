using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Cosmos.System.FileSystem.VFS;
using Cosmos.System.FileSystem;
using Sys = Cosmos.System;

namespace Banner.util.Edit
{
    class Edit
    {
        static CosmosVFS fs = new Sys.FileSystem.CosmosVFS();
        public static void Editor(string file)
        {
            while (true)
            {
                var input = Console.ReadLine();
                try
                {
                    var file1 = VFSManager.GetFile(@"0:\"+file);
                    var file_stream = file1.GetFileStream();

                    if (file_stream.CanWrite)
                    {
                        byte[] text_to_write = Encoding.ASCII.GetBytes(input);
                        file_stream.Write(text_to_write, 0, text_to_write.Length);
                        break;
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.ToString());
                    break;
                }
            }
        }
    }
}
