using System.Xml.Linq;

namespace C9Rss.Public.Domain.Rss.Interfaces.Helpers
{
    public interface IXmlHelper
    {
        XDocument CreateDocument(XDocument other);
    }
}
