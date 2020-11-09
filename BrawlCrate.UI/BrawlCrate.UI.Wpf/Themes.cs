using Eto.Drawing;
using Eto.Forms;
using Eto.Wpf;
using Eto.Wpf.Forms;

namespace BrawlCrate.UI.Wpf
{
    internal static class Themes
    {
        /// <summary>
        /// Generates a default set of themes for <see cref="Eto.Style"/>.
        /// </summary>
        internal static void GenerateThemes()
        {
            // Default Dark Mode
            var darkBackground1 = Color.FromArgb(30, 30, 30);
            var darkBackground2 = Color.FromArgb(62, 62, 66);
            var darkForeground = Color.FromArgb(104, 104, 104);
            var darkText = Color.FromArgb(220, 220, 220);
            Eto.Style.Add<FormHandler>("DefaultDark", handler =>
            {
                //handler.Control.Style.
            });
        }
    }
}
