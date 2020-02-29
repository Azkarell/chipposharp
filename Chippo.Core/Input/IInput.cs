using System;
using Chippo.Core.Interfaces;

namespace Chippo.Core.Input
{
    public interface IInput
    {
        bool IsPressed(KeyboardKey key);
        bool IsPressed(MouseButton button);

        MousePosition MousePosition { get; }

        ISubscription SubscribeWheelHorizontal(Action<float> callback);
        ISubscription SubscribeWheelVertical(Action<float> callback);
        ISubscription SubscribeOnRelease(KeyboardKey key, Action callback);
        ISubscription SubscribeOnPressed(KeyboardKey key, Action callback);
        ISubscription SubscribeOnRelease(MouseButton button, Action callback);
        ISubscription SubscribeOnPressed(MouseButton button, Action callback);
    }
}