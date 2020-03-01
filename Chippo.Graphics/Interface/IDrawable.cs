namespace Chippo.Graphics.Interface
{
    public interface IDrawable<TContext>
    {
        public delegate void DrawableDestroyEvent(DrwaableDestroyEventArgs<TContext> args);
        void Draw(TContext context);
        event DrawableDestroyEvent? OnDestroy;
    }

    public class DrwaableDestroyEventArgs<TContext>
    {
        public IDrawable<TContext> Drawable { get; }

        public DrwaableDestroyEventArgs(IDrawable<TContext> drawable)
        {
            Drawable = drawable;
        }
    }
}