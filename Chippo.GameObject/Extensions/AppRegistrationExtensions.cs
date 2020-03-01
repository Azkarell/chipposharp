using Chippo.Core;
using Chippo.Graphics;

namespace Chippo.GameObjects.Extensions
{
    public static class AppRegistrationExtensions
    {
        public static AppRegistration UseGameLogic(this AppRegistration appRegistration)
        {
            appRegistration
                .UseLogic<GameLogic>();
            return appRegistration;
        }
    }
}