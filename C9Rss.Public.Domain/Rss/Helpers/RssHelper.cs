using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using C9Rss.Public.Domain.Rss.Interfaces.Helpers;

namespace C9Rss.Public.Domain.Rss.Helpers
{
    public class RssHelper : IRssHelper
    {
        public RssManager RssManager { get; private set; }

        public RssHelper(RssManager manager)
        {
            RssManager = manager;
        }

        public virtual XDocument BuildDocument(int? maxItems, string element)
        {
            if (RssManager.Document.Root == null)
            {
                return null;
            }

            var xmlHelper = new XmlHelper();
            var tmpDocument = xmlHelper.CreateDocument(RssManager.Document);
            var ns = RssManager.Document.Root.Name.Namespace;

            IEnumerable<XElement> elements = RssManager.Document.Root.Elements(ns + element);

            if (maxItems != null)
            {
                elements = elements.Take(maxItems.Value);
            }

            tmpDocument.Root.Add(GetDocumentHead(RssManager.Document));
            tmpDocument.Root.Add(elements);

            return tmpDocument;
        }

        public virtual XDocument BuildDocument(int startIndex, int? maxItems, string element)
        {
            var tmpDocument = BuildDocument(null, element);

            var ns = RssManager.Document.Root.Name.Namespace;

            IEnumerable<XElement> subElements = RssManager.Document.Root.Elements(ns + element).Skip(startIndex);

            if (maxItems != null)
            {
                subElements = subElements.Take(maxItems.Value);
            }

            // Clear elements
            tmpDocument.Root.RemoveNodes();
            tmpDocument.Root.Add(GetDocumentHead(RssManager.Document));
            tmpDocument.Root.Add(subElements);

            return tmpDocument;
        }

        public ICollection<XElement> GetDocumentHead(XDocument document)
        {
            if(document.Root == null)
            {
                throw new NullReferenceException("document is null!");
            }

            ICollection<XElement> headElements = new List<XElement>();

            XNamespace headNs = document.Root.Name.Namespace;
            XNamespace feedburnerNs = "http://rssnamespace.org/feedburner/ext/1.0";

            headElements.Add(document.Root.Element(headNs + "title"));
            headElements.Add(document.Root.Element(headNs + "id"));
            headElements.Add(document.Root.Element(headNs + "updated"));
            headElements.Add(document.Root.Element(headNs + "subtitle"));
            headElements.Add(document.Root.Element(headNs + "generator"));
            headElements.Add(document.Root.Element(feedburnerNs + "info"));

            //foreach (var element in document.Root.Elements(headNs + "link"))
            //{
            //    headElements.Add(element);
            //}
            
            return headElements;
        }
    }
}