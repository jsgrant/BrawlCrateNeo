using BrawlCrate.UI.FileHandling;
using Eto.Forms;

namespace BrawlCrate.UI
{
    /// <summary>
    /// Main <see cref="Form"/> used as the base UI element for the program.
    /// </summary>
    public partial class MainForm : Form
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
        /// Private constructor.
        /// </summary>
        /// <remarks>Should only be called once by <see cref="Instance"/>.</remarks>
        private MainForm()
        {
            InitializeComponent();
        }
    }
}
