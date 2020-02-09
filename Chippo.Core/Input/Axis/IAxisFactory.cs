namespace Chippo.Core.Input.Axis
{
    public interface IAxisFactory
    {
        IAxis2D CreateAxis2D(Axis2DConfiguration configuration);
    }
}