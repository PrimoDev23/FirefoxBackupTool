using ICSharpCode.SharpZipLib.Tar;
using lz4;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirefoxBackupTool.Utils
{
    public static class TarUtil
    {
        public static void CreateTar(string directoryPath, string desinationFile)
        {
            //We can't do this if directory doesn't exist
            if (Directory.Exists(directoryPath))
            {
                //Always create this one and overwrite old ones
                using (FileStream fs = new FileStream(desinationFile, FileMode.Create))
                {
                    using (TarArchive archive = TarArchive.CreateOutputTarArchive(fs))
                    {
                        //Write the files to tar archive
                        archive.RootPath = directoryPath.Replace("\\", "/");
                        archive.WriteEntry(TarEntry.CreateEntryFromFile(directoryPath), true);
                    }
                }
            }
        }

        public static void ExtractTar(string tarPath, string destinationPath)
        {
            //If Directory doesn't exist just create it
            if (!Directory.Exists(destinationPath))
            {
                Directory.CreateDirectory(destinationPath);
            }

            using (FileStream fs = new FileStream(tarPath, FileMode.Open))
            {
                using (TarArchive archive = TarArchive.CreateInputTarArchive(fs))
                {
                    //Read files from the archive
                    archive.ExtractContents(destinationPath);
                }
            }
        }
    }
}
