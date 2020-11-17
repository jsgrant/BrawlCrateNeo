using System;
using System.IO;
using BrawlCrate.Core.Internal;
using BrawlCrate.Core.Nodes;
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
        public static MainForm? Instance { get; private set; }

        /// <summary>
        /// The default <see cref="OpenFileDialog"/> containing the default editable <see cref="SupportedFileFilter"/>s.
        /// </summary>
        public static readonly OpenFileDialog FileOpenDialog = SupportedFilesHandler.GetOpenFileDialog();

        /// <summary>
        /// The default <see cref="TreeGridView"/> which displays a visual representation of current node hierarchies.
        /// </summary>
        private TreeGridView? _nodeTree;

        /// <summary>
        /// The default <see cref="PropertyGrid"/> which displays all exposed properties of a selected node.
        /// </summary>
        private PropertyGrid? _propertyGrid;

        /// <summary>
        /// Preview <see cref="Panel"/> used to display a visual preview of a given Node, where applicable.
        /// </summary>
        private Panel? _previewPanel;

        public ResourceNode? RootNode { get; private set; }

        /// <summary>
        /// Argumented constructor allowing passing in of arguments from the program.
        /// </summary>
        /// <remarks>Should only be called once per run.</remarks>
        /// <exception cref="T:System.Exception"><see cref="Instance"/> is not null.</exception>
        public MainForm(string[] args)
        {
            if (Instance != null)
            {
                throw new InvalidOperationException("Only one instance of the Main Form can be active in a given program instance.");
            }
            Instance = this;
            InitializeComponent();
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
        public void OpenFile(object? sender, EventArgs e)
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
            OpenFile(fileName, false);
        }

        /// <summary>
        /// Opens a given file from a path string, with the option to skip error messages such as "File Not Found".
        /// </summary>
        /// <param name="fileName">The full path of the file that is to be opened.</param>
        /// <param name="hideErrors">If true, does not show error messages such as "File Not Found". Useful for API calls.</param>
        public void OpenFile(string fileName, bool hideErrors)
        {
            // Don't open a file if the user refuses to close the file
            if (!CloseFile())
            {
                return;
            }
            var path = fileName;
            if (!File.Exists(path))
            {
                // Show an error message if not hiding them.
                if (!hideErrors)
                {
                    MessageBox.Show("File Not Found", MessageBoxButtons.OK, MessageBoxType.Error);
                }
                return;
            }

            // Change the MainForm title
            Title = $"{Path.GetFileName(path)} - {Versioning.ProgramTitle}";

            // Get a temporary file location
            var tempFile = Path.GetTempFileName();
            try
            {
                // Attempt to copy to a temporary file to prevent write locks
                File.Copy(path, tempFile);
                path = tempFile;
            }
            catch
            {
                // Clear the temp file if an error is thrown. Just use the regular file
                if (File.Exists(tempFile))
                {
                    File.Delete(tempFile);
                }
            }

            RootNode = new ResourceNode(new DataSource(path));
        }

        public bool CloseFile()
        {
            return CloseFile(false);
        }

        public bool CloseFile(bool force)
        {
            RootNode?.Dispose();
            return true;
        }
    }
}
