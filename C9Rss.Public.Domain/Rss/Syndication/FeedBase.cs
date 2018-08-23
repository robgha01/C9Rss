using System;
using System.IO;
using System.ServiceModel.Syndication;
using System.Text;
using System.Xml;
using C9Rss.Public.Domain.Rss.Interfaces;

namespace C9Rss.Public.Domain.Rss.Syndication
{
    public abstract class FeedBase : SyndicationFeed, IHtmlSafe
    {
        public const string Namespace = "http://www.w3.org/2005/Atom";

        protected abstract void WriteFeedElement(XmlWriter writer, string name, string value, string prefix = "", string @namespace = "");

        protected FeedBase() {}

        protected FeedBase(string title, string description, Uri feedAlternateLink)
            : base(title, description, feedAlternateLink)
        {
        }

        protected override void WriteAttributeExtensions(XmlWriter writer, string version)
        {
            // Add the needed namespaces.
            writer.WriteAttributeString("xmlns", "xmlns:dc", null, "http://purl.org/dc/elements/1.1/");
            writer.WriteAttributeString("xmlns", "xmlns:thr", null, "http://purl.org/syndication/thread/1.0");
        }

        public string HtmlSafe(string html)
        {
            if (!string.IsNullOrEmpty(html))
            {
                return "<![CDATA[" + html + "]]>";
            }
            return string.Empty;
        }

        /// <summary>
        /// return the syndication feed as xml string
        /// </summary>
        public override string ToString()
        {
            return ToString(this);
        }

        protected string ToString(FeedBase feed)
        {
            using (var ms = new MemoryStream())
            {
                // Ensure the writer is UTF8 and nicely indented
                using (var writer = new AtomXmlTextWriter(ms, Encoding.UTF8) { Formatting = Formatting.Indented })
                {
                    // Write <?xml version="1.0" encoding="utf-8"?>
                    writer.WriteStartDocument();

                    var feedFormatter = new Atom10FeedFormatter(feed);
                    feedFormatter.WriteTo(writer);
                }

                var xmlContainer = new StringBuilder(Encoding.UTF8.GetString(ms.ToArray()));
                return xmlContainer.ToString().Replace(@"&lt;", "<").Replace(@"&gt;", ">");
            }
        }
    }
}