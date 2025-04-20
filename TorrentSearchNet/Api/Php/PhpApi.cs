using System.Text.Json;

namespace TorrentSearchNet.Api.Php
{
    public class PhpApi : ITorrentApi
    {
        private readonly string _baseUrl;
        private readonly HttpClient httpClient;

        public PhpApi(string? baseUrl = null)
        {
            _baseUrl = baseUrl ?? PhpApiSettings.Url;
            httpClient = new HttpClient();
        }

        public async Task<List<ContainedFilesInfo>> GetContainedFilesAsync(string fileId)
        {
            const string endpointUrl = "f.php?id=";
            string requestUrl = $"{_baseUrl}/{endpointUrl}{fileId}";

            HttpResponseMessage response = await httpClient.GetAsync(requestUrl);
            response.EnsureSuccessStatusCode();

            string json = await response.Content.ReadAsStringAsync();

            if (json == "[{\"name\":{\"0\":\"Filelist not found\"},\"size\":{\"0\":\"0\"}}]")
                return new List<ContainedFilesInfo>();

            List<TorrentFileResult>? rawItems = JsonSerializer.Deserialize<List<TorrentFileResult>>(json);
            List<ContainedFilesInfo> result = new List<ContainedFilesInfo>();

            if (rawItems != null)
            {
                foreach (TorrentFileResult item in rawItems)
                {
                    if (item.Name.Length > 0 && item.Size.Length > 0)
                    {
                        result.Add(new ContainedFilesInfo(item.Name[0], item.Size[0]));
                    }
                }
            }

            return result;
        }

        public async Task<List<TorrentFileInfo>> GetFilesFromSearchAsync(string query, Category category)
        {
            const string endpointUrl = "q.php";
            string requestUrl = $"{_baseUrl}/{endpointUrl}?q={query}&cat={(int)category}";

            HttpResponseMessage response = await httpClient.GetAsync(requestUrl);
            response.EnsureSuccessStatusCode();

            string json = await response.Content.ReadAsStringAsync();

            List<QueryResult>? rawResults = JsonSerializer.Deserialize<List<QueryResult>>(json);
            List<TorrentFileInfo> result = new List<TorrentFileInfo>();

            if (rawResults == null)
                return result;

            if (rawResults.Count == 1 && rawResults.First().Id == "0" && rawResults.First().Size == "0")
                return result;

            if (rawResults != null)
            {
                foreach (QueryResult raw in rawResults)
                {
                    result.Add(raw.ToFileInfo());
                }
            }

            return result;
        }
    }
}
