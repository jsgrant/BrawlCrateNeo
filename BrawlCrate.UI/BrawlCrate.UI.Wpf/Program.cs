using System;
using Eto;
using Eto.Forms;

namespace BrawlCrate.UI.Wpf
{
    internal static class MainClass
    {
        [STAThread]
        public static void Main(string[] args)
        {
            new Application(Platforms.Wpf).Run(new MainForm(args));
        }
    }
}
