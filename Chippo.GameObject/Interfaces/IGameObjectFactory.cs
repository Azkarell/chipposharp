using System;

namespace Chippo.GameObjects.Interfaces
{
    public interface IGameObjectFactory
    {
        void Register<T>(Func<T> factory)
            where T: GameObject;

        void Register(string name, Func<GameObject> factory);
        GameObject Create(string name);

        T Create<T>()
            where T: GameObject;
    }
}