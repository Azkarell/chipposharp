namespace Chippo.GameObjects.Interfaces
{
    public interface IBlueprintFactory
    {
        void RegisterBlueprint<T,TArgs>(Blueprint<T,TArgs> blueprint) where T: GameObject where TArgs: BlueprintArgs<T>;
        void RegisterBlueprint(BlueprintRegistration registration);
        T Construct<T>(string name) where T: GameObject;
    }
}