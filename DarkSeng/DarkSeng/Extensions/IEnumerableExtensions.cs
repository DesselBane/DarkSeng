using System;
using System.Collections.Generic;
using System.Linq;

namespace DarkSeng.Extensions
{
    public static class IEnumerableExtensions
    {
        /// <summary>
        /// Shuffles a given collection and returns it as an IEnumerable
        /// </summary>
        /// <typeparam name="T">Type</typeparam>
        /// <param name="collection">Collection to shuffle</param>
        /// <returns></returns>
        public static IEnumerable<T> Shuffle<T>(this IEnumerable<T> collection)
        {
            return collection.OrderBy(x => Guid.NewGuid());
        }
    }
}
