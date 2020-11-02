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
            new SupportedFileFilter("PAC File Archive", ".pac"),
            new SupportedFileFilter("PCS Compressed File Archive", ".pcs")
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
