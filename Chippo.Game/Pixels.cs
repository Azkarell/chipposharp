using Chippo.Movement.Interface;

namespace Chippo.Movement
{
    public class Pixels : IMovementUnit
    {
        private readonly float speed;

        public Pixels(float speed)
        {
            this.speed = speed;
        }
        public string Name { get; } = "Pixels";
        public float PixelsPerSecond => speed * 1.0f;
    }
}