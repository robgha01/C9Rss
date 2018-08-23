using System.Configuration;

namespace C9Rss.Public.Domain
{
    public static class SiteConstants
    {
        public static string C9_BLOGG_RSS_URL
        {
            get { return ConfigurationManager.AppSettings["C9BloggRssUrl"]; }
        }

        public static string C9_BLOGG_ENTITY_KEY
        {
            get { return ConfigurationManager.AppSettings["C9BloggEntityKey"]; }
        }

        public static int Page_Size
        {
            get { return int.Parse(ConfigurationManager.AppSettings["PageSize"]); }
        }
    }
}
