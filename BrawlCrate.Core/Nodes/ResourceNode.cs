using System;
using System.ComponentModel;
using BrawlCrate.Core.Internal;
using BrawlCrate.Core.Wii;

namespace BrawlCrate.Core.Nodes
{
    /// <summary>
    /// The base implementation used by nodes in the program.
    /// </summary>
    public class ResourceNode : IDisposable
    {
        private DataSource _source;

        /// <summary>
        /// The Endianness of the given node. Generally all children of a given node will follow the same Endianness.
        /// </summary>
        /// <remarks>Wii files almost always uniformly use Big Endian, which will be set by default.</remarks>
        [Browsable(false)]
        public virtual Endianness Endian { get; set; } = Endianness.Big;

        /// <summary>
        /// Default Constructor, taking in a <see cref="DataSource"/>.
        /// </summary>
        public ResourceNode(DataSource src)
        {
            _source = src;
        }

        /// <summary>
        /// Deconstructor, disposes of the node properly to free up memory.
        /// </summary>
        ~ResourceNode()
        {
            Dispose();
        }

        /// <summary>
        /// Free up memory used by this node.
        /// </summary>
        public virtual void Dispose()
        {
            _source.Dispose();
        }
    }
}
