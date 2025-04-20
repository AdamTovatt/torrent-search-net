namespace TorrentSearchNet.Api.Php
{
    /// <summary>
    /// Default settings for the PhpApi.
    /// </summary>
    public static class PhpApiSettings
    {
        /// <summary>
        /// The url that the api uses. Without "/" in the end as that will be added by the endpoints.
        /// </summary>
        public static string Url { get; set; } = "https://apibay.org";
    }
}
