using NetDevPack.Messaging;

namespace BookActivity.Domain.Core.Events
{
    public interface IEventStore
    {
        void Save<T>(T theEvent) where T : Event;
    }
}
