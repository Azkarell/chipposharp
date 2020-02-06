using System;
using System.Collections.Generic;
using System.Threading;
using Chippo.Interfaces;
using SFML.Graphics;
using SFML.System;
using SFML.Window;

namespace Chippo.Input
{
    public class Input : IInput
    {
        private readonly RenderWindow window;
        private readonly Dictionary<Keyboard.Key,bool> keyState = new Dictionary<Keyboard.Key, bool>();
        private readonly Dictionary<Mouse.Button,bool> mouseState = new Dictionary<Mouse.Button, bool>();
        public Input(RenderWindow window)
        {
            this.window = window;
            foreach (var key in (Keyboard.Key[]) Enum.GetValues(typeof(Keyboard.Key)))
            {
                RegisterOnPressed(key,() => keyState[key] = true);
                RegisterOnRelease(key,() => keyState[key] = false);
                keyState[key] = false;
            }

            window.MouseMoved += (sender, args) => { MousePosition = new Vector2f(args.X, args.Y); };
            
            foreach (var button in (Mouse.Button[]) Enum.GetValues(typeof(Mouse.Button)))
            {
                RegisterOnPressed(button, () => mouseState[button] = true);
                RegisterOnRelease(button, () => mouseState[button] = false);
                mouseState[button] = false;
            }

        }

        public void RegisterOnPressed(Mouse.Button button, Action action)
        {
            window.MouseButtonPressed += (sender, args) =>
            {
                if (args.Button == button)
                {
                    action();
                }
            };

        }

        public void RegisterOnRelease(Mouse.Button button, Action action)
        {
            window.MouseButtonReleased += (sender, args) =>
            {
                if (args.Button == button)
                {
                    action();
                }
            };
        }

        public void RegisterOnPressed(Keyboard.Key key, Action action)
        {
            window.KeyPressed += (sender, args) =>
            {
                if (args.Code == key)
                {
                    action();
                }
            };
        }

        public void RegisterOnRelease(Keyboard.Key key, Action action)
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
            return keyState[key];
        }

        public bool IsPressed(Mouse.Button button)
        {
            return mouseState[button];
        }

        public Vector2f MousePosition { get; private set; }
        public void RegisterWheelHorizontal(Action<float> callback)
        {
            window.MouseWheelScrolled += (sender, args) =>
            {
                if (args.Wheel == Mouse.Wheel.HorizontalWheel)
                {
                    callback(args.Delta);
                }
            };
        }

        public void RegisterWheelVertical(Action<float> callback)
        {
            window.MouseWheelScrolled += (sender, args) =>
            {
                if (args.Wheel == Mouse.Wheel.VerticalWheel)
                {
                    callback(args.Delta);
                }
            };
        }

    }
}