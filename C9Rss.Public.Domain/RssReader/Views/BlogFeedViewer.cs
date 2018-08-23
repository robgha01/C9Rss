using System.ServiceModel.Syndication;
using C9Rss.Public.Domain.Rss;
using C9Rss.Public.Domain.Rss.Behaviors.View;
using C9Rss.Public.Domain.Rss.Interfaces.Behaviors;

namespace C9Rss.Public.Domain.RssReader.Views
{
    public class BlogFeedViewer : ViewerBase, IViewBehavior<BlogFeed>
    {
        public BlogFeedViewer(RssManager manager) : base(manager)
        {
        }

        public BlogFeed View()
        {
            using (var reader = RssManager.Document.CreateReader())
            {
                return SyndicationFeed.Load<BlogFeed>(reader);
            }
        }

        public BlogFeed View(int? maxItems, string subElementKey)
        {
            var document = ViewHelper.BuildDocument(maxItems, subElementKey);
            
            using (var reader = document.CreateReader())
            {
                return SyndicationFeed.Load<BlogFeed>(reader);
            }
        }

        public BlogFeed View(int startIndex, string subElementKey, int? maxItems)
        {
            var document = ViewHelper.BuildDocument(startIndex, maxItems, subElementKey);
            
            using (var reader = document.CreateReader())
            {
                return SyndicationFeed.Load<BlogFeed>(reader);
            }
        }
    }
}
