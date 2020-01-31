using System.Threading.Tasks;

namespace Chippo.Interfaces
{
    public interface ILogic
    {
        Task<ApplicationState> Update();
    }

    public enum ApplicationState
    {
        Init,
        Running,
        Shutdown
    }
}