using System.Collections.Generic;
using Chippo.Core.Interfaces;

namespace Chippo.GameObjects
{
    public class GameState
    {
        public ICollection<GameObject> GameObjects { get; } = new List<GameObject>();
    }


}