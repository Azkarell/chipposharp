using System.Threading.Tasks;

namespace Chippo.Core.Interfaces
{
    public class Output<TContext> : Output
    {
        private TContext oldContext;
        private readonly IContextFactory<TContext> contextFactory;
        private readonly IOutput<TContext> output;

        public Output(IContextFactory<TContext> contextFactory, IOutput<TContext> output)
        {
            this.contextFactory = contextFactory;
            this.output = output;
        }

        public override bool IsOpen => output.IsOpen;
        public override Task Update()
        {
            oldContext = contextFactory.Create(oldContext);
            return output.Update(oldContext);
        }

        public override void Close()
        {
            output.Close();
        }
    }

    public abstract class Output
    {
        public abstract bool IsOpen { get; }
        public abstract Task Update();
        public abstract void Close();
    }
}