namespace TorrentSearchNet
{
    /// <summary>
    /// Represents a magnet link used to identify and download torrent content.
    /// </summary>
    public readonly struct MagnetLink
    {
        /// <summary>
        /// Gets the full magnet link as a string.
        /// </summary>
        public string Value { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="MagnetLink"/> struct using the torrent's info hash and optional name.
        /// Includes predefined public trackers from <see cref="MagnetLinkSettings"/>.
        /// </summary>
        /// <param name="hash">The info hash of the torrent.</param>
        /// <param name="name">The optional display name of the torrent.</param>
        public MagnetLink(string hash, string? name)
        {
            string trackerParams = string.Join("", MagnetLinkSettings.PublicTrackers.Select(t => $"&tr={Uri.EscapeDataString(t)}"));
            Value = $"magnet:?xt=urn:btih:{hash}&dn={Uri.EscapeDataString(name ?? "(missing file name)")}{trackerParams}";
        }

        /// <summary>
        /// Returns the full magnet link as a string.
        /// </summary>
        /// <returns>The magnet link.</returns>
        public override string ToString() => Value;
    }
}
