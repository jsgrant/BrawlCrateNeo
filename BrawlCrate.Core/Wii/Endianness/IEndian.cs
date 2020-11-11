using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrawlCrate.Core.Wii.BigEndian
{
    /// <summary>
    /// An Endian-Explicit variation of a given Endian-Independent type.
    /// </summary>
    /// <typeparam name="T">The corresponding Endian-Independent type.</typeparam>
    interface IEndian<T>
    {
        /// <summary>
        /// The value as given in the current system.
        /// </summary>
        public T Value { get; }
    }
}
