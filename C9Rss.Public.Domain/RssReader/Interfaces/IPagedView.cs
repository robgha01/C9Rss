namespace C9Rss.Public.Domain.RssReader.Interfaces
{
    public interface IPagedView
    {
        dynamic ViewFeed(int currentPage, int pageSize);
    }
}
