using System;
using System.Collections.Generic;
using Chippo.Core.Input;
using Chippo.Core.Interfaces;
using SFML.Graphics;
using SFML.Window;

namespace Chippo.Graphics.SFML.Input
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
                SubscribeOnPressed(key,() => keyState[key] = true);
                SubscribeOnRelease(key,() => keyState[key] = false);
                keyState[key] = false;
            }

            window.MouseMoved += (sender, args) => { MousePosition = new MousePosition(args.X,args.Y); };
            
            foreach (var button in (MouseButton[]) Enum.GetValues(typeof(MouseButton)))
            {
                SubscribeOnPressed(button,  () => mouseState[button] = true);
                SubscribeOnRelease(button, () => mouseState[button] = false);
                mouseState[button] = false;
            }

        }

        public ISubscription SubscribeOnPressed(MouseButton button, Action action)
        {
            void OnWindowOnMouseButtonPressed(object sender, MouseButtonEventArgs args)
            {
                if (args.Button == MapButton(button))
                {
                    action();
                }
            }

            window.MouseButtonPressed += OnWindowOnMouseButtonPressed;
            return new InputSubscription(delegate {
                window.MouseButtonPressed -= OnWindowOnMouseButtonPressed;
            });
        }

        public ISubscription SubscribeOnRelease(MouseButton button, Action action)
        {
            void OnWindowOnMouseButtonReleased(object sender, MouseButtonEventArgs args)
            {
                if (args.Button == MapButton(button))
                {
                    action();
                }
            }

            window.MouseButtonReleased += OnWindowOnMouseButtonReleased;
            return new InputSubscription(delegate {
                window.MouseButtonReleased -= OnWindowOnMouseButtonReleased;
            });
        }

        public ISubscription SubscribeOnPressed(KeyboardKey key, Action action)
        {
            void OnWindowOnKeyPressed(object sender, KeyEventArgs args)
            {
                if (args.Code == MapKey(key))
                {
                    action();
                }
            }

            window.KeyPressed += OnWindowOnKeyPressed;
            return new InputSubscription(delegate {
                window.KeyPressed -= OnWindowOnKeyPressed;
            });
        }

        public ISubscription SubscribeOnRelease(KeyboardKey key, Action action)
        {
            void OnWindowOnKeyReleased(object sender, KeyEventArgs args)
            {
                if (args.Code == MapKey(key))
                {
                    action();
                }
            }

            window.KeyReleased += OnWindowOnKeyReleased;
            return new InputSubscription(delegate { window.KeyReleased -= OnWindowOnKeyReleased; });
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

        public ISubscription SubscribeWheelHorizontal(Action<float> callback)
        {
            void OnWheelScrolled(object sender, MouseWheelScrollEventArgs args)
            {
                if (args.Wheel == Mouse.Wheel.HorizontalWheel)
                {
                    callback(args.Delta);
                }
            }

            window.MouseWheelScrolled += OnWheelScrolled;
            return new InputSubscription(delegate { window.MouseWheelScrolled -= OnWheelScrolled; });
        }

        public ISubscription SubscribeWheelVertical(Action<float> callback)
        {
            void OnWheelScrolled(object sender, MouseWheelScrollEventArgs args)
            {
                if (args.Wheel == Mouse.Wheel.VerticalWheel)
                {
                    callback(args.Delta);
                }
            }

            window.MouseWheelScrolled += OnWheelScrolled;

            return new InputSubscription(delegate { window.MouseWheelScrolled -= OnWheelScrolled; });

        }

        private static Keyboard.Key MapKey(KeyboardKey key)
        {
            return (Keyboard.Key) (int) key;
        }

        private static Mouse.Button MapButton(MouseButton button)
        {
            return (Mouse.Button) (int) button;
        }
    }
}