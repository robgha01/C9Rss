using System;
using System.Collections.Generic;
using System.Web.UI.HtmlControls;

namespace C9Rss.Public.Domain.RssReader.Model
{
    public class BlogItem
    {
        public string Title { get; set; }
        public HtmlLink AlternateLink { get; set; }
        public HtmlLink RepliesLink { get; set; }
        public string Id { get; set; }
        public DateTime Published { get; set; }
        public DateTime? Updated { get; set; }
        public string Summery { get; set; }
        public virtual Author Author { get; set; }
        public List<string> Categories { get; set; }
        public string Content { get; set; }

        public BlogItem()
        {
            Categories = new List<string>();
        }

        public BlogItem(string id, string title, string summery, string content)
            : this()
        {
            Id = id;
            Title = title;
            Summery = summery;
            Content = content;
        }

        public BlogItem(string id, string title, string summery, string content, Author author, DateTime published, DateTime? updated = null, HtmlLink alternateLink = null, HtmlLink repliesLink = null)
            : this(id, title, summery, content)
        {
            Author = author;
            Published = published;
            Updated = updated;
            AlternateLink = alternateLink;
            RepliesLink = repliesLink;
        }
    }
}
