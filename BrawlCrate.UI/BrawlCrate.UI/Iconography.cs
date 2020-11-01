using System;
using System.Collections.Generic;
using System.Text;
using Eto.Drawing;

namespace BrawlCrate.UI
{
    public static class Iconography
    {
        public readonly static Icon MainIcon =
#if CANARY
            Icon.FromResource("BrawlCrate.UI.Resources.BrawlCrateCanary.ico");
#else
            Icon.FromResource("BrawlCrate.UI.Resources.BrawlCrate.ico");
#endif
    }
}
