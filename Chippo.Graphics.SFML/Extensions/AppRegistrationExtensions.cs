using Chippo.Core;

namespace Chippo.Graphics.SFML.Extensions
{
    public static class AppRegistrationExtensions
    {
        public static AppRegistration UseSfml(this AppRegistration appRegistration)
        {
            appRegistration
                .UseDispatcher<EventDispatcher>()
                .UseOutput<SfmlGraphics2D,SfmlContext>();
            return appRegistration;
        }
    }
}
