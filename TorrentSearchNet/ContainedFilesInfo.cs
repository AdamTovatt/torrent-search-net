using System.Text.Json.Serialization;

namespace TorrentSearchNet
{
    /// <summary>
    /// Represents a single file contained within a torrent, including its name and size.
    /// </summary>
    public class ContainedFilesInfo
    {
        /// <summary>
        /// Gets the name of the contained file.
        /// </summary>
        [JsonPropertyName("name")]
        public string Name { get; }

        /// <summary>
        /// Gets the size of the contained file in bytes.
        /// </summary>
        [JsonPropertyName("size")]
        public long Size { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="ContainedFilesInfo"/> class with the specified name and size.
        /// </summary>
        /// <param name="name">The name of the file.</param>
        /// <param name="size">The size of the file in bytes.</param>
        public ContainedFilesInfo(string name, long size)
        {
            Name = name;
            Size = size;
        }
    }
}
