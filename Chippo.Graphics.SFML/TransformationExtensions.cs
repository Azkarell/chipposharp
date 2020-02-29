using System.Numerics;
using Chippo.Math;
using SFML.System;

namespace Chippo.Graphics.SFML
{
    public static class TransformationExtensions
    {
        public static Vector2f ToSfmlScale(this ITransformation transformation)
        {
            return transformation.Scale.ToSfmlVector();
        }

        public static Vector2f ToSfmlVector(this Vector2 vector)
        {
            return new Vector2f(vector.X,vector.Y);
        }

        public static float ToSflmRotation(this ITransformation transformation)
        {
            return (float) transformation.Rotation.InRadians.Value;
        }
    }
}