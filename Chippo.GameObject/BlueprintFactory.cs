using System;
using System.Collections.Generic;
using Chippo.GameObjects.Interfaces;
using Chippo.Graphics.Interface;

namespace Chippo.GameObjects
{
    public class BlueprintRegistration
    {
        public BlueprintRegistration((string, Type) key, Blueprint blueprint)
        {
            Key = key;
            Blueprint = blueprint;
        }
        public (string, Type) Key { get; }
        public Blueprint Blueprint { get; }
    }

    class BlueprintFactory : IBlueprintFactory
    {


        private readonly Dictionary<(string,Type),Blueprint> blueprints = new Dictionary<(string, Type), Blueprint>();
        public void RegisterBlueprint<T, TArgs>(Blueprint<T, TArgs> blueprint) 
            where T : GameObject 
            where TArgs : BlueprintArgs<T>
        {
            RegisterBlueprint(blueprint.AsBlueprintRegistration());
        }

        public void RegisterBlueprint(BlueprintRegistration registration)
        {
            blueprints.Add(registration.Key, registration.Blueprint);
        }

        public T Construct<T>(string name) where T: GameObject
        {
            if (!blueprints.TryGetValue((name, typeof(T)), out var blueprint))
                throw new ArgumentException($"Blueprint {name} for type {typeof(T).Name} not found");
            var go = (T)blueprint.Construct();
            return go;
        }
    }
}