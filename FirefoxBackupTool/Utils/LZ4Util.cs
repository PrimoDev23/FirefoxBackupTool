using lz4;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirefoxBackupTool.Utils
{
    public static class LZ4Util
    {
        public static void Compress(string tarPath, string destinationFile)
        {
            File.WriteAllBytes(destinationFile, LZ4Helper.Compress(File.ReadAllBytes(tarPath)));
        }

        public static void Decompress(string lz4Path, string destinationFile)
        {
            File.WriteAllBytes(destinationFile, LZ4Helper.Decompress(File.ReadAllBytes(lz4Path)));
        }
    }
}
