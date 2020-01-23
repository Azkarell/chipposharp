using System;
using System.Collections.Generic;
using System.Text;

namespace Chippo.Settings
{
    struct AppSettings
    {
        public WindowSettings WindowSettings {get; set;}
        public InputSettings InputSettings { get; set; }
        public string Title { get; set; }
    }

    struct WindowSettings
    {
        public uint Width { get; set; }
        public uint Height { get; set; }
    }
}
