using System.Text.Json.Serialization;

namespace TorrentSearchNet.Api.Php
{
    public class TorrentFileResult
    {
        [JsonPropertyName("name")]
        public string[] Name { get; }

        [JsonPropertyName("size")]
        public long[] Size { get; }

        [JsonConstructor]
        public TorrentFileResult(string[] name, long[] size)
        {
            Name = name;
            Size = size;
        }
    }
}
