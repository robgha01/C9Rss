using System.Data;
using System.Xml.Linq;
using C9Rss.Public.Domain.Rss.Interfaces.Behaviors;

namespace C9Rss.Public.Domain.Rss.Behaviors.Read
{
    public class UrlReader : IReadBehavior
    {
        protected string Url;

        public UrlReader()
            : this(string.Empty)
        {
            
        }

        public UrlReader(string url)
        {
            Url = url;
        }

        public virtual XDocument Read()
        {
            if(string.IsNullOrEmpty(Url))
            {
                throw new NoNullAllowedException("Url is null or emtpy!");
            }

            XDocument document = XDocument.Load(Url);
            return document;
        }
    }
}
