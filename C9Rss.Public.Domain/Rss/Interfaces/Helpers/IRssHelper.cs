using System.Collections.Generic;
using System.Xml.Linq;

namespace C9Rss.Public.Domain.Rss.Interfaces.Helpers
{
    public interface IRssHelper
    {
        XDocument BuildDocument(int? maxItems, string element = "");
        XDocument BuildDocument(int startIndex, int? maxItems, string element = "");
        ICollection<XElement> GetDocumentHead(XDocument document);
    }
}
