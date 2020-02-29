using System.Collections.Generic;
using Chippo.Math;
using SFML.Graphics;
using SFML.System;

namespace Chippo.Graphics.SFML
{
    public class SfmlContext : Graphics2DContext<Drawable>
    {
        private List<Drawable> drawables = new List<Drawable>();

        public override Graphics2DContext<Drawable> Square(Color color, ITransformation transformation)
        {
            var shape = new RectangleShape(new Vector2f(1,1));
            UpdateShape(shape, transformation);
            drawables.Add(shape);
            return this;
        }

        public override Graphics2DContext<Drawable> Circle(Color color, ITransformation transformation)
        {
            var shape = new CircleShape(1);
            UpdateShape(shape,transformation);
            drawables.Add(shape);
            return this;
        }

        public override IEnumerable<Drawable> GetDrawables()
        {
            return drawables;
        }

        private void UpdateShape(Shape shape, ITransformation transformation)
        {
            shape.Transform.Scale(transformation.ToSfmlScale());
            shape.Position = transformation.Translation.ToSfmlVector();
            shape.Rotation = transformation.ToSflmRotation();
        }

    }
}