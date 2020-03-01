using System.Threading.Tasks;

namespace Chippo.Core
{
    public interface IOutput
    {
        bool IsOpen { get; }
        Task Update();
        void Close();
    }
}