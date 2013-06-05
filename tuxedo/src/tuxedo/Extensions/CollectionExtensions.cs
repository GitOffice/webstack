using System.Collections.Generic;

namespace tuxedo.Extensions
{
    internal static class CollectionExtensions
    {
        public static IDictionary<T, K> AddRange<T, K>(this IDictionary<T, K> left, IDictionary<T, K> right)
        {
            foreach(var item in right)
            {
                left.Add(item);
            }
            return left;
        }
    }
}