using System;
using System.Threading;
using System.Xml.Linq;
using C9Rss.Public.Domain.Rss.Behaviors.View;
using C9Rss.Public.Domain.Rss.Interfaces.Behaviors;

namespace C9Rss.Public.Domain.Rss
{
    public abstract class RssManager
    {
        protected Lazy<XDocument> DocumentLazy;
        protected IReadBehavior ReadBehavior;
        protected IViewBehavior<dynamic> ViewBehavior;

        public XDocument Document { get { return DocumentLazy.Value; } }

        protected RssManager()
        {
            // Set Defaults
            ViewBehavior = new XmlViewer(this);
        }

        public dynamic ViewFeed()
        {
            return ViewBehavior.View();
        }

        public dynamic ViewFeed(string element)
        {
            return ViewBehavior.View(null, element);
        }

        public dynamic ViewFeed(int maxItems, string element)
        {
            return ViewBehavior.View(maxItems, element);
        }

        public dynamic ViewFeed(int startIndex, int maxItems, string element)
        {
            return ViewBehavior.View(startIndex, element, maxItems);
        }

        protected void SetReadBehavior(IReadBehavior readBehavior)
        {
            ReadBehavior = readBehavior;
            DocumentLazy = new Lazy<XDocument>(ReadBehavior.Read, LazyThreadSafetyMode.PublicationOnly);
        }

        protected void SetViewBehavior(IViewBehavior<dynamic> viewBehavior)
        {
            ViewBehavior = viewBehavior;
        }
    }
}
