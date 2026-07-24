using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TestFormsApp
{
    internal static class Program
    {
        // Import the Win32 API to set OS-level DPI awareness. This way we don't need separate app.config to remain next to the EXE.
        // See: https://learn.microsoft.com/en-us/windows/win32/api/winuser/nf-winuser-setprocessdpiawarenesscontext
        //  The docs recommend doing this via app.config instead of API call but have a file is ugly.
        [DllImport("user32.dll", SetLastError = true), DefaultDllImportSearchPaths(DllImportSearchPath.System32)]
        private static extern bool SetProcessDpiAwarenessContext(IntPtr dpiFlag);

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            //try
            //{
            //    // Tell Windows this app handles its own DPI scaling (replaces the manifest setting)
            //    // Enum values at: https://learn.microsoft.com/en-us/windows/win32/hidpi/dpi-awareness-context
            //    SetProcessDpiAwarenessContext(new IntPtr(-4));  // DPI_AWARENESS_CONTEXT_PER_MONITOR_AWARE_V2 = -4
            //    // Tell WinForms to actively resize controls (replaces the app.config setting)
            //    AppContext.SetSwitch("Switch.System.Windows.Forms.EnableWindowsFormsHighDpiAutoResizing", true);
            //}
            //catch (EntryPointNotFoundException) // Fails gracefully on Windows versions older than Windows 10 Anniversary Update
            //{ Debug.WriteLine("SetProcessDpiAwarenessContext not available on this Windows version"); }

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainForm());
        }
    }
}
