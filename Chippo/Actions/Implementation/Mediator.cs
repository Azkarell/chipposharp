using Autofac;
using Chippo.Common;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Threading.Tasks;
using System.Threading.Tasks.Dataflow;

namespace Chippo.Actions.Implementation
{
    abstract class HandlerWrapper
    {
        public abstract void Handle(object ev);
    }

    class HandlerWrapper<T, TId, TStream> : HandlerWrapper
        where TId : IEquatable<TId>
        where TStream : IEquatable<TStream>
        where T : IEvent<TId, TStream>
    {
        private readonly IEventHandler<T, TId, TStream> handler;

        public HandlerWrapper(IEventHandler<T, TId, TStream> handler)
        {
            this.handler = handler;
        }

        public override void Handle(object ev)
        {
            var typed = (T)ev;
            handler.Handle(typed);
        }
    }

    class Mediator : IMediator<Guid, string>
    {
        private readonly ICloneService cloneService;
        private ConcurrentDictionary<(Guid, string), BroadcastBlock<IEvent<Guid, string>>> buffers = new ConcurrentDictionary<(Guid, string), BroadcastBlock<IEvent<Guid, string>>>();
        private ConcurrentBag<Task> tasks = new ConcurrentBag<Task>();


        public Mediator(ICloneService cloneService)
        {
            this.cloneService = cloneService;
        }

        public async Task Publish(IEvent<Guid,string> @event)
        {
            if (buffers.TryGetValue((@event.Id, @event.Stream), out var buffer))
            {
                await buffer.SendAsync(@event);
            }

        }



        public void Subscribe(IEventHandler<IEvent<Guid,string>, Guid, string> eventHandler)
        {
            BroadcastBlock<IEvent<Guid,string>> tb = null;
            if (buffers.TryGetValue((eventHandler.Id, eventHandler.Stream), out var buffer))
            {
                tb = buffer;

            } else
            {
                tb = new BroadcastBlock<IEvent<Guid,string>>(x => cloneService.Clone(x));
                buffers.AddOrUpdate((eventHandler.Id, eventHandler.Stream), tb, (k, o) => o);
            }

            async Task HandleWrapper()
            {
                BufferBlock<IEvent<Guid,string>> source = new BufferBlock<IEvent<Guid,string>>();
                using (tb.LinkTo(source))
                {
                    while (await source.OutputAvailableAsync())
                    {
                        await eventHandler.Handle(await source.ReceiveAsync());
                    }
                }
            }
            var task = Task.Run(async () => await HandleWrapper());
            tasks.Add(task);

        }

    }

}





