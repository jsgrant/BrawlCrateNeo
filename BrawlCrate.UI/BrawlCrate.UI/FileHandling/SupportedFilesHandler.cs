using System;
using System.Collections.Generic;
using System.Linq;
using BrawlCrate.Core.Extensions;
using Eto.Forms;

namespace BrawlCrate.UI.FileHandling
{
    /// <summary>
    /// Handler for supported file types. See also: <seealso cref="SupportedFileFilter"/>.
    /// </summary>
    public static class SupportedFilesHandler
    {
        /// <summary>
        /// Full list of <see cref="SupportedFileFilter"/>s currently supported by the program.
        /// </summary>
        public static readonly SupportedFileFilter[] SupportedFiles =
        {
            // Archive Files
            new SupportedFileFilter("PAC File Archive", ".pac"),
            new SupportedFileFilter("PCS Compressed File Archive", ".pcs"),
            new SupportedFileFilter(false, "Archive Pair (*.pac & *.pcs)", ".pair"),

            // NW4R Containers
            new SupportedFileFilter("NW4R Resource Pack", ".brres"),

            // NW4R Raw Files
            new SupportedFileFilter("NW4R Model", ".mdl0"),
            new SupportedFileFilter("NW4R Texture", ".tex0"),
            new SupportedFileFilter("NW4R Palette", ".plt0"),
            new SupportedFileFilter("NW4R Bone Animation", ".chr0"),
            new SupportedFileFilter("NW4R Texture Animation", ".srt0"),
            new SupportedFileFilter("NW4R Vertex Morph", ".shp0"),
            new SupportedFileFilter("NW4R Visibility Sequence", ".vis0"),
            new SupportedFileFilter("NW4R Texture Pattern", ".pat0"),
            new SupportedFileFilter("NW4R Color Sequence", ".clr0"),
            new SupportedFileFilter("NW4R Scene Settings", ".scn0"),

            // NW4R Audio
            new SupportedFileFilter("NW4R Audio Stream", ".brstm"),
            new SupportedFileFilter("NW4R Sound Archive", ".brsar"),
            new SupportedFileFilter("NW4R RSAR Sound File", ".brwsd"),
            new SupportedFileFilter("NW4R RSAR Sound Bank File", ".brbnk"),
            new SupportedFileFilter("NW4R RSAR Sound Sequence", ".brseq"),

            // NW4R Effects
            new SupportedFileFilter("Particle Effect List", ".efls"),
            new SupportedFileFilter("NW4R Particle Effects", ".breff"),
            new SupportedFileFilter("NW4R Particle Textures", ".breft"),
            
            // Modules
            new SupportedFileFilter("Static Module", ".dol"),
            new SupportedFileFilter("Relocatable Module", ".rel"),

            // Text
            new SupportedFileFilter("Brawl Message Pack", ".msbin"),

            // Stage Files
            new SupportedFileFilter("Brawl Collision File", ".coll"),
            new SupportedFileFilter("Brawl Stage Parameters File", ".stpm"),
            new SupportedFileFilter("Brawl Stage Trap Data Table File", ".stdt"),
            new SupportedFileFilter("Brawl Stage Collision Attributes File", ".scla"),
            new SupportedFileFilter("Brawl TBCL File", ".tbcl"),
            new SupportedFileFilter("Brawl TBGC File", ".tbgc"),
            new SupportedFileFilter("Brawl TBGD File", ".tbgd"),
            new SupportedFileFilter("Brawl TBGM File", ".tbgm"),
            new SupportedFileFilter("Brawl TBLV File", ".tblv"),
            new SupportedFileFilter("Brawl TBRM File", ".tbrm"),
            new SupportedFileFilter("Brawl TBST File", ".tbst"),

            // Subspace Emissary Files
            new SupportedFileFilter("Adventure Stepjump", ".adsj"),
            new SupportedFileFilter("BLOC Adventure Archive", ".bloc"),

            // Mod-Specific Filetypes
            new SupportedFileFilter("Masquerade Costume File", ".masq"),
            new SupportedFileFilter("BrawlEx Configuration File", ".bx"),
            new SupportedFileFilter("Custom My Music Tracklist", ".cmm"),
            new SupportedFileFilter("Alternate Stage Loader Data", ".asl"),
            new SupportedFileFilter("Stage Info Parameters", ".param"),
            new SupportedFileFilter("Stage Tracklist", ".tlst"), 

            // Generic File Types
            new SupportedFileFilter(true, false, "Text File", ".txt"),
            new SupportedFileFilter(true, false, "Data File", ".dat"),
            new SupportedFileFilter(true, false, "Binary File", ".bin"),
            new SupportedFileFilter(true, false, "Binary Backup File", ".bak")
        };

