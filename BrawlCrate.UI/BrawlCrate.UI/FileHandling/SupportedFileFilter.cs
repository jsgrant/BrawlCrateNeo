using System;
using Eto.Forms;

namespace BrawlCrate.UI.FileHandling
{
    /// <summary>
    /// Based on <see cref="FileFilter"/> class. Adds additional booleans for sorting/filtering purposes.
    /// </summary>
    public class SupportedFileFilter : FileFilter
    {
        /// <summary>
        /// Whether this file type is supported for direct opening.
        /// </summary>
        public bool ForEditing;

        /// <summary>
        /// Whether this file type is meant to be associated with the program (only not set to the same as <see cref="ForEditing"/> for generic filetypes such as dat).
        /// </summary>
        public bool CanAssociate;

        /// <summary>
        /// Basic constructor. Sets both <see cref="CanAssociate"/> and <see cref="ForEditing"/> to true.
        /// </summary>
        /// <param name="name">The name of the filter.</param>
        /// <param name="extensions">The extension(s) to filter the file list. Each extension should begin with a period.</param>
        public SupportedFileFilter(string name, params string[] extensions)
        {
            if (extensions == null || extensions.Length == 0)
            {
                throw new ArgumentException("No extensions for file type \"" + name + "\".");
            }
            ForEditing = true;
            CanAssociate = true;
            Name = name;
            Extensions = extensions;
        }

        /// <summary>
        /// Constructor to be used primarily for not directly editable files. Sets both <see cref="CanAssociate"/> and <see cref="ForEditing"/> to the same value.
        /// </summary>
        /// <param name="forDirectEdit">Whether this file type is supported for direct opening.</param>
        /// <param name="name">The name of the filter.</param>
        /// <param name="extensions">The extension(s) to filter the file list. Each extension should begin with a period.</param>
        public SupportedFileFilter(bool forDirectEdit, string name, params string[] extensions)
        {
            if (extensions == null || extensions.Length == 0)
            {
                throw new ArgumentException("No extensions for file type \"" + name + "\".");
            }
            ForEditing = forDirectEdit;
            CanAssociate = forDirectEdit;
            Name = name;
            Extensions = extensions;
        }

        /// <summary>
        /// Constructor to be used when explicitly setting Sets both <see cref="CanAssociate"/> and <see cref="ForEditing"/> to different values.
        /// </summary>
        /// <param name="forDirectEdit">Whether this file type is supported for direct opening.</param>
        /// <param name="associate">Whether this file type is meant to be associated with the program (only not set to the same as <see cref="ForEditing"/> for generic filetypes).</param>
        /// <param name="name">The name of the filter.</param>
        /// <param name="extensions">The extensions to filter the file list. Each extension should begin with a period.</param>
        public SupportedFileFilter(bool forDirectEdit, bool associate, string name, params string[] extensions)
        {
            if (extensions == null || extensions.Length == 0)
            {
                throw new ArgumentException("No extensions for file type \"" + name + "\".");
            }
            ForEditing = forDirectEdit;
            CanAssociate = associate;
            Name = name;
            Extensions = extensions;
        }
    }
}
