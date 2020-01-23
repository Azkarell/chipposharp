using Chippo.Actions.System;
using System;
using System.Collections.Generic;
using System.Text;

namespace Chippo.Settings
{
    class DefaultSettingProvider : ISettingsProvider
    {
        public AppSettings GetSettings()
        {
            return new AppSettings
            {
                Title = "DefaultApp",
                WindowSettings = new WindowSettings
                {
                    Width = 800,
                    Height = 600,
                },
                InputSettings = new InputSettings
                {
                    ["Q"] = typeof(QuitEvent).FullName
                }
            };
        }
    }
}
