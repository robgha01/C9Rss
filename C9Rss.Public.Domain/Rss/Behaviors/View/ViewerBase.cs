using C9Rss.Public.Domain.Rss.Helpers;

namespace C9Rss.Public.Domain.Rss.Behaviors.View
{
    public abstract class ViewerBase
    {
        public RssHelper ViewHelper { get; private set; }
        public RssManager RssManager { get; private set; }

        protected ViewerBase(RssManager manager)
        {
            ViewHelper = new RssHelper(manager);
            RssManager = manager;
        }
    }
}
