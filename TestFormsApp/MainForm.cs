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

            // Get the default windows system icon
            Icon icon = SystemIcons.Application;
            ThioWinUtils.ContextMenu menu = new ThioWinUtils.ContextMenu(processRestartMenuOption: true, exitAppMenuOption: true, exitAction: ExitApp);
            SystemTray tray = new SystemTray(icon: icon, tooltipText: "Test", createContextMenuAction: menu.Show);
        }

        private void ExitApp()
        {
            Console.WriteLine("Tray icon closed. Exiting...");
            this.Close();
        }
    }
}
