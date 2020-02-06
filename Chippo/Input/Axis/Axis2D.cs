namespace Chippo.Input.Axis
{
    internal class Axis2D : IAxis2D
    {
        private readonly Axis2DConfiguration configuration;

        public Axis2D(Axis2DConfiguration configuration)
        {
            this.configuration = configuration;
        }

        public float XAxis => -1 * configuration.Left.GetValue() + configuration.Right.GetValue();
        public float YAxis => -1 * configuration.Up.GetValue() + configuration.Down.GetValue();
    }
}