using System;
using Serilog;
using System.Windows.Forms;
using System.Diagnostics;
using System.IO;

[assembly: CLSCompliant(true)]
namespace Memento
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.SetUnhandledExceptionMode(UnhandledExceptionMode.ThrowException);
            AppDomain.CurrentDomain.UnhandledException += CurrentDomain_UnhandledException;

            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Memento.Forms.Memento());
        }

        private static void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            var log = new LoggerConfiguration().WriteTo.File("unhandled.log", rollingInterval: RollingInterval.Day).CreateLogger();
            Exception ex = e.ExceptionObject as Exception;
            MessageBox.Show(ex?.ToString() ?? "Unhandled exception");
            log.Fatal(ex, "Unhandled exception");
            Environment.FailFast("Unhandled exception", ex);
        }
    }
}
