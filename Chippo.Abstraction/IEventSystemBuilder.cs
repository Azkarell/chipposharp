namespace Chippo.EventSystem.Abstraction
{
    public interface IEventSystemBuilder
    {
        IStreamRegistration AddStream(StreamId id);
    }
}