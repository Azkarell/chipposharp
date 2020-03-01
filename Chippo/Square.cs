using System;
using Chippo.GameObjects;
using Chippo.Graphics;
using Chippo.Graphics.Interface;
using Chippo.Graphics.SFML;
using Chippo.Math;
using Chippo.Movement.Interface;

namespace Chippo
{
    public class Square: DrawableGameObject<SfmlContext>
    {
        private readonly Color color;
        private Transformation transformation;
        private readonly IMovement movement;

        public Square(Color color, Transformation transformation, IMovement movement)
        {
            this.color = color;
            this.transformation = transformation;
            this.movement = movement;
        }
        protected override GameObjectLifeTime OnUpdate(TimeSpan delta)
        {
            transformation = transformation
                .Translate(movement.GetDelta(delta))
                .Rotate(movement.GetRotation(delta));
            return GameObjectLifeTime.Alive;
        }

        public override void Draw(SfmlContext context)
        {
            context.Square(color, transformation);
        }
    }
}