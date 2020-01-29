
namespace Chippo.Core
{
    public interface IEventLoop
    {
        void Publish(IEvent @event);
    }
}