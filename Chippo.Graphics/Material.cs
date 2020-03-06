namespace Chippo.Graphics
{
    public class Material
    {
        public Material() { }
        public Material(Color fillColor)
        {
            FillColor = fillColor;
        }
        public Color FillColor { get; set; } = Color.FromRGBA("#000000");
    }
}