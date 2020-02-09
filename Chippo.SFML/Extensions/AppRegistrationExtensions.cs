using System;
using System.Collections.Generic;
using System.Text;
using Chippo.Core;

namespace Chippo.SFML.Extensions
{
    public static class AppRegistrationExtensions
    {
        public static AppRegistration UseSfml(this AppRegistration appRegistration)
        {
            appRegistration.UseDispatcher<EventDispatcher>()
                .UseOutput<SfmlWindow>();
            return appRegistration;
        }
    }
}
