using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace BrawlCrate.Core.Compression
{
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
