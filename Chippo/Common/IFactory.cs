namespace Chippo.Common
{
    interface IFactory<in TInput, out TOut>
    {
        TOut Create(TInput input);
    }
}