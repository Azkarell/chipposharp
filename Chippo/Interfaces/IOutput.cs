using System.Threading.Tasks;

namespace Chippo.Interfaces
{
    public interface IOutput
    {
        bool IsOpen { get; }
        Task Update();
        void Close();
    }
}