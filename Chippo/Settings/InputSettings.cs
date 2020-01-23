using System;
using System.Collections.Generic;
using System.Text;
using static SFML.Window.Keyboard;

namespace Chippo.Settings
{
    class InputSettings: Dictionary<string, string>
    {
        public InputSettings() : base() { }
        public InputSettings(int capacity) : base(capacity) { }

    }
}
