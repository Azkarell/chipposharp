using Chippo.Actions;
using Chippo.Constants;
using System;
using System.Diagnostics.CodeAnalysis;

namespace Chippo.Actions.System
{
    internal class QuitEvent : IEvent<Guid, string>
    {
        public QuitEvent()
        {
      
        }

        public static Guid GlobalId { get; } = Guid.NewGuid();
        public string Stream => AppConstants.SystemEventStream;

        public Guid Id => GlobalId;

        public bool Equals([AllowNull] IEvent<Guid, string> other)
        {
            return other != null
                && Id == other.Id
                && Stream == other.Stream;
        }
    }
}