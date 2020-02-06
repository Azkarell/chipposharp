using System;
using Chippo.Interfaces;
using SFML.System;
using SFML.Window;

namespace Chippo.Input
{
    public interface IInput
    {
        bool IsPressed(Keyboard.Key key);
        bool IsPressed(Mouse.Button button);
        Vector2f MousePosition { get; }
        void RegisterWheelHorizontal(Action<float> callback);
        void RegisterWheelVertical(Action<float> callback);
        void RegisterOnRelease(Keyboard.Key key, Action callback);
        void RegisterOnPressed(Keyboard.Key key, Action callback);
        void RegisterOnRelease(Mouse.Button button, Action callback);
        void RegisterOnPressed(Mouse.Button button, Action callback);

    }
}