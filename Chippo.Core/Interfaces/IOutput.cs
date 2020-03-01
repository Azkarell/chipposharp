using System;
using System.Threading.Tasks;

namespace Chippo.Core.Interfaces
{
    public interface IOutput<in TContext>: IOutput
    {
        Task Update(TContext context);
    }
}