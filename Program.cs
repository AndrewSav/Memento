using Serilog;
using System;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows.Forms;

[assembly: CLSCompliant(true)]
namespace Memento
{
    static class Program
    {
        sealed class BringToTopReceiver : NativeWindow, IDisposable
        {
            private readonly Action _onShow;

            public BringToTopReceiver(Action onShow)
            {
                _onShow = onShow;

                // Create an invisible top-level window.
                CreateHandle(new CreateParams
                {
                    Caption = "Memento.ShowMeReceiver",
                    X = 0,
                    Y = 0,
                    Height = 0,
                    Width = 0,
                    Style = 0
                });
            }

            protected override void WndProc(ref Message m)
            {
                if (m.Msg == WM_SHOWME)
                {
                    _onShow();
                    return;
                }
                base.WndProc(ref m);
            }

            public void Dispose() => DestroyHandle();
        }

        static Mutex mutex = new Mutex(false, @"Global\{RO-54B7C3B0-A785-40B9-AFFF-397247B83F84}");
        public const int HWND_BROADCAST = 0xffff;
        public static readonly int WM_SHOWME = RegisterWindowMessage("WM_SHOWME.{RO-54B7C3B0-A785-40B9-AFFF-397247B83F84}");
        [DllImport("user32")]
        public static extern bool PostMessage(IntPtr hwnd, int msg, IntPtr wparam, IntPtr lparam);
        [DllImport("user32")]
        public static extern int RegisterWindowMessage(string message);

        [STAThread]
        static void Main()
        {
            if (mutex.WaitOne(TimeSpan.Zero, false))
            {
                Application.SetUnhandledExceptionMode(UnhandledExceptionMode.ThrowException);
                AppDomain.CurrentDomain.UnhandledException += CurrentDomain_UnhandledException;

                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Forms.Memento mainForm = new();

                using var receiver = new BringToTopReceiver(() =>
                {
                    if (!mainForm.IsHandleCreated) return;

                    mainForm.BeginInvoke(new Action(() =>
                    {
                        mainForm.BringToTop();
                    }));
                });

                Application.Run(mainForm);
                mutex.ReleaseMutex();
            }
            else
            {
                if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
                {
                    PostMessage(
                        HWND_BROADCAST,
                        WM_SHOWME,
                        IntPtr.Zero,
                        IntPtr.Zero);
                }
                else
                {
                    Console.WriteLine("The application is already running");
                }
            }
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
