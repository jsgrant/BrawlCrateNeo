using System;
using Eto.Forms;

namespace BrawlCrate.UI.Mac
{
    internal static class MainClass
    {
        [STAThread]
        public static void Main(string[] args)
        {
            new Application(Eto.Platforms.Mac64).Run(new MainForm(args));
        }
    }
}
