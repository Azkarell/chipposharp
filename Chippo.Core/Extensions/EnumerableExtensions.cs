using System.Collections.Generic;
using System.Linq;

namespace Chippo.Core.Extensions
{
    public static class EnumerableExtensions
    {
        public static IEnumerable<T> EmptyIfNull<T>(this IEnumerable<T> @this)
        {
            return @this ?? Enumerable.Empty<T>();
        }
    }
}