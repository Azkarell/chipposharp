namespace Chippo.Input.Axis
{
    class Axis2DProxy : IAxis2D
    {
        private IAxis2D axis2DImplementation;

        public Axis2DProxy(IAxis2D axis2DImplementation)
        {
            this.axis2DImplementation = axis2DImplementation;
        }

        public float XAxis => axis2DImplementation.XAxis;

        public float YAxis => axis2DImplementation.YAxis;

        public void SwitchImplementation(IAxis2D axis2D)
        {
            axis2DImplementation = axis2D;
        }
    }
}