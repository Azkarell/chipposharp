using Chippo.Core;

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