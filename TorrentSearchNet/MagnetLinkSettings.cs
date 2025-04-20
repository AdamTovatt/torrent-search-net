namespace TorrentSearchNet
{
    /// <summary>
    /// Provides settings related to magnet link generation, including a configurable list of public torrent trackers.
    /// </summary>
    public static class MagnetLinkSettings
    {
        /// <summary>
        /// Gets the list of public torrent tracker URLs to include in generated magnet links.
        /// Users may add or remove trackers from this list as needed.
        /// </summary>
        public static List<string> PublicTrackers { get; } = new List<string>
        {
            "udp://tracker.openbittorrent.com:80/announce",
            "udp://tracker.opentrackr.org:1337/announce",
            "udp://tracker.coppersurfer.tk:6969/announce",
            "udp://tracker.leechers-paradise.org:6969/announce",
            "udp://tracker.internetwarriors.net:1337/announce"
        };
    }
}
