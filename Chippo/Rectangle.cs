using System;
using Chippo.GameObjects;
using SFML.Graphics;
using SFML.System;

namespace Chippo
{
    public class Rectangle : GameObject, Drawable
    {
        private readonly IMovement movement;

        private RectangleShape rectangle;

        public Rectangle(Vector2f initPosition, Vector2f size, Color color, IMovement movement)
        {
            this.movement = movement;
            rectangle = new RectangleShape(size);
            rectangle.FillColor = color;
            rectangle.Position = initPosition;
        }

        protected override void OnUpdate(TimeSpan delta)
        {
             rectangle.Position = movement.Apply(rectangle.Position, delta);
        }

        public void Draw(RenderTarget target, RenderStates states)
        {
            rectangle.Draw(target, states);
        }


    }
}