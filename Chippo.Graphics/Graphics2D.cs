using System.Threading.Tasks;
using Chippo.Core.Interfaces;

namespace Chippo.Graphics
{
    public abstract class Graphics2D<TContext,TDrawable>: IOutput<TContext>
        where TContext : Graphics2DContext<TDrawable>
    {

        public abstract bool IsOpen { get; }

        public abstract Task Update(TContext context);

        public abstract void Close();
    }
}