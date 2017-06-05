using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Management;

namespace Memento.Helpers
{
    static class GameProcess
    {
        public static IEnumerable<Process> FindProcess(string gameExecutable)
        {
            var wmiQueryString = "SELECT ProcessId, ExecutablePath, CommandLine FROM Win32_Process";
            using (var searcher = new ManagementObjectSearcher(wmiQueryString))
            using (var results = searcher.Get())
            {
                var query = from p in Process.GetProcesses()
                            join mo in results.Cast<ManagementObject>()
                            on p.Id equals (int)(uint)mo["ProcessId"]
                            select new
                            {
                                Process = p,
                                Path = (string)mo["ExecutablePath"],
                                CommandLine = (string)mo["CommandLine"],
                            };
                foreach (var item in query)
                {
                    if (string.Equals(item.Path, gameExecutable, StringComparison.OrdinalIgnoreCase))
                    {
                        yield return item.Process;
                    }
                }
            }
        }

        public static void KillProcess(string gameExecutable)
        {
            Process[] processes = FindProcess(gameExecutable).ToArray();
            foreach (Process process in processes)
            {
                process.Kill();
            }
        }
    }
}
