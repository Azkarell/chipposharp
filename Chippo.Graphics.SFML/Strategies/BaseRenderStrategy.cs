using Chippo.Graphics.SFML.Extensions;
using Chippo.Graphics.SFML.Interface;
using Chippo.Math;
using SFML.Graphics;
using SFML.System;
using NotImplementedException = System.NotImplementedException;

namespace Chippo.Graphics.SFML.Strategies
{
    public class BaseRenderStrategy: ISfmlRenderStrategy
    {
        public Drawable CreateSquare(Transformation transformation, Material material)
        {
            var square = new RectangleShape(new Vector2f(1,1));
            square.Transform.Combine(transformation.ToSfmlTransform());
            square.FillColor = material.FillColor.ToSfmlColor();
            return square;
        }
    }
}