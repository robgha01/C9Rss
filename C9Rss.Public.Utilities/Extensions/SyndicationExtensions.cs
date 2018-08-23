using System;
using System.ServiceModel.Syndication;

namespace C9Rss.Public.Utilities.Extensions
{
    public static class SyndicationExtensions
    {
        public static class ContentTypes
        {
            public const string Atom = "application/atom+xml";
            public const string AtomEntry = "application/atom+xml;type=entry";
            public const string AtomServiceDocument = "application/atomsvc+xml";
        }

        public static void AddLink(this SyndicationFeed feed, Uri uri, string relationshipType)
        {
            if (feed == null)
            {
                throw new ArgumentNullException("feed");
            }

            if (uri == null)
            {
                throw new ArgumentNullException("uri");
            }

            feed.Links.Add(new SyndicationLink(uri, relationshipType, null, null, 0));
        }

        public static void AddSelfLink(this SyndicationFeed feed, Uri uri)
        {
            if (feed == null)
            {
                throw new ArgumentNullException("feed");
            }

            if (uri == null)
            {
                throw new ArgumentNullException("uri");
            }

            feed.Links.Add(SyndicationLink.CreateSelfLink(uri, null));
        }

        public static void AddNextPageLink(this SyndicationFeed feed, Uri uri)
        {
            feed.AddLink(uri, "next");
        }

        public static void AddPreviousPageLink(this SyndicationFeed feed, Uri uri)
        {
            feed.AddLink(uri, "prev");
        }

        public static void AddFirstPageLink(this SyndicationFeed feed, Uri uri)
        {
            feed.AddLink(uri, "first");
        }

        public static void AddLastPageLink(this SyndicationFeed feed, Uri uri)
        {
            feed.AddLink(uri, "last");
        }

        public static void AddEditLink(this SyndicationItem entry, Uri uri)
        {
            if (entry == null)
            {
                throw new ArgumentNullException("entry");
            }

            if (uri == null)
            {
                throw new ArgumentNullException("uri");
            }

            entry.Links.Add(new SyndicationLink(uri, "edit", "Edit Atom entry", ContentTypes.AtomEntry, 0));
        }

        public static void AddEditMediaLink(this SyndicationItem entry, Uri uri, string contentType, long contentLength)
        {
            if (entry == null)
            {
                throw new ArgumentNullException("entry");
            }
            if (uri == null)
            {
                throw new ArgumentNullException("uri");
            }
            entry.Links.Add(new SyndicationLink(uri, "edit-media", null, contentType, contentLength));
        }
    }
}
