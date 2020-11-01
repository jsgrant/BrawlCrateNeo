using System;
using System.Collections;
using System.IO;
using System.Reflection;
using System.Runtime.CompilerServices;
using Eto.Forms;
using Eto.Drawing;

namespace BrawlCrate.UI
{
    partial class MainForm : Form
    {
        public static readonly OpenFileDialog OpenFileDialog = new OpenFileDialog();
        public static readonly OpenFileDialog OpenFilesDialog = new OpenFileDialog { Title = "Open Files", MultiSelect = true };

        internal StackLayoutItem test;
        void InitializeComponent()
        {
            Icon = Iconography.Icon;
            Title = "BrawlCrate Neo";
            ClientSize = new Size(400, 350);
            Padding = 10;

            Content = new StackLayout
            {
                Items =
                {
                    "Hello World!",
					// add more controls here
				}
            };

            // create a few commands that can be used for the menu and toolbar
            var openFile = new Command {MenuText = "&Open", ToolBarText = "Open a file"};
            openFile.Executed += OpenFile;

            var clickMe = new Command { MenuText = "Click Me!", ToolBarText = "Click Me!" };
            clickMe.Executed += (sender, e) => MessageBox.Show(this, "I was clicked!");

            var quitCommand = new Command { MenuText = "Quit", Shortcut = Application.Instance.CommonModifier | Keys.Q };
            quitCommand.Executed += (sender, e) => Application.Instance.Quit();

            var aboutCommand = new Command { MenuText = "About..." };
            aboutCommand.Executed += (sender, e) => new AboutDialog().ShowDialog(this);

            // create menu
            Menu = new MenuBar
            {
                Items =
                {
					// File submenu
					new ButtonMenuItem { Text = "&File", Items = { openFile } },
					new ButtonMenuItem { Text = "&Edit", Items = { /* commands/items */ } },
					new ButtonMenuItem { Text = "&View", Items = { /* commands/items */ } },
				},
                ApplicationItems =
                {
					// application (OS X) or file menu (others)
					new ButtonMenuItem { Text = "&Preferences..." },
                },
                QuitItem = quitCommand,
                AboutItem = aboutCommand
            };

            // create toolbar			
            ToolBar = new ToolBar { Items = { clickMe } };
        }

        public void OpenFile(object sender, EventArgs e)
        {
            if (OpenFileDialog.ShowDialog(this) == DialogResult.Ok)
            {
                (Content as StackLayout).Items[0] = OpenFileDialog.FileName;
            }
        }
    }
}
