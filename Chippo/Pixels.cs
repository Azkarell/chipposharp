namespace Chippo
{
    public class Pixels : IMovementUnit
    {
        public Pixels(float pixelsPerSecond)
        {
            PixelsPerSecond = pixelsPerSecond;
        }
        public string Name { get; } = "Pixels";
        public float PixelsPerSecond { get; } 
    }
}