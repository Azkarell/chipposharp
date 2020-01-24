namespace Chippo.Actions
{
    interface IEvent
    {
        EventId EventId { get; }
        EventStream Stream { get; }
    }
}
