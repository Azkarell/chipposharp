using System.Collections.Generic;

namespace Chippo.GameObjects.Interfaces
{
    public interface IGameObjectProvider
    {
        IEnumerable<GameObject> GetGameObjects();
    }
}