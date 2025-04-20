using System.Text.Json.Serialization;

namespace TorrentSearchNet
{
    /// <summary>
    /// Represents information about a single torrent file, including metadata and statistics.
    /// </summary>
    public class TorrentFileInfo
    {
        /// <summary>
        /// Gets the unique identifier of the torrent.
        /// </summary>
        [JsonPropertyName("id")]
        public string Id { get; }

        /// <summary>
        /// Gets the display name of the torrent.
        /// </summary>
        [JsonPropertyName("name")]
        public string Name { get; }

        /// <summary>
        /// Gets the info hash of the torrent.
        /// </summary>
        [JsonPropertyName("infoHash")]
        public string InfoHash { get; }

        /// <summary>
        /// Gets the number of leechers (downloaders) for this torrent.
        /// </summary>
        [JsonPropertyName("leechers")]
        public int Leechers { get; }

        /// <summary>
        /// Gets the number of seeders (uploaders) for this torrent.
        /// </summary>
        [JsonPropertyName("seeders")]
        public int Seeders { get; }

        /// <summary>
        /// Gets the number of files contained in this torrent.
        /// </summary>
        [JsonPropertyName("numFiles")]
        public int NumFiles { get; }

        /// <summary>
        /// Gets the total size of the torrent in bytes.
        /// </summary>
        [JsonPropertyName("size")]
        public long Size { get; }

        /// <summary>
        /// Gets the username of the uploader.
        /// </summary>
        [JsonPropertyName("username")]
        public string Username { get; }

        /// <summary>
        /// Gets the date and time when the torrent was added.
        /// </summary>
        [JsonPropertyName("added")]
        public DateTime Added { get; }

        /// <summary>
        /// Gets the user status of the uploader (e.g., member, VIP).
        /// </summary>
        [JsonPropertyName("status")]
        public string Status { get; }

        /// <summary>
        /// Gets the category of the torrent.
        /// </summary>
        [JsonPropertyName("category")]
        public Category Category { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="TorrentFileInfo"/> class with the specified values.
        /// </summary>
        [JsonConstructor]
        public TorrentFileInfo(
            string id,
            string name,
            string infoHash,
            int leechers,
            int seeders,
            int numFiles,
            long size,
            string username,
            DateTime added,
            string status,
            Category category)
        {
            Id = id;
            Name = name;
            InfoHash = infoHash;
            Leechers = leechers;
            Seeders = seeders;
            NumFiles = numFiles;
            Size = size;
            Username = username;
            Added = added;
            Status = status;
            Category = category;
        }

        /// <summary>
        /// Generates a magnet link for this torrent, including public trackers.
        /// </summary>
        /// <returns>A <see cref="MagnetLink"/> representing this torrent.</returns>
        public MagnetLink GetMagnetLink()
        {
            return new MagnetLink(InfoHash, Name);
        }

        /// <summary>
        /// Returns a formatted string summarizing the torrent's key information.
        /// </summary>
        /// <returns>A human-readable summary of the torrent.</returns>
        public override string ToString()
        {
            return $"{Name} | {Category} | {Size / (1024 * 1024):N0} MB | Seeders: {Seeders} | Leechers: {Leechers} | Added: {Added:yyyy-MM-dd} | By: {Username}";
        }
    }
}
