using System;
using System.Numerics;
using System.Runtime.CompilerServices;

namespace Chippo.Math
{
    public interface ITransformation
    {
        Vector2 Translation { get; }
        Vector2 Scale { get; }
        Rotation Rotation { get; }
    }
}