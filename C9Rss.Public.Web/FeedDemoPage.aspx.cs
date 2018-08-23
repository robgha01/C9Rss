using System;
using System.Web.UI;
using C9Rss.Public.Domain;
using C9Rss.Public.Domain.RssReader;

namespace C9Rss.Public.Web
{
    public partial class FeedDemoPage : Page
    {
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            Response.Clear();
            Response.ContentType = "application/atom+xml";

            var feed = GetFeed();

            Response.Write(feed.ToString());
        }

        public BlogFeed GetFeed()
        {
            var rssManager = new C9RssFeedManager();

            int currentIndex;
            if (!int.TryParse(Request.QueryString["p"], out currentIndex))
            {
                currentIndex = 1;
            }

            BlogFeed feed = rssManager.ViewFeed(currentIndex, SiteConstants.Page_Size);

            if (feed == null)
            {
                throw new ArgumentNullException("feed");
            }

            return feed;
        }
    }
}