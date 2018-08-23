using System.ServiceModel.Syndication;
using C9Rss.Public.Domain.Rss.Interfaces.Behaviors;

namespace C9Rss.Public.Domain.Rss.Behaviors.View
{
    public class SyndicationFeedViewer : ViewerBase, IViewBehavior<SyndicationFeed>
    {
        public SyndicationFeedViewer(RssManager manager) : base(manager)
        {
        }

        public virtual SyndicationFeed View()
        {
            using (var reader = RssManager.Document.CreateReader())
            {
                return SyndicationFeed.Load(reader);
            }
        }

        public virtual SyndicationFeed View(int? maxItems, string subElementKey)
        {
            var document = ViewHelper.BuildDocument(maxItems, subElementKey);

            using (var reader = document.CreateReader())
            {
                return SyndicationFeed.Load(reader);
            }
        }

        public virtual SyndicationFeed View(int startIndex, string subElementKey, int? maxItems)
        {
            var document = ViewHelper.BuildDocument(startIndex, maxItems, subElementKey);

            using (var reader = document.CreateReader())
            {
                return SyndicationFeed.Load(reader);
            }
        }
    }
}
