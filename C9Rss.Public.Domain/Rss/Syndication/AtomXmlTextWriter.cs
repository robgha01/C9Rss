using System.IO;
using System.Text;
using System.Xml;

namespace C9Rss.Public.Domain.Rss.Syndication
{
    public class AtomXmlTextWriter : XmlTextWriter
    {
        public AtomXmlTextWriter(Stream stream, Encoding encoding)
            : base(stream, encoding)
        {
        }

        public override void WriteStartElement(string prefix, string localName, string ns)
        {
            base.WriteStartElement(string.Empty, localName, ns);
        }

        public override void WriteStartAttribute(string prefix, string localName, string ns)
        {
            base.WriteStartAttribute(string.Empty, localName, ns);
        }
    }
}
