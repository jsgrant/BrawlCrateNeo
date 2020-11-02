using Eto.Drawing;

namespace BrawlCrate.UI
{
    /// <summary>
    /// Handler for basic Imagery and Iconography used by the program.
    /// </summary>
    public static class Iconography
    {
        /// <summary>
        /// Main Icon used by the program. Different in Canary and Release builds.
        /// </summary>
        public readonly static Icon MainIcon =
#if CANARY
            Icon.FromResource("BrawlCrate.UI.Resources.BrawlCrateCanary.ico");
#else
            Icon.FromResource("BrawlCrate.UI.Resources.BrawlCrate.ico");
#endif
    }
}
