using System.Xml.Linq;
using C9Rss.Public.Domain.Rss.Interfaces.Behaviors;

namespace C9Rss.Public.Domain.Rss.Behaviors.View
{
    public class XmlViewer : ViewerBase, IViewBehavior<XDocument>
    {
        public XmlViewer(RssManager manager) : base(manager)
        {
        }

        public virtual XDocument View()
        {
            return RssManager.Document;
        }

        public virtual XDocument View(int? maxItems, string subElementKey)
        {
            return ViewHelper.BuildDocument(maxItems, subElementKey);
        }

        public virtual XDocument View(int startIndex, string subElementKey, int? maxItems)
        {
            return ViewHelper.BuildDocument(startIndex, maxItems, subElementKey);
        }
    }
}