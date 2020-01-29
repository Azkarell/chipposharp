using System;

namespace Chippo.Core.Component
{

    abstract class ComponentWrapper
    {
        private TimeSpan last = TimeSpan.Zero;

        public ApplicationState Update(TimeSpan total)
        {
            var dif = total - last;
            var ret = DoUpdate(dif);
            last = total;
            return ret;
        }

        protected abstract ApplicationState DoUpdate(TimeSpan delta);
    };

    internal class ComponentWrapper<T> : ComponentWrapper where T : IComponent
    {
        public T Component { get; }

        public ComponentWrapper(T component)
        {
            Component = component;
        }

        protected override ApplicationState DoUpdate(TimeSpan delta)
        {
            return Component.Update(delta);
        }

    }

    abstract class StartupWrapper
    {
        public abstract void Start();
    }

    class StartupWrapper<T> : StartupWrapper where T : IStartable
    {
        private readonly T startable;

        public StartupWrapper(T startable)
        {
            this.startable = startable;
        }
        public override void Start()
        {
            startable.Start();
        }
    }

    abstract class ShutdownWrapper
    {
        public abstract void Shutdown();
    }

    class ShutdownWrapper<T> : ShutdownWrapper where T : ICloseable
    {
        private readonly T closable;

        public ShutdownWrapper(T closable)
        {
            this.closable = closable;
        }
        public override void Shutdown()
        {
            closable.Shutdown();
        }
    }


}