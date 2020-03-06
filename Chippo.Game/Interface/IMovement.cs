using System;
using System.Numerics;
using Chippo.Math;

namespace Chippo.Movement.Interface
{
    public interface IMovement
    {
        Vector2 GetDelta(in TimeSpan delta);
        RotationAngle GetRotation(in TimeSpan delta);
    }
}