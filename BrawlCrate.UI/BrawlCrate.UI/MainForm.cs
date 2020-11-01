using System;
using Eto.Forms;
using Eto.Drawing;

namespace BrawlCrate.UI
{
    public partial class MainForm : Form
    {
        public static readonly MainForm Instance = new MainForm();

        public MainForm()
        {
            InitializeComponent();
        }
    }
}
