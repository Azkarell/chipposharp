using System;
using SFML.System;

namespace Chippo
{
    public interface IMovement
    {
        Vector2f Apply(in Vector2f oldPosition, in TimeSpan delta);
    }
}