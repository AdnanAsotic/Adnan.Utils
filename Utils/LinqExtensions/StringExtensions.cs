
using System.Text.RegularExpressions;

namespace Utils.LinqExtensions
{
    public static class StringExtensions
    {
        public static bool MatchesPattern(this string input, string pattern)
        {
            Regex regex = new Regex(pattern, RegexOptions.Multiline | RegexOptions.IgnorePatternWhitespace);
            return regex.IsMatch(input);
        }
    }
}
