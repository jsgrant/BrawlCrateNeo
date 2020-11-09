using System;
using Eto.Forms;

namespace BrawlCrate.UI.Wpf
{
    class MainClass
    {
        [STAThread]
        public static void Main(string[] args)
        {
            Themes.GenerateThemes();
            new Application(Eto.Platforms.Wpf).Run(new MainForm(args));
        }
    }
}
