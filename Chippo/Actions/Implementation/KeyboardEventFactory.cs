using Autofac;
using Chippo.Settings;
using SFML.Window;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace Chippo.Actions.Implementation
{
    class KeyboardEventFactory : IKeyboardEventFactory<Guid, string>
    {
        private readonly InputSettings inputSettings;
        private readonly ILifetimeScope lifetimeScope;

        public KeyboardEventFactory(InputSettings inputSettings, ILifetimeScope lifetimeScope)
        {
            this.inputSettings = inputSettings;
            this.lifetimeScope = lifetimeScope;
        }

        public IEvent<Guid, string>? Create(KeyEventArgs s) 
        {
            var cs = s.Code.ToString("g");
            if (inputSettings.TryGetValue(cs, out var ev))
            {
                var type = Type.GetType(ev);
                if (type == null) return null;
                return Activator.CreateInstance(type) as IEvent<Guid, string>;
            }
            return null;
        }


    }
}
