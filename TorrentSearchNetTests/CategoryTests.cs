using TorrentSearchNet;

namespace TorrentSearchNetTests
{
    [TestClass]
    public class CategoryTests
    {
        [TestMethod]
        public void ToString_ReturnsExpectedEnumMemberValue()
        {
            Assert.AreEqual("Music", CategoryHelper.ToString(Category.Music));
            Assert.AreEqual("Other Video", CategoryHelper.ToString(Category.VideoOther));
        }

        [TestMethod]
        public void FromString_ParsesEnumMemberValue()
        {
            Assert.AreEqual(Category.Music, CategoryHelper.FromString("Music"));
            Assert.AreEqual(Category.VideoOther, CategoryHelper.FromString("Other Video"));
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void FromString_InvalidString_Throws()
        {
            _ = CategoryHelper.FromString("NotARealCategory");
        }

        [TestMethod]
        public void ToString_FallbacksToEnumName_WhenNoEnumMember()
        {
            // Assuming no EnumMember is defined for this test category
            string name = CategoryHelper.ToString(Category.Any);
            Assert.IsFalse(string.IsNullOrEmpty(name));
        }
    }
}
