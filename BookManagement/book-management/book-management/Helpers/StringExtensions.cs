using System;

namespace book_management.Helpers
{
    public static class StringExtensions
    {
        /// <summary>
        /// Extension method để hỗ trợ Contains với StringComparison
        /// </summary>
        public static bool Contains(this string source, string value, StringComparison comparisonType)
        {
            if (source == null || value == null)
                return false;

            return source.IndexOf(value, comparisonType) >= 0;
        }
        // Helper method cho dynamic objects
        public static bool ContainsIgnoreCase(this string source, string value)
        {
            if (source == null) return false;
            if (value == null) return false;

            return source.IndexOf(value, StringComparison.OrdinalIgnoreCase) >= 0;
        }

        // Safe method cho dynamic properties
        public static bool SafeContains(object dynamicProperty, string searchValue)
        {
            if (dynamicProperty == null || searchValue == null) return false;

            string propertyValue = dynamicProperty.ToString();
            return propertyValue.IndexOf(searchValue, StringComparison.OrdinalIgnoreCase) >= 0;
        }

    }
}