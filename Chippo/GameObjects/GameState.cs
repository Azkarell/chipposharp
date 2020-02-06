using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using SFML.Graphics;

namespace Chippo.GameObjects
{
    public class GameState
    {
        public ICollection<StaticObject> StaticObjects { get; } = new List<StaticObject>();
        public ICollection<GameObject> GameObjects { get; } = new List<GameObject>();
        public ICollection<Drawable> Drawables { get; } = new List<Drawable>();
    }
}