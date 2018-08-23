using C9Rss.Public.Domain.Rss;
using C9Rss.Public.Domain.Rss.Behaviors.Read;
using C9Rss.Public.Domain.RssReader.Views;

namespace C9Rss.Public.Domain.RssReader
{
    public class C9RssModelManager : RssManager
    {
        public C9RssModelManager()
        {
            SetReadBehavior(new UrlReader(SiteConstants.C9_BLOGG_RSS_URL));
            SetViewBehavior(new BlogModelViewer(this));
        }
    }
}
