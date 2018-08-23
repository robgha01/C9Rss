using System.Xml.Linq;

namespace C9Rss.Public.Domain.Rss.Interfaces.Behaviors
{
    public interface IReadBehavior
    {
        XDocument Read();
    }
}
