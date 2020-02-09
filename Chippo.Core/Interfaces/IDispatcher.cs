

using System.Threading.Tasks;

namespace Chippo.Core.Interfaces
{
    public interface IDispatcher
    {
        Task DispatchPendingEvents();
    }


}