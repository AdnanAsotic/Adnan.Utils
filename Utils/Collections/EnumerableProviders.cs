using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utils.Collections
{
    /// <summary>
    /// Various extension methods for Enumerable type
    /// </summary>
    public static class EnumerableProviders
    {
        /// <summary>
        /// Checks if specific value is contained in some collection
        /// </summary>
        /// <typeparam name="T">Type of collection to check</typeparam>
        /// <param name="col">The collection to check in</param>
        /// <param name="val">The value to search for</param>
        /// <returns>true when found else false</returns>
        public static bool IsContainedIn<T>(this IEnumerable<T> col, T val)
        {
            return col.Contains<T>(val);
        }
    }
}
