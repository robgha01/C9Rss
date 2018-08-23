using System;
using System.Web;

namespace C9Rss.Public.Utilities.Extensions
{
    public static class UriExtensions
    {
        public static Uri AddOrUpdateQuery(this Uri uri, string name, string value)
        {
            var ub = new UriBuilder(uri);
            var queryString = HttpUtility.ParseQueryString(uri.Query);

            if (string.IsNullOrEmpty(queryString[name]))
            {
                queryString.Add(name, value);
            }
            else
            {
                queryString[name] = value;
            }
            
            ub.Query = queryString.ToString();

            return ub.Uri;
        }
    }
}
