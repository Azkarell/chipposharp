namespace Chippo.Graphics.Interface
{
    public interface IContextFactory<T>
    {
        T Create(T oldContext);
    }
}