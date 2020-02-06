namespace Chippo.Input.Axis
{
    internal interface IAxisFactory
    {
        IAxis2D CreateAxis2D(Axis2DConfiguration configuration);
    }
}