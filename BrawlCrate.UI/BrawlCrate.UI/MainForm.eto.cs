using Eto.Drawing;
using Eto.Forms;

namespace BrawlCrate.UI
{
    partial class MainForm : Form
    {
        /// <summary>
        /// Set up the <see cref="Form"/> with visual styling.
        /// </summary>
        void InitializeComponent()
        {
            Icon = Iconography.MainIcon;
            Title = Versioning.ProgramTitle;
            ClientSize = new Size(680, 420);
            Padding = 5;

            Content = new Splitter
            {
                FixedPanel = SplitterFixedPanel.Panel1,
                Panel1 = _nodeTree = new TreeGridView(),
                Panel2 = new Splitter
                {
                    Orientation = Orientation.Vertical,
                    FixedPanel = SplitterFixedPanel.None,
                    Panel1 = _propertyGrid = new PropertyGrid { Size = new Size(100,100) },
                    Panel2 = _previewPanel = new Panel { Size = new Size(100, 100) },
                    Position = 255
                },
                Position = 235
            };

            // create a few commands that can be used for the menu and toolbar
            var openFile = new Command { MenuText = "&Open", ToolBarText = "Open a file", Shortcut = Application.Instance.CommonModifier | Keys.O };
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
                    new ButtonMenuItem { Text = "&Edit", Items = { new Command { MenuText = "Coming Soon™" } } }
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
