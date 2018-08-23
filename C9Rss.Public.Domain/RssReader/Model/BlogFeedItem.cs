using System;
using System.ServiceModel.Syndication;
using System.Xml;
using C9Rss.Public.Domain.Rss.Interfaces;

namespace C9Rss.Public.Domain.RssReader.Model
{
    public class BlogFeedItem : SyndicationItem, IHtmlSafe
    {
        public string Link { get; set; }
        public DateTime PubDate { get; set; }
        public string Guid { get; set; }
        public string Encoded { get; set; }

        public BlogFeedItem(string title, string content, Uri itemAlternateLink)
            : base(title, content, itemAlternateLink)
        {
            Summary = new TextSyndicationContent(content);
            Link = itemAlternateLink.AbsoluteUri;
        }

        protected override void WriteElementExtensions(XmlWriter writer, string version)
        {
            WriteFeedElement(writer, "link", Link);
            WriteFeedElement(writer, "Title", Title.Text);
            WriteFeedElement(writer, "Description", HtmlSafe(Summary.Text));
            WriteFeedElement(writer, "PubDate", PubDate.ToLongDateString());
            WriteFeedElement(writer, "Guid", Guid);
            WriteFeedElement(writer, "Encoded", HtmlSafe(Encoded));
        }

        protected void WriteFeedElement(XmlWriter writer, string name, string value, string prefix = "", string @namespace = "")
        {
            if (value != null)
            {
                writer.WriteStartElement(prefix, name, @namespace);
                writer.WriteValue(value);
                writer.WriteEndElement();
            }
        }

        public string HtmlSafe(string html)
        {
            if (!string.IsNullOrEmpty(html))
            {
                return "<![CDATA[" + html + "]]";
            }
            return string.Empty;
        }
    }
}
