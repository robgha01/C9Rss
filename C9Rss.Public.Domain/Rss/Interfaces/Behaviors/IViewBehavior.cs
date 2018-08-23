namespace C9Rss.Public.Domain.Rss.Interfaces.Behaviors
{
    public interface IViewBehavior<out T>
    {
        T View();
        T View(int? maxItems, string subElementKey);
        T View(int startIndex, string subElementKey, int? maxItems);
    }
}
