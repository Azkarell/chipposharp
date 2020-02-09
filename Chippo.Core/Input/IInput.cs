using System;

namespace Chippo.Core.Input
{
    public interface IInput
    {
        bool IsPressed(KeyboardKey key);
        bool IsPressed(MouseButton button);
        MousePosition MousePosition { get; }
        void RegisterWheelHorizontal(Action<float> callback);
        void RegisterWheelVertical(Action<float> callback);
        void RegisterOnRelease(KeyboardKey key, Action callback);
        void RegisterOnPressed(KeyboardKey key, Action callback);
        void RegisterOnRelease(MouseButton button, Action callback);
        void RegisterOnPressed(MouseButton button, Action callback);
    }
}