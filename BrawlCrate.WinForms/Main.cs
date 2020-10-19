using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BrawlCrate.WinForms
{
    public partial class Main : Form
    {
        internal OpenFileDialog openFileDialog = new OpenFileDialog();

        public Main()
        {
            InitializeComponent();
        }

        private void OpenFile_Click(object sender, EventArgs e)
        {
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                Program.OpenFile = File.ReadAllBytes(openFileDialog.FileName);
                Text = $"BrawlCrate NEO - {Encoding.UTF8.GetString(Program.OpenFile, 0, 4)}";
            }
        }
        private void CloseFile_Click(object sender, EventArgs e)
        {
            Program.OpenFile = null;
            Text = "BrawlCrate NEO";
        }
    }
}
