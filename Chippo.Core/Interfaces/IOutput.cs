using System;
using System.Threading.Tasks;

namespace Chippo.Core.Interfaces
{


    public interface IOutput<in TContext>
    {
        bool IsOpen { get; }
        Task Update(TContext context);
        void Close();
    }
}