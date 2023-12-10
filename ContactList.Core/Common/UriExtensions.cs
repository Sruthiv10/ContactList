using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RFL.TechStack.Core.Common
{
    /// <summary>
    /// Extension methods for <see cref="string"/>.
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public static class UriExtensions
    {
        /// <summary>
        /// Checks to see if the URI scheme is 'http'. The check is case-insensitive.
        /// </summary>
        /// <param name="input">The URI to verify.</param>
        /// <returns><c>true</c> if URI scheme is 'http'; false otherwise.</returns>
        public static bool IsHttp(this Uri input)
        {
            return input != null && input.IsAbsoluteUri && string.Equals(input.Scheme, Uri.UriSchemeHttp, StringComparison.OrdinalIgnoreCase);
        }

        /// <summary>
        /// Checks to see if the URI scheme is 'https'. The check is case-insensitive.
        /// </summary>
        /// <param name="input">The URI to verify.</param>
        /// <returns><c>true</c> if URI scheme is 'https'; false otherwise.</returns>
        public static bool IsHttps(this Uri input)
        {
            return input != null && input.IsAbsoluteUri && string.Equals(input.Scheme, Uri.UriSchemeHttps, StringComparison.OrdinalIgnoreCase);
        }
    }
}
