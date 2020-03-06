namespace Chippo.Graphics.Interface
{
    public interface IDrawable<TContext>
    {
        void Draw(TContext context);
    }


}