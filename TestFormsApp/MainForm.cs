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

            // Create a TrayContextMenu instance to then use with SystemTray constructor
            ThioWinUtils.TrayContextMenu menu = new(
                updateURL: "https://example.com/update",
                appVersion: "1.0.0",
                processRestartMenuOption: true, 
                exitAction: ExitApp
                );

            menu.AddCustomMenuItem("Example Custom Item", ShowModernDialogExample);

            // SystemTray constructor to show an icon in the system tray.
            // Also we pass in the optional TrayContextMenu object we created above so it is right clickable.
            SystemTray tray = new(
                trayContextMenu: menu,
                iconHandle: SystemIcons.Exclamation.Handle,
                tooltipText: "Example Icon",
                restoreAction: null,
                hwndInput: IntPtr.Zero
               );
        }

        private void ExitApp()
        {
            Console.WriteLine("Tray icon closed. Exiting...");
            this.Close();
        }

        private void ShowModernDialogExample()
        {
            ThioWinUtils.ModernTaskDialog.Template.ShowSuccess("Success message title", "This is the main message", "This is additional info");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ThioWinUtils.ModernTaskDialog testDialog = new()
            {
                CollapsedControlText = "Show More",
                ExpandedControlText = "Show Less",
                ExpandedInformation = "Test Info Expanded",
                MainInstruction = "Main instruction Header",
                Content = "Content Text"
            };

            testDialog.Show();
        }
    }
}
