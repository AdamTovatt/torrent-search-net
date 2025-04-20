using System.Text.Json;
using System.Text.Json.Serialization;

namespace TorrentSearchNet
{
    /// <summary>
    /// Represents the result of a torrent search query, including the list of matching files.
    /// </summary>
    public class SearchResult
    {
        /// <summary>
        /// Gets or sets the list of torrent files returned by the search.
        /// </summary>
        [JsonPropertyName("files")]
        public List<TorrentFileInfo> Files { get; set; }

        /// <summary>
        /// Gets the number of files returned in the search result.
        /// </summary>
        [JsonPropertyName("fileCount")]
        public int FileCount => Files.Count;

        /// <summary>
        /// Initializes a new instance of the <see cref="SearchResult"/> class with the specified list of files.
        /// </summary>
        /// <param name="files">The list of torrent files returned from the search.</param>
        public SearchResult(List<TorrentFileInfo> files)
        {
            Files = files;
        }

        /// <summary>
        /// Serializes the current <see cref="SearchResult"/> instance to a JSON string.
        /// </summary>
        /// <returns>A JSON string representation of the search result.</returns>
        public string ToJson()
        {
            return JsonSerializer.Serialize(this);
        }
    }
}
