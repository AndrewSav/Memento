using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Memento.Helpers;

namespace Memento
{
    static class Program
    {
        [STAThread]
        static void Main()
        {

            //string path = @"D:\Projects\ConsoleApplication19\bin\Debug\Saves\Darkest Dungeon Profile 0";

            //var b1 = BackupFolders.GetBackupsDescending(path).ToArray();

            //List<string> x = new List<string>();
            //string t = BackupFolders.FindNext(path);
            //while(t != null)
            //{
            //    x.Add(t);
            //    t = BackupFolders.FindNext(path,t);
            //}
            //var b2 = x.ToArray();

            //if (b1.Length == b2.Length)
            //{
            //    for (int i = 0; i < b1.Length; i++)
            //    {
            //        if (b1[i] != b2[i])
            //        {
            //            Console.WriteLine(@"Bla!");
            //        }
            //    }
            //}

            //LoggerHelper.GetLoggerForFolder(@"d:\Andrew");


            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Forms.Memento());
        }
    }
}
