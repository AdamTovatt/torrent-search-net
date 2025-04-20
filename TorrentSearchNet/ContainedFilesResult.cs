using System.Text.Json.Serialization;

namespace TorrentSearchNet
{
    /// <summary>
    /// Represents the result of retrieving the list of files contained within a torrent.
    /// </summary>
    public class ContainedFilesResult
    {
        /// <summary>
        /// Gets the list of contained files.
        /// </summary>
        [JsonPropertyName("containedFiles")]
        public List<ContainedFilesInfo> Files { get; }

        /// <summary>
        /// Gets the number of contained files.
        /// </summary>
        [JsonPropertyName("containedFileCount")]
        public int FilesCount => Files.Count;

        /// <summary>
        /// Initializes a new instance of the <see cref="ContainedFilesResult"/> class with the specified list of files.
        /// </summary>
        /// <param name="containedFiles">The list of files contained in the torrent.</param>
        public ContainedFilesResult(List<ContainedFilesInfo> containedFiles)
        {
            Files = containedFiles;
        }
    }
}
