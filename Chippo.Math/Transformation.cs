using System;
using System.Numerics;
using System.Runtime.CompilerServices;

namespace Chippo.Math
{
    public struct Transformation
    {
        public Transformation(Vector2 translation, Vector2 scale, RotationAngle rotationAngle)
        {
            Translation = translation;
            Scale = scale;
            RotationAngle = rotationAngle;
        }
        public Vector2 Translation { get;  } 
        public Vector2 Scale { get;  }
        public RotationAngle RotationAngle { get;  }

        public Transformation Translate(Vector2 vector2)
        {
            return new Transformation(this.Translation + vector2, this.Scale, this.RotationAngle);
        }

        public Transformation Rotate(RotationAngle rotationAngle)
        {
            return new Transformation(Translation,Scale,RotationAngle.Add(rotationAngle));
        }

        public Transformation WithScale(Vector2 scale)
        {
            return new Transformation(Translation,scale,RotationAngle);
        }

        public Transformation WithTranslation(Vector2 translation)
        {
            return new Transformation(translation,Scale,RotationAngle);
        }

        public Transformation WithRotation(RotationAngle rotationAngle)
        {
            return new Transformation(Translation,Scale,rotationAngle);
        }

        public static Transformation Identity { get; } = new Transformation(Vector2.Zero, Vector2.One, Math.RotationAngle.Zero);

        public BoundingBox GetBoundingBox()
        {
            var minX = Translation.X;
            var maxX = Translation.X * Scale.X;
            var minY = Translation.Y;
            var maxY = Translation.Y * Scale.Y;
            return new BoundingBox(minX,minY,maxX,maxY);
        }
    }

    public class BoundingBox
    {
        private readonly float minX;
        private readonly float minY;
        private readonly float maxX;
        private readonly float maxY;

        public BoundingBox(float minX, float minY, float maxX, float maxY)
        {
            this.minX = minX;
            this.minY = minY;
            this.maxX = maxX;
            this.maxY = maxY;
            AssertDimension();
        }

        private void AssertDimension()
        {
            if (minX > maxX || minY > maxY)
            {
                throw new ArgumentException("Invalid dimension for boundingbox");
            }
        }

        public bool IsInside(Vector2 vector)
        {
            var testX = minX <= vector.X && maxX >= vector.X;
            var testY = minY <= vector.Y && maxY >= vector.Y;
            return testX && testY;
        }
    }
}