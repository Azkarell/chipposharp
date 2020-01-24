namespace Chippo.EventSystem.Abstraction
{
    public interface IBus
    {
        void Publish<T>(T @event);
    }
}