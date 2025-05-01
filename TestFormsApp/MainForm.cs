using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using ThioWinUtils;

namespace TestFormsApp
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();

            ThioWinUtils.TrayContextMenu menu = new(
                updateURL: "https://example.com/update",
                appVersion: "1.0.0",
                processRestartMenuOption: true, 
                exitAction: ExitApp
                );

            SystemTray tray = new(
                trayContextMenu: menu,
                iconHandle: SystemIcons.Exclamation.Handle,
                tooltipText: "Test App",
                restoreAction: null,
                hwndInput: IntPtr.Zero
               );
        }

        private void ExitApp()
        {
            Console.WriteLine("Tray icon closed. Exiting...");
            this.Close();
        }
    }
}
