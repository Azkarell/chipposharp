using System.Numerics;
using Chippo.Math;
using SFML.System;

namespace Chippo.Graphics.SFML.Extensions
{
    public static class TransformationExtensions
    {
        public static Vector2f ToSfmlScale(this Transformation transformation)
        {
            return transformation.Scale.ToSfmlVector();
        }

        public static Vector2f ToSfmlVector(this Vector2 vector)
        {
            return new Vector2f(vector.X,vector.Y);
        }

        public static float ToSflmRotation(this Transformation transformation)
        {
            return (float) transformation.Rotation.InRadians.Value;
        }
    }
}