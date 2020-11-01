using System;
using Eto.Forms;

namespace BrawlCrate.UI.Gtk
{
    class MainClass
    {
        [STAThread]
        public static void Main(string[] args)
        {
            new Application(Eto.Platforms.Gtk).Run(MainForm.Instance);
        }
    }
}
