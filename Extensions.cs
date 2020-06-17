using System.Text.RegularExpressions;

namespace SimpleMMO_Bot
{
    public static class Extensions
    {
        public static string RemoveHTMLTags(this string text)
        {
            return Regex.Replace(text, " ?<[^>]*>", string.Empty);
        }
    }
}
