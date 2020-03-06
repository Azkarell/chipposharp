namespace Chippo.Graphics.Interface
{
    public interface IContextFactory<T>
      where T : class
    {
        T Create(T? oldContext);
    }
}