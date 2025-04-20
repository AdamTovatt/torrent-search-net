using System.Reflection;
using System.Runtime.Serialization;

namespace TorrentSearchNet
{
    /// <summary>
    /// Provides helper methods for converting between <see cref="Category"/> enum values and their string representations,
    /// using <see cref="EnumMemberAttribute"/> values when available.
    /// Includes internal caching for performance.
    /// </summary>
    public static class CategoryHelper
    {
        private static readonly Dictionary<string, Category> _fromStringCache;
        private static readonly Dictionary<Category, string> _toStringCache;

        /// <summary>
        /// Static constructor initializes the internal caches by reflecting over the <see cref="Category"/> enum.
        /// </summary>
        static CategoryHelper()
        {
            _fromStringCache = new Dictionary<string, Category>(StringComparer.OrdinalIgnoreCase);
            _toStringCache = new Dictionary<Category, string>();

            foreach (Category category in Enum.GetValues(typeof(Category)))
            {
                string enumName = category.ToString();
                string value = GetEnumMemberValue(category) ?? enumName;

                _fromStringCache[value] = category;
                _fromStringCache[enumName] = category;
                _toStringCache[category] = value;
            }
        }

        /// <summary>
        /// Parses a string into a <see cref="Category"/> enum value.
        /// Accepts both enum names and <see cref="EnumMemberAttribute"/> values.
        /// </summary>
        /// <param name="value">The string to parse.</param>
        /// <returns>The corresponding <see cref="Category"/> enum value.</returns>
        /// <exception cref="ArgumentException">Thrown if the string does not map to a valid category.</exception>
        public static Category FromString(string value)
        {
            if (_fromStringCache.TryGetValue(value, out Category category))
            {
                return category;
            }

            throw new ArgumentException($"Invalid category: {value}", nameof(value));
        }

        /// <summary>
        /// Converts a <see cref="Category"/> enum value to its corresponding string representation.
        /// Uses the <see cref="EnumMemberAttribute"/> value if present; otherwise, uses the enum name.
        /// </summary>
        /// <param name="category">The category to convert.</param>
        /// <returns>The string representation of the category.</returns>
        public static string ToString(Category category)
        {
            return _toStringCache.TryGetValue(category, out string? value)
                ? value
                : category.ToString();
        }

        /// <summary>
        /// Retrieves the <see cref="EnumMemberAttribute"/> value for a given <see cref="Category"/> enum member, if defined.
        /// </summary>
        /// <param name="category">The category enum member.</param>
        /// <returns>The <see cref="EnumMemberAttribute.Value"/>, or null if not found.</returns>
        private static string? GetEnumMemberValue(Category category)
        {
            FieldInfo? field = category.GetType().GetField(category.ToString());
            EnumMemberAttribute? attribute = field?.GetCustomAttribute<EnumMemberAttribute>();
            return attribute?.Value;
        }
    }
}
