using System.Xml.Linq;
using C9Rss.Public.Domain.Rss.Behaviors.Read;

namespace C9Rss.Public.Domain.C9RssReader
{
    public class C9BloggReader : UrlReader
    {
        public C9BloggReader()
            : base(SiteConstants.C9_BLOGG_RSS_URL)
        {
        }

        public override XDocument Read()
        {
            XDocument document = base.Read();

            // ToDO Create Model for the rss data.



            return document;
        }
    }
}
