using FirefoxBackupTool.Properties;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirefoxBackupTool.Utils
{
    public static class ProfileUtil
    {
        public static string Backup()
        {
            //Create paths
            string tarPath = Path.Combine(Settings.Default.BackupPath, $"{DateTime.Now.ToString("dd-MM-yyyy-HH-mm-ss")}.tar");
            string lz4Path = Path.Combine(Settings.Default.BackupPath, $"{DateTime.Now.ToString("dd-MM-yyyy-HH-mm-ss")}.lz4");

            //First get a tar from the profile folder
            TarUtil.CreateTar(Settings.Default.ProfilePath, tarPath);
            LZ4Util.Compress(tarPath, lz4Path);

            return lz4Path;
        }

        public static void Restore(string lz4File)
        {
            if (File.Exists(lz4File))
            {
                string tarPath = Path.Combine(Settings.Default.BackupPath, $"{DateTime.Now.ToString("dd-MM-yyyy-HH-mm-ss")}.tar");

                LZ4Util.Decompress(lz4File, tarPath);

                TarUtil.ExtractTar(tarPath, Settings.Default.ProfilePath);
            }
        }
    }
}
