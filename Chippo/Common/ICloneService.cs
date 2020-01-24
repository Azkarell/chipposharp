namespace Chippo.Common
{
    public interface ICloneService
    {
        public T Clone<T>(T val) where T: class;
    }
}