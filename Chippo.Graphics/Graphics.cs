

using System;
using Chippo.Core;
using Chippo.Core.Component;
using SFML.Graphics;

namespace Chippo.Graphics
{
    public abstract class Graphics: IComponent
    {
        public abstract ApplicationState Update(TimeSpan delta);
    }
}