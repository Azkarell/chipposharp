namespace Chippo.Core.Input.Axis
{
    class AxisFactory : IAxisFactory
    {
        public IAxis2D CreateAxis2D(Axis2DConfiguration configuration)
        {
            return new Axis2D(configuration);
        }
    }
}