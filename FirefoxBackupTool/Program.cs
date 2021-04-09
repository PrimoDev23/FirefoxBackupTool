using FirefoxBackupTool.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ICSharpCode.SharpZipLib.Tar;
using System.Diagnostics;

namespace FirefoxBackupTool
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("##########################################################");
            Console.WriteLine("#                          MENU                          #");
            Console.WriteLine("#            CLOSE FIREFOX BEFORE BACKING UP!!           #");
            Console.WriteLine("#                                                        #");
            Console.WriteLine("#                       1. BACKUP                        #");
            Console.WriteLine("#                       2. RESTORE                       #");
            Console.WriteLine("##########################################################");
            Console.WriteLine("Choose an option:");

            var key = Console.ReadKey();

            if(key.KeyChar == '1')
            {
                Stopwatch sw = Stopwatch.StartNew();
                string path = ProfileUtil.Backup();
                sw.Stop();

                Console.WriteLine();
                Console.WriteLine($"Backup created under {path} (Took: {(sw.ElapsedMilliseconds / 1000.0).ToString()}s)");
            }
            else
            {
                Console.WriteLine();
                Console.WriteLine("Enter the archive path:");

                string path = Console.ReadLine();

                Stopwatch sw = Stopwatch.StartNew();
                ProfileUtil.Restore(path);
                sw.Stop();

                Console.WriteLine($"Restore finsihed (Took: {(sw.ElapsedMilliseconds / 1000.0).ToString()}s)");
            }
            Console.ReadKey();
        }
    }
}
