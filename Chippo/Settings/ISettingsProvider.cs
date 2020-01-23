using System;
using System.Collections.Generic;
using System.Text;

namespace Chippo.Settings
{
    interface ISettingsProvider
    {
        public AppSettings GetSettings();
    }
}
