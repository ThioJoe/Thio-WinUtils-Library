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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Tab;
using static ThioWinUtils.ModernTaskDialog;

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

        private void buttonExample2_Click(object sender, EventArgs e)
        {
            var dialog = new ModernTaskDialog
            {
                Title = "Sample Title",
                MainInstruction = "Example Main Instruction",
                Content = "Example Content",
                VerificationText = "Verification Text",
                //MainIcon = ModernTaskDialog.TaskDialogIcon.Information,
                MainIcon = (ModernTaskDialog.TaskDialogIcon)14,
                ParentWindowHandle = default,
                Coloredbar = TaskDialogBarColor.Yellow,

            };

            dialog.UpdateIcon(TaskDialogIconElement.Main, TaskDialogIcon.Error);
            dialog.UpdateColoredBar(TaskDialogBarColor.Green);

            int buttonId = dialog.Show();

        }

        private void button3_Click(object sender, EventArgs e)
        {
            var dialog = new ModernTaskDialog
            {
                Title = "Sample Title",
                MainInstruction = "Example Main Instruction",
                Content = "Example Content",
                VerificationText = "Verification Text",
                MainIcon = ModernTaskDialog.TaskDialogIcon.Information,
                ParentWindowHandle = default,
                Coloredbar = TaskDialogBarColor.Yellow,
            };

            // Call show on a separate thread
            Task.Run(() =>
            {
                int buttonId = dialog.Show();
                Console.WriteLine($"Button clicked with ID: {buttonId}");
            });

            // While it's showing, update the icon back and forth every second
            for (int i = 0; i < 5; i++)
            {
                Thread.Sleep(1000);
                dialog.UpdateIcon(TaskDialogIconElement.Main, TaskDialogIcon.Error);
                dialog.UpdateColoredBar(TaskDialogBarColor.Red);
                Thread.Sleep(1000);
                dialog.UpdateIcon(TaskDialogIconElement.Main, TaskDialogIcon.Information);
                dialog.UpdateColoredBar(TaskDialogBarColor.Yellow);
            }

        }
    }
}
