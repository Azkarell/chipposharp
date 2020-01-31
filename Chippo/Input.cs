using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using SFML.Graphics;
using SFML.System;
using SFML.Window;

namespace Chippo
{
    public class Input
    {
        private readonly RenderWindow window;
        private ConcurrentDictionary<Keyboard.Key,bool> keyState = new ConcurrentDictionary<Keyboard.Key, bool>();
        public Input(RenderWindow window)
        {
            this.window = window;
            foreach (var key in (Keyboard.Key[]) Enum.GetValues(typeof(Keyboard.Key)))
            {
                RegisterOnPressed(key,() => keyState[key] = true);
                RegisterOnRelease(key,() => keyState[key] = false);
            }

            window.MouseMoved += (sender, args) => { MousePosition = new Vector2f(args.X, args.Y); };
            
        }

        private void RegisterOnPressed(Keyboard.Key key, Action action)
        {
            window.KeyPressed += (sender, args) =>
            {
                if (args.Code == key)
                {
                    action();
                }
            };
        }

        private void RegisterOnRelease(Keyboard.Key key, Action action)
        {
            window.KeyReleased += (sender, args) =>
            {
                if (args.Code == key)
                {
                    action();
                }
            };
        }

        public bool IsPressed(Keyboard.Key key)
        {
            if (keyState.TryGetValue(key, out bool val))
            {
                return val;
            }
            return false;
        }

        public Vector2f MousePosition { get; private set; }
    }
}