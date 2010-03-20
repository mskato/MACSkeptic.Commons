using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace MACSkeptic.ExpLorer.Utils.Extensions
{
    internal static class EnumerableExtensions
    {
        internal static void ExecuteForEach<T>(this IEnumerable<T> @collection, Action<T> action)
        {
            if (@collection == null ||
                action == null)
            {
                return;
            }

            foreach (var element in @collection)
            {
                action.Invoke(element);
            }
        }

        internal static bool IsEmpty(this IEnumerable @collection)
        {
            if (@collection == null)
            {
                return true;
            }

            return !@collection.GetEnumerator().MoveNext();
        }

        internal static string JoinAsString(this IEnumerable @collection, string separator, bool oneItemPerLine)
        {
            if (@collection.IsEmpty())
            {
                return string.Empty;
            }

            var builder = new StringBuilder();
            var first = true;

            foreach (var element in @collection)
            {
                if (!first)
                {
                    builder.Append(separator);
                    if (oneItemPerLine)
                    {
                        builder.AppendLine();
                    }
                }
                builder.Append(element);
                first = false;
            }

            return builder.ToString();
        }

        internal static string JoinAsString(this IEnumerable @collection, string separator)
        {
            return @collection.JoinAsString(separator, false);
        }
    }
}