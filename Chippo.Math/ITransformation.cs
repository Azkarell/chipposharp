using System;
using System.Numerics;
using System.Runtime.CompilerServices;

namespace Chippo.Math
{
    public struct Transformation
    {
        public Transformation(Vector2 translation, Vector2 scale, Rotation rotation)
        {
            Translation = translation;
            Scale = scale;
            Rotation = rotation;
        }
        public Vector2 Translation { get;  } 
        public Vector2 Scale { get;  }
        public Rotation Rotation { get;  }

        public Transformation Translate(Vector2 vector2)
        {
            return new Transformation(this.Translation + vector2, this.Scale, this.Rotation);
        }

        public Transformation Rotate(Rotation rotation)
        {
            return new Transformation(Translation,Scale,Rotation.Add(rotation));
        }

        public Transformation WithScale(Vector2 scale)
        {
            return new Transformation(Translation,scale,Rotation);
        }

        public static Transformation Default { get; } = new Transformation(Vector2.Zero, Vector2.One, Math.Rotation.Zero);
    }
}