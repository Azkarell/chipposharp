using System.Threading.Tasks;

namespace Chippo.Core.Interfaces
{
    public interface IOutput
    {
        bool IsOpen { get; }
        Task Update();
        void Close();
    }
}