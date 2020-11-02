using System.Collections.ObjectModel;

namespace BrawlCrate.Core.Extensions
{
    /// <summary>
    /// Extensions to <see cref="Collection{T}"/>.
    /// </summary>
    public static class CollectionExtension
    {
        /// <summary>
        /// Adds all the elements from <param name="array">an array</param> to <param name="coll">the collection</param>.
        /// </summary>
        /// <typeparam name="T">The type of collection used.</typeparam>
        /// <param name="coll">The collection to add to.</param>
        /// <param name="array">The array to add to the collection.</param>
        public static void AddRange<T>(this Collection<T> coll, T[] array)
        {
            foreach (var item in array)
            {
                coll.Add(item);
            }
        }
    }
}
