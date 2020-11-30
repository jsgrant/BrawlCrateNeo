using System;
using System.Diagnostics;
using System.IO;
using System.IO.MemoryMappedFiles;
using BrawlCrate.Core.Extensions;
using BrawlCrate.Core.Wii.Compression;
using BrawlCrate.Core.Wii.Types.Common;

namespace BrawlCrate.Core.Internal
{
    public class DataSource : IDisposable
    {
        private MemoryMappedFile? OriginalFile;

        private MemoryMappedViewAccessor OriginalSource;

        private MemoryMappedFile? UncompressedFile;

        private MemoryMappedViewAccessor? UncompressedSource;

        public string? Path { get; init; }

        public MemoryMappedViewAccessor Source => UncompressedSource ?? OriginalSource;

        public string Tag
        {
            get
            {
                if (Source.Capacity < 4)
                {
                    return "";
                }

                return Source.Read<FileMagic>(0);
            }
        }

        public DataSource(MemoryMappedViewAccessor original)
        {
            OriginalSource = original;
            Decompress();
        }

        public DataSource(string path)
        {
            if (!File.Exists(path))
            {
                throw new FileNotFoundException($"{path} is not a valid file.");
            }
            var info = new FileInfo(path);
            OriginalFile = MemoryMappedFile.CreateFromFile(path, FileMode.Open);
            OriginalSource = OriginalFile.CreateViewAccessor(0, info.Length);
            Path = path;
            Decompress();
        }

        private void Decompress()
        {
            try
            {
                if (OriginalSource.TryRead(0, out CompressionHeader header) && header.IsActualHeader)
                {
                    Debug.WriteLine($"Compression Type: {header.Compression}\nSize: {header.Size}");
                    UncompressedFile = MemoryMappedFile.CreateNew(null, header.Size);
                    UncompressedSource = UncompressedFile.CreateViewAccessor(0, header.Size);
                    Compression.Decompress(header, OriginalSource, UncompressedSource);
                }
            }
            catch
            {
                Debug.WriteLine("Decompression Failure");
                UncompressedSource?.Dispose();
                UncompressedSource = null;
                UncompressedFile?.Dispose();
                UncompressedFile = null;
            }
            Source.Read(0, out FileMagic m);
            Debug.WriteLine(m);
        }

        public void Dispose()
        {
            OriginalFile?.Dispose();
            OriginalSource.Dispose();
            UncompressedFile?.Dispose();
            UncompressedSource?.Dispose();
        }
    }
}
