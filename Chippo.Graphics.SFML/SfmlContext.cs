using System;
using System.Collections.Generic;
using System.Numerics;
using Chippo.Core.Resources;
using Chippo.Graphics.SFML.Extensions;
using Chippo.Graphics.SFML.Interface;
using Chippo.Math;
using SFML.Graphics;

namespace Chippo.Graphics.SFML
{
    public class SfmlContext : IGraphics2DContext<Drawable,SfmlContext>
    {
        internal ISfmlRenderStrategy Strategy { get; }
        private readonly RenderWindow renderWindow;

        private List<Drawable> drawables = new List<Drawable>();

        public SfmlContext(RenderWindow renderWindow, ISfmlRenderStrategy strategy)
        {
            Strategy = strategy;
            this.renderWindow = renderWindow;
        }


        public SfmlContext Square(Transformation transformation, Material material)
        {
            drawables.Add(Strategy.CreateSquare(transformation,material));
            return this;
        }

        public SfmlContext Text(Transformation transformation, Material material, string text)
        {
            var resourceLoader = new ResourceLoader();
            var font = new Font(resourceLoader.Load("ErbosDraco"));
            var drawableText = new Text(text,font);
            drawableText.FillColor = material.FillColor.ToSfmlColor();
            drawableText.Transform.Combine(transformation.ToSfmlTransform());
            drawables.Add(new Text(text, font));
            return this;
        }

        public IEnumerable<Drawable> GetDrawables()
        {
            return drawables;
        }

        public Vector2 Dimension => new Vector2(renderWindow.Size.X,renderWindow.Size.Y);



    }
}