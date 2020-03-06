using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using Chippo.GameObjects.Interfaces;
using Chippo.Math;

namespace Chippo.GameObjects
{
    public abstract class GameObject
    {
        private TimeSpan last = TimeSpan.Zero;

        private List<Action> onRemove = new List<Action>();
        public GameObjectLifeTime Update(TimeSpan totalElapsed)
        {
            State = OnUpdate(totalElapsed - last);
            last = totalElapsed;
            return State;

        }
        protected abstract GameObjectLifeTime OnUpdate(TimeSpan delta);


        public GameObjectLifeTime State { get; private set; }

        internal IBlueprintFactory Factory { get; set; }

        public T ConstructByBlueprint<T>(string bluePrintName) where T: GameObject
        {
            var ngo = Factory.Construct<T>(bluePrintName);
            ngo.Factory = Factory;
            return Factory.Construct<T>(bluePrintName);
        }

        public void OnRemove(Action action)
        {
            onRemove.Add(action);
        }

        public void Remove()
        {
            foreach (var action in onRemove)
            {
                action();
            }
        }
    }


    
}