namespace TorrentSearchNet.Api
{
    public interface ITorrentApi
    {
        public Task<List<TorrentFileInfo>> GetFilesFromSearchAsync(string query, Category category);
        public Task<List<ContainedFilesInfo>> GetContainedFilesAsync(string fileId);
    }
}
