using TorrentSearchNet;

namespace TorrentSearchNetTests
{
    [TestClass]
    public class TorrentFinderTests
    {
        [TestMethod]
        public async Task SearchAsync_ReturnsResults()
        {
            SearchResult result = await TorrentFinder.SearchAsync("bäst i test", Category.HdTvShows);
            Assert.IsNotNull(result);
            Assert.IsTrue(result.Files.Count > 0);

            Assert.AreEqual(1, result.Files.Where(x => x.ToString() == "Bäst I Test Säsong 5 (1080p), Bast I Test | HdTvShows | 13 815 MB | Seeders: 7 | Leechers: 2 | Added: 2021-04-30 | By: digson9").Count());
            Assert.AreEqual(1, result.Files.Where(x => x.ToString() == "Bäst I Test Säsong 4 (1080p) Bast I Test | HdTvShows | 13 821 MB | Seeders: 8 | Leechers: 4 | Added: 2021-08-20 | By: digson9").Count());

            string json = result.ToJson();
            MagnetLink magnetLink = result.Files.First().GetMagnetLink();

            string magnetLinkString = magnetLink.ToString();
        }

        [TestMethod]
        public async Task SearchAsync_ReturnsEmptyListForNoResults()
        {
            SearchResult result = await TorrentFinder.SearchAsync("bäst i test", Category.AndroidApp);
            Assert.IsNotNull(result);
            Assert.AreEqual(0, result.Files.Count);
        }

        [TestMethod]
        public async Task GetContainedFilesAsync_ReturnsFiles()
        {
            string testFileId = "36418511";
            ContainedFilesResult result = await TorrentFinder.GetContainedFilesAsync(testFileId);

            Assert.IsNotNull(result);
            Assert.IsTrue(result.Files.Count > 0);
        }

        [TestMethod]
        public async Task GetContainedFilesAsync_ReturnsEmptyListWhenNoFilesFound()
        {
            string fakeFileId = "00000000";
            ContainedFilesResult result = await TorrentFinder.GetContainedFilesAsync(fakeFileId);

            Assert.IsNotNull(result);
            Assert.AreEqual(0, result.Files.Count);
        }
    }
}
