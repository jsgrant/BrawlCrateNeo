using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace BrawlCrate.WinForms
{
    internal partial class MainForm : Form
    {
        /// <summary>
        /// The running instance of the MainForm. This should be the only MainForm in use at any given time.
        /// </summary>
        internal static readonly MainForm Instance = new MainForm();

        /// <summary>
        /// Default Constructor
        /// </summary>
        internal MainForm()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Handler for opening a file.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">An object that contains no event data.</param>
        private void OpenFile_Click(object sender, EventArgs e)
        {
            if (Program.OpenFileDialog.ShowDialog() == DialogResult.OK)
            {
                Program.OpenFile = File.ReadAllBytes(Program.OpenFileDialog.FileName);
                Text = $"BrawlCrate NEO - {Encoding.UTF8.GetString(Program.OpenFile, 0, 4)}";
            }
        }

        /// <summary>
        /// Handler for closing a file.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">An object that contains no event data.</param>
        private void CloseFile_Click(object sender, EventArgs e)
        {
            Program.OpenFile = null;
            Text = "BrawlCrate NEO";
        }
    }
}
