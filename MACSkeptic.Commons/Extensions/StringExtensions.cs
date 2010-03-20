using System.Linq;
using System.Reflection;
using System.Text.RegularExpressions;

namespace MACSkeptic.ExpLorer.Utils.Extensions
{
    internal static class StringExtensions
    {
        internal static string ApplyArguments(this string @string, object arguments)
        {
            if (@string.IsEmpty())
            {
                return @string;
            }

            var regex = new Regex(@"\#\{(\w+)\}");

            if (!regex.IsMatch(@string))
            {
                return @string;
            }

            var matches = regex.Matches(@string);
            var newString = @string;

            foreach (var match in matches.Cast<Match>())
            {
                var placeholder = match.Groups[0].Value;
                var replacementTarget = match.Groups[1].Value;
                var replacement = ReflectAboutTheValue(arguments, replacementTarget);
                newString = newString.Replace(placeholder, replacement);
            }

            return newString;
        }

        private static string ReflectAboutTheValue(object arguments, string replacementTarget)
        {
            return arguments.GetType().GetProperty(
                       replacementTarget,
                       BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Public)
                       .GetValue(arguments, null) as string;
        }

        internal static bool IsEmpty(this string @string)
        {
            return string.IsNullOrEmpty(@string);
        }
    }
}