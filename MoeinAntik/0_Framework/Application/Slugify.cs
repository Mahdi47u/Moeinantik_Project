using System.Globalization;
using System.Text;
using System.Text.RegularExpressions;

namespace _0_Framework.Application
{
    public static class Slugify
    {
        public static string GenerateSlug(this string phrase)
        {
            string str = phrase.ToLowerInvariant();

            // Remove accents
            str = RemoveDiacritics(str);

            // Remove invalid chars
            str = Regex.Replace(str, @"[^a-z0-9\s-]", "");

            // Convert multiple spaces into one space
            str = Regex.Replace(str, @"\s+", " ").Trim();

            // Replace spaces with hyphens
            str = Regex.Replace(str, @"\s", "-");

            return str.ToLower();
        }


        private static string RemoveDiacritics(this string text)
        {
            if (string.IsNullOrEmpty(text))
                return String.Empty;
            
            var normalizedString = text.Normalize(NormalizationForm.FormD);
            var stringBuilder = new StringBuilder();


            foreach (var c in normalizedString)
            {
                var unicodeCategory = CharUnicodeInfo.GetUnicodeCategory(c);
                if (unicodeCategory != UnicodeCategory.NonSpacingMark)
                {
                    stringBuilder.Append(c);
                }
            }

            return stringBuilder.ToString().Normalize(NormalizationForm.FormC);
        }
    }
}
