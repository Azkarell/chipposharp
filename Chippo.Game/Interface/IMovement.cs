using System;
using System.Numerics;
using Chippo.Math;

namespace Chippo.Movement.Interface
{
    public interface IMovement
    {
        Vector2 Apply(in Vector2 oldPosition, in TimeSpan delta);
    }
}