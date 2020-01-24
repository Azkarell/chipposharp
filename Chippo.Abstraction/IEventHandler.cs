using System.Threading.Tasks;

namespace Chippo.EventSystem.Abstraction
{
    public interface IEventHandler<in T>
    {
        Task HandleAsync(T @event);
    }
}