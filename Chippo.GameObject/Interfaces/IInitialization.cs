using System.Threading.Tasks;

namespace Chippo.GameObjects.Interfaces
{
    public interface IInitialization
    {
        Task<ILevel> InitializeAsync();
    }
}