using System;
using System.ComponentModel;
using System.ServiceModel.Syndication;
using System.Xml;
using C9Rss.Public.Domain.Rss.Syndication;

namespace C9Rss.Public.Domain.RssReader
{
    public class BlogFeed : FeedBase
    {
        public string Link { get; set; }
        
        public BlogFeed()
        {
        }

        public BlogFeed(string title, string description, Uri feedAlternateLink)
            : base(title, description, feedAlternateLink)
        {
            Link = feedAlternateLink.AbsoluteUri;
        }

        protected override void WriteElementExtensions(XmlWriter writer, string version)
        {
            var tmpList = new BindingList<SyndicationItem>();
            Links.Clear();

            foreach (var item in Items)
            {
                var syndicationItem = new SyndicationItem(item.Title.Text, item.Summary.Text, null)
                {
                    LastUpdatedTime = item.LastUpdatedTime,
                    Id = item.Id
                };

                foreach (var autor in item.Authors)
                {
                    syndicationItem.Authors.Add(autor);
                }

                tmpList.Add(syndicationItem);
            }

            Items = tmpList;
        }

        protected override void WriteFeedElement(XmlWriter writer, string name, string value, string prefix = "", string @namespace = "")
        {
            if (value != null)
            {
                writer.WriteStartElement(prefix, name, @namespace);
                writer.WriteValue(value);
                writer.WriteEndElement();
            }
        }
    }
}
