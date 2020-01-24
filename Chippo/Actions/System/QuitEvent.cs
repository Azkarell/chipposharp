using Chippo.Actions;
using Chippo.Constants;
using System;
using System.Diagnostics.CodeAnalysis;

namespace Chippo.Actions.System
{
    internal class QuitEvent : IEvent
    {
        public QuitEvent()
        {
      
        }

        public EventId EventId { get; } = EventId.NewId();
        public EventStream Stream { get; } = new EventStream();
    }
}