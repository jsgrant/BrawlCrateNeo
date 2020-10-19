using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BrawlCrate.WinForms
{
    internal static class Program
    {
        /// <summary>
        /// A byte array representation of the currently open file. Null when no file is currently open.
        /// </summary>
        internal static byte[]? OpenFile { get; set; }

        /// <summary>
        /// The only single-file open file dialog to be used by the program.
        /// </summary>
        internal static readonly OpenFileDialog OpenFileDialog = new OpenFileDialog();

        /// <summary>
        /// The only multi-file open file dialog to be used by the program.
        /// </summary>
        internal static readonly OpenFileDialog OpenMultiFileDialog = new OpenFileDialog {Multiselect = true};

        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(MainForm.Instance);
        }
    }
}
