using System;

namespace BrawlCrate.Core.Nodes
{
    /// <summary>
    /// The base implementation used by nodes in the program.
    /// </summary>
    public class ResourceNode : IDisposable
    {
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
            // Does nothing yet
        }
    }
}
