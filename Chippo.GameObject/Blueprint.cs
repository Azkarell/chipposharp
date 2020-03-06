using Chippo.Graphics.Interface;
using NotImplementedException = System.NotImplementedException;

namespace Chippo.GameObjects
{


    public abstract class Blueprint
    {
        public string Name { get; }

        public Blueprint(string name)
        {
            Name = name;
        }
        public abstract GameObject Construct();
        public abstract BlueprintRegistration AsBlueprintRegistration();
    }

    public abstract class Blueprint<T, TArgs> : Blueprint
        where T : GameObject
        where TArgs : BlueprintArgs<T>
    {
        public TArgs Args { get; }

        public Blueprint(string name, TArgs args) : base(name)
        {
            Args = args;
        }

        public override GameObject Construct()
        {
            return MakeObject(Args);
        }

        public override BlueprintRegistration AsBlueprintRegistration()
        {
            return new BlueprintRegistration((Name,typeof(T)), this);
        }

        protected abstract T MakeObject(TArgs args);
    }

    public abstract class DrawableBlueprint<T, TArgs, TContext> : Blueprint<T, TArgs>
        where T : DrawableGameObject<TContext>
        where TArgs : BlueprintArgs<T>
    {
        private readonly IDrawableProvider<DrawableGameObject<TContext>, TContext> drawableProvider;

        public DrawableBlueprint(string name, TArgs args, IDrawableProvider<DrawableGameObject<TContext>, TContext> drawableProvider) : base(name, args)
        {
            this.drawableProvider = drawableProvider;
        }

        public override GameObject Construct()
        {
            var go = MakeObject(Args);
            drawableProvider.Add(go);
            return go;
        }
    }
}