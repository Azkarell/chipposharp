using System;

namespace Chippo.GameObjects.Interfaces
{
    public interface IGameObjectFactory
    {
        void Register<T>(Func<GameState, T> factory)
            where T: GameObject;

        void Register(string name, Func<GameState, GameObject> factory);
        GameObject Create(string name);

        T Create<T>()
            where T: GameObject;
    }
}