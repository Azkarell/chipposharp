using System;
using System.Numerics;
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
            if (transformation.Translation.X > context.Dimension.X)
            {
                transformation = transformation.WithTranslation(new Vector2(context.Dimension.X,transformation.Translation.Y));
            }

            if (transformation.Translation.Y > context.Dimension.Y)
            {
                transformation =
                    transformation.WithTranslation(new Vector2(transformation.Translation.X, context.Dimension.Y));
            }
            context.Square(transformation, new Material(color));
        }
    }
}