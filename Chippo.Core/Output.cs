using System.Collections;
using System.Threading.Tasks;

namespace Chippo.Core
{
    public interface IOutput
    {
        bool IsOpen { get; }
        void Close();
        Task Update();
    }
}