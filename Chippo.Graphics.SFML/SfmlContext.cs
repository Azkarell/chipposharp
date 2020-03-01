using System.Collections.Generic;
using System.Numerics;
using Chippo.Graphics.SFML.Extensions;
using Chippo.Math;
using SFML.Graphics;
using SFML.System;

namespace Chippo.Graphics.SFML
{
    public class SfmlContext : Graphics2DContext<Drawable>
    {
        private readonly RenderWindow renderWindow;

        private List<Drawable> drawables = new List<Drawable>();

        public SfmlContext(RenderWindow renderWindow)
        {
            this.renderWindow = renderWindow;
        }

        public override Graphics2DContext<Drawable> Square(Color color, Transformation transformation)
        {
            var shape = new RectangleShape(new Vector2f(1,1));
            UpdateShape(shape, transformation);
            shape.FillColor = color.ToSfmlColor();
            drawables.Add(shape);
            return this;
        }

        public override Graphics2DContext<Drawable> Circle(Color color, Transformation transformation)
        {
            var shape = new CircleShape(1);
            UpdateShape(shape,transformation);
            shape.FillColor = color.ToSfmlColor();
            drawables.Add(shape);
            return this;
        }

        public override IEnumerable<Drawable> GetDrawables()
        {
            return drawables;
        }

        public override Vector2 Dimension => new Vector2(renderWindow.Size.X,renderWindow.Size.Y);

        private void UpdateShape(Shape shape, Transformation transformation)
        {
            shape.Transform.Scale(transformation.ToSfmlScale());
            shape.Position = transformation.Translation.ToSfmlVector();
            shape.Rotation = transformation.ToSflmRotation();
        }

    }
}