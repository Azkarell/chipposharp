using System.Threading.Tasks;

namespace Chippo.Core.Interfaces
{
    public interface ILogic
    {
        Task Initialize();
        Task Update();
        Task Shutdown();
    }
}