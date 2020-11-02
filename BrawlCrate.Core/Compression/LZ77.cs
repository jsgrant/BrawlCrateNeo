using System.IO;

namespace BrawlCrate.Core.Compression
{
    /// <summary>
    /// Implementation of the LZ77 compression algorithm used by Brawl.
    /// </summary>
    public static class LZ77
    {
        public static byte[] Compress(byte[] uncompressed, bool extended)
        {
            MemoryStream output = new MemoryStream();
            int remain = uncompressed.Length;
            do
            {

            } while (remain > 0);

            return uncompressed;
        }

        public static byte[] Expand(byte[] compressed, bool extended)
        {
            MemoryStream output = new MemoryStream();


            do
            {

            } while (false);

            return output.ToArray();
        }
    }
}
