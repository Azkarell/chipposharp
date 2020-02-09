using System;
using System.Collections.Generic;
using Chippo.Core.Input;
using SFML.Graphics;
using SFML.Window;

namespace Chippo.SFML.Input
{
    public class Input : IInput
    {
        private readonly RenderWindow window;
        private readonly Dictionary<KeyboardKey,bool> keyState = new Dictionary<KeyboardKey, bool>();
        private readonly Dictionary<MouseButton,bool> mouseState = new Dictionary<MouseButton, bool>();
        public Input(RenderWindow window)
        {
            this.window = window;
            foreach (var key in (KeyboardKey[]) Enum.GetValues(typeof(KeyboardKey)))
            {
                RegisterOnPressed(key,(Action) (() => keyState[key] = true));
                RegisterOnRelease(key,(Action) (() => keyState[key] = false));
                keyState[key] = false;
            }

            window.MouseMoved += (sender, args) => { MousePosition = new MousePosition { X = args.X, Y = args.Y }; };
            
            foreach (var button in (MouseButton[]) Enum.GetValues(typeof(MouseButton)))
            {
                RegisterOnPressed(button, (Action) (() => mouseState[button] = true));
                RegisterOnRelease(button, (Action) (() => mouseState[button] = false));
                mouseState[button] = false;
            }

        }

        public void RegisterOnPressed(MouseButton button, Action action)
        {
            window.MouseButtonPressed += (sender, args) =>
            {
                if (args.Button == MapButton(button))
                {
                    action();
                }
            };

        }

        public void RegisterOnRelease(MouseButton button, Action action)
        {
            window.MouseButtonReleased += (sender, args) =>
            {
                if (args.Button == MapButton(button))
                {
                    action();
                }
            };
        }

        public void RegisterOnPressed(KeyboardKey key, Action action)
        {
            window.KeyPressed += (sender, args) =>
            {
                if (args.Code == MapKey(key))
                {
                    action();
                }
            };
        }

        public void RegisterOnRelease(KeyboardKey key, Action action)
        {
            window.KeyReleased += (sender, args) =>
            {
                if (args.Code == MapKey(key))
                {
                    action();
                }
            };
        }

        public bool IsPressed(KeyboardKey key)
        {
            return keyState[key];
        }

        public bool IsPressed(MouseButton button)
        {
            return mouseState[button];
        }

        public MousePosition MousePosition { get; private set; }

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

        private Keyboard.Key MapKey(KeyboardKey key)
        {
            return (Keyboard.Key) (int) key;
        }

        private Mouse.Button MapButton(MouseButton button)
        {
            return (Mouse.Button) (int) button;
        }
    }
}