using TorrentSearchNet;
using TorrentSearchNet.Api.Php;
using TorrentSearchNet.Api;
using System.Text.Json;

namespace TorrentSearchNetTests
{
    [TestClass]
    public class PhpApiTests
    {
        private ITorrentApi _api = null!;

        [TestInitialize]
        public void Setup()
        {
            _api = new PhpApi();
        }

        [TestMethod]
        public void DeserializeSearchResult()
        {
            const string json = "[{\"id\":\"51487392\",\"name\":\"B&auml;st I Test S&auml;song 4 (1080p) Bast I Test\",\"info_hash\":\"BBAEE065FE303EB9AE9440A669499ECC00A12735\",\"leechers\":\"4\",\"seeders\":\"8\",\"num_files\":\"20\",\"size\":\"14493275698\",\"username\":\"digson9\",\"added\":\"1629432800\",\"status\":\"member\",\"category\":\"208\",\"imdb\":\"\"},{\"id\":\"44999039\",\"name\":\"B&auml;st I Test S&auml;song 5 (1080p), Bast I Test\",\"info_hash\":\"1F86628EB82D6F19C71B7A1D1D7D6DF472BDC882\",\"leechers\":\"2\",\"seeders\":\"7\",\"num_files\":\"20\",\"size\":\"14486851711\",\"username\":\"digson9\",\"added\":\"1619795090\",\"status\":\"member\",\"category\":\"208\",\"imdb\":\"\"}]";

            List<QueryResult>? rawResults = JsonSerializer.Deserialize<List<QueryResult>>(json);

            Assert.IsNotNull(rawResults);
            Assert.AreEqual(2, rawResults.Count);
        }

        [TestMethod]
        public void DeserializeFileDetails()
        {
            const string json = "[{\"name\":[\"S03E02.mp4\"],\"size\":[1451349291]},{\"name\":[\"S01E01.srt\"],\"size\":[47689]},{\"name\":[\"S01E02.mp4\"],\"size\":[1439997054]},{\"name\":[\"S01E02.srt\"],\"size\":[53924]},{\"name\":[\"S01E03.mp4\"],\"size\":[1439657327]},{\"name\":[\"S01E03.srt\"],\"size\":[49535]},{\"name\":[\"S01E04.mp4\"],\"size\":[1428607145]},{\"name\":[\"S01E04.srt\"],\"size\":[51219]},{\"name\":[\"S02E01.mp4\"],\"size\":[1449067436]},{\"name\":[\"S02E01.srt\"],\"size\":[49076]},{\"name\":[\"S02E02.mp4\"],\"size\":[1382529871]},{\"name\":[\"S02E02.srt\"],\"size\":[46359]},{\"name\":[\"S02E03.mp4\"],\"size\":[1450629458]},{\"name\":[\"S02E03.srt\"],\"size\":[49226]},{\"name\":[\"S02E04.mp4\"],\"size\":[1449964732]},{\"name\":[\"S02E04.srt\"],\"size\":[48025]},{\"name\":[\"S02E05.mp4\"],\"size\":[1447553090]},{\"name\":[\"S02E05.srt\"],\"size\":[45174]},{\"name\":[\"S02E06.mp4\"],\"size\":[1438815037]},{\"name\":[\"S02E06.srt\"],\"size\":[49879]},{\"name\":[\"S02E07.mp4\"],\"size\":[1436130343]},{\"name\":[\"S02E07.srt\"],\"size\":[49346]},{\"name\":[\"S02E08.mp4\"],\"size\":[1450530806]},{\"name\":[\"S02E08.srt\"],\"size\":[47041]},{\"name\":[\"S03E01.mp4\"],\"size\":[1450568233]},{\"name\":[\"S03E01.srt\"],\"size\":[51396]},{\"name\":[\"S01E01.mp4\"],\"size\":[1447168244]},{\"name\":[\"S03E02.srt\"],\"size\":[51130]},{\"name\":[\"S03E03.mp4\"],\"size\":[1448805269]},{\"name\":[\"S03E03.srt\"],\"size\":[50198]},{\"name\":[\"S03E04.mp4\"],\"size\":[1449065733]},{\"name\":[\"S03E04.srt\"],\"size\":[50853]},{\"name\":[\"S03E05.mp4\"],\"size\":[1426711212]},{\"name\":[\"S03E05.srt\"],\"size\":[53682]},{\"name\":[\"S03E06.mp4\"],\"size\":[1446977226]},{\"name\":[\"S03E06.srt\"],\"size\":[52652]},{\"name\":[\"S03E07.mp4\"],\"size\":[1446011965]},{\"name\":[\"S03E07.srt\"],\"size\":[55710]},{\"name\":[\"S03E08.mp4\"],\"size\":[1442535548]},{\"name\":[\"S03E08.srt\"],\"size\":[48332]}]";

            List<TorrentFileResult>? rawItems = JsonSerializer.Deserialize<List<TorrentFileResult>>(json);

            Assert.IsNotNull(rawItems);
            Assert.AreEqual(40, rawItems.Count);
        }

