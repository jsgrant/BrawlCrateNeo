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
        /// <typeparam name="T">The type if tg</typeparam>
        /// <param name="coll"></param>
        /// <param name="array">The array</param>
        public static void AddRange<T>(this Collection<T> coll, T[] array)
        {
            foreach (var item in array)
            {
                coll.Add(item);
            }
        }
    }
}
