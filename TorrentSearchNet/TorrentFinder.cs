using TorrentSearchNet.Api;
using TorrentSearchNet.Api.Php;

namespace TorrentSearchNet
{
    /// <summary>
    /// Provides a unified interface for searching torrents and retrieving contained files from multiple torrent APIs.
    /// </summary>
    public class TorrentFinder
    {
        private static readonly List<ITorrentApi> _apiList;

        static TorrentFinder()
        {
            _apiList = new List<ITorrentApi>
            {
                new PhpApi()
            };
        }

        /// <summary>
        /// Adds a ITorrentApi to the list of torrent apis.
        /// </summary>
        /// <param name="api"></param>
        public static void AddTorrentApi(ITorrentApi api)
        {
            _apiList.Add(api);
        }

        /// <summary>
        /// Searches all configured torrent APIs for torrents matching the given query and category.
        /// </summary>
        public static async Task<SearchResult> SearchAsync(string query, Category category = Category.Any)
        {
            List<TorrentFileInfo> totalFiles = new List<TorrentFileInfo>();
            HashSet<string> addedFileIds = new HashSet<string>();

            foreach (ITorrentApi api in _apiList)
            {
                List<TorrentFileInfo> files = await api.GetFilesFromSearchAsync(query, category);

                foreach (TorrentFileInfo file in files)
                {
                    if (!addedFileIds.Contains(file.Id))
                    {
                        totalFiles.Add(file);
                        addedFileIds.Add(file.Id);
                    }
                }
            }

            return new SearchResult(totalFiles);
        }

        /// <summary>
        /// Retrieves the list of files contained in a torrent by querying the configured torrent APIs.
        /// </summary>
        public static async Task<ContainedFilesResult> GetContainedFilesAsync(string torrentId)
        {
            foreach (ITorrentApi api in _apiList)
            {
                List<ContainedFilesInfo> containedFiles = await api.GetContainedFilesAsync(torrentId);
                if (containedFiles.Count > 0)
                    return new ContainedFilesResult(containedFiles);
            }

            return new ContainedFilesResult(new List<ContainedFilesInfo>());
        }
    }
}
