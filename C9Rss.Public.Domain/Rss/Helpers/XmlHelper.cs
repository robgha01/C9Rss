using System.Diagnostics;
using System.Xml.Linq;
using C9Rss.Public.Domain.Rss.Interfaces.Helpers;

namespace C9Rss.Public.Domain.Rss.Helpers
{
    public class XmlHelper : IXmlHelper
    {
        public XDocument CreateDocument(XDocument other)
        {
            var tmpDocument = new XDocument();
            tmpDocument.AddFirst(other.DocumentType);
            tmpDocument.Declaration = other.Declaration;

            if (other.Root == null)
            {
                return tmpDocument;
            }

            // Add the root element
            tmpDocument.Add(new XElement(other.Root.Name));

            // Add all root attributes
            foreach (XAttribute attribute in other.Root.Attributes())
            {
                Debug.Assert(tmpDocument.Root != null, "tmpDocument.Root != null");
                tmpDocument.Root.SetAttributeValue(attribute.Name, attribute.Value);
            }

            return tmpDocument;
        }
    }
}
