using System;
using System.IO;
using System.IO.MemoryMappedFiles;

namespace BrawlCrate.Core.Extensions
{
    public static class MemoryMappedFileExtension
    {
        public static void WriteToFile(this MemoryMappedFile mem, string path, long size)
        {
            Directory.CreateDirectory(Path.GetDirectoryName(path) ??
                                      throw new InvalidOperationException("Path cannot be null."));
            using (var file = new FileStream(path, FileMode.Create, FileAccess.Write))
            {
                MemoryMappedViewStream m = mem.CreateViewStream(0, size);
                m.CopyTo(file);
            }
        }
    }
}
