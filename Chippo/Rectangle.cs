using System;
using Chippo.GameObjects;
using Chippo.Interfaces;
using SFML.Graphics;
using SFML.System;

namespace Chippo
{
    public class Rectangle : DrawableGameObject
    {
        private readonly float speed;
        private readonly IAxis2D axis;
        private SFML.Graphics.RectangleShape rectangle = new RectangleShape(new Vector2f(10,10));

        public Rectangle(float speed, IAxis2D axis)
        {
            this.speed = speed;
            this.axis = axis;
            rectangle.FillColor = Color.Red;
        }

        public override void Update(TimeSpan delta)
        {
            rectangle.Position = new Vector2f(rectangle.Position.X + speed * axis.XAxis * (float) delta.TotalSeconds, rectangle.Position.Y + speed * axis.YAxis * (float) delta.TotalSeconds);
        }

        public override Drawable AsDrawable => rectangle;
    }
}