using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;
using Chippo.Core.Input;
using Chippo.GameObjects;
using Chippo.GameObjects.Interfaces;
using Chippo.Graphics.Interface;
using Chippo.Graphics.SFML;
using NotImplementedException = System.NotImplementedException;

namespace Chippo
{
    public class Initialization : IInitialization
    {
        private readonly IInput input;
        private readonly IDrawableProvider<DrawableGameObject<SfmlContext>, SfmlContext> drawableProvider;

        public Initialization(IInput input, IDrawableProvider<DrawableGameObject<SfmlContext>, SfmlContext> drawableProvider )
        {
            this.input = input;
            this.drawableProvider = drawableProvider;
        }
        public Task<ILevel> InitializeAsync()
        {
            var item = new MenuItem(input, () => Debug.WriteLine("clicked"));
            drawableProvider.Add(item);
            return Task.FromResult((ILevel)new Menu(new List<MenuItem>
            {
               item
            }, input));
        }
    }
}