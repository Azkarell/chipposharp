namespace Chippo.EventSystem.Abstraction
{
    public interface IStreamRegistration
    {
        IEventRegistration<T> AddEvent<T>();
        IStreamRegistration WithName(string name);
    }


}