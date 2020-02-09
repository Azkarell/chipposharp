namespace Chippo.Core.Input.Axis
{

    public interface IAxisProvider
    {
        void Register(string name, Axis2DConfiguration configuration);
        void Register(string name, IAxis2D axis2D);
        IAxis2D GetAxis2D(string name);
    }
}