using System.Runtime.Serialization;

namespace TorrentSearchNet
{
    /// <summary>
    /// Represents the various torrent content categories used for filtering or classification.
    /// Matches the category codes from supported torrent APIs.
    /// </summary>
    public enum Category
    {
        /// <summary>
        /// Any category (no filtering).
        /// </summary>
        [EnumMember(Value = "Any")]
        Any = 0,

        // Audio

        /// <summary>
        /// Music files.
        /// </summary>
        [EnumMember(Value = "Music")]
        Music = 101,

        /// <summary>
        /// Audio books.
        /// </summary>
        [EnumMember(Value = "Audio Books")]
        AudioBooks = 102,

        /// <summary>
        /// Sound clips.
        /// </summary>
        [EnumMember(Value = "Sound Clips")]
        SoundClips = 103,

        /// <summary>
        /// FLAC audio files.
        /// </summary>
        [EnumMember(Value = "FLAC")]
        Flac = 104,

        /// <summary>
        /// Other audio content.
        /// </summary>
        [EnumMember(Value = "Other Audio")]
        AudioOther = 199,

        // Video

        /// <summary>
        /// Movies in general.
        /// </summary>
        [EnumMember(Value = "Movies")]
        Movies = 201,

        /// <summary>
        /// Movies in DVD-R format.
        /// </summary>
        [EnumMember(Value = "Movies DVDR")]
        MoviesDvdr = 202,

        /// <summary>
        /// High-definition movies.
        /// </summary>
        [EnumMember(Value = "HD Movies")]
        HdMovies = 207,

        /// <summary>
        /// Music video files.
        /// </summary>
        [EnumMember(Value = "Music Videos")]
        MusicVideos = 203,

        /// <summary>
        /// Movie clips or short scenes.
        /// </summary>
        [EnumMember(Value = "Movie Clips")]
        MovieClips = 204,

        /// <summary>
        /// Television shows.
        /// </summary>
        [EnumMember(Value = "TV Shows")]
        TvShows = 205,

        /// <summary>
        /// High-definition television shows.
        /// </summary>
        [EnumMember(Value = "HD TV Shows")]
        HdTvShows = 208,

        /// <summary>
        /// Video content for handheld devices.
        /// </summary>
        [EnumMember(Value = "Handheld Video")]
        HandheldVideo = 206,

        /// <summary>
        /// 3D video content.
        /// </summary>
        [EnumMember(Value = "3D")]
        ThreeD = 209,

        /// <summary>
        /// Other types of video content.
        /// </summary>
        [EnumMember(Value = "Other Video")]
        VideoOther = 299,

        // Application

        /// <summary>
        /// Windows software and applications.
        /// </summary>
        [EnumMember(Value = "Windows")]
        Windows = 301,

        /// <summary>
        /// MacOS software and applications.
        /// </summary>
        [EnumMember(Value = "Mac")]
        Mac = 302,

        /// <summary>
        /// UNIX or Linux applications.
        /// </summary>
        [EnumMember(Value = "UNIX")]
        Unix = 303,

        /// <summary>
        /// Applications for handheld devices.
        /// </summary>
        [EnumMember(Value = "Handheld App")]
        HandheldApp = 304,

        /// <summary>
        /// Applications for iOS.
        /// </summary>
        [EnumMember(Value = "iOS App")]
        IosApp = 305,

        /// <summary>
        /// Applications for Android.
        /// </summary>
        [EnumMember(Value = "Android App")]
        AndroidApp = 306,

        /// <summary>
        /// Other applications not categorized above.
        /// </summary>
        [EnumMember(Value = "Other Application")]
        AppOther = 399,

        // Games

        /// <summary>
        /// Games for PC.
        /// </summary>
        [EnumMember(Value = "PC Games")]
        PcGames = 401,

        /// <summary>
        /// Games for Mac.
        /// </summary>
        [EnumMember(Value = "Mac Games")]
        MacGames = 402,

        /// <summary>
        /// PlayStation (PSX) games.
        /// </summary>
        [EnumMember(Value = "PSX")]
        Psx = 403,

        /// <summary>
        /// Xbox 360 games.
        /// </summary>
        [EnumMember(Value = "Xbox 360")]
        Xbox360 = 404,

        /// <summary>
        /// Nintendo Wii games.
        /// </summary>
        [EnumMember(Value = "Wii")]
        Wii = 405,

        /// <summary>
        /// Games for handheld consoles.
        /// </summary>
        [EnumMember(Value = "Handheld Games")]
        HandheldGames = 406,

        /// <summary>
        /// Games for iOS devices.
        /// </summary>
        [EnumMember(Value = "iOS Games")]
        IosGames = 407,

        /// <summary>
        /// Games for Android devices.
        /// </summary>
        [EnumMember(Value = "Android Games")]
        AndroidGames = 408,

        /// <summary>
        /// Other types of games.
        /// </summary>
        [EnumMember(Value = "Other Games")]
        GamesOther = 499,

        // Other

        /// <summary>
        /// E-book files.
        /// </summary>
        [EnumMember(Value = "E-books")]
        Ebooks = 601,

        /// <summary>
        /// Comic book files.
        /// </summary>
        [EnumMember(Value = "Comics")]
        Comics = 602,

        /// <summary>
        /// Image or picture files.
        /// </summary>
        [EnumMember(Value = "Pictures")]
        Pictures = 603,

        /// <summary>
        /// Cover artwork files.
        /// </summary>
        [EnumMember(Value = "Covers")]
        Covers = 604,

        /// <summary>
        /// Physibles (3D printable objects).
        /// </summary>
        [EnumMember(Value = "Physibles")]
        Physibles = 605,

        /// <summary>
        /// Other miscellaneous content.
        /// </summary>
        [EnumMember(Value = "Other Other")]
        OtherOther = 699
    }
}
