namespace Chippo.Core.Interfaces
{
    public interface IContextFactory<T>
    {
        T Create(T oldContext);
    }
}