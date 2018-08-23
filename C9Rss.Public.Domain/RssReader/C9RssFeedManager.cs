using System;
using System.Linq;
using System.Web;
using C9Rss.Public.Domain.Rss;
using C9Rss.Public.Domain.Rss.Behaviors.Read;
using C9Rss.Public.Domain.RssReader.Interfaces;
using C9Rss.Public.Domain.RssReader.Views;
using C9Rss.Public.Utilities.Extensions;

namespace C9Rss.Public.Domain.RssReader
{
    public class C9RssFeedManager : RssManager, IPagedView
    {
        public C9RssFeedManager()
        {
            SetReadBehavior(new UrlReader(SiteConstants.C9_BLOGG_RSS_URL));
            SetViewBehavior(new BlogFeedViewer(this));
        }

        public int CountEntities()
        {
            return Document.Root.Descendants(Document.Root.Name.Namespace + SiteConstants.C9_BLOGG_ENTITY_KEY).Count();
        }

        public dynamic ViewFeed(int currentPage, int pageSize)
        {
            var url = HttpContext.Current.Request.Url.AbsoluteUri;
            int numberOfPages = (CountEntities() + SiteConstants.Page_Size - 1)/SiteConstants.Page_Size;
            BlogFeed feed;

            if (currentPage == 1)
            {
                feed = ViewFeed(SiteConstants.Page_Size, SiteConstants.C9_BLOGG_ENTITY_KEY) as BlogFeed;
            }
            else
            {
                // Get the last index of previous page and add one index
                int offset = (currentPage - 1)*SiteConstants.Page_Size + 1;

                feed = ViewFeed(offset, SiteConstants.Page_Size, SiteConstants.C9_BLOGG_ENTITY_KEY) as BlogFeed;
            }

            feed.AddSelfLink(new Uri(url).AddOrUpdateQuery("p", currentPage.ToString()));
            feed.AddFirstPageLink(new Uri(url).AddOrUpdateQuery("p", "1"));

            if (currentPage > 1)
            {
                feed.AddPreviousPageLink(new Uri(url).AddOrUpdateQuery("p", (currentPage - 1).ToString()));
            }

            if (currentPage < numberOfPages)
            {
                feed.AddNextPageLink(new Uri(url).AddOrUpdateQuery("p", (currentPage + 1).ToString()));
            }

            feed.AddLastPageLink(new Uri(url).AddOrUpdateQuery("p", numberOfPages.ToString()));
            
            return feed;
        }
    }
}