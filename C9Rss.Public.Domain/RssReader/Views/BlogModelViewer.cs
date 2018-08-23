using System;
using System.Collections.Generic;
using System.Web.UI.HtmlControls;
using System.Xml.Linq;
using C9Rss.Public.Domain.Rss;
using C9Rss.Public.Domain.Rss.Behaviors.View;
using C9Rss.Public.Domain.Rss.Interfaces.Behaviors;
using C9Rss.Public.Domain.RssReader.Model;

namespace C9Rss.Public.Domain.RssReader.Views
{
    public class BlogModelViewer : ViewerBase, IViewBehavior<List<BlogItem>>
    {
        public BlogModelViewer(RssManager manager) : base(manager)
        {
        }

        public List<BlogItem> View()
        {
            return CreateModel(RssManager.Document);
        }

        public List<BlogItem> View(int? maxItems, string element)
        {
            var document = ViewHelper.BuildDocument(maxItems, element);
            return CreateModel(document);
        }

        public List<BlogItem> View(int startIndex, string element, int? maxItems)
        {
            var document = ViewHelper.BuildDocument(startIndex, maxItems, element);
            return CreateModel(document);
        }

        protected HtmlLink BuildHtmlLink(XElement element)
        {
            var link = new HtmlLink();

            var rel = element.Attribute("rel");
            if (rel != null)
            {
                link.Attributes.Add("rel", rel.Value);
            }

            var type = element.Attribute("type");
            if (type != null)
            {
                link.Attributes.Add("type", type.Value);
            }

            var href = element.Attribute("href");
            if (href != null)
            {
                link.Href = href.Value;
            }

            return link;
        }

        protected void SetBloggEntityLinks(XElement element, ref BlogItem entity)
        {
            var ns = element.Document.Root.Name.Namespace;

            foreach (var item in element.Elements(ns + "link"))
            {
                var link = item.Attribute("rel");

                switch (link.Value)
                {
                    case "alternate":
                        entity.AlternateLink = BuildHtmlLink(item);
                        break;
                    case "replies":
                        entity.RepliesLink = BuildHtmlLink(item);
                        break;
                }
            }
        }

        protected void SetCategories(XElement element, ref BlogItem entity)
        {
            var ns = element.Document.Root.Name.Namespace;

            foreach (var item in element.Elements(ns + "category"))
            {
                entity.Categories.Add(item.Attribute("term").Value);
            }
        }

        protected List<BlogItem> CreateModel(XDocument document)
        {
            var tmpList = new List<BlogItem>();
            var ns = document.Root.Name.Namespace;

            foreach (var item in document.Root.Elements(ns + SiteConstants.C9_BLOGG_ENTITY_KEY))
            {
                var entity = new BlogItem();
                entity.Id = item.Element(ns + "id").Value;
                entity.Title = item.Element(ns + "title").Value;
                entity.Summery = item.Element(ns + "summary").Value;
                entity.Content = item.Element(ns + "content").Value;
                entity.Author = new Author(item.Element(ns + "author").Element(ns + "name").Value);
                entity.Published = DateTime.Parse(item.Element(ns + "published").Value);
                entity.Updated = DateTime.Parse(item.Element(ns + "updated").Value);

                SetBloggEntityLinks(item, ref entity);
                SetCategories(item, ref entity);

                tmpList.Add(entity);
            }

            return tmpList;
        }
    }
}
