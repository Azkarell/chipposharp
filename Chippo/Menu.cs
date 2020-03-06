using System;
using System.Collections.Generic;
using System.Numerics;
using System.Threading.Tasks;
using Chippo.Core.Input;
using Chippo.GameObjects;
using Chippo.GameObjects.Interfaces;
using Chippo.Graphics;
using Chippo.Graphics.SFML;
using Chippo.Math;

namespace Chippo
{
    public class Menu: Level
    {
        private readonly IInput input;

        public Menu(IEnumerable<MenuItem> items, IInput input)
        {
            this.input = input;
            foreach (var menuItem in items)
            {
                Add(menuItem);
            }
        }


        protected override Task<ILevel> OnUpdate(TimeSpan delta)
        {
            return input.IsPressed(KeyboardKey.Q) ? Task.FromResult((ILevel)null) : Task.FromResult((ILevel) this);
        }
    }

    public class MenuItem: DrawableGameObject<SfmlContext>
    {
        private readonly IInput input;
        private readonly Action clickAction;

        public MenuItem(IInput input, Action clickAction)
        {
            this.input = input;
            this.clickAction = clickAction;
        }
        public override void Draw(SfmlContext context)
        {
            Transformation =
                Transformation.WithTranslation(new Vector2(context.Dimension.X / 2, context.Dimension.Y / 2));
            context.Text(Transformation, new Material(Color.FromRGBA("#ff0000")), "Hi");
        }

        protected override GameObjectLifeTime OnUpdate(TimeSpan delta)
        {
            if (IsClicked())
            {
                clickAction();
            }
            return GameObjectLifeTime.Alive;
        }

        private bool IsClicked()
        {
            return Transformation.GetBoundingBox().IsInside(input.MousePosition.AsVector());
        }
    }
}