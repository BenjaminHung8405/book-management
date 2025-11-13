using System;

namespace book_management.Helpers
{
    public static class StringExtensions
    {
        /// <summary>
        /// Extension method cho string thường - .NET Framework 4.8 compatible
        /// </summary>
        public static bool Contains(this string source, string value, StringComparison comparisonType)
        {
            if (source == null || value == null)
                return false;

            return source.IndexOf(value, comparisonType) >= 0;
        }

        /// <summary>
        /// Helper method cho dynamic objects - Safe Contains - FIXED
        /// </summary>
        public static bool SafeContains(object dynamicProperty, string searchValue)
        {
            // Kiểm tra null và empty đầy đủ
            if (dynamicProperty == null || searchValue == null)
                return false;

            if (string.IsNullOrEmpty(searchValue))
                return true; // Empty search matches everything

            string propertyValue = dynamicProperty.ToString();

            // Kiểm tra propertyValue sau khi convert
            if (string.IsNullOrEmpty(propertyValue))
                return false;

            try
            {
                return propertyValue.IndexOf(searchValue, StringComparison.OrdinalIgnoreCase) >= 0;
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"SafeContains error: {ex.Message}");
                return false;
            }
        }

        /// <summary>
        /// Case-insensitive contains for regular strings
        /// </summary>
        public static bool ContainsIgnoreCase(this string source, string value)
        {
            if (source == null) return false;
            if (value == null) return false;

            return source.IndexOf(value, StringComparison.OrdinalIgnoreCase) >= 0;
        }
    }
}