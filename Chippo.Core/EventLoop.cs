using System.Collections.Generic;

namespace Chippo.Core
{
    class EventLoop: IEventLoop
    {

        private Queue<IEvent> queue = new Queue<IEvent>();

        public void Publish(IEvent @event)
        {
            queue.Enqueue(@event);
        }

        public IEvent? Next()
        {
            if (queue.Count > 0)
            {
                return queue.Dequeue();
            }
            return null;
        }
    }
}