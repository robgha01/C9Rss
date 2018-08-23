using System;
using System.Diagnostics;
using System.Xml.Linq;
using C9Rss.Public.Domain.Rss;
using C9Rss.Public.Domain.Rss.Behaviors.View;
using C9Rss.Public.Domain.Rss.Helpers;

namespace C9Rss.Public.Domain.RssReader.Views
{
    public class BlogXmlViewer : XmlViewer
    {
        public BlogXmlViewer(RssManager manager) : base(manager)
        {
            
        }

        public override XDocument View(int? maxItems, string element)
        {
            var document = base.View(maxItems, element);
            return ReFormatDocument(document, element);
        }

        public override XDocument View(int startIndex, string element, int? maxItems)
        {
            var document = base.View(startIndex, element, maxItems);
            return ReFormatDocument(document, element);
        }

        protected XDocument ReFormatDocument(XDocument document, string element)
        {
            if(document.Root == null)
            {
                throw new NullReferenceException("document root is null!");
            }

            var xmlHelper = new XmlHelper();
            var tmpDocument = xmlHelper.CreateDocument(document);
            var ns = document.Root.Name.Namespace;

            tmpDocument.Root.Add(ViewHelper.GetDocumentHead(document));

            foreach (var item in document.Root.Elements(ns + element))
            {
                Debug.Assert(tmpDocument.Root != null, "tmpDocument.Root != null");

                var entity = new XElement(ns + SiteConstants.C9_BLOGG_ENTITY_KEY);
                entity.Add(item.Element(ns + "title"));
                entity.Add(item.Element(ns + "summary"));

                tmpDocument.Root.Add(entity);
            }

            return tmpDocument;
        }
    }
}