        /// <summary>
        /// Full list of <see cref="SupportedFileFilter"/>s with the <see cref="SupportedFileFilter.ForEditing"/> flag set to true.
        /// </summary>
        public static readonly FileFilter[] EditableFiles = SupportedFiles.Where(o => o.ForEditing).ToArray<FileFilter>();

        /// <summary>
        /// Full list of supported extensions with the <see cref="SupportedFileFilter.ForEditing"/> flag set to true.
        /// </summary>
        public static readonly string[] EditableExtensions = GetSupportedExtensions(EditableFiles);

        /// <summary>
        /// Gets an <see cref="OpenFileDialog"/> with relevant <see cref="FileFilter"/>s.
        /// </summary>
        /// <param name="extensions">The extensions to be used for filtering. If empty, uses <see cref="EditableFiles"/>.</param>
        /// <returns>An <see cref="OpenFileDialog"/> with the expected <see cref="FileFilter"/>s</returns>
        public static OpenFileDialog GetOpenFileDialog(params string[] extensions)
        {
            return GetOpenFileDialog(GetSupportedFilters(true, extensions));
        }

        /// <summary>
        /// Gets an <see cref="OpenFileDialog"/> with relevant <see cref="FileFilter"/>s.
        /// </summary>
        /// <param name="filters">The <see cref="FileFilter"/>s to be used for filtering.</param>
        /// <returns>An <see cref="OpenFileDialog"/> with the expected <see cref="FileFilter"/>s</returns>
        public static OpenFileDialog GetOpenFileDialog(FileFilter[] filters)
        {
            OpenFileDialog openDialog = new OpenFileDialog();

            openDialog.Filters.AddRange(filters);

            return openDialog;
        }

        /// <summary>
        /// Gets relevant <see cref="FileFilter"/>s from a list of extensions
        /// </summary>
        /// <param name="open">True if opening a file, false if saving.</param>
        /// <param name="extensions">Extensions to filter for. If empty, uses <see cref="EditableFiles"/>.</param>
        /// <returns></returns>
        public static FileFilter[] GetSupportedFilters(bool open, params string[] extensions)
        {
            var filters = new List<FileFilter>();

            if (extensions == null || extensions.Length == 0)
            {
                if (open)
                {
                    // First, add "all supported" filter if opening a file
                    filters.Add(new FileFilter("All Supported Files", EditableExtensions));
                }
                // Add all supported editable files
                filters.AddRange(EditableFiles);
            }
            else
            {
                // Document currently unknown extensions
                var unknownExtensions = extensions.ToList();

                if (open && extensions.Length > 1)
                {
                    // First, add "all supported" filter if opening a file and there are at least two supported extensions
                    filters.Add(new FileFilter("All Supported Files", extensions));
                }

                // Add all known extensions as corresponding filters
                foreach (var f in SupportedFiles.Where(ff =>
                    ff.Extensions.Any(ext1 =>
                        unknownExtensions.Exists(ext2 => ext1.Equals(ext2, StringComparison.OrdinalIgnoreCase)))))
                {
                    // Add corresponding filter
                    filters.Add(f);
                    // Remove now-known extensions from unknown extensions list
                    foreach (var ext in f.Extensions)
                    {
                        unknownExtensions.Remove(ext);
                    }
                }

                // Add unknown extensions as default filters
                foreach (var ext in unknownExtensions)
                {
                    filters.Add(new FileFilter($"{ext} File", ext));;
                }
            }

            // Add a filter for all files
            filters.Add(new FileFilter("All Files", ".*"));

            return filters.ToArray();
        }

        /// <summary>
        /// Gets an array of extensions supported by a given array of <see cref="FileFilter"/>s.
        /// </summary>
        /// <param name="filters">The <see cref="FileFilter"/>s to take the extensions from.</param>
        /// <returns>An array of supported extensions.</returns>
        public static string[] GetSupportedExtensions(params FileFilter[] filters)
        {
            List<string> extensions = new List<string>();

            // Add supported extensions from every supported filter
            foreach (var filter in filters)
            {
                extensions.AddRange(filter.Extensions);
            }

            return extensions.ToArray();
        }
    }
}
