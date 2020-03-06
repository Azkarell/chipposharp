using Chippo.Core;
using Chippo.Graphics.Interface;
using SFML.Graphics;

namespace Chippo.Graphics.SFML.Extensions
{
    public static class AppRegistrationExtensions
    {
        public static AppRegistration UseSfml<TDrawable>(this AppRegistration appRegistration)
           where TDrawable: IDrawable<SfmlContext>
        {
            appRegistration
                .UseDispatcher<EventDispatcher>()
                .UseOutput<Graphics2D<TDrawable, SfmlContext, Drawable>>();
            return appRegistration;
        }
    }
}
