using Eto.Forms;
using Eto.Drawing;

namespace BrawlCrate.UI
{
    partial class MainForm : Form
    {
        void InitializeComponent()
        {
            Icon = Iconography.MainIcon;
            Title = Versioning.ProgramTitle;
            ClientSize = new Size(680, 420);
            Padding = 10;

            Content = new StackLayout
            {
                Items =
                {
                    "Welcome to BrawlCrate Neo! Actual features coming soon™"
                    // add more controls here
				}
            };

            // create a few commands that can be used for the menu and toolbar
            var openFile = new Command {MenuText = "&Open", ToolBarText = "Open a file", Shortcut = Application.Instance.CommonModifier | Keys.O };
            openFile.Executed += OpenFile;

            var quitCommand = new Command { MenuText = "Quit", ToolBarText = "Quit the program" };
            quitCommand.Executed += (sender, e) => Application.Instance.Quit();

            var aboutCommand = new Command { MenuText = "About...", ToolBarText = "Learn more about the program" };
            aboutCommand.Executed += (sender, e) => new AboutDialog().ShowDialog(this);

            // create menu
            Menu = new MenuBar
            {
                Items =
                {
					// File submenu
					new ButtonMenuItem { Text = "&File", Items = { openFile } },
					new ButtonMenuItem { Text = "&Edit", Items = { /* commands/items */ } },
					new ButtonMenuItem { Text = "&View", Items = { /* commands/items */ } }
                },
                ApplicationItems =
                {
					// application (OS X) or file menu (others)
					new ButtonMenuItem { Text = "&Preferences..." }
                },
                // Placed in Application Menu for OSX, File Menu for Windows/Linux
                QuitItem = quitCommand,
                // Placed in Application Menu for OSX, Help Menu for Windows/Linux
                AboutItem = aboutCommand
            };
        }
    }
}
