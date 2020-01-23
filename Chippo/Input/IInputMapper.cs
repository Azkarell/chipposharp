using SFML.Window;

namespace Chippo.Graphics
{
    public interface IInputMapper
    {
        void HandlePressed(KeyEventArgs s);
        void HandleReleased(KeyEventArgs s);
        void HandlePressed(MouseButtonEventArgs s);
        void HandleReleased(MouseButtonEventArgs s);
        void HandleMove(MouseMoveEventArgs s);
        void HandleWheel(MouseWheelScrollEventArgs s);
    }
}