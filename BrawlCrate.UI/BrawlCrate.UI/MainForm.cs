using System;
using System.IO;
using BrawlCrate.UI.FileHandling;
using Eto.Forms;

namespace BrawlCrate.UI
{
    /// <summary>
    /// Main <see cref="Form"/> used as the base UI element for the program.
    /// </summary>
    public partial class MainForm
    {
        /// <summary>
        /// The sole instance of the <see cref="MainForm"/> in a given instance of the program.
        /// </summary>
        public static MainForm Instance { get; private set; }

        /// <summary>
        /// The default <see cref="OpenFileDialog"/> containing the default editable <see cref="SupportedFileFilter"/>s.
        /// </summary>
        public static readonly OpenFileDialog FileOpenDialog = SupportedFilesHandler.GetOpenFileDialog();

        /// <summary>
        /// The default <see cref="TreeGridView"/> which displays a visual representation of current node hierarchies.
        /// </summary>
        private TreeGridView _nodeTree;

        /// <summary>
        /// The default <see cref="PropertyGrid"/> which displays all exposed properties of a selected node.
        /// </summary>
        private PropertyGrid _propertyGrid;

        /// <summary>
        /// Preview <see cref="Panel"/> used to display a visual preview of a given Node, where applicable.
        /// </summary>
        private Panel _previewPanel;

        private static string _theme = "DefaultDark";
        public static string CurrentTheme
        {
            get => _theme;
            set
            {
                _theme = value;
            }
        }

        /// <summary>
        /// Argumented constructor allowing passing in of arguments from the program.
        /// </summary>
        /// <remarks>Should only be called once per run.</remarks>
        /// <exception cref="T:System.Exception"><see cref="Instance"/> is not null.</exception>
        public MainForm(string[] args)
        {
            if (Instance != null)
            {
                throw new Exception("Only one instance of the Main Form can be active in a given program instance.");
            }
            Themes.GenerateThemes();
            Instance = this;
            InitializeComponent();
            RefreshTheme();
            if (args.Length >= 1)
            {
                OpenFile(args[0]);
            }
        }

        /// <summary>
        /// Opens the base OpenFileDialog and opens a file if the user selects one.
        /// </summary>
        /// <param name="sender">The sending object.</param>
        /// <param name="e">Event arguments.</param>
        public void OpenFile(object sender, EventArgs e)
        {
            if (FileOpenDialog.ShowDialog(this) == DialogResult.Ok)
            {
                OpenFile(FileOpenDialog.FileName);
            }
        }

        /// <summary>
        /// Opens a given file from a path string.
        /// </summary>
        /// <param name="fileName">The full path of the file that is to be opened.</param>
        public void OpenFile(string fileName)
        {
            Title = $"{Path.GetFileName(fileName)} - {Versioning.ProgramTitle}";
        }

        public void RefreshTheme()
        {
            Themes.UpdateThemeRecursive(this);
            Invalidate();
        }
    }
}
