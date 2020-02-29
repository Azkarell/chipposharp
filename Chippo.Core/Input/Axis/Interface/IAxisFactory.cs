namespace Chippo.Core.Input.Axis.Interface
{
    public interface IAxisFactory
    {
        IAxis2D CreateAxis2D(Axis2DConfiguration configuration);
    }
}