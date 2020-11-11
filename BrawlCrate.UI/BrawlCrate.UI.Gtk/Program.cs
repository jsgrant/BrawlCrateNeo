using System;
using Eto;
using Eto.Forms;

namespace BrawlCrate.UI.Gtk
{
    internal static class MainClass
    {
        [STAThread]
        public static void Main(string[] args)
        {
            new Application(Platforms.Gtk).Run(new MainForm(args));
        }
    }
}
