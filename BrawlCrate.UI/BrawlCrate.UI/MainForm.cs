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
        public static readonly MainForm Instance = new MainForm();

        /// <summary>
        /// The default <see cref="OpenFileDialog"/> containing the default editable <see cref="SupportedFileFilter"/>s.
        /// </summary>
        public static readonly OpenFileDialog FileOpenDialog = SupportedFilesHandler.GetOpenFileDialog();

        /// <summary>
        /// The default <see cref="OpenFileDialog"/> containing the default editable <see cref="SupportedFileFilter"/>s.
        /// </summary>
        private readonly PropertyGrid _propertyGrid = new PropertyGrid();

        /// <summary>
        /// Private constructor.
        /// </summary>
        /// <remarks>Should only be called once by <see cref="Instance"/>.</remarks>
        private MainForm()
        {
            InitializeComponent();
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

        public void OpenFile(string fileName)
        {
            Title = $"{Path.GetFileName(fileName)} - {Versioning.ProgramTitle}";
        }
    }
}
