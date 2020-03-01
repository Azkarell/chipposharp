namespace Chippo.Graphics.SFML.Extensions
{
    public static class ColorExtensions
    {

        public static global::SFML.Graphics.Color ToSfmlColor(this Color color)
        {
            return new global::SFML.Graphics.Color(color.R,color.G,color.B,color.A);
        }
    }
}