        [TestMethod]
        public void ConvertingToTorrentFileInfoFixesWeirdCharacteres()
        {
            const string json = "[{\"id\":\"51487392\",\"name\":\"B&auml;st I Test S&auml;song 4 (1080p) Bast I Test\",\"info_hash\":\"BBAEE065FE303EB9AE9440A669499ECC00A12735\",\"leechers\":\"4\",\"seeders\":\"8\",\"num_files\":\"20\",\"size\":\"14493275698\",\"username\":\"digson9\",\"added\":\"1629432800\",\"status\":\"member\",\"category\":\"208\",\"imdb\":\"\"},{\"id\":\"44999039\",\"name\":\"B&auml;st I Test S&auml;song 5 (1080p), Bast I Test\",\"info_hash\":\"1F86628EB82D6F19C71B7A1D1D7D6DF472BDC882\",\"leechers\":\"2\",\"seeders\":\"7\",\"num_files\":\"20\",\"size\":\"14486851711\",\"username\":\"digson9\",\"added\":\"1619795090\",\"status\":\"member\",\"category\":\"208\",\"imdb\":\"\"}]";

            List<QueryResult>? rawResults = JsonSerializer.Deserialize<List<QueryResult>>(json);

            Assert.IsNotNull(rawResults);
            Assert.AreEqual(2, rawResults.Count);

            QueryResult firstItem = rawResults[0];
            TorrentFileInfo fileInfo = firstItem.ToFileInfo();

            Assert.IsNotNull(firstItem);
            Assert.AreEqual("Bäst I Test Säsong 4 (1080p) Bast I Test", fileInfo.Name);
        }

        [TestMethod]
        public async Task GetFilesFromSearchAsync_ReturnsResults()
        {
            List<TorrentFileInfo> results = await _api.GetFilesFromSearchAsync("bäst i test", Category.HdTvShows);
            Assert.IsNotNull(results);
            Assert.IsTrue(results.Count > 0);
        }

        [TestMethod]
        public async Task GetFilesFromSearchAsync_ReturnsEmptyListForNoResultsFound()
        {
            List<TorrentFileInfo> results = await _api.GetFilesFromSearchAsync("bäst i test", Category.AndroidApp);
            Assert.IsNotNull(results);
            Assert.AreEqual(0, results.Count);
        }

        [TestMethod]
        public async Task GetContainedFilesAsync_ReturnsFiles()
        {
            // Use a known valid fileId from a working search result
            string testFileId = "36418511";

            List<ContainedFilesInfo> files = await _api.GetContainedFilesAsync(testFileId);
            Assert.IsNotNull(files);
            Assert.IsTrue(files.Count > 0);
        }
    }
}
