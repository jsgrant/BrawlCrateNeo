using System.Runtime.CompilerServices;
using Eto;
using Eto.Drawing;
using Eto.Forms;

namespace BrawlCrate.UI
{
    internal static class Themes
    {
        /// <summary>
        /// Generates a default set of themes for <see cref="Eto.Style"/>.
        /// </summary>
        [ModuleInitializer]
        internal static void GenerateThemes()
        {
            // Default Dark Mode
            var DarkBackground1 = Color.FromArgb(30, 30, 30);
            var DarkBackground2 = Color.FromArgb(62, 62, 66);
            var DarkForeground = Color.FromArgb(104, 104, 104);
            var DarkText = Color.FromArgb(220, 220, 220);
            Style.Add<Form>("DefaultDark", handler =>
            {
                handler.BackgroundColor = DarkBackground1;
            });
            Style.Add<Control>("DefaultDark", handler =>
            {
                handler.BackgroundColor = DarkBackground1;
            });
            Style.Add<PropertyGrid>("DefaultDark", handler =>
            {
                handler.BackgroundColor = DarkBackground1;
            });
        }

        public static void UpdateThemeRecursive(Widget w)
        {
            switch (w)
            {
                case Form frm:
                    UpdateThemeRecursive(frm.Content);
                    UpdateThemeRecursive(frm.Menu);
                    break;
                case MenuBar mnbr:
                    foreach (var item in mnbr.Items)
                        UpdateThemeRecursive(item);
                    break;
                case Splitter spl:
                    UpdateThemeRecursive(spl.Panel1);
                    UpdateThemeRecursive(spl.Panel2);
                    break;
                case Panel p:
                    foreach (var child in p.Children)
                        UpdateThemeRecursive(child);
                    break;
            }

            w.Style = MainForm.CurrentTheme;
        }
    }
}
