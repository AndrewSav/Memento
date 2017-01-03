using System;
using System.Windows.Forms;
using Serilog;

namespace Memento
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.SetUnhandledExceptionMode(UnhandledExceptionMode.ThrowException);
            AppDomain.CurrentDomain.UnhandledException += CurrentDomain_UnhandledException;

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Forms.Memento());
        }

        private static void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            var log = new LoggerConfiguration().WriteTo.RollingFile("unlandled.log").CreateLogger();
            Exception ex = e.ExceptionObject as Exception;
            MessageBox.Show(ex?.ToString() ?? "Unhandled exception");
            log.Fatal(ex, "Unhandled exception");
            Environment.FailFast("Unhandled exception", ex);
        }
    }
}
