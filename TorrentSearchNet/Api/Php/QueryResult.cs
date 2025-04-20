using System.Text.Json.Serialization;

namespace TorrentSearchNet.Api.Php
{
    public class QueryResult
    {
        [JsonPropertyName("id")]
        public string Id { get; }

        [JsonPropertyName("name")]
        public string Name { get; }

        [JsonPropertyName("info_hash")]
        public string InfoHash { get; }

        [JsonPropertyName("leechers")]
        public string Leechers { get; }

        [JsonPropertyName("seeders")]
        public string Seeders { get; }

        [JsonPropertyName("num_files")]
        public string NumFiles { get; }

        [JsonPropertyName("size")]
        public string Size { get; }

        [JsonPropertyName("username")]
        public string Username { get; }

        [JsonPropertyName("added")]
        public string Added { get; }

        [JsonPropertyName("status")]
        public string Status { get; }

        [JsonPropertyName("category")]
        public string Category { get; }

        [JsonPropertyName("imdb")]
        public string Imdb { get; }

        [JsonConstructor]
        public QueryResult(
            string id,
            string name,
            string infoHash,
            string leechers,
            string seeders,
            string numFiles,
            string size,
            string username,
            string added,
            string status,
            string category,
            string imdb)
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
            Imdb = imdb;
        }

        internal TorrentFileInfo ToFileInfo()
        {
            return new TorrentFileInfo(
                id: Id,
                name: GetHtmlDecodedString(Name),
                infoHash: InfoHash,
                leechers: int.TryParse(Leechers, out int l) ? l : 0,
                seeders: int.TryParse(Seeders, out int s) ? s : 0,
                numFiles: int.TryParse(NumFiles, out int nf) ? nf : 0,
                size: long.TryParse(Size, out long sz) ? sz : 0,
                username: GetHtmlDecodedString(Username),
                added: long.TryParse(Added, out long timestamp)
                    ? DateTimeOffset.FromUnixTimeSeconds(timestamp).UtcDateTime
                    : DateTime.MinValue,
                status: Status,
                category: int.TryParse(Category, out int catInt) && Enum.IsDefined(typeof(Category), catInt)
                    ? (Category)catInt
                    : TorrentSearchNet.Category.Any
            );
        }

        internal string GetHtmlDecodedString(string value)
        {
            if (string.IsNullOrEmpty(value)) return value;
            return System.Net.WebUtility.HtmlDecode(value);
        }
    }
}
